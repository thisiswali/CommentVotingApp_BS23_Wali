using CommentVotingApp_BS23_Wali.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommentVotingApp_BS23_Wali.Controllers
{
    public class PostsController : Controller
    {
        private PostDbContext db = new PostDbContext();

        #region ++ post report

        const int RecordsPerPage = 3;
        public ActionResult PostReports(PostSearchModel model)
        {
            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {

                var results = db.Posts
                .Where(p => (p.PostTitle.Contains(model.Title) || model.Title == null))
                .OrderBy(p => p.PostID);

                var pageIndex = model.Page ?? 1;
                model.SearchResults = results.ToPagedList(pageIndex, RecordsPerPage);

                return View(model);
            }


            return View(model);
        }


        #endregion



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}