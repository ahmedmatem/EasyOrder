namespace EasyOrder.Infrastructure.Data.Models
{
    using EasyOrder.Infrastructure.Data.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order : DataModel
    {
        [ForeignKey("Table")]
        public string TableId { get; set; } = string.Empty;

        [Comment("Status of the order {e.g., Pending, Completed, Cancelled, …}")]
        public int OrderStatus { get; set; }

        [NotMapped]
        public decimal TotalPrice => Items?.Sum(oi => oi.TotalPrice) ?? 0;

        // Navigation properties

        public IList<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Table Table { get; set; } = null!;
    }
}
