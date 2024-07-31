using CommunityToolkit.Mvvm.ComponentModel;
using Notification_APP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification_APP.ViewModel
{
    internal partial class CurrentIndex : ObservableObject
    {
        private static readonly CurrentIndex _instance = new CurrentIndex();

        public static CurrentIndex Instance => _instance;

        public double? SelectedIndex;

        private CurrentIndex()
        {
            SelectedIndex = 0;
        }
    }
}
