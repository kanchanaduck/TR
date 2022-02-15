using System;
using System.Linq;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using api_hrgis.Data;
using api_hrgis.Models;
using api_hrgis.Repository;

namespace api_hrgis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly IRepository _repository;


        public AuthenticateController(ApplicationDbContext context, IConfiguration config, IRepository repository)
        {
            _context = context;
            _config = config;
            _repository = repository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] request_login model)
        {
            var store = _context.tb_user.FirstOrDefault(u => u.username == model.Username);
            var user = _repository.VerifyPassword(model.Password, store.storedsalt, store.passwordhash);
            if (user)
            {
                //Login Successfull
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:ValidIssuer"],
                  _config["Jwt:ValidIssuer"],
                  null,
                  expires: DateTime.Now.AddHours(8),
                  signingCredentials: credentials);

                var query = await (from tb in _context.tb_employee
                                   join tbs in _context.tr_stakeholder on tb.emp_no equals tbs.emp_no
                                   where tb.emp_no == model.Username
                                   select new
                                   {
                                       tb.emp_no,
                                       tb.sname_eng,
                                       tb.gname_eng,
                                       tb.fname_eng,
                                       tb.dept_code,
                                       tb.dept_abb_name,
                                       tbs.org_code,
                                       tb.band,
                                       tb.posn_ename
                                   }
                                    ).FirstOrDefaultAsync();


                token.Payload["user"] = query;

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                });
            }

            return Unauthorized();
        }
    }
}

public class request_login
{
    public string Username { get; set; }
    public string Password { get; set; }
}