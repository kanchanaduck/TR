using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFirst.Models
{
    public class tb_course_trainer
    {
        [Key]
        public string course_no { get; set; }
        public string trainer_no { get; set; }
    }
}