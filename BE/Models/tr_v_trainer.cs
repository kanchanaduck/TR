using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{        
    [Keyless]
    [Comment("วิวแสดงผลข้อมูลเทรนเนอร์")]
    public class tr_v_trainer
    {
        public string trainer_no { get; set; }     
        [MaxLength(7)] 
        public string emp_no { get; set; }
        public string sname_en { get; set; }
        public string gname_en { get; set; }
        public string fname_en { get; set; }
        public string sname_th { get; set; }
        public string gname_th { get; set; }
        public string fname_th { get; set; }
        public string type { get; set; }
        public string organization { get; set; }
        public string band { get; set; }
        public string position_name_en { get; set; }
        public string email { get; set; }
        public bool status_active { get; set; }
        public string remark { get; set; }
    }
}