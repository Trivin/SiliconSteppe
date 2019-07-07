using SiliconStepe.Classes;
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
	public partial class QuestionsView : ContentPage
	{
        public ObservableCollection<Question> Questions = new ObservableCollection<Question>()
        {
            new Question()
            {
                Text = "Соблюдаются ли на объекте защиты проектные решения по наличию системы обеспечения пожарной безопасности?",
            },

            new Question()
            {
                Text = "Соблюдаются ли на объекте защиты проектные решения по противопожарным расстояниям между зданиями и сооружениями?",
            },
            new Question()
            {
                Text = "Соблюдаются ли на объекте защиты проектные решения по наружному противопожарному водоснабжению?",
            },
            new Question()
            {
                Text = "Соблюдаются ли на объекте защиты проектные решения по проездам и подъездам для пожарной техники?",
            },
            new Question()
            {
                Text = "Соблюдаются ли на объекте защиты проектные решения по обеспечению безопасности пожарно-спасательных подразделений при ликвидации пожара?",
            },
        };

        public QuestionsView()
		{
			InitializeComponent();
            MainListView.ItemsSource = Questions;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (Questions.Any(x => !x.Answer))
            {
                await DisplayAlert("Внимание!", "Рекомендуется обратиться к специалисту!", "Принять");
                await Navigation.PushAsync((new EmployeesPage() { Title = "Исполнители"}));
            }
        }

        private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}