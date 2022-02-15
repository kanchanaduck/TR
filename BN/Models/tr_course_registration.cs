using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_hrgis.Models
{
    public class tr_course_registration
    {
         public string course_no	{ get; set; }
        public tr_course courses { get; set; }
        [Required]
        public string emp_no { get; set; }
        public tb_employee employees { get; set; }
        [Required]
        public int seq_no { get; set; }
        public string last_status { get; set; }
        public string remark { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? register_at { get; set; }
        public string register_by { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? manager_approved_at { get; set; }
        public string manager_approved_by { get; set; }
        public bool? manager_approved_checked { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? center_approved_at	 { get; set; }
        public string center_approved_by { get; set; }
        public bool? center_approved_checked { get; set; }
        [Range(0, 100)]
        public int? pre_test_score { get; set; }
        public string pre_test_grade { get; set; }
        [Range(0, 100)]
        public int? post_test_score { get; set; }
        public string post_test_grade { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? scored_at { get; set; }
        public string scored_by { get; set; }

    }
}