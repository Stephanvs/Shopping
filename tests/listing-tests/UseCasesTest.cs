using System;
using System.Collections.Generic;
using Akka.Actor;
using Even;
using Even.Persistence;

namespace listing
{
    public abstract class UseCasesTest<TSubject> where TSubject : Aggregate, new()
    {
        protected UseCasesTest()
        {
            var store = new InMemoryStore();
            Sys = ActorSystem.Create("listing-tests");

            Gateway = Sys
                .SetupEven()
                .UseStore(store)
                .Start()
                .Result;
        }

        protected ActorSystem Sys { get; private set; }

        protected EvenGateway Gateway { get; private set; }

        protected virtual void Verify(UseCase useCase)
        {
            //todo: replay 'given' events from useCase
            var actor = Sys.ActorOf<TSubject>();
            foreach (var evt in useCase.Given)
            {
                actor.Tell(evt);
            }

            var cmd = useCase.When();

            Gateway.SendAggregateCommand<TSubject>(cmd).Wait();

            var expectation = useCase.Expect(new Expector(useCase));

            //actual.ShouldBeEquivalentTo(expectation, useCase.Name, useCase.Detail);
        }
    }

    public sealed class UseCase
    {
        public string Name { get; set; }

        public string Detail { get; set; }

        public IEnumerable<object> Given { get; set; }

        public Func<object> When { get; set; }

        public Func<Expector, string> Expect { get; set; }
    }

    public class Expector
    {
        private readonly UseCase _useCase;

        public Expector(UseCase useCase)
        {
            _useCase = useCase;
        }

        public string JsonAndEvents(object expected, params object[] events)
        {
            return "";
        }
    }
}
