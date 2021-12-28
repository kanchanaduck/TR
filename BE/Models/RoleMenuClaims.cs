using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFirst.Models
{
    public class RoleMenuClaims
    {
        [Key]
        public int Id { get; set; }
        // [Key][Column(Order = 0)]
        public int role_id { get; set; }
        // [Key][Column(Order = 1)]
        public string menu_code { get; set; }
        public string active { get; set; }
        public string spare1 { get; set; }
        public string spare2 { get; set; }
        public string spare3 { get; set; }
        public string spare4 { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime update_date { get; set; }
        [Required]
        public string update_by { get; set; }
    }
}