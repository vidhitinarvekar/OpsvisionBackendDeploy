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
    public class Shifts
    {
        [Key]

        public int ShiftId { get; set; }



        public string? ShiftName { get; set; }



        public TimeSpan? StartTime { get; set; }



        public TimeSpan? EndTime { get; set; }



        public ICollection<Staff> Staffs { get; set; }
    }
}
