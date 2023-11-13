using Domain;
using Domain.Interfaces;
using Mapster;

namespace Infrastructure.Models
{
    public class EntityTDalDto
    {
        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }
        public EntityTDalDto()
        {
        }
        public EntityTDalDto(EntityT entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            Id = entity.Id;
            OperationDate = entity.OperationDate;
           
            Amount = entity.Amount;
        }
    }
}
