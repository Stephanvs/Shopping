using listing.Aggregates;
using Xunit;

namespace listing
{
    public class UseCases : UseCasesTest<Listing>
    {
        [Fact]
        public void uc_Product_Listing_Requested()
        {
            var created = ListingCreated();

            Verify(new UseCase
            {
                Name = "Visitor can view a product listing",
                Given = new [] { created },
                When = () => ViewListing(),
                Expect = e => e.JsonAndEvents(
                    new ListingState
                    {
                        IsRemoved = false,
                        Name = "Default Listing Name",
                        VisitedCount = 1
                    },
                    new ListingViewed()
                )
            });
        }

        private static ViewListing ViewListing()
        {
            return new ViewListing();
        }

        private static ListingCreated ListingCreated()
        {
            return new ListingCreated
            {
                Name = "Default Listing Name"
            };
        }
    }
}
