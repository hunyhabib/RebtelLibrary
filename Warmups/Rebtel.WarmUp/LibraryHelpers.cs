namespace Rebtel.WarmUp
{
    public static class LibraryHelpers
    {
        /// <summary>
        /// Determines whether [is power of two] [the specified number].
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if [is pow of two] [the specified number]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPowOfTwo(int number) =>
            (number > 0) && (number & (number - 1)) == 0;

        /// <summary>
        /// Reverses the string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Book Title Cannot Be Empty</exception>
        public static string ReverseBookTitle(string bookTitle)
        {
            if (string.IsNullOrEmpty(bookTitle))
            {
                throw new ArgumentException("Book Title Cannot Be Empty");
            }
            return string.IsNullOrEmpty(bookTitle) ? bookTitle : string.Concat(bookTitle.Reverse());
        }


        /// <summary>
        /// Replicates the string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Count must be greater than zero</exception>
        public static string ReplicateString(string input, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count must be greater than zero");
            }
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be empty");
            }
            return string.Concat(Enumerable.Repeat(input, count));
        }

        /// <summary>
        /// Gets the odd numbers between 0 and 100.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> GetOddNumbers()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i % 2 != 0)
                {
                    yield return i;
                }
            }
        }
    }
}
