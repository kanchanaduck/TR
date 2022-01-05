using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AngularFirst.Models
{
    // [Keyless]
    public class Employees
    {
        public string BAND { get; set; }
        public string DEPT_ABB_NAME { get; set; }
        public string DEPT_CODE { get; set; }
        public string DEPT_NAME { get; set; }
        public string DIV_ABB_NAME { get; set; }
        public string DIV_CLS { get; set; }
        public string DIV_NAME { get; set; }
        public string EMAIL { get; set; }
        public string EMAIL_ACTIVE_DATE { get; set; }
        [Key]
        public string EMP_NO { get; set; }
        public string FNAME_ENG { get; set; }
        public string FNAME_THA { get; set; }
        public string GNAME_ENG { get; set; }
        public string GNAME_THA { get; set; }
        public string FULLNAME_THA{
            get
            {
                return GNAME_THA + " " + FNAME_THA;
            }
        }
        public string FULLNAME_ENG{
            get
            {
                return GNAME_ENG + " " + FNAME_ENG;
            }
        }
        public string OLD_EMP_NO { get; set; }
        public string POSN_CODE { get; set; }
        public string POSN_ENAME { get; set; }
        public string PROB_DATE { get; set; }
        public string RESN_DATE { get; set; }
        public string SNAME_ENG { get; set; }
        public string SNAME_THAI { get; set; }
        public string WC_ABB_NAME { get; set; }
        public string WC_CODE { get; set; }
        public string WC_NAME { get; set; }
    }
}