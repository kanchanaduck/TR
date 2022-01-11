using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFirst.Models
{
    public class tb_band
    {
        [Key]
        public string band { get; set; }
        public bool? status_active { get; set; }
        public virtual ICollection<tr_course_master> course_masters { get; set; }      
        public virtual ICollection<tr_course> courses { get; set; }
    }
}