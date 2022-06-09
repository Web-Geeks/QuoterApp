using System.Collections.Generic;

namespace QuoterApp
{
    /// <summary>
    /// Interface to access market orders
    /// </summary>
    public interface IMarketOrderSource
    {
        /// <summary>
        /// Blocking method that will return next available market order.
        /// </summary>
        /// <returns>Market order containing InstrumentId, Price and Quantity</returns>
        public MarketOrder GetNextMarketOrder();

        public double MarketOrderGetQuote(string id, int qty);
        public double GetVolumeWeightedAveragePrice(string id);
    }
}
