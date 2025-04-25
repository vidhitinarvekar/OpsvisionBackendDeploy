using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ManagementCodes
    {
        [Key]

        public int MgtCodeId { get; set; }



        public string CodeName { get; set; }



        public string Description { get; set; }



        public ICollection<Staff> Staffs { get; set; }
    }
}
