using System.Threading.Tasks;
using Even;

namespace listing.Aggregates
{
    public class ListingState
    {
        public string Name { get; set; }

        public int VisitedCount { get; set; }

        public bool IsRemoved { get; set; }
    }

    public class Listing : Aggregate<ListingState>
    {
        public Listing()
        {
            OnCommand<CreateListing>(cmd =>
            {
                if (State != null)
                    Reject("Listing already exists");

                Persist(new ListingCreated
                {
                    Name = cmd.Name
                });
            });

            OnEvent<ListingCreated>(evt =>
            {
                State = new ListingState
                {
                    Name = evt.Name
                };
            });

            OnCommand<ViewListing>(async cmd =>
            {
                if (State == null)
                    Reject("Listing doesn't seem to exist");

                var alreadyExists = await Task.FromResult(false);

                if (alreadyExists)
                    Reject("");

                Persist(new ListingViewed());
            });

            OnEvent<ListingViewed>(evt =>
            {
                State.VisitedCount++;
            });

            OnCommand<RemoveListing>(cmd =>
            {
                if (State != null && !State.IsRemoved)
                    Persist(new ListingRemoved());
            });

            OnEvent<ListingRemoved>(e =>
            {
                State.IsRemoved = true;
            });
        }
    }
}