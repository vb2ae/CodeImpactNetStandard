using Android.App;
using Android.Widget;
using Android.OS;
using Android.EFCore.Entity;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Android.EFCore
{
    [Activity(Label = "Android.EFCore", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        MonkeyAdapter adapter;


        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            List<Monkey> lst = null;
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "monkeys.db");

            using (var db = new MonkeyContext(path))

            {
                await db.Database.EnsureCreatedAsync();
                if (!db.Monkeys.Any())
                {
                    db.Monkeys.Add(new Monkey { monkeyType = "Squirrel Monkey" });
                    db.Monkeys.Add(new Monkey { monkeyType = "Spider Monkey" });
                    db.Monkeys.Add(new Monkey { monkeyType = "Golden Lion Tamarin" });
                    db.Monkeys.Add(new Monkey { monkeyType = "Howler Monkey" });
                    db.Monkeys.Add(new Monkey { monkeyType = "Owl or Night Monkey" });
                    await db.SaveChangesAsync();
                }
                lst = db.Monkeys.ToList();

            }



            adapter = new MonkeyAdapter(this, lst);

            ListAdapter = adapter;

        }
    }
}

