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
    public class Departments
    {
        [Key]

        public int DepartmentId { get; set; }


        [Required(ErrorMessage = "Department name is required.")]
        public string DepartmentName { get; set; }



        public ICollection<Staff> Staffs { get; set; }


    }
}
