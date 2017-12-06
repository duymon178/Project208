using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project208.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Project208.Domain.Abstract;
using Project208.Services.Abstract;
using Project208.Services.Concrete;
using FluentValidation.AspNetCore;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Project208.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration) => Configuration = configuration;
        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<EFDbContext>(options => options.UseSqlServer(
                Configuration["Data:Project208CnString:ConnectionString"]));
            services.AddTransient<IContractStatusRepository, EFContractStatusRepository>();
            services.AddTransient<ICustomerRepository, EFCustomerRepository>();
            services.AddTransient<ILocationRepository, EFLocationRepository>();
            services.AddTransient<INoteRepository, EFNoteRepository>();
            services.AddTransient<ISlowlyReturnTypeRepository, EFSlowlyReturnTypeRepository>();
            services.AddTransient<IT1ContractRepository, EFT1ContractRepository>();
            services.AddTransient<IT2ContractRepository, EFT2ContractRepository>();
            services.AddTransient<IT1PaymentDetailRepository, EFT1PaymentDetailRepository>();
            services.AddTransient<IT2PaymentDetailRepository, EFT2PaymentDetailRepository>();

            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICommonContractService, CommonContractService>();
            services.AddTransient<IT1ContractService, T1ContractService>();
            services.AddTransient<IT2ContractService, T2ContractService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc()
                .AddJsonOptions(
                    options => { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; }
                )
                .AddFluentValidation(fv => {
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                });
            

            services.AddAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error/500");
            }
            
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
