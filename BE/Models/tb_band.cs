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
        /* public ICollection<tr_course_master> course_masters { get; set; }
        public List<tr_course_master_band> course_master_band { get; set; }        
        public ICollection<tr_course> courses { get; set; }
        public List<tr_course_band> course_band { get; set; } */
    }
}