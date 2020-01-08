using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalFinal_mvc.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Enter user name in this text box")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Gender in this text box")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter user email in this text box")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Select date or input date")]
        public string Date { get; set; }
    }
}