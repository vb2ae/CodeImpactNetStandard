using CodeImpact2017Demo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeImpact2017Demo.Services
{
    public class FeedReader
    {
        private HttpClient _client;

        private HttpClient client
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient();
                }

                return _client;
            }
        }


        public async Task<List<Feed>> GetFeed(string url, string fileName)
        {
            var file = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication();
            List<Feed> posts = new List<Feed>();
            string json = "";
            try
            {
                json = await client.GetStringAsync(url);
                var jsonFile = file.OpenFile(fileName, FileMode.Create);
                var streamWriter = new StreamWriter(jsonFile);
                await streamWriter.WriteAsync(json);
                await streamWriter.FlushAsync();
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                if (file != null)
                {
                    if (file.FileExists(fileName))
                    {
                        var jsonFile = file.OpenFile(fileName, System.IO.FileMode.Open);
                        var streamReader = new StreamReader(jsonFile);
                        json = await streamReader.ReadToEndAsync();
                    }
                }
            }
            posts = JsonConvert.DeserializeObject<List<Feed>>(json);
            return posts;
        }

    }
}

