using Data_Parser;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DB_Interface
{
    public class Db
    {
        private static HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Creates the Db object that manages the connection to the database.
        /// Connection persists through the lifetime of the Db object, hence
        /// static _httpClient member
        /// </summary>
        /// <param name="uri">ip address of database</param>
        /// <param name="dbName">database name</param>
        /// <param name="uName">user name</param>
        /// <param name="passwd">user password</param>
        public Db(string uri, string dbName, string uName, string passwd)
        {
            _httpClient.BaseAddress = new Uri(uri + "/" + dbName);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                        ASCIIEncoding.ASCII.GetBytes(
                           $"{uName}:{passwd}")));
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Retrieves a view from the database based on design document and view name.  
        /// If view does not exist or anything else goes wrong, throws a general exception
        /// </summary>
        /// <param name="designName">name of _design doc that contains targeted view</param>
        /// <param name="viewName">name of view</param>
        public async Task<string> GetDocsByView(string designName, string viewName)
        {
            try
            {
                var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/_design/" + designName + "/_view/" + viewName).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return content;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }

        /// <summary>
        /// Add a document to the database
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>bool</returns>
        public async Task<bool> AddDoc(DataClass doc)
        {
            // convert object to Json string
            var json = JsonConvert.SerializeObject(doc);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_httpClient.BaseAddress, content);
            try
            {
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

    }
}
