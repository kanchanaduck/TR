using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFirst.Models
{
    public class tb_course_band
    {
        [Key]
        public string course_no { get; set; }
        public string band { get; set; }
    }
}