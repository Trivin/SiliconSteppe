using SiliconStepe.Models;
using SiliconStepe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SiliconStepe.Views
{
    public partial class MainPage : ContentPage
    {
        LoginViewModel viewModel;
        public MainPage()
        {
            viewModel = new LoginViewModel();
            viewModel.OnLoaded += ViewModel_OnLoaded; ;
            InitializeComponent();
            MainScrollView.InputTransparent = false;
            this.BindingContext = viewModel;
            RegLabel.BindingContext = this;
        }

        private void ViewModel_OnLoaded(object sender)
        {
            var us = new Models.User()
            {
                SecondName = "Иванов",
                FirstName = "Иван",
                MiddleName = "Иванович",
                Login = "ivan",
                Password = "ivan",
                Rate = new List<Rate>()
                        {
                            new Rate()
                            {
                                Score = 5
                            },
                            new Rate()
                            {
                                Score = 5
                            },
                            new Rate()
                            {
                                Score = 2
                            },
                            new Rate()
                            {
                                Score = 1
                            },
                            new Rate()
                            {
                                Score = 3
                            },
                            new Rate()
                            {
                                Score = 5
                            },
                            new Rate()
                            {
                                Score = 1
                            },
                            new Rate()
                            {
                                Score = 1
                            },
                        },
                Organization = new Organization()
                {
                    Name = "ООО \"Заря\"",
                },
                Type = viewModel.User.Login[0] == '1' ? 1 : 0,
            };
            CurrentProperties.CurrentUser = us;
            if (us.Type == 1)
            {
                Navigation.PushModalAsync(new EmployeesDetailPage());
            }
            else
            {
                Navigation.PushModalAsync(new WorkerDetailPage());
            }
        }

        public ICommand TapCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await DisplayAlert("Внимание", "Тест", "Ок");
                }
                );
            }
        }
    }
    public static class DoubleResources
    {
        public static readonly Thickness ButtonGroupPadding = new Thickness(0, Device.OnPlatform(12, 0, 0), 0, 0);
        public static readonly double SignUpButtonHeight = Device.OnPlatform(40, 40, 80);
        public static readonly double FBButtonHeight = Device.OnPlatform(135, 135, 64);
    }
}
