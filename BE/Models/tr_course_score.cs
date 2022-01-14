using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    [Keyless]
    [Comment("ตารางเก็บคะแนนและเกรด")]
    public class tr_course_score
    {
        public string course_no { get; set; }
        public string emp_no { get; set; }
        [Range(0, 100)]
        public int pre_test_score { get; set; }
        public char pre_test_grade { get; set; }
        [Range(0, 100)]
        public int post_test_score { get; set; }
        public char post_test_grade { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get { return _date; } set { _date = value; } }
        [Required]
        public string updated_by { get { return _username; } set { _username = value; } }
        private DateTime _date = DateTime.Now;
        private string _username = "014496";
    }
}