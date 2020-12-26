using System.Web;
using System.Web.Mvc;

namespace CommentVotingApp_BS23_Wali
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
