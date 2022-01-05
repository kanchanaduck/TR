using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFirst.Models
{
    public class tr_band
    {
        [Key]
        public string band { get; set; }
        public bool status_active { get; set; }
    }
}