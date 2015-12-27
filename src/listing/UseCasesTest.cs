using System;
using System.Collections.Generic;
using FluentAssertions;
using sys;

namespace listing
{
    public abstract class UseCasesTest
    {
        protected virtual void Verify(UseCase useCase)
        {
            // sys.ReplayEvents(useCase.Given);

            useCase.When();

            var expectation = useCase.Expect(new Expector());

            actual.ShouldBeEquivalentTo(expectation, useCase.Name, useCase.Detail);
        }
    }

    public sealed class UseCase
    {
        public string Name { get; set; }

        public string Detail { get; set; }

        public IEnumerable<Event> Given { get; set; }

        public Action When { get; set; }

        public Func<Expector, string> Expect { get; set; }
    }

    public class Expector
    {
        private object _expected;

        public string JsonAndEvents(object model, params Event[] events)
        {
            return "";
        }
    }
}
