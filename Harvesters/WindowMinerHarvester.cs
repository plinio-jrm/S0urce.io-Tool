namespace S0urce.io_tool.Harvesters {
   public class WindowMinerHarvester: BaseHarvester {
      public float GetBTCoin() {
         string sBTCoin = this.References.WindowMinerRef.WindowMinerBTCoin.InnerText;
         try {
            return float.Parse(sBTCoin.Replace('.', ','));
         } catch {
            return -1;
         }
      }

      public float GetBTCoinGain() {
         string sBTCoin = this.References.WindowMinerRef.WindowMinerBTCoinGain.InnerText;
         try {
            return float.Parse(sBTCoin.Replace('.', ','));
         } catch {
            return -1;
         }
      }
   }
}
