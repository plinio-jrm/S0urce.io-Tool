using S0urce.io_tool.BotControllers;

namespace S0urce.io_tool.BotSystem {
   public class DataMinerSystem: DefaultSystem {
      #region varaibles
      private float currentBTCoin;
      #endregion
      #region events
      public event BTCoinChangeEvent OnBTCoinChange;
      public event BTCoinChangeEvent OnBTCoinGainChange;
      #endregion
      #region methods
      public override void Process() {
         if (!this.References.IsSet())
            return;

         float BTCoin = this.References.GetBTCoin();
         if (BTCoin >= 0) {
            this.currentBTCoin = BTCoin;
            if (this.OnBTCoinChange != null)
               OnBTCoinChange(this.currentBTCoin);
         }

         float BTCoinGain = this.References.GetBTCoinGain();
         if (BTCoinGain >= 0) {
            if (this.OnBTCoinGainChange != null)
               OnBTCoinGainChange(BTCoinGain);
         }
      }
      #endregion
   }
}
