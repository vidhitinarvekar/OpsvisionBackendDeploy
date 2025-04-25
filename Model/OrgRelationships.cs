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
    public class OrgRelationships
    {
        [Key]

        public int RelationshipId { get; set; }


        [Required(ErrorMessage = "Relationship name is required.")]
        public string Name { get; set; }



        public ICollection<Staff> Staffs { get; set; }
    }
}
