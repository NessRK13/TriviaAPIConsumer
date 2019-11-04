using System;
using System.Threading.Tasks;

namespace TriviaAPIConsumer
{
    class Program
    {
        static async Task Main()
        {
            TriviaClient trivia = new TriviaClient();
            string result = await trivia.GetTriviaQuestionsAsync();

            Console.WriteLine("Received trivia questions.\n\n");

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
