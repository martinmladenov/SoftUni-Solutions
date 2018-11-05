namespace PANDA.App.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IPackagesService
    {
        bool Create(string description, decimal weight, string shippingAddress, string recipientId);
        ICollection<PackageListingViewModel> GetPendingForUser(string username);
        ICollection<PackageListingViewModel> GetShippedForUser(string username);
        ICollection<DeliveredPackageListingViewModel> GetDeliveredForUser(string username);
        PackageDetailsViewModel Get(string id, string userId, bool isAdmin);
        ICollection<PendingPackageTableItemViewModel> GetAllPending();
        ICollection<ShippedPackageTableItemViewModel> GetAllShipped();
        ICollection<DeliveredPackageTableItemViewModel> GetAllDelivered();
        void Ship(string id);
        void Deliver(string id);
        void Acquire(string id, string username);
    }
}
