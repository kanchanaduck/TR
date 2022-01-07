using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFirst.Models
{
    public class tb_employee_role_claims
    {
        [Key]
        public int id { get; set; }
        public tb_employee emp_no { get; set; }
        public tb_role role_id{ get; set; }
        public string active { get; set; }
        public string spare1 { get; set; }
        public string spare2 { get; set; }
        public string spare3 { get; set; }
        public string spare4 { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public string created_by { get; set; }
        [Required]
        public DateTime updated_at { get; set; }
        [Required]
        public string updated_by { get; set; }
    }
}