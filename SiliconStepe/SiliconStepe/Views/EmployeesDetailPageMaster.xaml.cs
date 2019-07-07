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
    public partial class EmployeesDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public EmployeesDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new EmployeesDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class EmployeesDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<EmployeesDetailPageMenuItem> MenuItems { get; set; }
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

            public EmployeesDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<EmployeesDetailPageMenuItem>(new[]
                {
                     new EmployeesDetailPageMenuItem { Id = 1, Title = "Опрос", Icon = OnPlatformString("settings"), TargetType = typeof(QuestionsView)  },
                     new EmployeesDetailPageMenuItem { Id = 1, Title = "Требуемая документация", Icon = OnPlatformString("competitions"), TargetType = typeof(OrganizationTypeView) },
                     new EmployeesDetailPageMenuItem { Id = 1, Title = "Исполнители", Icon = OnPlatformString("competitions"), TargetType = typeof(EmployeesPage) },
                     new EmployeesDetailPageMenuItem { Id = 1, Title = "Список обращений", Icon = OnPlatformString("competitions"), TargetType = typeof(InvitesEmpTabbedPage) },
                     new EmployeesDetailPageMenuItem { Id = 1, Title = "FAQ", Icon = OnPlatformString("competitions"), TargetType = typeof(FaqPage) },
                     new EmployeesDetailPageMenuItem { Id = 1, Title = "Настройки", Icon = OnPlatformString("settings"), TargetType = typeof(SettingPage) },
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