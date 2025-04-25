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
    public class StaffClasses
    {
        [Key]

        public int ClassId { get; set; }


        [Required(ErrorMessage = "Staff class name is required.")]
        public string ClassName { get; set; }



        public ICollection<Staff> Staffs { get; set; }
    }
}
