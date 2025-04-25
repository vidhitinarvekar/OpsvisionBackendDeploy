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
    public class HolidayCalender
    {
        [Key]
        public int HolidayId { get; set; }
        [Required(ErrorMessage = "Holiday name is required.")]
        public string HolidayName { get; set; }
        [Required(ErrorMessage = "Holiday date is required.")]
        public DateTime HolidayDate { get; set; }
        
        public string Region { get; set; }

        public string HolidayDay { get; set; }
        [Required]
        public bool IsNationalHoliday { get; set; } = false;

    }
}
