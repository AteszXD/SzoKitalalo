using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzoKitalalo
{
    internal class Program
    {
        static string wordState = "";
        static void Main(string[] args)
        {
            Console.Title = "Szókitaláló";

            List<string> guessedLetters = new List<string>();
            string[] words = { "első", "alma", "kukac", "vizibicikli" };
            byte remainingLives = 10;
            string guessedLetter = "";

            Random random = new Random();
            string wordToGuess = words[random.Next(words.Length)];

            do
            {
                wordState = showCurrentProgress();

                if (!wordState.Contains("_"))
                {
                    Console.WriteLine("Gratulálok! Kitaláltad a szót!");
                    break;
                }

                Console.Write($"{remainingLives} életed van még...");
                Console.Write("\nKérem tippeljen betűt: ");
                guessedLetter = Console.ReadLine();

                if (guessedLetters.Contains(guessedLetter))
                {
                    Console.WriteLine("Ezt a betűt már tippelted");
                }
                else
                {
                    guessedLetters.Add(guessedLetter.ToLower());
                    if (!wordToGuess.Contains(guessedLetter))
                    {
                        remainingLives -= 1;

                        if (remainingLives == 0)
                        {
                            Console.WriteLine("Kifogytál az életekből, vége a játéknak!");
                        }
                    }
                }
            } while (remainingLives > 0);

        string showCurrentProgress()
            {
                string wordState = "";
                foreach (char letter in wordToGuess)
                {
                    if (guessedLetters.Contains(Convert.ToString(letter)))
                    {
                        wordState += letter;
                    }
                    else
                    {
                        wordState += '_';
                    }
                }
                Console.Clear();
                Console.WriteLine(wordState);
                return wordState;
            }
        }
    }
}