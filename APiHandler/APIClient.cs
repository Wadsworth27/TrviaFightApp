using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APiHandler
{
    
    public class APIClient
    {
        public static HttpClient apiclient { get; set; }= new HttpClient();
        public static void initializeClient()
        {
            apiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public static async Task<QuestionResultsModel> GetQuestionsAsync(string url)
        {
            QuestionResultsModel results; 
            HttpResponseMessage response = await apiclient.GetAsync(url);
            results = await response.Content.ReadAsAsync<QuestionResultsModel>() ;
            return results;

        }
        public static async Task<String> GetQuoteAsync(string url)
        {
            HttpResponseMessage response = await apiclient.GetAsync(url);
            KanyeModel results = await response.Content.ReadAsAsync<KanyeModel>();
            return results.Quote;

        }


    }
}
