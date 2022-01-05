using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    [Comment("ตารางเก็บข้อมูลเทรนเนอร์")]
    public class tr_trainer
    {
        [Key]
        public string trainer_no { get; set; }  
        [MaxLength(7)]    
        public string emp_no { get; set; }
        [Required]
        public string sname_en { get; set; }
        [Required]
        public string gname_en { get; set; }
        [Required]
        public string fname_en { get; set; }
        public string sname_th { get; set; }
        public string gname_th { get; set; }
        public string fname_th { get; set; }
        [Required]
        public string type { get; set; }
        public string organization { get; set; }
        public bool status_active { get; set; }
        public string remark { get; set; }
        public DateTime created_at { get; set; }
        public string created_by { get; set; }
        public DateTime updated_at { get; set; }
        public string updated_by { get; set; }
    }
}