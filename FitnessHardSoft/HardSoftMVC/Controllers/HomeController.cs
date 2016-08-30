﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HardSoftMVC.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNet.Identity;

namespace HardSoftMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var trainers = db.Trainers.OrderByDescending(t => t.Date).Take(4).ToList();
            var posts = db.Posts.Include(p => p.Author).OrderByDescending(p => p.Date).Take(6).ToList();
            var contact = new Contact();

            var viewModel = new CookMeIndexViewModel
            {
                Trainers = trainers,
                Posts = posts,
                Contact = contact
            };

            List<CookMeIndexViewModel> viewModelList = new List<CookMeIndexViewModel>();
            viewModelList.Add(viewModel);

            foreach (var item in viewModelList)
            {
                foreach (var post in item.Posts)
                {
                    if (post.Title.Length >= 30)
                    {
                        post.Title = post.Title.Substring(0, 30);

                        post.Title += "...";
                    }

                    if (post.Content.Length >= 45) {
                        post.Content = post.Content.Substring(0, 45);

                        post.Content += "...";
                    }

                    post.Content = Regex.Replace(post.Content, @"<[^>]*>", String.Empty);
                }
            }

            return View(viewModelList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Subject,Message,Date")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }
    }
}