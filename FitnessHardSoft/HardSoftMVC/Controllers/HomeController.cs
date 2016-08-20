﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HardSoftMVC.Models;

namespace HardSoftMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var trainers = db.Trainers.OrderByDescending(t => t.Date).Take(4).ToList();
            var posts = db.Posts.Include(p => p.Author).OrderByDescending(p => p.Date).Take(6).ToList();

            var viewModel = new CookMeIndexViewModel
            {
                Trainers = trainers,
                Posts = posts
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

                    if (post.Content.Length >= 60) {
                        post.Content = post.Content.Substring(0, 60);

                        post.Content += "...";
                    }
                }
            }

            return View(viewModelList);
        }
    }
}