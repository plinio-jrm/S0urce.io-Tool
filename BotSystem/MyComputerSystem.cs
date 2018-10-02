using S0urce.io_tool.BotControllers;
using S0urce.io_tool.Harvesters;
using System.Threading;

namespace S0urce.io_tool.BotSystem {
   public enum FirewallPortButtons {
      Charge,
      MaxCharge,
      Difficulty,
      Regen
   }

   public class MyComputerSystem: BaseSystem {
      #region constants
      private const string DEFAULT_QUOTE = "github.com/plinio-jrm/S0urce.io-Tool";
      private const int GETINFO_DELAY = 200;
      #endregion
      #region events
      public event FirewallPortGetEvent OnPortAGetInfo;
      public event FirewallPortGetEvent OnPortBGetInfo;
      public event FirewallPortGetEvent OnPortCGetInfo;
      #endregion
      #region variables
      public bool Auto_Recharge;
      public bool Auto_Upgrade;

      private bool updateQuote;
      private float BTCoin;
      private WindowMyComputerHarvester Harvester;

      private FirewallPortInfo portAInfo;
      private FirewallPortInfo portBInfo;
      private FirewallPortInfo portCInfo;
      #endregion
      #region methods
      public MyComputerSystem() {
         this.Harvester = new WindowMyComputerHarvester();
         this.Auto_Recharge = true;
         this.Auto_Upgrade = true;
      }

      public override void Setup() {
         this.updateQuote = true;
         this.Harvester.SetReference(this.References);
      }
       
      public override bool Process() {
         if (!base.Process())
            return false;

         if (this.updateQuote) {
            this.updateQuote = false;
            this.Harvester.SetQuote(DEFAULT_QUOTE);
         }

         this.ProcessPortAInfo();
         this.ProcessPortBInfo();
         this.ProcessPortCInfo();

         return true;
      }

      private void AutoRecharge(MyComputerPorts port) {
         if (!this.Auto_Recharge)
            return;

         if (port == MyComputerPorts.PortA) {
            if (this.portAInfo.NeedRecharge())
               this.Harvester.RechargePort();
         }
         if (port == MyComputerPorts.PortB) {
            if (this.portBInfo.NeedRecharge())
               this.Harvester.RechargePort();
         }
         if (port == MyComputerPorts.PortC) {
            if (this.portCInfo.NeedRecharge())
               this.Harvester.RechargePort();
         }
      }

      private void AutoUpgrade(MyComputerPorts port) {
         if (!this.Auto_Upgrade)
            return;

         FirewallPortButtons priority = FirewallPortButtons.Charge;
         if (port == MyComputerPorts.PortA)
            priority = portAInfo.GetPriority();
         if (port == MyComputerPorts.PortB)
            priority = portBInfo.GetPriority();
         if (port == MyComputerPorts.PortC)
            priority = portCInfo.GetPriority();

         if (priority == FirewallPortButtons.Difficulty)
            this.Harvester.RaiseDifficulty();
         if (priority == FirewallPortButtons.Regen)
            this.Harvester.RaiseRegen();
         if (priority == FirewallPortButtons.MaxCharge)
            this.Harvester.RaiseMaxCharge();
      }

      private void ProcessPortAInfo() {
         if (this.OnPortAGetInfo == null)
            return;

         this.Harvester.OpenPortShop(MyComputerPorts.PortA);
         Thread.Sleep(GETINFO_DELAY);
         portAInfo = this.Harvester.GetPortInfo();

         this.AutoRecharge(MyComputerPorts.PortA);
         this.AutoUpgrade(MyComputerPorts.PortA);
         this.OnPortAGetInfo(portAInfo);
         this.Harvester.CloseShop();
      }

      private void ProcessPortBInfo() {
         if (this.OnPortBGetInfo == null)
            return;
         
         this.Harvester.OpenPortShop(MyComputerPorts.PortB);
         Thread.Sleep(GETINFO_DELAY);
         portBInfo = this.Harvester.GetPortInfo();

         this.AutoRecharge(MyComputerPorts.PortB);
         this.AutoUpgrade(MyComputerPorts.PortB);
         this.OnPortBGetInfo(portBInfo);
         this.Harvester.CloseShop();
      }

      private void ProcessPortCInfo() {
         if (this.OnPortBGetInfo == null)
            return;

         this.Harvester.OpenPortShop(MyComputerPorts.PortC);
         Thread.Sleep(GETINFO_DELAY);
         portCInfo = this.Harvester.GetPortInfo();

         this.AutoRecharge(MyComputerPorts.PortC);
         this.AutoUpgrade(MyComputerPorts.PortC);
         this.OnPortCGetInfo(portCInfo);
         this.Harvester.CloseShop();
      }

      public void SetBTCoin(float amount) {
         this.BTCoin = amount;
      }
      #endregion
   }
}
