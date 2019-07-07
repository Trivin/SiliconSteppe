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
    public static class InvitesApi
    {
        public static async Task<List<Invite>> GetActiveInvites(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            var response = await client.GetAsync($"{API.GetActiveInvitesPath}");
            string json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LInvites>(json);
            if (result.HasError)
                throw new CustomException(result.Messages);
            client.Dispose();
            response.Dispose();
            return result.Invites;
        }

        public static async Task<List<Invite>> GetArchiveInvites(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            var response = await client.GetAsync($"{API.GetArchiveInvitesPath}");
            string json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LInvites>(json);
            if (result.HasError)
                throw new CustomException(result.Messages);
            client.Dispose();
            response.Dispose();
            return result.Invites;
        }

        class LInvites : ResultQueryInfo
        {
            public List<Invite> Invites { get; set; }
        }
    }
}
