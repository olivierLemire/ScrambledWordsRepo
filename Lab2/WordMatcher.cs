using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class WordMatcher
    {

        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach(string scrambledWord in scrambledWords)
            {
                foreach(string word in wordList)
                {
                    if(scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord,word));
                    }
                    else
                    {
                        char[] wordChars = word.ToCharArray();
                        char[] scrambledChars = scrambledWord.ToCharArray();

                        Array.Sort(wordChars);
                        Array.Sort(scrambledChars);

                        string sortedWord = new string(wordChars);
                        string sortedScrambled = new string(scrambledChars);

                        if(string.Compare(sortedWord,sortedScrambled) == 0)
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }

                    }
                }
            }
            return matchedWords;
        }

        MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };
            return matchedWord;
        }
    }
}
