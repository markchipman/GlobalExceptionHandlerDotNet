using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalExceptionHandler.Tests.Fixtures
{
    public class WebApiServerFixture
    {
        public IWebHostBuilder CreateWebHost()
        {
            return CreateWebHost(null);
        }
        
        public IWebHostBuilder CreateWebHostWithMvc()
        {
            return CreateWebHost(s => s.AddMvc());
        }
        
        public IWebHostBuilder CreateWebHostWithXmlFormatters()
        {
            return CreateWebHost(s =>
            {
                s.AddMvc().AddXmlSerializerFormatters();
            });
        }
        
        private IWebHostBuilder CreateWebHost(Action<IServiceCollection> serviceBuilder)
        {
            var config = new ConfigurationBuilder().Build();
            var host = new WebHostBuilder()
                .UseConfiguration(config);
                
            if (serviceBuilder != null)
                host.ConfigureServices(serviceBuilder);

            return host;
        }
    }
}