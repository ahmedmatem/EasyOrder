namespace EasyOrder.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using EasyOrder.Infrastructure.Data.Contracts;
    using Microsoft.EntityFrameworkCore;
    using static EasyOrder.Infrastructure.Data.Constraints;
    using static EasyOrder.Infrastructure.Data.ErrorMessages;

    public class MenuItem : DataModel
    {
        [ForeignKey("MenuCategory")]
        public string MenuCategoryId { get; set; } = string.Empty;

        [Required]
        [MaxLength(MenuItemTitleMaxLength, ErrorMessage = MaxLengthErrorMessage)]
        [Comment("The title of the menu item.")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(MenuItemDescriptionMaxLength, ErrorMessage = MaxLengthErrorMessage)]
        [Comment("The description of menu item and/or its ingredients.")]
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        [Comment("Boolean flag indicating if the item is currently available.")]
        public bool IsAvailable { get; set; }

        [Comment("Quantity or portion size (e.g., grams, millilitres, pieces).")]
        public int Quantity { get; set; }

        [Comment("List of tags describing the item characteristics (e.g., spacy, sweet, vegan)")]
        public string Tags { get; set; } = string.Empty;

        [Comment("Optional image Url for the menu item.")]
        public string ImageUrl { get; set; } = string.Empty;

        // Navigation properties

        public MenuCategory MenuCategory { get; set; } = null!;
    }
}
