namespace EasyOrder.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;

    using EasyOrder.Infrastructure.Data.Contracts;

    using static EasyOrder.Infrastructure.Data.Constraints;
    using static EasyOrder.Infrastructure.Data.ErrorMessages;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Table : DataModel
    {
        [ForeignKey("Site")]
        public string SiteId { get; set; } = string.Empty;

        [Required]
        [MaxLength(TableNameMaxLength, ErrorMessage = MaxLengthErrorMessage)]
        [Comment("The name of the table (could be just a number)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Unique long length token for the table.")]
        public string Token { get; set; } = string.Empty;

        // Navigation properties

        public Site Site { get; set; } = null!;

        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
