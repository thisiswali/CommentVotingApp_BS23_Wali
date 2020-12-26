using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommentVotingApp_BS23_Wali.Models
{
    public class PostVModel
    {
        public virtual PostEntity PostEntity { get; set; }
        public virtual IEnumerable<PostEntity> Posts { get; set; }

        public virtual CommentEntity CommentEntity { get; set; }
        public virtual IEnumerable<CommentEntity> Comments { get; set; }

        public virtual VoteEntity Vote { get; set; }
        public virtual IEnumerable<VoteEntity> Votes { get; set; }
    }

    #region post report vm
    public class PostSearchModel
    {
        public int? Page { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        [Display(Name = "Date")]
        public DateTime CreatedOn { get; set; }

        public IPagedList<PostEntity> SearchResults { get; set; }
        public string SearchButton { get; set; }
        public virtual PostEntity PostEntity { get; set; }
    }
    #endregion
}