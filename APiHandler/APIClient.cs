using System.Net.Http.Headers;

namespace APiHandler
{

    public class APIClient
    {
        public static HttpClient apiclient { get; set; } = new HttpClient();
        public static void initializeClient()
        {
            apiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public static async Task<QuestionResultsModel> GetQuestionsAsync(string url)
        {
            QuestionResultsModel results;
            HttpResponseMessage response = await apiclient.GetAsync(url);
            results = await response.Content.ReadAsAsync<QuestionResultsModel>();
            return results;

        }


    }
}
