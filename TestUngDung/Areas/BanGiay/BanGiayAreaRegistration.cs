using System.Web.Mvc;

namespace TestUngDung.Areas.BanGiay
{
    public class BanGiayAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BanGiay";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BanGiay_default",
                "BanGiay/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}