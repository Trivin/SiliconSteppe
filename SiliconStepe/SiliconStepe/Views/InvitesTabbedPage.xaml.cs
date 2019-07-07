using Acr.UserDialogs;
using SiliconStepe.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            ObservableCollection<Doc> documents = new ObservableCollection<Doc>();
            documents.Add(new Doc() { Name = "Акт обследования ограждения", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga") });
            documents.Add(new Doc() { Name = "Акт опробования АПС(1})", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga") });
            documents.Add(new Doc() { Name = "Акт перекатки пожарных рукавов(1})", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga") });
            documents.Add(new Doc() { Name = "Акт по воздуховодам", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga") });
            documents.Add(new Doc() { Name = "Акт по п-п дверям", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga") });
            documents.Add(new Doc() { Name = "Приказ уборка отходов", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga") });
            documents.Add(new Doc() { Name = "Протокол по лестнице маршевой", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga") });
            documents.Add(new Doc() { Name = "Журнал инструктажей", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga") });
            documents.Add(new Doc() { Name = "Протокол испытаний ПГ", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga") });
            documents.Add(new Doc() { Name = "Журнал учета огнетушителей", Uri = new Uri(@"https://drive.google.com/open?id=1bvUJQxgylbnX7eEvbZkSaJqjbqAR89ga") });
            Navigation.PushAsync(new DocumentationView(documents) { Title = "Документация организации" });
            (sender as ListView).SelectedItem = null;
        }
    }
}