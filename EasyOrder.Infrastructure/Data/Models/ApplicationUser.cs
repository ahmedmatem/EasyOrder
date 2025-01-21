namespace EasyOrder.Infrastructure.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using static EasyOrder.Infrastructure.Data.Constraints;
    using static EasyOrder.Infrastructure.Data.ErrorMessages;

    public class ApplicationUser : IdentityUser
    {
        [Comment("User full name.")]
        [MaxLength(ApplicationUserFullNameMaxLength, ErrorMessage = MaxLengthErrorMessage)]
        public string FullName { get; set; } = string.Empty;

        [ForeignKey("Site")]
        [Comment("Unique identifier of the site user/staff participate in.")]
        public string? SiteId { get; set; }

        // Navigation properties
        public Site Site { get; set; } = null!;
    }
}
