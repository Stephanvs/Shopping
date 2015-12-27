using System.Collections.Generic;

namespace sys
{
    public class Commit
    {
        public Commit(IEnumerable<Event> events)
        {
            Events = events;
        }

        public IEnumerable<Event> Events { get; }
    }
}
