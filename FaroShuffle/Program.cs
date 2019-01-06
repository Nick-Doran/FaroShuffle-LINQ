using System;
using System.Collections.Generic;
using System.Linq;

namespace FaroShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            var startingDeck =
                from s in Suits()
                from r in Ranks()
                select new { Suit = s, Rank = r };

            foreach ( var card in startingDeck)
            {
                Console.WriteLine(card);
            }
            Console.ReadKey();

            var top = startingDeck.Take(26);
            var bottom = startingDeck.Skip(26);
            var shuffle= top.InterleaveSequenceWith(bottom);
            foreach (var card in shuffle)
            {
                Console.WriteLine(card);
            }
            Console.ReadKey();

            int i = 0;
            while(!startingDeck.Equalss(shuffle))
            {
                i++;
                top = shuffle.Take(26);
                bottom = shuffle.Skip(26);
                shuffle = top.InterleaveSequenceWith(bottom);
            }
            Console.WriteLine(i);
            Console.ReadLine();

        }
        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }
        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }
    }
}
