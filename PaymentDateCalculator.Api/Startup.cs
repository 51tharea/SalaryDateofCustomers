using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PaymentDateCalculator.Api.Core;
using PaymentDateCalculator.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace PaymentDateCalculator.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { Configuration = configuration; }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
        
            services.AddSingleton<ISalaryDateCalculation, SalaryDateCalculation>();

            services.AddMvc(options => { options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider()); })
                    .AddJsonOptions(jsonOptions =>
                                    {
                                        jsonOptions.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                                        jsonOptions.SerializerSettings.NullValueHandling     = NullValueHandling.Ignore;
                                        jsonOptions.SerializerSettings.Formatting            = Formatting.Indented;
                                        jsonOptions.SerializerSettings.DateFormatString      = "dd.MM.yyyy";
                                    }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
                                   {
                                       c.SwaggerDoc("v1", new Info
                                                          {
                                                              Version        = "v1",
                                                              Title          = "Payment Date Calculator API",
                                                              Description    = "Assignment: Finding next salary date of customers",
                                                              TermsOfService = "None",
                                                              Contact = new Contact
                                                                        {
                                                                            Name  = "Can ACAR",
                                                                            Email = "can.acar@windowslive.com",
                                                                            Url   = "https://github.com/51tharea"
                                                                        },
                                                              License = new License
                                                                        {
                                                                            Name = "Public",
                                                                            Url  = ""
                                                                        }
                                                          });
                                       
                                       c.MapType<DateTime>(() => new Schema { Type = "string", Format = "date" });
                                   });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
                             {
                                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment Date Calculator API");
                                
                             });

            app.UseMvc();
        }
    }
}
