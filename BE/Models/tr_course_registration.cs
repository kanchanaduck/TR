using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    [Comment("เปิ้ลอธิบายตารางนี้ให้ฟังหน่อย")]
    public class tr_course_registration
    {
        [Key]
        public int id { get; set; }
        public tr_course course_no	{ get; set; }
        [Required]
        public tb_employee emp_no { get; set; }	
        [Required]
        public int seq_no { get; set; }
        public string last_status { get; set; }
        public string remark { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime register_at { get; set; }
        public string register_by { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime manager_approved_at	 { get; set; }
        public string manager_approved_by { get; set; }
        public bool? manager_approved_checked { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime center_approved_at	 { get; set; }
        public string center_approved_by { get; set; }
        public bool? center_approved_checked { get; set; }

    }
}