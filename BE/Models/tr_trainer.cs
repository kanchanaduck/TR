using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoolProof.Core;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    [Comment("ตารางเก็บข้อมูลเทรนเนอร์")]
    public class tr_trainer
    {
        [Key]
        public int trainer_no { get; set; }  
        [MaxLength(7)]
        [RequiredIf("trainer_type","Internal",ErrorMessage = "EMP NO. is required due to TRAINER TYPE being equal to Internal")]
        [Display(Name = "EMP NO.")]
        public string emp_no { get; set; }
        public string sname_en { get; set; }
        [RequiredIf("trainer_type","External")]
        [Display(Name = "FIRSTNAME")]
        public string gname_en { get; set; }
        [RequiredIf("trainer_type","External")]
        [Display(Name = "LASTNAME")]
        public string fname_en { get; set; }
        public string sname_th { get; set; }
        public string gname_th { get; set; }
        public string fname_th { get; set; }
        [Required]
        [Display(Name = "TRAINER TYPE")]
        public string trainer_type { get; set; } = "Internal";
        public string organization { get; set; }
        public bool? status_active { get; set; }
        public string remark { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get { return _date; } set { _date = value; } }
        [Required]
        public string updated_by { get { return _username; } set { _username = value; } }
        public List<tr_course_trainer> courses_trainers { get; set; }
        private DateTime _date = DateTime.Now;
        private string _username = "014496";
    }
}