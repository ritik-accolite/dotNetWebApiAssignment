using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SoapApiAssignmnet;
using SoapCore;
using System.ServiceModel;

namespace SoapApiAssignmnet
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSoapCore();
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();
            services.AddSingleton<ICalculatorService, CalculatorService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var soapOptions = new SoapEncoderOptions();
            app.UseSoapEndpoint<ICalculatorService>("/CalculatorService.asmx", soapOptions, SoapSerializer.DataContractSerializer);
        }
    }
}
