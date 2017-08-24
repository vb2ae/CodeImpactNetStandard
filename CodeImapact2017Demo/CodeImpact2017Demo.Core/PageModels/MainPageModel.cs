using CodeImpact2017Demo.Models;
using CodeImpact2017Demo.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            FeedReader reader = new FeedReader();
            var posts = await reader.GetFeed("http://kentuckerapps.azurewebsites.net/api/MaritimeNews/GetMaritimeNews", "feedItems.json");
            Posts.Clear();
            foreach(var post in posts)
            {
                Posts.Add(post);
            }
        }


    }
}
