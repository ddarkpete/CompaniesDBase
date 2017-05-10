using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CompaniesDBase.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required, StringLength(40), Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required, StringLength(10), Display(Name = "NIP")]
        public string NIPNumber { get; set; }

        [Required, StringLength(10), Display(Name = "KRS")]
        public string KRSNumber { get; set; }

        [Required, StringLength(14), Display(Name = "REGON")]
        public string REGONNumber { get; set; }
    }
}

namespace CompaniesDBase.Models
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string NIPNumber { get; set; }
        public string KRSNumber { get; set; }
        public string REGONNumber { get; set; }
    }
}