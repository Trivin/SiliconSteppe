using Newtonsoft.Json;
using SiliconStepe.Classes;
using SiliconStepe.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static SiliconStepe.Views.SettingPage;

namespace SiliconStepe.API
{
    public class SettingApi
    {
        public static async Task<bool> SetSetting(string token, string newValue, SettingType type)
        {
            bool success = false;
            HttpClient client = new HttpClient();
            string path = "";
            Dictionary<string, string> param;
            switch (type)
            {
                case SettingType.SecondName:
                    param = new Dictionary<string, string>() { { "secondname", newValue } };
                    break;
                case SettingType.FirstName:
                    param = new Dictionary<string, string>() { { "firstname", newValue } };
                    break;
                case SettingType.MiddleName:
                    param = new Dictionary<string, string>() { { "middlename", newValue } };
                    break;
                default:
                    throw new CustomException("Введено неверное значение!");
            }
            var response = await client.GetAsync(path);
            string json = await response.Content.ReadAsStringAsync();
            success = response.IsSuccessStatusCode;
            var result = JsonConvert.DeserializeObject<ResultQueryInfo>(json);
            if (result.HasError)
                throw new CustomException(result.Messages);
            client.Dispose();
            response.Dispose();
            return false;
        }
    }
}
