using Even;
using listing.Aggregates;
using Nancy;

namespace listing
{
    public class Service : NancyModule
    {
        public Service(EvenGateway gateway)
            : base(modulePath: "listing")
        {
            Get["/{productId}"] = arguments =>
            {
                var productId = arguments.productId;

                var model = new { ProductId = productId, Name = "ABC" };
                // var model = sys.store.load(productId);

                gateway.SendAggregateCommand<Listing>(productId, new ViewListing());

                return Response.AsJson(model);
            };
        }
    }
}
