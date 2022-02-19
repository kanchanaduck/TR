using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_hrgis.Models
{
    [Keyless]
    public class cpt_holidays
    {
        [Column(TypeName = "date")]
        public DateTime holiday { get; set;}
        public string mark { get; set;}
    }
}