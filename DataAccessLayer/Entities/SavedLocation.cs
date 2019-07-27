using AcuityHome.DataAccessLayer.Entities;
using AcuityHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcuityHome.DataAccessLayer.Entities
{
    public class SavedLocation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("StoreUserId")]
        public StoreUser User { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}
