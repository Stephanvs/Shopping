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

                // todo: retrieve model from store
                // var model = sys.store.load(productId);
                var model = new { ProductId = productId, Name = "ABC" };

                gateway.SendAggregateCommand<Listing>(productId, new ViewListing());

                return Response.AsJson(model);
            };
        }
    }
}
