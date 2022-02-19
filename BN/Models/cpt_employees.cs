using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_hrgis.Models
{
    [Keyless]
    public class cpt_employees
    {
        public string old_emp_no { get; set;}
        public string emp_no { get; set;}
        public string title_name_en { get; set;}
        public string firstname_en { get; set;}
        public string lastname_en { get; set;}
        public string title_name_th { get; set;}
        public string firstname_th { get; set;}
        public string lastname_th { get; set;}
        public string div_code { get; set;}
        public string div_abb { get; set;}
        public string div_name { get; set;}
        public string dept_code { get; set;}
        public string dept_abb { get; set;}
        public string dept_name { get; set;}
        public string wc_code { get; set;}
        public string wc_abb { get; set;}
        public string wc_name { get; set;}
        public string band { get; set;}
        public string position_code { get; set;}
        public string position_name_en { get; set;}
        public string position_name_th { get; set;}
        public string entrance_date { get; set;}
        public string probation_date { get; set;}
        public string resign_date { get; set;}
        public string id_card_no { get; set;}
        public string rfid_no { get; set;}
        public string email { get; set;}
        public string email_active_date { get; set;}
        public string email_active { get; set;}
    }
}