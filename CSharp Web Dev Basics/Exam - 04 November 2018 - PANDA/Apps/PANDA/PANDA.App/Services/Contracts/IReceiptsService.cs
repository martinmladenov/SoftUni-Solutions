namespace PANDA.App.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IReceiptsService
    {
        void Create(string recipientId, string packageId, decimal packageWeight);
        ICollection<ReceiptListingViewModel> GetAllForUser(string username);
        ReceiptDetailsViewModel Get(string id, string username);
    }
}
