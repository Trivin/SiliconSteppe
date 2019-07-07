using SiliconStepe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiliconStepe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkerDetailPage : MasterDetailPage
    {
        public WorkerDetailPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new InvitesTabbedPage() { Title = "Список обращений" });
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as WorkerDetailPageMenuItem;
            if (item == null)
                return;

            switch (item.TargetType)
            {
                case Type order when typeof(InvitesTabbedPage) == item.TargetType:
                    Detail = new NavigationPage(new InvitesTabbedPage() { Title = item.Title });
                    break;
                case Type order when typeof(SettingPage) == item.TargetType:
                    Detail = new NavigationPage(new SettingPage() { Title = item.Title });
                    break;
                case Type order when typeof(EmployeesPage) == item.TargetType:
                    Detail = new NavigationPage(new EmployeesPage() { Title = item.Title });
                    break;
                default:
                    Detail = new NavigationPage(new InvitesTabbedPage() { Title = item.Title });
                    break;
            }
            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;

        }
    }
}