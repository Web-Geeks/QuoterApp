using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace QuoterApp
{
    class Program
    {
       

        static void Main(string[] args)
        {
            
            var gq = new YourQuoter(new HardcodedMarketOrderSource());
            var qty = 14;

            var quote = gq.GetQuote("AB73567490", qty);
            var vwap = gq.GetVolumeWeightedAveragePrice("AB73567490");
            
            gq.Next();

            Console.WriteLine($"Quote: {quote}, {quote / (double)qty}");
            Console.WriteLine($"Average Price: {vwap}");
            Console.WriteLine();
            Console.WriteLine($"Done");
        }

       
    }
}
