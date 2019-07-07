using SiliconStepe.API;
using SiliconStepe.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static SiliconStepe.App;
using static SiliconStepe.Views.SettingPage;

namespace SiliconStepe.ViewModels
{
    public class SettingsViewModel
    {
        bool Error = false;
        public delegate void OnDataLoaded(string value, SettingType type);
        public event OnDataLoaded OnLoaded;
        public async Task SetSetting(string newValue, SettingType type)
        {
            try
            {
                Error = (await SettingApi.SetSetting(CurrentProperties.CurrentUser.Token, newValue, type));
            }
            catch (CustomException exc)
            {
                OnLoaded(newValue, type);
                DependencyService.Get<IMessage>().ShortAlert(exc.Message);
                return;
            }
            catch
            {
                Error = true;
                //Error = null;
            }
            if (Error)
            {
                OnLoaded(newValue, type);
                DependencyService.Get<IMessage>().LongAlert("Произошла ошибка!");
                return;
            }
            OnLoaded(newValue, type);
            return;
        }
    }
}
