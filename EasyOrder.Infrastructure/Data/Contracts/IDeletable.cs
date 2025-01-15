namespace EasyOrder.Infrastructure.Data.Contracts
{
    internal interface IDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
