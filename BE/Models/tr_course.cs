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
        public bool? open_register { get; set; }
        [Required]
         [Column(TypeName = "date")]
        public DateTime date_start { get; set; } 
        [Required]
         [Column(TypeName = "date")]
        public DateTime date_end { get; set; } 
        [Required]
        [Column(TypeName = "time")]
        public TimeSpan time_in { get; set; } 
        [Required]
        [Column(TypeName = "time")]
        public TimeSpan time_out { get; set; }
        [Required]
        public string place { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime created_at { get; set; } 
        public string created_by { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get; set; } 
        public string updated_by { get; set; }
        public bool? status_active { get; set; }
        public ICollection<tb_band> bands { get; set; }
        public List<tr_course_band> course_band { get; } = new List<tr_course_band>();
        public ICollection<tr_trainer> trainers { get; set; }
        public List<tr_trainer> triner_no { get; } = new List<tr_trainer>();
    }
}