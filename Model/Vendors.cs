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
    public class Vendors
    {
        [Key]

        public int VendorId { get; set; }


        // Optional: vendor name is not always provided in Excel
        public string? VendorName { get; set; }



        public ICollection<Staff> Staffs { get; set; }
    }
}
