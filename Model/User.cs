using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class User
    {
        [Key]

        public int UserId { get; set; }



        [Required(ErrorMessage = "Username is required.")]

        public string Username { get; set; }



        // Optional for now — can be null until user is activated

        public string? PasswordHash { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }





        [Required]
        public int RoleId { get; set; } = 1;

        [ForeignKey("RoleId")]

        public Role Role { get; set; }
    }
}

