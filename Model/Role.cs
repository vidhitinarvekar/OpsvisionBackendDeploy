using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using System.ComponentModel.DataAnnotations.Schema;


namespace Model
{
    public class Role
    {
        [Key]

        public int RoleId { get; set; }



        [Required(ErrorMessage = "Role name is required.")]

        public string RoleName { get; set; }



        public ICollection<User> Users { get; set; }
    }
}
