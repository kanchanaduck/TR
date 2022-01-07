using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    [Comment("ตารางเก็บ period การ survey เฉพาะคอร์สของ MTP")]
    public class tr_survey_setting
    {
        [Key]
        [MaxLength(4)]
        public string year { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime date_start { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime date_end { get; set; }
        public DateTime created_at { get; set; }
        public string created_by { get; set; }
        [Required]
        public DateTime updated_at { get; set; }  
        [Required]
        public string updated_by { get; set; }
    }
}