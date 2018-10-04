using S0urce.io_tool.BotControllers;
using S0urce.io_tool.BotSystem;
using System;
using System.Windows.Forms;

namespace S0urce.io_tool.Harvesters {
   #region structs
   public struct FirewallPortInfo {
      public int Charge;
      public int MaxCharge;
      public int Difficulty;
      public int Regen;

      public bool NeedRecharge() {
         return ((MaxCharge - Charge) >= 5);
      }

      public FirewallPortButtons GetPriority() {
         if (this.Difficulty < 4)
            return FirewallPortButtons.Difficulty;

         if (this.MaxCharge < 30)
            return FirewallPortButtons.MaxCharge;

         if (this.Regen < 10)
            return FirewallPortButtons.Regen;

         return FirewallPortButtons.Charge;
      }
   }
   #endregion

   public class WindowMyComputerHarvester: BaseHarvester {
      public void SetQuote(string quote) {
         this.References.WindowComputerRef.WindowComputerInputQuote.SetAttribute("value", quote);
         this.References.WindowComputerRef.WindowComputerUpdateBtnQuote.InvokeMember("click");
      }

      public void OpenPortShop(MyComputerPorts port) {
         switch (port) {
            case MyComputerPorts.PortA:
               this.References.WindowComputerRef.Ports.PortA.InvokeMember("click");
               break;
            case MyComputerPorts.PortB:
               this.References.WindowComputerRef.Ports.PortB.InvokeMember("click");
               break;
            case MyComputerPorts.PortC:
               this.References.WindowComputerRef.Ports.PortC.InvokeMember("click");
               break;
            default:
               break;
         }
      }

      public FirewallPortInfo GetPortInfo() {
         FirewallPortInfo info;
         info.Charge = this.GetCharge();
         info.MaxCharge = this.GetMaxCharge();
         info.Difficulty = this.GetDifficulty();
         info.Regen = this.GetRegen();

         return info;
      }

      public void RechargePort() {
         if (!this.References.WindowComputerRef.Shop.Charge.Style.Contains("0.4"))
            this.References.WindowComputerRef.Shop.Charge.InvokeMember("click");
      }

      public void RaiseMaxCharge() {
         if (!this.References.WindowComputerRef.Shop.MaxCharge.Style.Contains("0.4"))
            this.References.WindowComputerRef.Shop.MaxCharge.InvokeMember("click");
      }

      public void RaiseDifficulty() {
         if (!this.References.WindowComputerRef.Shop.Difficulty.Style.Contains("0.4"))
            this.References.WindowComputerRef.Shop.Difficulty.InvokeMember("click");
      }

      public void RaiseRegen() {
         if (!this.References.WindowComputerRef.Shop.Regen.Style.Contains("0.4"))
            this.References.WindowComputerRef.Shop.Regen.InvokeMember("click");
      }

      public void CloseShop() {
         this.References.WindowComputerRef.Shop.BackButton.InvokeMember("click");
      }

      private int GetCharge() {
         HtmlElement charge = this.References.WindowComputerRef.WindowComputer.Document.GetElementById("shop-charges");
         string chargeAmount = charge.InnerText;

         try {
            return (Int32.Parse(chargeAmount));
         } catch {
            return -1;
         }
      }

      private int GetMaxCharge() {
         HtmlElement maxCharge = this.References.WindowComputerRef.WindowComputer.Document.GetElementById("shop-max-charges");
         string maxChargeAmount = maxCharge.InnerText;

         try {
            return (Int32.Parse(maxChargeAmount));
         } catch {
            return -1;
         }
      }

      public float GetCost(FirewallPortButtons option) {
         string sCost = string.Empty;
         switch (option) {
            case FirewallPortButtons.Charge:
               sCost = this.References.WindowComputerRef.Shop.ChargeCost.InnerText;
               break;
            case FirewallPortButtons.MaxCharge:
               sCost = this.References.WindowComputerRef.Shop.MaxChargeCost.InnerText;
               break;
            case FirewallPortButtons.Difficulty:
               sCost = this.References.WindowComputerRef.Shop.DifficultyCost.InnerText;
               break;
            case FirewallPortButtons.Regen:
               sCost = this.References.WindowComputerRef.Shop.RegenCost.InnerText;
               break;
         }
         try {
            return float.Parse(sCost.Replace('.', ','));
         } catch {
            return -1;
         }
      }

      private int GetDifficulty() {
         HtmlElement difficulty = this.References.WindowComputerRef.WindowComputer.Document.GetElementById("shop-strength");
         string difficultyAmount = difficulty.InnerText;

         try {
            return (Int32.Parse(difficultyAmount));
         } catch {
            return -1;
         }
      }

      private int GetRegen() {
         HtmlElement regen = this.References.WindowComputerRef.WindowComputer.Document.GetElementById("shop-regen");
         string regenAmount = regen.InnerText;

         try {
            return (Int32.Parse(regenAmount));
         } catch {
            return -1;
         }
      }
   }
}
