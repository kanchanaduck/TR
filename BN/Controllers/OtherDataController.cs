using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Data;
using api_hrgis.Data;
using api_hrgis.Models;
using api_hrgis.Repository;

namespace api_hrgis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherDataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config; // using Microsoft.Extensions.Configuration;
        private readonly IRepository _repository;

        public OtherDataController(ApplicationDbContext context, IConfiguration config, IRepository repository)
        {
            _context = context;
            _config = config;
            _repository = repository;
        }

        [HttpGet("GetCountTrainee")]
        public IActionResult GetCountTrainee(string course_no, string date_start, string date_end)
        {
            var query = string.Format(@"SELECT tc.course_no, tc.course_name_th, tc.course_name_en, tc.date_start, tc.date_end, tc.place, COUNT(tr.emp_no) as count_emp
                        FROM [HRGIS].[dbo].[tr_course] tc
                        left join [HRGIS].[dbo].[tr_course_registration] tr on tc.course_no = tr.course_no
                        where tc.course_no like '%{0}%'
                        and tc.date_start >= '{1}' AND tc.date_end <= '{2}'
                        and (tr.last_status = '{3}' or (tr.last_status = '{4}'))
                        group by tc.course_no, tc.course_name_th, tc.course_name_en, tc.date_start, tc.date_end, tc.place"
                        , course_no, date_start, date_end, _config.GetValue<string>("Status:center_approved"), _config.GetValue<string>("Status:continuous"));
            
            DataTable dt = new DataTable();
            dt = _repository.get_datatable(query);

            return Ok(dt);
        }

        [HttpGet("GetCountAttendee")]
        public IActionResult GetCountAttendee(string course_no)
        {
            var query = string.Format(@"SELECT tc.course_no, tc.course_name_th, tc.course_name_en, tc.date_start, tc.date_end, tc.place
                        , tr.emp_no, tr.pre_test_score, tr.pre_test_grade, tr.post_test_score, tr.post_test_grade
                        , te.title_name_en
                        , case when te.band = 'JP' then te.lastname_en else te.firstname_en end as firstname_en
                        , case when te.band = 'JP' then te.firstname_en else te.lastname_en end as lastname_en
                        , te.title_name_th
                        , case when te.band = 'JP' then te.lastname_th else te.firstname_th end as firstname_th
                        , case when te.band = 'JP' then te.firstname_th else te.lastname_th end as lastname_th
                        , te.band, te.position_name_en, te.dept_abb, te.div_abb
                        FROM [HRGIS].[dbo].[tr_course] tc
                        left join [HRGIS].[dbo].[tr_course_registration] tr on tc.course_no = tr.course_no
                        left join tb_employee te on tr.emp_no = te.emp_no
                        where tc.course_no like '%{0}%'
                        and (tr.last_status = '{1}' or (tr.last_status = '{2}'))"
                        , course_no, _config.GetValue<string>("Status:center_approved"), _config.GetValue<string>("Status:continuous"));
            
            DataTable dt = new DataTable();
            dt = _repository.get_datatable(query);

            return Ok(dt);
        }

        [HttpGet("GetEmployeeTraining")]
        public IActionResult GetEmployeeTraining(string emp_no)
        {
            var query = string.Format(@"SELECT tc.course_no, tc.course_name_th, tc.course_name_en, tc.date_start, tc.date_end, tc.place, tbo.org_abb as org
                                , tr.emp_no, tr.pre_test_score, tr.pre_test_grade, tr.post_test_score, tr.post_test_grade
                                , te.title_name_en
                                , case when te.band = 'JP' then te.lastname_en else te.firstname_en end as firstname_en
                                , case when te.band = 'JP' then te.firstname_en else te.lastname_en end as lastname_en
                                , te.title_name_th
                                , case when te.band = 'JP' then te.lastname_th else te.firstname_th end as firstname_th
                                , case when te.band = 'JP' then te.firstname_th else te.lastname_th end as lastname_th
                                , te.band, te.position_name_en, te.dept_abb, te.div_abb
                                , tbt.full_trainer
                                FROM [HRGIS].[dbo].[tr_course] tc
                                left join tb_organization tbo on tc.org_code = tbo.org_code
                                left join [HRGIS].[dbo].[tr_course_registration] tr on tc.course_no = tr.course_no
                                left join tb_employee te on tr.emp_no = te.emp_no
                                left join (
                                    SELECT course_no ,full_trainer = STUFF(
                                                (
                                                    SELECT ',' + tb.full_trainer from (
                                                        select CASE WHEN trt.trainer_type = '{0}' THEN te.title_name_en + te.firstname_en + ' ' + LEFT(te.lastname_en,1) + ' ('+ te.dept_abb +')' 
                                                                ELSE trt.sname_en + trt.gname_en + ' ' + LEFT(trt.fname_en,1) + '.' END AS full_trainer
                                                        FROM [HRGIS].[dbo].[tr_course]  tc
                                                        left join tr_course_trainer tt on tc.course_no = tt.course_no
                                                        left join tr_trainer trt on tt.trainer_no = trt.trainer_no
                                                        left join tb_employee te on trt.emp_no = te.emp_no
                                                        where tc.course_no = tb1.course_no
                                                    ) tb
                                                FOR XML PATH (''))
                                                , 1, 1, '') from tr_course_trainer tb1 group by course_no) tbt on tc.course_no = tbt.course_no
                                where  tr.emp_no = '{1}'
                                and (tr.last_status = '{2}' or (tr.last_status = '{3}'))"
                        , _config.GetValue<string>("Text:internal"), emp_no, _config.GetValue<string>("Status:center_approved"), _config.GetValue<string>("Status:continuous"));
            
            DataTable dt = new DataTable();
            dt = _repository.get_datatable(query);

            return Ok(dt);
        }

    }
}
