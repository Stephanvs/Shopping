using System;
using sys;
using Xunit;

namespace listing
{
    public class UseCases : UseCasesTest
    {
        [Fact]
        public void uc_Product_Listing_Requested()
        {
            var prd = productCreated("MacBook Air");

            Verify(new UseCase
            {
                Name = "Visitor can view a product listing",
                Given = new [] { prd },
                When = () => viewProductListing(prd),
                Expect = e => e.JsonAndEvents(
                    null, // todo: test actual expectation
                    productListingViewed(prd)
                )
            });
        }

        private static void viewProductListing(ProductListingCreated @event)
        {
            var cmd = new ViewProductListing(@event.ProductId);

            // todo: --> execute Command via CommandHandler or something
        }

        private static ProductListingViewed productListingViewed(ProductListingCreated @event)
        {
            return new ProductListingViewed(@event.ProductId);
        }

        private static ProductListingCreated productCreated(string productName)
        {
            return new ProductListingCreated(productName);
        }
    }
}
