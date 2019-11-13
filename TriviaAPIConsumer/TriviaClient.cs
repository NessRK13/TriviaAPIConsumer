﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

            //Base address must end with a forward slash
            client.BaseAddress = new Uri("https://opentdb.com/");
        }

        public async Task<TriviaResponse> GetTriviaQuestionsAsync(byte numQuestions)
        {
            HttpResponseMessage response = await client.GetAsync($"api.php?amount={numQuestions}");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                TriviaResponse result = JsonConvert.DeserializeObject<TriviaResponse>(data);
                return result;
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
