using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    [Keyless]
    public class tr_course_band
    {
        [MaxLength(7)]
        public string course_no { get; set; }
        /* [ForeignKey("courseFK")]
        public virtual tr_course course { get; set; } */
        public string band_text { get; set; }
        /* [ForeignKey("bandFK")]
        public virtual tb_band band { get; set; } */
    }
}