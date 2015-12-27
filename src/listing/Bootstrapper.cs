using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace listing
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            // your customization goes here
            
        }
    }
}
