using System;
using System.Collections.Generic;
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

            //Print out each question one by one, followed by their answers, then the correct answer.
            DisplayQuestions(result.results);

            Console.ReadKey();
        }
        
        static void DisplayQuestions(List<Result> questions)
        {
            foreach (Result q in questions)
            {
                Console.WriteLine("Question:");
                Console.WriteLine(q.QuestionText);
                Console.WriteLine("Incorrect Answers:");
                foreach (string incorrect in q.IncorrectAnswers)
                {
                    Console.WriteLine(incorrect);
                }
                Console.WriteLine("Correct Answer:");
                Console.WriteLine($"{q.CorrectAnswer}\n");
            }
        }
    }
}
