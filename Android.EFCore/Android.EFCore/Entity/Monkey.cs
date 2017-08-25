using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Android.EFCore.Entity
{
    public class Monkey
    {
        public int id { get; set; }
        public string monkeyType { get; set; }
    }
}