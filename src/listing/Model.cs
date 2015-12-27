using System;
using sys;

namespace listing
{
    public sealed class ViewProductListing : Command
    {
        public ViewProductListing(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; private set; }
    }

    public sealed class ProductListingCreated : Event
    {
        public ProductListingCreated(string productName)
        {
            ProductId = Guid.NewGuid();
            ProductName = productName;
        }

        public Guid ProductId { get; private set; }

        public string ProductName { get; private set; }
    }

    public sealed class ProductListingViewed : Event
    {
        public ProductListingViewed(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; private set; }
    }
}
