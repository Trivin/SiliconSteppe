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
	public partial class EmployeeView : ContentPage
	{
		public EmployeeView (User user)
		{
			InitializeComponent();
            BindingContext = user;
		}

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}