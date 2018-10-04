using S0urce.io_tool.BotControllers;
using S0urce.io_tool.Harvesters;
using System;
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
      private const int GETINFO_DELAY = 300;
      private const int AFTER_PROCESS_DELAY = 50;
      private const int RECHARGE_BTCOIN_MULT = 20;
      private const int MIN_HACK_BTCOIN = 5;
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
      private float BTCoinGain;
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
         Thread.Sleep(AFTER_PROCESS_DELAY);
         this.ProcessPortBInfo();
         Thread.Sleep(AFTER_PROCESS_DELAY);
         this.ProcessPortCInfo();
         Thread.Sleep(AFTER_PROCESS_DELAY);

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

         if (priority == FirewallPortButtons.Difficulty && this.CanUpgrade(FirewallPortButtons.Difficulty))
            this.Harvester.RaiseDifficulty();
         if (priority == FirewallPortButtons.Regen && this.CanUpgrade(FirewallPortButtons.Regen))
            this.Harvester.RaiseRegen();
         if (priority == FirewallPortButtons.MaxCharge && this.CanUpgrade(FirewallPortButtons.MaxCharge))
            this.Harvester.RaiseMaxCharge();
      }

      private bool CanUpgrade(FirewallPortButtons option) {
         float rechargeBTCoinNeed = (this.BTCoinGain * RECHARGE_BTCOIN_MULT);
         float optionCost = 0;
         switch (option) {
            case FirewallPortButtons.Charge:
               optionCost = this.Harvester.GetCost(FirewallPortButtons.Charge);
               break;
            case FirewallPortButtons.MaxCharge:
               optionCost = this.Harvester.GetCost(FirewallPortButtons.MaxCharge);
               break;
            case FirewallPortButtons.Difficulty:
               optionCost = this.Harvester.GetCost(FirewallPortButtons.Difficulty);
               break;
            case FirewallPortButtons.Regen:
               optionCost = this.Harvester.GetCost(FirewallPortButtons.Regen);
               break;
         }

         return ((this.BTCoin - rechargeBTCoinNeed - optionCost) > (this.BTCoinGain * MIN_HACK_BTCOIN));
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

      public void SetBTCoinGain(float amount) {
         this.BTCoinGain = amount;
      }
      #endregion
   }
}
