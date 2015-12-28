using System.Threading.Tasks;
using Akka.Actor;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Even;
using Even.Persistence;

namespace listing
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            var actorSystem = ActorSystem.Create("listing");

            Task.Run(async () =>
            {
                var inMemoryStore = new InMemoryStore();

                var gateway = await actorSystem
                    .SetupEven()
                    .UseStore(inMemoryStore)
                    //.AddProjectection<ActiveProducts>()
                    .Start("even");

                container.Register(typeof(EvenGateway), gateway);
            }).Wait();
        }
    }
}
