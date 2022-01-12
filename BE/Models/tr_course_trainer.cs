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
        public tr_course tr_course { get; set; }
        public string trainer_no { get; set; }
        public tr_trainer tr_trainer { get; set; }
    }
}