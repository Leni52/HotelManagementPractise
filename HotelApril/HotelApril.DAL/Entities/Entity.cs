using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.DAL.Entities
{
   public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string CreatorId { get; set; }
        public DateTime ChangeDate { get; set; }
        public string UpdaterId { get; set; }
    }
}
