using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            byte selector = 0;
            bool selected = false;

            Random random = new Random();
            string wordToGuess = words[random.Next(words.Length)];


            do
            {
                DifficultySelector();
            } while (!selected);

            #region Game-Loop
            Console.ResetColor(); // Enélkül a "Szakértő" mód piros lenne, nem tudom miért
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
                    if (!wordToGuess.Contains(guessedLetter.ToLower()))
                    {
                        remainingLives -= 1;

                        if (remainingLives == 0)
                        {
                            Console.WriteLine("Kifogytál az életekből, vége a játéknak!");
                        }
                    }
                }
            } while (remainingLives > 0);
            #endregion

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

            void DifficultySelector()
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Kérem válasszon nehézséget: ");

                if (selector == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("Baba (10 élet)");

                if (selector == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("Normál (5 élet)");

                if (selector == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("Szakértő (3 élet)");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        selected = true;
                        break;
                    case ConsoleKey.UpArrow:
                        if (selector > 0)
                        {
                            selector -= 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selector < 2)
                        {
                            selector += 1;
                        }
                        break;
                }

                switch (selector)
                {
                    case 0:
                        remainingLives = 10;
                        break;
                    case 1:
                        remainingLives = 5;
                        break;
                    case 2:
                        remainingLives = 3;
                        break;
                }
            }
        }
    }
}