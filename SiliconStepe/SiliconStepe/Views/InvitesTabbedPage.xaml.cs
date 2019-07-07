using Acr.UserDialogs;
using SiliconStepe.ViewModels;
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
    public partial class InvitesTabbedPage : TabbedPage
    {
        ActiveInvitesPageViewModel aipvm = new ActiveInvitesPageViewModel();
        ArchiveInvitesPageViewModel aripvm = new ArchiveInvitesPageViewModel();
        public InvitesTabbedPage ()
        {
            InitializeComponent();
            ActiveInvites.Appearing += ActiveInvites_Appearing;
            ArchiveInvites.Appearing += ArchiveInvites_Appearing;
            aipvm.OnLoaded += Itpvm_OnLoaded;
            aripvm.OnLoaded += Aripvm_OnLoaded;
        }

        private void Aripvm_OnLoaded(object sender)
        {
            ArchiveInvites.BindingContext = aripvm;
        }

        private async void ArchiveInvites_Appearing(object sender, EventArgs e)
        {
            base.OnAppearing();
            UserDialogs.Instance.ShowLoading("Загрузка...");
            await aripvm.GetInvites();
            UserDialogs.Instance.HideLoading();
        }

        private async void ActiveInvites_Appearing(object sender, EventArgs e)
        {
            base.OnAppearing();
            UserDialogs.Instance.ShowLoading("Загрузка...");
            await aipvm.GetInvites();
            UserDialogs.Instance.HideLoading();
        }

        private void Itpvm_OnLoaded(object sender)
        {
            ActiveInvites.BindingContext = aipvm;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}