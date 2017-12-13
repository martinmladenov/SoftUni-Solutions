using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_17.ASP.NET_Blog.Startup))]

namespace _17.ASP.NET_Blog
{
    using Migrations;
    using Models;
    using System.Data.Entity;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>());
            ConfigureAuth(app);
        }
    }
}
