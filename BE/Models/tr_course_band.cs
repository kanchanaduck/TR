using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    public class tr_course_band
    {
        [MaxLength(7)]
        [ForeignKey("course")]
        public string course_no { get; set; }
        public virtual tr_course course { get; set; }
        [ForeignKey("band")]
        public string band_text { get; set; }
        public virtual tb_band band { get; set; }
    }
}