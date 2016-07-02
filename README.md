# IdentityServer4 EF Seed data
Seeding data into database when playing with 20|20 IdentityServer4.EntityFrameworkCore

After migration process you get empty data tables. If ypu don't know where to put what (just like me) this file is for You.
Solution is not very elegant, but usefull in development process.
#### Usage
1) Copy EnsureSeedDataClient.cs into your solution and change namespace

2) Add this code into Startup.cs (Configure section)

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
        ...
            if (env.IsDevelopment())
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<ClientConfigurationContext>().EnsureSeedClientData();
                    serviceScope.ServiceProvider.GetService<ScopeConfigurationContext>().EnsureSeedScopeData();
                }
            }

            app.UseIdentityServer();
            ...
        }
        
  3) Make sure that Conigure directory still contains example files (Clients.cs and Scopes.cs). These extensions will use them.
  
