namespace EasyOrder.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    
    using Microsoft.EntityFrameworkCore;

    using EasyOrder.Infrastructure.Data.Contracts;

    using static EasyOrder.Infrastructure.Data.Constraints;
    using static EasyOrder.Infrastructure.Data.ErrorMessages;

    public class MenuCategory : DataModel
    {
        [Required]
        [MaxLength(MenuCategoryTitleMaxLength, ErrorMessage = MaxLengthErrorMessage)]
        [Comment("Category name of the menu.")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(
            MenuCategoryDescriptionMaxLength,
            ErrorMessage = MaxLengthErrorMessage)]
        [Comment("Menu category description.")]
        public string Description { get; set; } = string.Empty;
    }
}
