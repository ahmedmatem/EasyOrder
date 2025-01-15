namespace EasyOrder.Infrastructure.Data.Contracts
{
    internal interface IAuditable
    {
        DateTime CreatedOn { get; set; }

        DateTime? LastModifiedOn { get; set; }
    }
}
