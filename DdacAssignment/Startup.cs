using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using DdacAssignment.Utils;

[assembly: OwinStartup(typeof(DdacAssignment.Startup))]

namespace DdacAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
