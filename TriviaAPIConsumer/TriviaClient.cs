using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TriviaAPIConsumer
{
    //Trivia API: https://opentdb.com/api_config.php
    public class TriviaClient
    {
        static readonly HttpClient client = new HttpClient();

        // Static constructor; Runs once per class
        static TriviaClient()
        {
            // Initialize all HttpClient settings
        }

        public async Task<string> GetTriviaQuestionsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("https://opentdb.com/api.php?amount=5");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return data;
            }
            else
            {
                // if not successful, null is returned
                return null;
            }
        }
    }

    public class Result
    {
        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }

    public class TriviaResponse
    {
        public int response_code { get; set; }

        public List<Result> results { get; set; }
    }
}
