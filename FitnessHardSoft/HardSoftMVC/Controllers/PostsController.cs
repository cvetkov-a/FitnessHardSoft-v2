using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HardSoftMVC.Models;
using PagedList;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace HardSoftMVC.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index(string currentFilter, string searchString, int? page, int? id)
        {
            BlogWholeInfo Blog = new BlogWholeInfo();
            var posts = db.Posts.Include(p => p.Author);

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            List<List<Tag>> PostResults = new List<List<Tag>>();
            var additionalPosts = new List<Post>();
            if (!String.IsNullOrEmpty(searchString))
            {
                List<string> TagsContainer = db.Tags.Select(a => a.TagName).ToList();
                PostResults = db.Posts.Select(a=>a.Tags).ToList();
                posts = posts.Where(s => s.Title.Contains(searchString)
                                       || s.Content.Contains(searchString)
                                        );
            }

            foreach (var post in posts)
            {
                if (post.Title.Length >= 40)
                {
                    post.Title = post.Title.Substring(0, 40);

                    post.Title += "...";
                }

                if (post.Content.Length >= 300)
                {
                    post.Content = post.Content.Substring(0, 300);

                    post.Content += "...";
                }
            }

            posts = posts.OrderByDescending(p => p.Date);

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            if (isAdministrator())
                ViewBag.isAdmin = true;

            if (isTrainer())
                ViewBag.isTrainer = true;

           
            
            Blog.Posts = posts.ToPagedList(pageNumber, pageSize);
            Blog.Tags = db.Tags.Take(20).ToList();
            searchString = null;
            

            return View(Blog);
        }

        public Boolean isAdministrator()
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!User.Identity.IsAuthenticated)
                return false;

            var user = User.Identity;

            if (!userManager.IsInRole(user.GetUserId(), "Administrators"))
                return false;

            return true;
        }

        public Boolean isTrainer()
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!User.Identity.IsAuthenticated)
                return false;

            var user = User.Identity;

            if (!userManager.IsInRole(user.GetUserId(), "Trainers"))
                return false;

            return true;
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public ActionResult Search(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Post> posts = new List<Post>();
            var postIds = db.Tags.Where(a => a.Id == id).Select(a=>a.Posts).ToList();
            
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // GET: Posts/Create
        [Authorize(Roles = "Administrators, Trainers")]
        public ActionResult Create()
        {
            ViewBag.authors = db.Users.ToList();

            ViewBag.IdentityAuthorName = User.Identity.GetUserName();
            ViewBag.IdentityAuthorId = User.Identity.GetUserId();

            if (isAdministrator())
                ViewBag.isAdmin = true;

            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators, Trainers")]
        public ActionResult Create([Bind(Include = "Id,Title,Content,ImageURL,Tags,TagsString,Date,Author_Id")] Post post)
        {
            string Tagove = post.TagsString;
            var TagsList = Tagove.Split(' ').ToList();
            
            List<Tag> TagsResult = new List<Tag>();
            foreach(var tag in TagsList)
            {
                Tag check = new Tag();
                check.TagName = tag;
                List<string> existing = db.Tags.Select(a => a.TagName).ToList();
                if(!existing.Contains(check.TagName))
                {
                    db.Tags.Add(check);
                    db.SaveChanges();
                }
                TagsResult.Add(check);
                db.SaveChanges();
            }
            post.Tags = TagsResult;
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,ImageURL,Tags,Date,Author_Id")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
