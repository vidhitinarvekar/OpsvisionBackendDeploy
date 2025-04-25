using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading.Tasks;

namespace Model
{
    public class Locations
    {
        [Key]

        public int LocationId { get; set; }



        public string LocationName { get; set; }



        public string Region { get; set; }



        public ICollection<Staff> Staffs { get; set; }
    }
}
