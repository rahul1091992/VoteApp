using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vote.Data;
using Vote.Data.Abstraction;
using Vote.Data.DB;
using Vote.Service;
using Vote.Service.Abstraction;

namespace VoteAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<VoteDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("VoteDatabase")));


            services.AddMvc();

            // Services
            services.AddTransient<IAdminAccountService, AdminAccountService>();
            services.AddTransient<IElectionService, ElectionService>();
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddTransient<IVoterService, VoterService>();

            services.AddTransient<IUCustomerService, UCustomerService>();
            services.AddTransient<IUDriverService, UDriverService>();
            services.AddTransient<ILuckyService, LuckyService>();
            services.AddTransient<ILuckyprizeService, LuckyprizeService>();
            services.AddTransient<ILuckygameService, LuckygameService>();


            // Repositories
            services.AddTransient<IAdminAccountRepository, AdminAccountRepository>();
            services.AddTransient<IElectionRepository, ElectionRepository>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<IFileUploadRepository, FileUploadRepository>();
            services.AddTransient<IVoterRepository, VoterRepository>();

            services.AddTransient<IUCustomerRepository, UCustomerRepository>();
            services.AddTransient<IUDriverRepository, UDriverRepository>();
            services.AddTransient<ILuckyRepository, LuckyRepository>();
            services.AddTransient<ILuckyprizeRepository, LuckyprizeRepository>();
            services.AddTransient<ILuckygameRepository, LuckygameRepository>();



            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                       Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
                RequestPath = "/Uploads"
            });



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

           


            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());





            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
