namespace EasyOrder.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using EasyOrder.Infrastructure.Data.Contracts;

    using static EasyOrder.Infrastructure.Data.Constraints;
    using static EasyOrder.Infrastructure.Data.ErrorMessages;

    public class OrderItem :DataModel
    {
        // Foreign key to order Id in Order table
        public string OrderId { get; set; } = string.Empty;

        [Comment("Quantity of the item ordered.")]
        public int Quantity { get; set; }

        [MaxLength(OrderItemNameMaxLength, ErrorMessage = MaxLengthErrorMessage)]
        [Comment("Yhe name of the item in the order.")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Price of a single unit of the item.")]
        public decimal UnitPrice { get; set; }

        [Comment("Additional notes or comments about the item.")]
        public string Notes { get; set; } = string.Empty;

        [NotMapped]
        public decimal TotalPrice => Quantity * UnitPrice;

        // Navigation properties

        [ForeignKey("OrderId")]
        public Order Order { get; set; } = null!;
    }
}
