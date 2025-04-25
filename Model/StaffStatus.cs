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
    public class StaffStatus
    {
        [Key]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "Staff status name is required.")]
        public string StatusName { get; set; }

    }
}
