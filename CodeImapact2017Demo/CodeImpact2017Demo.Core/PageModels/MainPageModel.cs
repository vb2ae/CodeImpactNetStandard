using CodeImpact2017Demo.Entity;
using CodeImpact2017Demo.Models;
using CodeImpact2017Demo.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CodeImpact2017Demo.PageModels
{
    public class MainPageModel : FreshBasePageModel

    {

        public MainPageModel()
        {
            Posts = new ObservableCollection<Feed>();
        }

        public ObservableCollection<Feed> Posts { get; set; }
        public ObservableCollection<Monkey> Monkeys { get; set; }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            FeedReader reader = new FeedReader();
            var posts = await reader.GetFeed("http://kentuckerapps.azurewebsites.net/api/MaritimeNews/GetMaritimeNews", "feedItems.json");
            Posts.Clear();
            foreach (var post in posts)
            {
                Posts.Add(post);
            }

            string path = "";

            if (Device.RuntimePlatform == Device.Android)
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "codeimpact.db");
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "codeimpact.db");
            }
            else if(Device.RuntimePlatform == Device.UWP)
            {
                path = Path.Combine(Environment.CurrentDirectory, "codeimpact.db");
            }
            List<Monkey> lst = null;

            //using (var db = new MonkeyContext(path))
            //{
            //    await db.Database.EnsureCreatedAsync();
            //    if (!db.Monkeys.Any())
            //    {
            //        db.Monkeys.Add(new Monkey { monkeyType = "Squirrel Monkey" });
            //        db.Monkeys.Add(new Monkey { monkeyType = "Spider Monkey" });
            //        db.Monkeys.Add(new Monkey { monkeyType = "Golden Lion Tamarin" });
            //        db.Monkeys.Add(new Monkey { monkeyType = "Howler Monkey" });
            //        db.Monkeys.Add(new Monkey { monkeyType = "Owl or Night Monkey" });
            //        await db.SaveChangesAsync();
            //    }
            //    lst = db.Monkeys.ToList();

            //}

        }


    }
}
