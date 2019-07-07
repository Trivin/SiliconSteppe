using Acr.UserDialogs;
using SiliconStepe.Classes;
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
	public partial class SettingPage : ContentPage
	{
        List<CustomListViewItem> list2 = new List<CustomListViewItem>();
        List<CustomListViewItem> list = new List<CustomListViewItem>();
        SettingsViewModel svm = new SettingsViewModel();
        public SettingPage()
        {
            InitializeComponent();
            svm.OnLoaded += Svm_OnLoaded;
            list.Add(new CustomListViewItem()
            {
                Name = "Фамилия",
                Value = CurrentProperties.CurrentUser.SecondName,
                Type = SettingType.SecondName,
                TapCommand = TapCommand
            }
            );

            list.Add(new CustomListViewItem()
            {
                Name = "Имя",
                Value = CurrentProperties.CurrentUser.FirstName,
                Type = SettingType.FirstName,
                TapCommand = TapCommand
            }
            );

            list.Add(new CustomListViewItem()
            {
                Name = "Отчество",
                Value = CurrentProperties.CurrentUser.MiddleName,
                Type = SettingType.MiddleName,
                TapCommand = TapCommand
            }
            );
            this.BindingContext = list;
        }

        private void Svm_OnLoaded(string value, SettingType type)
        {
            switch (type)
            {
                case SettingType.SecondName:
                    list[0].Value = value;
                    CurrentProperties.CurrentUser.SecondName = value;
                    break;
                case SettingType.FirstName:
                    list[1].Value = value;
                    CurrentProperties.CurrentUser.FirstName = value;
                    break;
                case SettingType.MiddleName:
                    list[2].Value = value;
                    CurrentProperties.CurrentUser.MiddleName = value;
                    break;
            }
        }

        public Command TapCommand
        {
            get => new Command((obj) =>
            {
                switch ((obj as CustomListViewItem).Type)
                {
                    case SettingType.SecondName:
                        UserDialogs.Instance.Prompt(new PromptConfig()
                        {
                            InputType = InputType.Phone,
                            Placeholder = "Фамилия",
                            Message = "Введите вашу фамилию:",
                            IsCancellable = false,
                            OkText = "Принять",
                            Title = "Ввод фамилии",
                            Text = list[0].Value,
                            OnAction = new Action<PromptResult>(async (res) =>
                            {
                                await Task.Delay(400);

                                UserDialogs.Instance.ShowLoading("Загрузка...");
                                await svm.SetSetting(res.Text, SettingType.SecondName);
                                UserDialogs.Instance.HideLoading();
                            }),
                        });
                        break;
                    case SettingType.FirstName:
                        UserDialogs.Instance.Prompt(new PromptConfig()
                        {
                            InputType = InputType.Email,
                            Placeholder = "Имя",
                            Message = "Введите ваше имя:",
                            IsCancellable = false,
                            OkText = "Принять",
                            Title = "Ввод имени",
                            Text = list[1].Value,
                            OnAction = new Action<PromptResult>(async (res) =>
                            {
                                await Task.Delay(400);

                                UserDialogs.Instance.ShowLoading("Загрузка...");
                                await svm.SetSetting(res.Text, SettingType.FirstName);
                                UserDialogs.Instance.HideLoading();
                            }),
                        });
                        break;
                    case SettingType.MiddleName:
                        UserDialogs.Instance.Prompt(new PromptConfig()
                        {
                            InputType = InputType.Email,
                            Placeholder = "Отчество",
                            Message = "Введите ваше отчество:",
                            IsCancellable = false,
                            OkText = "Принять",
                            Title = "Ввод отчества",
                            Text = list[2].Value,
                            OnAction = new Action<PromptResult>(async (res) =>
                            {
                                await Task.Delay(400);

                                UserDialogs.Instance.ShowLoading("Загрузка...");
                                await svm.SetSetting(res.Text, SettingType.MiddleName);
                                UserDialogs.Instance.HideLoading();
                            }),
                        });
                        break;
                    default: return;
                }
            });
        }


        public enum SettingType
        {
            SecondName,
            FirstName,
            MiddleName,
            Login,
            Password,
            Description,
            Empty
        }
    }
}