using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFirst.Models
{
    public class tr_course
    {
        [Key]
        public string course_no { get; set; }
        public string course_name_th { get; set; }
        public string course_name_en { get; set; }
        public string dept_abb_name { get; set; }
        public int days { get; set; }
        public int capacity { get; set; }
        public bool open_register { get; set; }
        public DateTime start_date  { get; set; }
        public DateTime end_date { get; set; }
        public DateTime time_in { get; set; }
        public DateTime time_out { get; set; }
        public string place { get; set; }
        public DateTime created_at { get; set; }
        public string created_by { get; set; }
        public DateTime updated_at { get; set; }
        public string updated_by { get; set; }
        public bool status_active { get; set; }
    }
}