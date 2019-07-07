using Newtonsoft.Json;
using SiliconStepe.Classes;
using SiliconStepe.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SiliconStepe.API
{
    public static class UserApi
    {
        public static async Task<User> TryLoginAsync(string login, string password)
        {
            bool success = false;
            HttpClient client = new HttpClient();
            User us = new User()
            {
                Login = login,
                Password = password
            };
            var param = new Dictionary<string, string>() { { "Login", login }, { "Password", password } };
            var encodedContent = new FormUrlEncodedContent(param);
            var response = await client.PostAsync(API.AuthPath, encodedContent);
            string json = await response.Content.ReadAsStringAsync();
            success = response.IsSuccessStatusCode;
            var result = JsonConvert.DeserializeObject<LUser>(json);
            if (result.HasError)
                throw new CustomException(result.Messages);
            client.Dispose();
            response.Dispose();
            return result.User;
        }
        class LUser : ResultQueryInfo
        {
            public User User { get; set; }
        }
    }
}
