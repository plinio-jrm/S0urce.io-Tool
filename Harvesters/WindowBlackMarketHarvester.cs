namespace S0urce.io_tool.Harvesters {
   public enum BlackMarketMiners {
      BasicMiner,
      AdvancedMiner,
      MiningDrill,
      DataCenter,
      BotNet,
      QuantumServer
   }

   public class WindowBlackMarketHarvester: BaseHarvester {
      public void ButtonClick(BlackMarketMiners miner) {
         switch (miner) {
            case BlackMarketMiners.BasicMiner:
               this.References.WindowBlackMarketRef.BasicMinerButton.InvokeMember("click");
               break;
            case BlackMarketMiners.AdvancedMiner:
               this.References.WindowBlackMarketRef.AdvancedMinerButton.InvokeMember("click");
               break;
            case BlackMarketMiners.MiningDrill:
               this.References.WindowBlackMarketRef.MiningDrillButton.InvokeMember("click");
               break;
            case BlackMarketMiners.DataCenter:
               this.References.WindowBlackMarketRef.DataCenterButton.InvokeMember("click");
               break;
            case BlackMarketMiners.BotNet:
               this.References.WindowBlackMarketRef.BotNetButton.InvokeMember("click");
               break;
            case BlackMarketMiners.QuantumServer:
               this.References.WindowBlackMarketRef.QuantumServerButton.InvokeMember("click");
               break;
         }
      }

      public bool MinerAvailable(BlackMarketMiners miner) {
         switch (miner) {
            case BlackMarketMiners.BasicMiner:
               if (this.References.WindowBlackMarketRef.BasicMinerButton.Style != null)
                  return (this.References.WindowBlackMarketRef.BasicMinerButton.Style.Contains("1"));
               break;
            case BlackMarketMiners.AdvancedMiner:
               if (this.References.WindowBlackMarketRef.AdvancedMinerButton.Style != null)
                  return (this.References.WindowBlackMarketRef.AdvancedMinerButton.Style.Contains("1"));
               break;
            case BlackMarketMiners.MiningDrill:
               if (this.References.WindowBlackMarketRef.MiningDrillButton.Style != null)
                  return (this.References.WindowBlackMarketRef.MiningDrillButton.Style.Contains("1"));
               break;
            case BlackMarketMiners.DataCenter:
               if (this.References.WindowBlackMarketRef.DataCenterButton.Style != null)
                  return (this.References.WindowBlackMarketRef.DataCenterButton.Style.Contains("1"));
               break;
            case BlackMarketMiners.BotNet:
               if (this.References.WindowBlackMarketRef.BotNetButton.Style != null)
                  return (this.References.WindowBlackMarketRef.BotNetButton.Style.Contains("1"));
               break;
            case BlackMarketMiners.QuantumServer:
               if (this.References.WindowBlackMarketRef.QuantumServerButton.Style != null)
                  return (this.References.WindowBlackMarketRef.QuantumServerButton.Style.Contains("1"));
               break;
         }
         return false;
      }

      public float GetCost(BlackMarketMiners miner) {
         string sCost = string.Empty;
         switch (miner) {
            case BlackMarketMiners.BasicMiner:
               sCost = this.References.WindowBlackMarketRef.BasicMinerButtonCost.InnerText;
               break;
            case BlackMarketMiners.AdvancedMiner:
               sCost = this.References.WindowBlackMarketRef.AdvancedMinerButtonCost.InnerText;
               break;
            case BlackMarketMiners.MiningDrill:
               sCost = this.References.WindowBlackMarketRef.MiningDrillButtonCost.InnerText;
               break;
            case BlackMarketMiners.DataCenter:
               sCost = this.References.WindowBlackMarketRef.DataCenterButtonCost.InnerText;
               break;
            case BlackMarketMiners.BotNet:
               sCost = this.References.WindowBlackMarketRef.BotNetButtonCost.InnerText;
               break;
            case BlackMarketMiners.QuantumServer:
               sCost = this.References.WindowBlackMarketRef.QuantumServerButtonCost.InnerText;
               break;
         }

         try {
            return float.Parse(sCost.Replace('.', ','));
         } catch {
            return -1;
         }
      }
   }
}
