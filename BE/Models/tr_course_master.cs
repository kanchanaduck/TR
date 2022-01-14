using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;

namespace AngularFirst.Models
{
    [Comment("ตารางเก็บข้อมูลคอร์ส 6 หลัก เพื่อช่วยในการเปิดคอร์ส")]
    public class tr_course_master
    {
        [Key]
        [MaxLength(7)]
        public string course_no { get; set; }
        [Required]
        public string course_name_th { get; set; }
        public string course_name_en { get; set; }
        [Required]
        public string dept_abb_name { get; set; }
        [Required]
        public int capacity { get; set; }
        public string prev_course_no { get; set; }
        [Required]
        public int days { get; set; }
        public string category { get; set; }
        public string level { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? created_at { get; set; } 
        public string created_by { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get { return _date; } set { _date = value; } }
        [Required]
        public string updated_by { get { return _username; } set { _username = value; } }
        public bool? status_active { get; set; }
        public List<tr_course_master_band> course_masters_bands { get; set; }
        [ForeignKey("prev_course_no")]
        public virtual tr_course_master prev_course { get; set; }
        public virtual ICollection<tr_course_master> next_course { get; set; }
        private DateTime _date = DateTime.Now;
        private string _username = "014496";
    }
}