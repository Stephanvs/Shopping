using System.Threading.Tasks;
using listing.Aggregates;
using Xunit;

namespace listing
{
    public class UseCases : UseCasesTest<Listing>
    {
        [Fact]
        public async Task uc_Product_Listing_Requested()
        {
            var created = ListingCreated();

            await VerifyAsync(new UseCase
            {
                Name = "Visitor can view a product listing",
                Given = new [] { created },
                When = () => ViewListing(),
                Expect = e => e.StateAndEmittedEvents(
                    new ListingState
                    {
                        IsRemoved = false,
                        Name = "Default Listing Name",
                        VisitedCount = 1
                    },
                    typeof(ListingViewed)
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
