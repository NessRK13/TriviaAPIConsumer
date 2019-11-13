using System;
using System.Threading.Tasks;

namespace TriviaAPIConsumer
{
    class Program
    {
        static async Task Main()
        {
            TriviaClient trivia = new TriviaClient();
            TriviaResponse result = await trivia.GetTriviaQuestionsAsync(3);

            Console.WriteLine("Received trivia questions.\n\n");

            Console.WriteLine(result.results[0].question);

            Console.ReadKey();
        }
    }
}
