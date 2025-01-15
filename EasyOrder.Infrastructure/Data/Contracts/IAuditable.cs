namespace EasyOrder.Infrastructure.Data.Contracts
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }

        DateTime? LastModifiedOn { get; set; }
    }
}
