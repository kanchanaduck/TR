using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    public class tb_organization
    {
        [Required]
        public int level_seq { get; set; }
        [Required]
        public string level_name { get; set; }
        [Comment("Center (1) > Division (2) > Department(3) > Work center(4)")]
        [Key]
        public string org_code { get; set; }
        public string org_abb { get; set; }
        [Required]
        public string org_name { get; set; }
        public string parent_org_code { get; set; }
        public string description { get; set; }        
        public string spare1 { get; set; }
        public string spare2 { get; set; }
        public string spare3 { get; set; }
        public string spare4 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get { return _date; } set { _date = value; } }
        [Required]
        public string updated_by { get { return _username; } set { _username = value; } }
        [ForeignKey("parent_org_code")]
        public virtual tb_organization parent_org { get; set; }
        public virtual ICollection<tb_organization> children_org { get; set; }
        public virtual ICollection<tr_stakeholder> stakeholders { get; set; }
        private DateTime _date = DateTime.Now;
        private string _username = "014496";
    }
}