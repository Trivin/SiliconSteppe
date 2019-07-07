using SiliconStepe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiliconStepe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkerDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public WorkerDetailPageMaster()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                MenuItemsListView.Margin = new Thickness(0, 22, 0, 0);
            }

            BindingContext = new WorkerDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class WorkerDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<WorkerDetailPageMenuItem> MenuItems { get; set; }
            public User User
            {
                get
                {
                    return CurrentProperties.CurrentUser;
                }
                set
                {
                    if (value != CurrentProperties.CurrentUser)
                    {
                        CurrentProperties.CurrentUser = value;
                        OnPropertyChanged("User");
                    }
                }
            }
            
            public WorkerDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<WorkerDetailPageMenuItem>(new[]
                {
                     new WorkerDetailPageMenuItem { Id = 0, Title = "Список обращений", Icon = OnPlatformString("competitions"), TargetType = typeof(InvitesTabbedPage)  },
                     new WorkerDetailPageMenuItem { Id = 1, Title = "Настройки", Icon = OnPlatformString("settings"), TargetType = typeof(SettingPage)  },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        public static string OnPlatformString(string str)
        {
            return Device.RuntimePlatform == Device.Android ? str : str + @".png";
        }
    }
}