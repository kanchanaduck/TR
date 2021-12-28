using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFirst.Models
{
    public class EmployeeHistory
    {
        [Key]
        public int id { get; set; }
        public string emp_no { get; set; }
        public string sname_eng { get; set; }
        public string gname_eng { get; set; }
        public string fname_eng { get; set; }
        public string posn_code { get; set; }
        public string posn_ename { get; set; }
        public string dept_code { get; set; }
        public string dept_name { get; set; }
        public string course_no { get; set; }
        public string course_name_en { get; set; }
        public string group { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string pre_test_score { get; set; }
        public string post_test_score { get; set; }
        public string trainner { get; set; }

    }
}