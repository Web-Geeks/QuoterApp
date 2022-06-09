using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace QuoterApp
{
    public class HardcodedMarketOrderSource : IMarketOrderSource
    {
        private readonly MarketOrder[] _quotes = new MarketOrder[]
        {
            new MarketOrder { InstrumentId = "BA79603015", Price = 102.997, Quantity = 12 },
            new MarketOrder { InstrumentId = "BA79603015", Price = 103.2, Quantity = 60 },
            new MarketOrder { InstrumentId = "AB73567490", Price = 103.25, Quantity = 79 },
            new MarketOrder { InstrumentId = "AB73567490", Price = 95.5, Quantity = 14 },
            new MarketOrder { InstrumentId = "BA79603015", Price = 98.0, Quantity = 1 },
            new MarketOrder { InstrumentId = "AB73567490", Price = 100.7, Quantity = 17 },
            new MarketOrder { InstrumentId = "DK50782120", Price = 100.001, Quantity = 900 },
            new MarketOrder { InstrumentId = "DK50782120", Price = 99.81, Quantity = 421 },
        };

        private int position = 0;

        public MarketOrder GetNextMarketOrder()
        {
            if (_quotes.Length <= position)
            {
                // No more quotes to give
                Thread.Sleep(Timeout.Infinite);
            }

            Thread.Sleep(500); // Simulates delay in getting next quote
            return _quotes[position++];
        }

        public double MarketOrderGetQuote(string id, int qty)
        {
            var quotes = _quotes.Where(x => x.InstrumentId == id && x.Quantity == qty).Select(x => x.Price);
            foreach (var quote in quotes)
            {
               return quote;
            }

            return 0;
        }

        public double GetVolumeWeightedAveragePrice(string id)
        {
            var averagePrice = _quotes.Where(x => x.InstrumentId == id).Select(x => x.Price);
           return averagePrice.Average();
        }
    }
}
