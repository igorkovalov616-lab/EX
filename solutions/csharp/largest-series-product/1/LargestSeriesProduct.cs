public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (digits == null) throw new ArgumentNullException(nameof(digits));
        if (span < 0) throw new ArgumentException("Span must not be negative.", nameof(span));
        if (span > digits.Length) throw new ArgumentException("Span must be smaller than string length.", nameof(span));

        // span = 0 => порожній добуток = 1
        if (span == 0) return 1;

        foreach (char c in digits)
        {
            if (c < '0' || c > '9')
                throw new ArgumentException("Digits input must only contain digits.", nameof(digits));
        }

        long max = 0;

        for (int i = 0; i <= digits.Length - span; i++)
        {
            long product = 1;

            for (int j = 0; j < span; j++)
            {
                product *= (digits[i + j] - '0');
            }

            if (product > max)
                max = product;
        }

        return max;
    }
}