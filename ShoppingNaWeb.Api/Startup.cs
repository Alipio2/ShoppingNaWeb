using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories;
using ShoppingNaWeb.Infra.Repositories;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Handlers;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Handlers;

namespace ShoppingNaWeb.Api
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddResponseCompression();
            
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();    

            services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();
            services.AddTransient<OrderCommandHandle, OrderCommandHandle>();
            
        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseResponseCompression();
        }
    }
}
