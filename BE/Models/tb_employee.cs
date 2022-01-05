using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularFirst.Models
{
    public class tb_employee
    {
        [Key]
        public string emp_no { get; set; }
        
        [StringLength(10)]
        public string sname_eng { get; set; }
        [StringLength(30)]
        public string gname_eng { get; set; }
        [StringLength(30)]
        public string fname_eng { get; set; }
        [StringLength(10)]
        public string sname_tha { get; set; }
        [StringLength(30)]
        public string gname_tha { get; set; }
        [StringLength(30)]
        public string fname_tha { get; set; }
        [StringLength(2)]
        public string div_cls { get; set; }
        [StringLength(50)]
        public string div_name { get; set; }
        [StringLength(20)]
        public string div_abb_name { get; set; }
        [StringLength(4)]
        public string dept_code { get; set; }
        [StringLength(20)]
        public string dept_abb_name { get; set; }
        [StringLength(50)]
        public string dept_name { get; set; }
        [StringLength(4)]
        public string wc_code { get; set; }
        [StringLength(20)]
        public string wc_abb_name { get; set; }
        [StringLength(50)]
        public string wc_name { get; set; }
        [StringLength(3)]
        public string band { get; set; }
        [StringLength(3)]
        public string posn_code { get; set; }
        [StringLength(100)]
        public string posn_ename { get; set; }
        [StringLength(100)]
        public string email { get; set; }
        public DateTime resn_date { get; set; }
        public DateTime prob_date { get; set; }
    }
}