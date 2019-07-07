using Acr.UserDialogs;
using SiliconStepe.API;
using SiliconStepe.Classes;
using SiliconStepe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static SiliconStepe.App;

namespace SiliconStepe.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public delegate void OnDataLoaded(object sender);
        public event OnDataLoaded OnLoaded;
        private User user = new User() { Login = "yar.your@mail.ru", Password = ".hfirf99" };
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                if (value != user)
                {
                    user = value;
                    OnPropertyChanged("User");
                }
            }
        }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    bool isException = false;
                    if (User.Login == "" || User.Password == "")
                    {
                        DependencyService.Get<IMessage>().ShortAlert("Заполнены не все поля!");
                        return;
                    }
                    try
                    {
                        UserDialogs.Instance.ShowLoading("Загрузка...");
                        CurrentProperties.CurrentUser = await UserApi.TryLoginAsync(User.Login, User.Password);
                        UserDialogs.Instance.HideLoading();
                    }
                    catch (CustomException ex)
                    {
                        UserDialogs.Instance.HideLoading();
                        DependencyService.Get<IMessage>().ShortAlert(ex.Message);
                        return;
                    }
                    catch
                    {
                        UserDialogs.Instance.HideLoading();
                        isException = true;
                        //CurrentProperties.CurrentUser = null;
                    }
                    if (isException)
                    {
                        User.Password = "";
                        DependencyService.Get<IMessage>().LongAlert("Произошла ошибка!");
                        OnLoaded(this);
                        return;
                    }
                    else
                    {
                        OnLoaded(this);
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
