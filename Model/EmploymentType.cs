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
    public class EmploymentType
    {
        [Key]

        public int TypeId { get; set; }


        [Required(ErrorMessage = "Employment type name is required.")]
        public string TypeName { get; set; }



        public ICollection<Staff> Staffs { get; set; }
        
    }
}
