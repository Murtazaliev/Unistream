using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityT
    {
        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }
        public EntityT()
        {
            this.Id = Guid.NewGuid();
            this.OperationDate = DateTime.Now;
        }        
    }
}
