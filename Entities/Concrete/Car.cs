using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{

    public class Car : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public int ColorID { get; set; }
        public short DailyPrice { get; set; }
        public string Model { get; set; }
        public short ModelYear { get; set; }
        public string Engine { get; set; }
        public int FuelID { get; set; }
        public string Description { get; set; }
        public bool isAvailable { get; set; }
    }
}