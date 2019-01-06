﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FaroShuffle
{
    public static class Extensions
    {
        public static IEnumerable<T> InterleaveSequenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                yield return firstIter.Current;
                yield return secondIter.Current;
            }
        }

        public static bool Equalss<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while(firstIter.MoveNext() && secondIter.MoveNext())
            {
                if(!firstIter.Current.Equals(secondIter.Current))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
