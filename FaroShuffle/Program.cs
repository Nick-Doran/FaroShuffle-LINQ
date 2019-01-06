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
                (from s in Suits()
                from r in Ranks()
                select new { Suit = s, Rank = r }).ToArray();

            foreach (var card in startingDeck)
            {
                Console.WriteLine(card);
            }
            Console.ReadKey();

            //var top = startingDeck.Take(26);
            //var bottom = startingDeck.Skip(26);
            var shuffle = startingDeck.Skip(26).InterleaveSequenceWith(startingDeck.Take(26));
            foreach (var card in shuffle)
            {
                Console.WriteLine(card);
            }
            Console.ReadKey();
            var times = 0;
            // We can re-use the shuffle variable from earlier, or you can make a new one
            shuffle = startingDeck;
            do
            {
                shuffle = shuffle.Skip(26).InterleaveSequenceWith(shuffle.Take(26)).ToArray();

                foreach (var card in shuffle)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
                times++;

            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }
        //int i = 0;
        //shuffle = startingDeck;
        //shuffle = shuffle.Skip(26).InterleaveSequenceWith(shuffle.Take(26));


        //while (!startingDeck.SequenceEquals(shuffle))
        //{
        //    i++;
        //    shuffle = shuffle.Skip(26).InterleaveSequenceWith(shuffle.Take(26));
        //}
        //Console.WriteLine(i);
        //Console.ReadLine();


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
