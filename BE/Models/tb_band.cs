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
        public List<tr_course_master_band> tr_course_master_band { get; set; }
        public List<tr_course_band> tr_course_band { get; set; }
    }
}