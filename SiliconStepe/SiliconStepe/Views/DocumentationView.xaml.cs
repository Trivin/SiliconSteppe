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
	public partial class DocumentationView : ContentPage
    {
        ObservableCollection<Doc> Docs = new ObservableCollection<Doc>();
        public DocumentationView(ObservableCollection<Doc> Docs)
		{
			InitializeComponent();
            this.Docs = Docs;
            MainListView.ItemsSource = this.Docs;
		}

        private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Device.OpenUri((MainListView.SelectedItem as Doc).Uri);
            MainListView.SelectedItem = null;
        }
    }
}