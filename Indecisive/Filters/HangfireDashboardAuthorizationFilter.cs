using Hangfire.Dashboard;

namespace Indecisive.Filters
{
    public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            //will add control
            //Allow all authenticated users to see the Dashboard(potentially dangerous)
            //return httpContext.User.Identity.IsAuthenticated;
            return true;
        }
    }
}