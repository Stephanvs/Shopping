namespace listing
{
    using Nancy;

    public class Service : NancyModule
    {
        //private readonly EvenGateway _gateway;

        public Service() : base("listing")
        {
            Get["/{productId}"] = arguments =>
            {
                var productId = arguments.productId;

                var model = new { ProductId = productId, Name = "ABC" };
                // var model = sys.store.load(productId);

                // sys.pub.Publish(() =>
                //     sys.NewListingVisited()
                // );

                return Response.AsJson(model);
            };
        }
    }
}
