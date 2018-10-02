using S0urce.io_tool.BotControllers;
using S0urce.io_tool.Harvesters;

namespace S0urce.io_tool.BotSystem {
   public class DataMinerSystem: BaseSystem {
      #region varaibles
      private float currentBTCoin;
      private WindowMinerHarvester Harvester;
      #endregion
      #region events
      public event BTCoinChangeEvent OnBTCoinChange;
      public event BTCoinChangeEvent OnBTCoinGainChange;
      #endregion
      #region methods
      public DataMinerSystem() {
         this.Harvester = new WindowMinerHarvester();
      }

      public override void Setup() {
         this.Harvester.SetReference(this.References);
      }

      public override bool Process() {
         if (!base.Process())
            return false;

         float BTCoin = this.Harvester.GetBTCoin();
         if (BTCoin >= 0) {
            this.currentBTCoin = BTCoin;
            if (this.OnBTCoinChange != null)
               OnBTCoinChange(this.currentBTCoin);
         }

         float BTCoinGain = this.Harvester.GetBTCoinGain();
         if (BTCoinGain >= 0) {
            if (this.OnBTCoinGainChange != null)
               OnBTCoinGainChange(BTCoinGain);
         }

         return true;
      }
      #endregion
   }
}
