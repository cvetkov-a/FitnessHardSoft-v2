namespace HardSoftMVC.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                // If the database is empty, populate sample data in it

                CreateUser(context, "ib0x@abv.bg", "123456789", "System Administrator", "noavatar.jpg");
                CreateUser(context, "pesho@gmail.com", "12345", "System Administrator", "noavatar.jpg");
                CreateUser(context, "merry@gmail.com", "12345", "Merry", "noavatar.jpg");
                CreateUser(context, "geshu@gmail.com", "12345", "Geshu", "noavatar.jpg");
                CreateUser(context, "georgi.yazovaliiski@gmail.com", "gogo2000", "Gosho", "noavatar.jpg");
                CreateUser(context, "sashobgb@abv.bg", "12345", "Sasho", "noavatar.jpg");

                CreateRole(context, "Administrators");
                CreateRole(context, "Trainers");


                AddUserToRole(context, "ib0x@abv.bg", "Administrators");
                AddUserToRole(context, "georgi.yazovaliiski@gmail.com", "Administrators");
                AddUserToRole(context, "pesho@gmail.com", "Trainers");
                AddUserToRole(context, "merry@gmail.com", "Trainers");
                AddUserToRole(context, "geshu@gmail.com", "Trainers");

                CreateTrainer(context,
                    name: "Dwayne Johnson",
                    information: "Dwayne Douglas Johnson (born May 2, 1972), also known by his ring name The Rock, is an American-Canadian actor, producer, and semi-retired professional wrestler, currently signed to WWE.",
                    imageURL: "therock.jpg",
                    date: new DateTime(2016, 03, 27, 17, 54, 48)
                );

                CreateTrainer(context,
                    name: "Lazar Angelov",
                    information: "He owns some of the best abs in the world. As a personal trainer he has been able to transform the bodies of thousands of people and to make his motivation and knowledge contagious to them.",
                    imageURL: "lazar.jpg",
                    date: new DateTime(2016, 03, 27, 17, 54, 48)
                );

                CreateTrainer(context,
                    name: "Jeff Seid",
                    information: "Jeff Seid is an American professional bodybuilder and fitness model who is best known for his charming look and his bodybuilding. He was born on  12, June 1994 in Renton, Washington. He is 21 year old and standing in 6 feet height and 88 kg weight. He has millions of followers on his social network.",
                    imageURL: "jeffseid.jpg",
                    date: new DateTime(2016, 03, 27, 17, 54, 48)
                );

                CreateTrainer(context,
                    name: "Ronnie Coleman",
                    information: "Ronnie Dean Coleman (born May 13, 1964) is a retired American professional bodybuilder and the winner of the Mr. Olympia bodybuilding title 8 years in a row. Alongside his eight Mr. Olympia wins as a professional bodybuilder, he holds the record for most wins as an IFBB professional with 26.",
                    imageURL: "ronnie.jpg",
                    date: new DateTime(2016, 03, 27, 17, 54, 48)
                );

                CreatePost(context,
                    title: "Carb Cycling That Actually Works",
                    body: @"There's a lot of hype about carb cycling, and many claims are being made about it that are yet to be substantiated. The idea that alternating between high and low-carb days will accelerate fat loss is, well, hogwash. The truth is, any diet that causes you to expend more energy than you consume, whether it's daily or even weekly, will result in weight loss. That said, there are some practical ways of using this method for burning fat while preserving muscle and strength.Carb cycling is basically just planned changes in carbohydrate intake in order to accelerate fat loss and/or avoid weight loss plateaus. The traditional approach has you rotate through high-carb, moderate-carb, and low-carb days while protein intake remains unchanged. Fat intake becomes low when carbs are high, and high when carbs are low.",
                    imageUrl: "carbs.jpeg",
                    TagsString: "Carb Cycling",
                    date: new DateTime(2016, 03, 27, 17, 53, 48),
                    authorUsername: "merry@gmail.com"
                );

                CreatePost(context,
                    title: "The Single Best Muscle-Building Method",
                    body: @"A recent study found that when it comes to hypertrophy (muscle growth), if you go to muscle failure the weight used doesn't really matter. The same amount of muscle growth and protein synthesis occurred with 3 sets to failure using 30% and 3 sets to failure using 80% of your maximum load.What does that mean? Training to muscle failure, regardless of the load, leads to a maximal recruitment of muscle fibers.Shocked? I was. It's not so much the value of training to failure that surprised me, but rather the fact that when it comes to stimulating hypertrophy, the act of reaching muscle failure might be the MAIN trigger for growth. Not the weight lifted or the explosiveness used, but the muscle failure itself.",
                    imageUrl: "muscle.jpg",
                    TagsString: "Muscle Gain",
                    date: new DateTime(2016, 05, 11, 08, 22, 03),
                    authorUsername: "merry@gmail.com"
                );

                CreatePost(context,
                    title: "Whey vs. Casein: The Real Story",
                    body: @"Casein results in greater deposition of protein than whey, which simply means more muscle. Whey causes protein synthesis to increase rapidly and to a high degree, but it doesn't last long. There's an increase in protein synthesis and protein oxidation, but there's no change in protein breakdown.That last point is a huge negative for whey. Contrast that with casein, which, like whey, increases protein synthesis but inhibits breakdown to a large degree.A good number of studies have confirmed that casein leads to superior gains of lean mass and strength.One study using weight-trained subjects showed a doubling of lean mass gains and 50% greater fat loss over that of the whey group. The casein group also increased bench, shoulder press, and leg extension strength by a collective 59% whereas the whey group only had a 28% increase in strength.Another study, this one with burn patients, showed that 70-75 grams of casein outperformed the same amount of whey. The casein group gained lean muscle twice as fast as the whey group, despite having to deal with the incredibly high metabolism and increased protein oxidation from injuries.And those two are just a very small sampling of studies that have shown the superiority of generic casein. There are, however, sophisticated caseins whose muscle-building properties go much further than the generic, garden-variety caseins.",
                    imageUrl: "whey.jpg",
                    TagsString: "Whey Casein",
                    date: new DateTime(2016, 03, 27, 17, 53, 48),
                    authorUsername: "merry@gmail.com"
                );

                CreatePost(context,
                    title: "The Five Principles of Radical Fat Loss",
                    body: @"If you want to lose fat fast, you need to do work and you need to do it often. In almost all cases, it's more effective to spread your activity over a greater period of time (while still allowing for rest). For fat loss I like training twice per day, splitting it between weight training and cardio.Of course, training twice per day is not possible for some people, in which case I allow them to do the weight training and cardio back-to-back, as long as they ensure the weights come first.The high level of frequency ensures a consistently elevated metabolic rate, a tremendous and constant surge of EPOC (Excess Post-exercise Oxygen Consumption) and the resultant boost in the rate of energy expenditure that accompanies those things.For the sake of demonstration, here's an actual 3-week schedule for one of my online coaching clients, whose goal was to lose 18 pounds of fat in eight weeks (it wound up taking six weeks).",
                    imageUrl: "fatloss.jpg",
                    TagsString: "Fatloss",
                    date: new DateTime(2016, 02, 18, 22, 14, 38),
                    authorUsername: "pesho@gmail.com"
                );

                CreatePost(context,
                    title: "Steroids for Dummies",
                    body: @"Anabolic steroids are synthetic analogs or derivatives of Testosterone and nor-testosterone. In the 1930s, scientists found that these anabolic steroids could increase the growth of muscle in lab animals. The compounds were then used to treat debilitating diseases in humans.In the 1950s, a doctor, John Ziegler had dispensed an oral anabolic steroid by the name of Dianabol. Soon after, athletes began to use this steroid in order to increase muscle mass and strength. Soon, more and more analogs and derivatives were being made available to athletes.While all steroids have the same four ring carbon structure, simple chemical alterations produced different effects in terms of anabolic/androgenic activity. Anabolic activity refers to the steroid's ability to facilitate skeletal muscle growth, while androgenic activity refers to how potent the drug is at inducing the development of male sexual characteristics (facial hair, deep voice, the ability to channel surf and watch six TV programs at once, etc.)",
                    imageUrl: "piana.jpg",
                    TagsString: "Steroids",
                    date: new DateTime(2016, 04, 11, 19, 02, 05),
                    authorUsername: "geshu@gmail.com"
                );

                CreateTypeCard(context,
                    type: "SixMonthMembership"
                    );
                CreateTypeCard(context,
                    type: "OneYearMembership"
                    );

                CreateCard(context,
                    CreationDate: new DateTime(2016, 06, 30, 17, 36, 52),
                    ExpirationDate: new DateTime(2017, 06, 30, 17, 36, 52),
                    CardName: 1,
                    Purchaser: "georgi.yazovaliiski@gmail.com"
                    );
                CreateCard(context,
                    CreationDate: new DateTime(2016, 06, 30, 17, 36, 52),
                    ExpirationDate: new DateTime(2017, 06, 30, 17, 36, 52),
                    CardName: 2,
                    Purchaser: "georgi.yazovaliiski@gmail.com"
                    );
                
                context.SaveChanges();
            }
        }

        private void CreateUser(ApplicationDbContext context,
            string email, string password, string fullName, string avatar)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullName,
                Avatar = avatar
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        private void CreateRole(ApplicationDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        {
            var user = context.Users.First(u => u.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private void CreateTrainer(ApplicationDbContext context, string name, string information, string imageURL, DateTime date)
        {
            var trainer = new Trainer();

            trainer.Name = name;
            trainer.Information = information;
            trainer.ImageURL = imageURL;
            trainer.Date = date;
            context.Trainers.Add(trainer);
        }

        private void CreatePost(ApplicationDbContext context,
            string title, string body, string imageUrl, string TagsString, DateTime date, string authorUsername)
        {
            var post = new Post();
            var TagsList = TagsString.Split(' ').ToList();

            List<Tag> TagsResult = new List<Tag>();
            foreach (var tag in TagsList)
            {
                Tag check = new Tag();
                check.TagName = tag;
                List<string> existing = context.Tags.Select(a => a.TagName).ToList();
                if (existing.Contains(check.TagName) == false)
                {
                    context.Tags.Add(check);
                    context.SaveChanges();
                    TagsResult.Add(check);
                }
                else
                {
                    var partialId = context.Tags.Where(a => a.TagName == tag).Select(a => a.Id).ToList();
                    check.Id = partialId[0];
                    TagsResult.Add(check);
                }
            }
            post.Tags = TagsResult;
            post.Title = title;
            post.Content = body;
            post.ImageURL = imageUrl;
            post.Date = date;
            post.Author = context.Users.Where(u => u.UserName == authorUsername).FirstOrDefault();
            context.Posts.Add(post);
        }

        private void CreateTypeCard(ApplicationDbContext context,
            string type)
        {
            var cardType = new TypeCard();
            cardType.Type = type;
            context.Types.Add(cardType);
        }
        private void CreateCard(ApplicationDbContext context,
            DateTime CreationDate, DateTime ExpirationDate, int CardName, string Purchaser)
        {
            var currentCard = new Card();
            currentCard.DateOfCreating = CreationDate;
            currentCard.ExpirationDate = ExpirationDate;
            currentCard.CardId = context.Types.Where(a => a.Id == CardName).FirstOrDefault();
            currentCard.Purchaser = context.Users.Where(a => a.Email == Purchaser).FirstOrDefault();
            context.Cards.Add(currentCard);
        }
    }
}
