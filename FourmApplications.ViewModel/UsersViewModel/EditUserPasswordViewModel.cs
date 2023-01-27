using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplications.ViewModel.UsersViewModel
{
    public  class EditUserPasswordViewModel
    {
        public int UserID { get; set; } 
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } 
    }
}
