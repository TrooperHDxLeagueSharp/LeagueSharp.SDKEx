#region License and Terms

// MoreLINQ - Extensions to LINQ to Objects
// Copyright (c) 2008 Jonathan Skeet. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

namespace LeagueSharp.SDKEx.MoreLinq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    static partial class MoreEnumerable
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Returns every N-th element of a source sequence.
        /// </summary>
        /// <typeparam name="TSource">Type of the source sequence</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="step">Number of elements to bypass before returning the next element.</param>
        /// <remarks>
        ///     This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        ///     <code>
        /// int[] numbers = { 1, 2, 3, 4, 5 };
        /// IEnumerable&lt;int&gt; result = numbers.TakeEvery(2);
        /// </code>
        ///     The <c>result</c> variable, when iterated over, will yield 1, 3 and 5, in turn.
        /// </example>
        public static IEnumerable<TSource> TakeEvery<TSource>(this IEnumerable<TSource> source, int step)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (step <= 0)
            {
                throw new ArgumentOutOfRangeException("step");
            }
            return source.Where((e, i) => i % step == 0);
        }

        #endregion
    }
}