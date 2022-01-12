using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    [Keyless]
    [Comment("ตารางจับคู่คอร์สมาสเตอร์และแบนด์")]
    public class tr_course_master_band
    {
        [MaxLength(7)]
        public string course_no { get; set; }
        public tr_course_master tr_course_master { get; set; }
        public string band { get; set; }
        public tb_band tb_band { get; set; }
    }
}