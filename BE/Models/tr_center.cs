using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    [Comment("ตารางเก็บข้อมูลcenter")]
    public class tr_center
    {
        [Key]
        public int center_no { get; set; }  
        [MaxLength(7)]    
        public string emp_no { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime created_at { get; set; }
        public string created_by { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get; set; }
        public string updated_by { get; set; }
    }
}