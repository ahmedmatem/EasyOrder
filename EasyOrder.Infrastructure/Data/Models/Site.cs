namespace EasyOrder.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;

    using EasyOrder.Infrastructure.Data.Contracts;

    using static EasyOrder.Infrastructure.Data.Constraints;
    using static EasyOrder.Infrastructure.Data.ErrorMessages;

    [Comment("Represents the model of food and beverage establishments.")]
    public class Site : DataModel
    {
        [Required]
        [MaxLength(SiteNameMaxLength, ErrorMessage = MaxLengthErrorMessage)]
        [Comment("The name of the site.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(SiteTypeMaxLength, ErrorMessage = MaxLengthErrorMessage)]
        [Comment("Type of the site (e.g, Restaurant, Pizzeria, Cafe, Buffet, Pub, Bar and Gril)")]
        public string Type { get; set; } = string.Empty;

        [Required]
        [MaxLength(SiteCityMaxLength, ErrorMessage = MaxLengthErrorMessage)]
        [Comment("The name of the city site belongs to.")]
        public string City { get; set; } = string.Empty;
    }
}
