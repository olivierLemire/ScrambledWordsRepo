using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();
        private static readonly Constants constants = new Constants();
        static void Main(string[] args)
        {
            string redo = "";
            bool loop = true;
            bool askLoop = true;
            bool startLoop = true;
            do
            {
                try
                {
                    do
                    {
                        Console.WriteLine(constants.START_PROMPT);
                        string option = Console.ReadLine() ?? throw new Exception(constants.EMPTY_STRING);

                        switch (option.ToUpper())
                        {
                            case "F":
                                Console.WriteLine(constants.ASK_FILE);
                                ExecuteScrambledWordsInFileScenario();
                                startLoop = false;
                                break;

                            case "M":
                                Console.WriteLine(constants.ASK_WORDS);
                                ExecuteScrambledWordsManualEntryScenario();
                                startLoop = false;
                                break;
                            default:
                                Console.WriteLine(constants.DEFAULT_OPTION);
                                startLoop = true;
                                break;
                        }
                    } while (startLoop == true);
                    startLoop = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(constants.ERROR + e.Message);
                }


                while (askLoop == true)
                {
                    Console.WriteLine(constants.CONTINUE);
                    redo = Console.ReadLine();

                    if (redo.ToUpper() == "N")
                    {
                        loop = false;
                        askLoop = false;
                    }
                    else if (redo.ToUpper() == "Y")
                    {
                        loop = true;
                        askLoop = false;
                    }
                   
                }
                askLoop = true;
            } while (loop==true);
            }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string fileName = Console.ReadLine();
            string[] scrambledWords = fileReader.Read(fileName);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario() 
        {
            string manualScrambledWords = Console.ReadLine();
            string[] scrambledWords = manualScrambledWords.Split(',');
            DisplayMatchedScrambledWords(scrambledWords);
        }


        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(constants.FILENAME);

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords,wordList);

            if(matchedWords.Count() == 0)
            {
                Console.WriteLine(constants.NOT_MATCHED);
            }
            else
            {
                foreach( MatchedWord matchedWord in  matchedWords)
                {
                    string line = string.Format(constants.WAS_FOUND, matchedWord.ScrambledWord,matchedWord.Word);
                    Console.WriteLine(line);
                }
            }
        }
    }
}
