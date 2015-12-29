using System;
using System.Collections.Generic;
using Akka.Actor;
using Akka.Actor.Dsl;
using Even;
using Even.Persistence;
using Even.Tests;
using Even.Messages;
using System.Threading.Tasks;
using Even.Tests.Mocks;
using FluentAssertions;

namespace listing
{
    public abstract class UseCasesTest<TSubject> : EvenTestKit where TSubject : Aggregate, new()
    {
        protected static readonly string TestStream = "listing-00000000-0000-0000-0000-000000000000";

        private IActorRef CreateWorkingReader(int eventCount = 0)
        {
            var reader = Sys.ActorOf(conf =>
            {
                conf.Receive<ReadStreamRequest>((r, ctx) =>
                {
                    for (var i = 1; i <= eventCount; i++)
                    {
                        var e = MockPersistedStreamEvent.Create(new ListingCreated(), i, i, TestStream);
                        ctx.Sender.Tell(new ReadStreamResponse(r.RequestID, e));
                    }

                    ctx.Sender.Tell(new ReadStreamFinished(r.RequestID));
                });
            });

            return reader;
        }

        protected async Task VerifyAsync(UseCase useCase)
        {
            // Arrange
            var reader = CreateWorkingReader(1); //todo: inject `useCase.Given` events here
            var writer = CreateTestProbe();
            var gateway = await Sys.SetupEven().Start();
            var aggRoot = Sys.ActorOf<Aggregates.Listing>();

            aggRoot.Tell(new InitializeAggregate(reader, writer, new GlobalOptions()));
            //foreach (var evt in useCase.Given)
            //{
            //    aggRoot.Tell(evt);
            //}

            // Act
            var cmd = useCase.When();

            /*var response = */await gateway.SendAggregateCommand<TSubject>(TestStream, cmd);

            // Assert
            //response.Accepted.Should().BeTrue();

            var expectation = useCase.Expect(new Expector(useCase));

            Console.ReadLine();
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

        public string StateAndEmittedEvents(object expected, params Type[] events)
        {
            return "";
        }
    }
}
