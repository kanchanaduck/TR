using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    [Comment("ตารางเก็บไฟล์ในการ survey")]
    public class tr_survey_file
    {
        [Key]
        public int file_id { get; set;}
        [MaxLength(4)]
        [Column("year")]
        public tr_survey_setting year { get; set; }
        [Required]
        public string file_name { get; set; }
        [Required]
        public bool? approved { get; set; }
        [Required]
        [Comment("เก็บ division หรือ department ที่ committee คนนั้นรับผิดชอบ")]
        public string organization { get; set; }
        [Required]
        [Comment("Level")]
        public string level { get; set; }
        public DateTime created_at { get; set; }
        public string created_by { get; set; }
    }

}