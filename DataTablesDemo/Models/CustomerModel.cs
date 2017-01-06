using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataTablesDemo.Models
{
    public class Customer
    {
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int CustomerID { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }
}