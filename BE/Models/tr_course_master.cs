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
        [Required]        
        public string category { get; set; }
        public string level { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime created_at { get; set; } 
        public string created_by { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get; set; }
        [Required]
        public string updated_by { get; set; }
        public bool? status_active { get; set; }
        public virtual ICollection<tb_band> bands { get; set; }
    }
}