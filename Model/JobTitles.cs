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
    public class JobTitles
    {
        [Key]

        public int JobTitleId { get; set; }



        [Required(ErrorMessage = "Title name is required.")]

        public string TitleName { get; set; }



        public ICollection<Staff> Staffs { get; set; }
    }
}
