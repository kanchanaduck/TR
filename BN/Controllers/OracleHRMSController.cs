using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_hrgis.Data;
using api_hrgis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace api_hrgis.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class OracleHRMSController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly OracleDbContext _oracle_context;
        private readonly IConfiguration _config;

        public OracleHRMSController(
            ApplicationDbContext context, 
            OracleDbContext oracle_context, 
            IConfiguration config)
        {
            _context = context;
            _oracle_context = oracle_context;
            _config = config;
        }

        // GET: api/Employees
        [HttpGet("Employee")]
        public async Task<ActionResult<IEnumerable<tb_employee>>> Employee()
        {
            var hrms_employees  = await _oracle_context.cpt_employees.ToListAsync();

            foreach (var item in hrms_employees)
            {
                tb_employee tb_employee = await _context.tb_employee.FindAsync(item.emp_no);
                _context.Entry(tb_employee).State = tb_employee==null? EntityState.Added: EntityState.Modified;
            }
            await _context.SaveChangesAsync();

            return await _context.tb_employee.Take(5).ToListAsync();
        }
        // GET: api/Employees/Dump
        [HttpGet("Employee/Dump")]
        public async Task<ActionResult<IEnumerable<tb_employee>>> Employee_Dump()
        {
            DataTable dt = new DataTable();

            dt = get_oracle_datatable(@"select * from cpt_employees");

            DumpDataTableToDB("tb_employee",dt);

            return await _context.tb_employee.Take(5).ToListAsync();
        }
        // GET: api/Organization/Dump
        [HttpGet("Organization/Dump")]
        public async Task<ActionResult<IEnumerable<tb_organization>>> Organization()
        {
            DataTable dt = new DataTable();

            dt = get_oracle_datatable(@"select * from cpt_organization");

            DumpDataTableToDB("tb_organization",dt);

            return await _context.tb_organization.Take(5).ToListAsync();
        }
        private DataTable get_oracle_datatable(string query)
        {
            DataTable dt = new DataTable();
            string constr = _config["ConnectionStrings:OracleConnection"];
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand(query))
                {
                    cmd.Connection = con;
                    using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }

        private void DumpDataTableToDB(string TableName, DataTable dt)
        {
            string SqlConnectionStr = _config["ConnectionStrings:DefaultConnection"];
            using (SqlConnection destinationConnection = new SqlConnection(SqlConnectionStr))
            {
              destinationConnection.Open();
              using (SqlBulkCopy bkCopy = new SqlBulkCopy(destinationConnection))
              {
                    bkCopy.DestinationTableName = TableName;
                    try
                    {
                        foreach (DataColumn d in dt.Columns) 
                        { 
                            Console.WriteLine(d.ColumnName);
                            bkCopy.ColumnMappings.Add(d.ColumnName, d.ColumnName.ToLower()); 
                        }
                        bkCopy.WriteToServer(dt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
              }
              destinationConnection.Close();
            }
        }   
    }
}
