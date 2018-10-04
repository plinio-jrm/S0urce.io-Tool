using System;
using System.Threading;
using S0urce.io_tool.Harvesters;

namespace S0urce.io_tool.BotSystem {
   public class BlackMarketSystem: BaseSystem {
      #region constants
      private const int MIN_BTCOIN_MULT = 30;
      private const int RECHARGE_BTCOIN_MULT = 20;
      #endregion
      #region variables
      private WindowBlackMarketHarvester Harvester;
      private float BTCoinAmount;
      private float BTCoinGainAmount;
      #endregion

      public BlackMarketSystem() {
         this.Harvester = new WindowBlackMarketHarvester();
      }

      public override void Setup() {
         this.Harvester.SetReference(this.References);
      }

      public override bool Process() {
         if (!base.Process())
            return false;

         //if (!this.HaveEnoughtBTCoin())
            //return false;

         if (this.Harvester.MinerAvailable(BlackMarketMiners.QuantumServer) && this.CanBuy(BlackMarketMiners.QuantumServer)) {
            this.Harvester.ButtonClick(BlackMarketMiners.QuantumServer);
         } else if (this.Harvester.MinerAvailable(BlackMarketMiners.BotNet) && this.CanBuy(BlackMarketMiners.BotNet)) {
            this.Harvester.ButtonClick(BlackMarketMiners.BotNet);
         } else if (this.Harvester.MinerAvailable(BlackMarketMiners.DataCenter) && this.CanBuy(BlackMarketMiners.DataCenter)) {
            this.Harvester.ButtonClick(BlackMarketMiners.DataCenter);
         } else if (this.Harvester.MinerAvailable(BlackMarketMiners.MiningDrill) && this.CanBuy(BlackMarketMiners.MiningDrill)) {
            this.Harvester.ButtonClick(BlackMarketMiners.MiningDrill);
         } else if (this.Harvester.MinerAvailable(BlackMarketMiners.AdvancedMiner) && this.CanBuy(BlackMarketMiners.AdvancedMiner)) {
            this.Harvester.ButtonClick(BlackMarketMiners.AdvancedMiner);
         } else if (this.Harvester.MinerAvailable(BlackMarketMiners.BasicMiner) && this.CanBuy(BlackMarketMiners.BasicMiner))
            this.Harvester.ButtonClick(BlackMarketMiners.BasicMiner);

         Thread.Sleep(300);
         return true;
      }
      #region methods
      public void SetBTCoin(float amount) {
         this.BTCoinAmount = amount;
      }

      public void SetBTCoinGain(float amount) {
         this.BTCoinGainAmount = amount;
      }

      private bool CanBuy(BlackMarketMiners option) {
         float cost = this.Harvester.GetCost(option);
         return ((this.BTCoinAmount - cost) > this.GetRechargeBTCoinNeed());
      }

      private bool HaveEnoughtBTCoin() {
         return ((this.BTCoinAmount - this.GetRechargeBTCoinNeed()) > (this.BTCoinGainAmount * MIN_BTCOIN_MULT));
      }

      private float GetRechargeBTCoinNeed() {
         return (this.BTCoinGainAmount * RECHARGE_BTCOIN_MULT * 2);
      }
      #endregion
   }
}
