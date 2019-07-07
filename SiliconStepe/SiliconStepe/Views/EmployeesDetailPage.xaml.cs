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
    public partial class EmployeesDetailPage : MasterDetailPage
    {
        public EmployeesDetailPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new EmployeesPage() { Title = "Исполнители" });
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as EmployeesDetailPageMenuItem;
            if (item == null)
                return;

            switch (item.TargetType)
            {
                case Type order when typeof(QuestionsView) == item.TargetType:
                    Detail = new NavigationPage(new QuestionsView() { Title = item.Title });
                    break;
                case Type order when typeof(OrganizationTypeView) == item.TargetType:
                    Detail = new NavigationPage(new OrganizationTypeView() { Title = item.Title });
                    break;
                case Type order when typeof(EmployeesPage) == item.TargetType:
                    Detail = new NavigationPage(new EmployeesPage() { Title = item.Title });
                    break;
                case Type order when typeof(FaqPage) == item.TargetType:
                    Detail = new NavigationPage(new FaqPage() { Title = item.Title });
                    break;
                case Type order when typeof(SettingPage) == item.TargetType:
                    Detail = new NavigationPage(new SettingPage() { Title = item.Title });
                    break;
                case Type order when typeof(InvitesEmpTabbedPage) == item.TargetType:
                    Detail = new NavigationPage(new InvitesEmpTabbedPage() { Title = item.Title });
                    break;
                default:
                    Detail = new NavigationPage(new EmployeesPage() { Title = item.Title });
                    break;
            }
            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;

        }
    }
}