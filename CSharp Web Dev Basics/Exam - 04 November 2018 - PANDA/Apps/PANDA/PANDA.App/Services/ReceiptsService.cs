namespace PANDA.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using PANDA.Models;

    public class ReceiptsService : DataService, IReceiptsService
    {
        public ReceiptsService(PandaDbContext context) : base(context)
        {
        }

        public void Create(string recipientId, string packageId, decimal packageWeight)
        {
            Receipt receipt = new Receipt
            {
                RecipientId = recipientId,
                Fee = packageWeight * 2.67m,
                PackageId = packageId,
                IssuedOn = DateTime.Now
            };

            this.context.Receipts.Add(receipt);
            this.context.SaveChanges();
        }

        public ICollection<ReceiptListingViewModel> GetAllForUser(string username)
        {
            var user = this.context.Users
                .Include(u => u.Receipts)
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return null;
            }

            var receipts = user.Receipts
                .Select(r => new ReceiptListingViewModel
                {
                    Fee = r.Fee.ToString("F2"),
                    Id = r.Id,
                    IssuedOn = r.IssuedOn.ToString("dd/MM/yyyy"),
                    Recipient = user.Username
                })
                .ToArray();

            return receipts;
        }

        public ReceiptDetailsViewModel Get(string id, string username)
        {
            var receipt = this.context.Receipts
                .Include(r => r.Recipient)
                .Include(r => r.Package)
                .FirstOrDefault(r => r.Id == id);

            if (receipt == null || receipt.Recipient.Username != username)
            {
                return null;
            }

            var receiptModel = new ReceiptDetailsViewModel
            {
                Address = receipt.Package.ShippingAddress,
                Fee = receipt.Fee.ToString("F2"),
                Id = receipt.Id,
                IssuedOn = receipt.IssuedOn.ToString("dd/MM/yyyy"),
                PackageDescription = receipt.Package.Description,
                PackageWeight = receipt.Package.Weight.ToString(),
                Recipient = receipt.Recipient.Username
            };

            return receiptModel;
        }
    }
}
