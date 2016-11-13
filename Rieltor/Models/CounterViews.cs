using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rieltor.Models
{
    public class CounterViews
    {
        public void AddCount(Views view, string linkOnPost)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var postId = db.Posts.Where(p => p.UrlSeo == linkOnPost).Select(c => c.Id).FirstOrDefault();

                var list = db.PostViews.Where(p => p.PostId == postId).Select(c => c.ViewsId).ToList();


                if (list.Count() == 0)
                {
                    db.PostViews.Add(new PostViews { PostId = postId, ViewsId = view.ViewsId });
                    db.Views.Add(view);
                    db.SaveChanges();
                }

                    List<Views> viewList = new List<Views>();

                if (list != null)
                {
                    foreach (var item in list)
                    {
                        viewList.Add(db.Views.Where(v => v.ViewsId == item).FirstOrDefault());
                    }
                }

                foreach (var itemId in list)
                {
                    var viewItem = viewList.Where(v => v.ViewsId == itemId && v.IpAddress == view.IpAddress).FirstOrDefault();
                  
                    if (viewItem == null)
                    {
                        db.PostViews.Add(new PostViews { PostId = postId, ViewsId = view.ViewsId });
                        db.Views.Add(view);
                        db.SaveChanges();
                    }
                }
                
            }

        }



        public int GetCount(string linkOnPost)
        {
            int count;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var postId = db.Posts.Where(p => p.UrlSeo == linkOnPost).Select(c => c.Id).FirstOrDefault();

                count = db.PostViews.Where(p => p.PostId == postId).Count();
            }
               
            return count;
        }

       

       
    }
}