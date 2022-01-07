using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    [Keyless]
    public class tr_course_trainer
    {
        public string course_no { get; set; }
        [ForeignKey("course_no")]
        public tr_course course { get; set; }
        public int trainer_no { get; set; }
        [ForeignKey("trainer")]
        public tr_trainer trainer { get; set; }
    }
}