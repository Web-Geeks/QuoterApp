using System;

namespace QuoterApp
{
    public class YourQuoter : IQuoter
    {
        private readonly IMarketOrderSource _marketOrderSource;


        public YourQuoter(IMarketOrderSource marketOrderSource)
        {
            _marketOrderSource = marketOrderSource;
           
        }

       public double GetQuote(string instrumentId, int quantity)
        {
            return _marketOrderSource.MarketOrderGetQuote(instrumentId, quantity);
        }


      public double GetVolumeWeightedAveragePrice(string instrumentId)
        {
            return _marketOrderSource.GetVolumeWeightedAveragePrice(instrumentId); ;
        }

      public void Next()
      {
          _marketOrderSource.GetNextMarketOrder();
      }
    }
}
