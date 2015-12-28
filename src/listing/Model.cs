namespace listing
{
    public sealed class CreateListing
    {
        public string Name { get; set; }
    }

    public sealed class ViewListing
    {
    }

    public sealed class RemoveListing
    {
    }


    public sealed class ListingCreated
    {
        public string Name { get; set; }
    }

    public sealed class ListingViewed
    {
    }

    public sealed class ListingRemoved
    {
    }
}