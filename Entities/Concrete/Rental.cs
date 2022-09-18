using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentID { get; set; }

        public int CarID { get; set; }
        public int UserID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
