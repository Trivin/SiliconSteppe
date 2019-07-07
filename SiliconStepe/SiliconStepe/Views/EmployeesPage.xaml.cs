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
	public partial class EmployeesPage : ContentPage
    {
        EmployeesPageViewModel ParticipantsModel;
        public EmployeesPage ()
		{
			InitializeComponent ();
            var tl = new ToolbarItem() { Icon = "plus.png" };
            tl.Clicked += Button_Clicked;
            ToolbarItems.Add(tl);
            ParticipantsModel = new EmployeesPageViewModel();
            ParticipantsModel.OnLoaded += ParticipantsModel_OnLoaded;
        }

        private void ParticipantsModel_OnLoaded(object sender)
        {
            this.BindingContext = ParticipantsModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            UserDialogs.Instance.ShowLoading("Загрузка...");
            await Task.Delay(1000);
            await ParticipantsModel.GetParticipants();
            UserDialogs.Instance.HideLoading();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var page = new CreateParticipantView();
            //await Navigation.PushAsync(page);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}