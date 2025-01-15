namespace EasyOrder.Infrastructure.Data.Contracts
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;

    public class DataModel : IAuditable, IDeletable
    {
        [Key]
        [Comment("Unique data model identifier")]
        public string Id { get; set; }

        [Comment("Indicate a record in table as deleted or not.")]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        [Comment("Set the date of soft deleting the record in database.")]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        [Comment("Set the date of creating the record in the database.")]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        [Comment("Set the date of last modifing the record in the database.")]
        public DateTime? LastModifiedOn { get; set; }
    }
}
