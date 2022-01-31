using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_hrgis.Models
{
    public class tb_band
    {
        [Key]
        public string band { get; set; }
        public bool? status_active { get; set; }
        public List<tr_course_master_band> course_masters_bands { get; set; }
        public List<tr_course_band> courses_bands { get; set; }
    }
}