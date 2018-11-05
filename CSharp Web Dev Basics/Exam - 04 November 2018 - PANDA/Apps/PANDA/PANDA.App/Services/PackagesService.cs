namespace PANDA.App.Services
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Data;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using PANDA.Models;

    public class PackagesService : DataService, IPackagesService
    {
        private IReceiptsService receiptsService;

        public PackagesService(PandaDbContext context, IReceiptsService receiptsService) : base(context)
        {
            this.receiptsService = receiptsService;
        }

        public bool Create(string description, decimal weight, string shippingAddress, string recipientId)
        {
            if (!this.context.Users.Any(u => u.Id == recipientId))
            {
                return false;
            }

            var package = new Package
            {
                Description = description,
                Weight = weight,
                Status = Status.Pending,
                ShippingAddress = shippingAddress,
                RecipientId = recipientId
            };

            this.context.Packages.Add(package);
            this.context.SaveChanges();

            return true;
        }

        public ICollection<PackageListingViewModel> GetPendingForUser(string username)
        {
            var user = this.context.Users
                .Include(u => u.Packages)
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return null;
            }

            var packages = user.Packages
                .Where(p => p.Status == Status.Pending)
                .ToArray()
                .Select(p => new PackageListingViewModel
                {
                    Id = p.Id,
                    Description = p.Description
                })
                .ToArray();

            return packages;
        }

        public ICollection<PackageListingViewModel> GetShippedForUser(string username)
        {
            var user = this.context.Users
                .Include(u => u.Packages)
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return null;
            }

            var packages = user.Packages
                .Where(p => p.Status == Status.Shipped)
                .ToArray()
                .Select(p => new PackageListingViewModel
                {
                    Id = p.Id,
                    Description = p.Description
                })
                .ToArray();

            return packages;
        }

        public ICollection<DeliveredPackageListingViewModel> GetDeliveredForUser(string username)
        {
            var user = this.context.Users
                .Include(u => u.Packages)
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return null;
            }

            var packages = user.Packages
                .Where(p => p.Status == Status.Delivered)
                .ToArray()
                .Select(p => new DeliveredPackageListingViewModel
                {
                    Id = p.Id,
                    Description = p.Description
                })
                .ToArray();

            return packages;
        }

        public PackageDetailsViewModel Get(string id, string username, bool isAdmin)
        {
            var package = this.context.Packages
                .Include(p => p.Recipient)
                .FirstOrDefault(p => p.Id == id);

            if (package == null || !isAdmin
                && (package.Recipient.Username != username || package.Status == Status.Acquired))
            {
                return null;
            }

            string date = null;

            switch (package.Status)
            {
                case Status.Pending:
                    date = "N/A";
                    break;
                case Status.Shipped:
                    date = package.EstimatedDeliveryDate?.ToString("dd/MM/yyyy");
                    break;
                case Status.Delivered:
                case Status.Acquired:
                    date = "Delivered";
                    break;
            }

            var viewModel = new PackageDetailsViewModel
            {
                Address = package.ShippingAddress,
                Description = package.Description,
                EstimatedDeliveryDate = date,
                Weight = package.Weight.ToString(),
                Recipient = package.Recipient.Username,
                Status = package.Status.ToString()
            };

            return viewModel;
        }

        public ICollection<PendingPackageTableItemViewModel> GetAllPending()
        {
            var packages = this.context.Packages
                .Include(p => p.Recipient)
                .Where(p => p.Status == Status.Pending)
                .ToArray()
                .Select(p => new PendingPackageTableItemViewModel
                {
                    Address = p.ShippingAddress,
                    Description = p.Description,
                    Id = p.Id,
                    Recipient = p.Recipient.Username,
                    Weight = p.Weight.ToString()
                })
                .ToArray();

            for (var i = 0; i < packages.Length; i++)
            {
                packages[i].No = i + 1;
            }

            return packages;
        }

        public ICollection<ShippedPackageTableItemViewModel> GetAllShipped()
        {
            var packages = this.context.Packages
                .Include(p => p.Recipient)
                .Where(p => p.Status == Status.Shipped)
                .ToArray()
                .Select(p => new ShippedPackageTableItemViewModel
                {
                    DeliveryDate = p.EstimatedDeliveryDate?.ToString("dd/MM/yyyy"),
                    Description = p.Description,
                    Id = p.Id,
                    Recipient = p.Recipient.Username,
                    Weight = p.Weight.ToString()
                })
                .ToArray();

            for (var i = 0; i < packages.Length; i++)
            {
                packages[i].No = i + 1;
            }

            return packages;
        }

        public ICollection<DeliveredPackageTableItemViewModel> GetAllDelivered()
        {
            var packages = this.context.Packages
                .Include(p => p.Recipient)
                .Where(p => p.Status == Status.Delivered || p.Status == Status.Acquired)
                .ToArray()
                .Select(p => new DeliveredPackageTableItemViewModel
                {
                    Address = p.ShippingAddress,
                    Description = p.Description,
                    Id = p.Id,
                    Recipient = p.Recipient.Username,
                    Weight = p.Weight.ToString()
                })
                .ToArray();

            for (var i = 0; i < packages.Length; i++)
            {
                packages[i].No = i + 1;
            }

            return packages;
        }

        public void Ship(string id)
        {
            var package = this.context.Packages
                .Include(p => p.Recipient)
                .FirstOrDefault(p => p.Id == id);

            if (package == null || package.Status != Status.Pending)
            {
                return;
            }

            Random random = new Random();
            var date = DateTime.Now.AddDays(random.Next(20, 40));

            package.Status = Status.Shipped;
            package.EstimatedDeliveryDate = date;

            this.context.Packages.Update(package);
            this.context.SaveChanges();
        }

        public void Deliver(string id)
        {
            var package = this.context.Packages
                .Include(p => p.Recipient)
                .FirstOrDefault(p => p.Id == id);

            if (package == null || package.Status != Status.Shipped)
            {
                return;
            }

            package.Status = Status.Delivered;

            this.context.Packages.Update(package);
            this.context.SaveChanges();
        }

        public void Acquire(string id, string username)
        {
            var package = this.context.Packages
                .Include(p => p.Recipient)
                .FirstOrDefault(p => p.Id == id);

            if (package == null || package.Recipient.Username != username || package.Status != Status.Delivered)
            {
                return;
            }

            this.receiptsService.Create(package.RecipientId, package.Id, package.Weight);

            package.Status = Status.Acquired;
            this.context.Packages.Update(package);

            this.context.SaveChanges();
        }
    }
}
