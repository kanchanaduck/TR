using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace api_hrgis.Models
{
    [Comment("ตารางเก็บข้อมูลคอร์ส 6 หลัก เพื่อช่วยในการเปิดคอร์ส")]
    public class tr_course_master_previous
    {
        [MaxLength(10)]
        [Required]
        [Display(Name = "COURSE NO.")]
        public string course_no { get; set; }
        [Display(Name = "COURSE NO.")]
        public string prev_course_no { get; set; }
    }
}