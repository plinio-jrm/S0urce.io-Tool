using System;
using System.Windows.Forms;

namespace S0urce.io_tool.Tool {
   public struct WindowToolReference {
      public HtmlElement WindowTool;
      public HtmlElement WindowToolProgress;
      public HtmlElement WindowToolInput;
   }

   public struct WindowMinerReference {
      public HtmlElement WindowMiner;
      public HtmlElement WindowMinerBTCoin;
      public HtmlElement WindowMinerBTCoinGain;
   }

   public struct WindowComputerPortsReference {
      public HtmlElement PortA;
      public HtmlElement PortB;
      public HtmlElement PortC;
   }

   public struct WindowcomputerShopReference {
      public HtmlElement Charge;
      public HtmlElement MaxCharge;
      public HtmlElement Difficulty;
      public HtmlElement Regen;
      public HtmlElement BackButton; // window-firewall-pagebutton
   }

   public struct WindowComputerReference {
      public HtmlElement WindowComputer;
      public HtmlElement WindowComputerInputQuote;
      public HtmlElement WindowComputerUpdateBtnQuote;
      public WindowComputerPortsReference Ports;
      public WindowcomputerShopReference Shop;
   }

   public class GameReferences {
      #region varaibles
      public WebBrowser Browser;
      public WindowToolReference WindowToolRef;
      public WindowMinerReference WindowMinerRef;
      public WindowComputerReference WindowComputerRef;

      private HtmlElement GamePage;
      private HtmlElement LoginPage;
      #endregion
      #region class methods
      public bool IsSet() {
         return (this.WindowToolRef.WindowToolInput != null);
      }

      public void LoadReferences() {
         #region game page
         HtmlElement gamepage = this.GetGamePage();
         if (gamepage == null) return;
         this.GamePage = gamepage;

         HtmlElement loginpage = this.GetLoginPage();
         if (loginpage == null) return;
         this.LoginPage = loginpage;
         #endregion
         
         #region window miner
         HtmlElement windowMiner = this.GamePage.Document.GetElementById("window-miner");
         if (windowMiner == null) return;
         this.WindowMinerRef.WindowMiner = windowMiner;

         HtmlElement windowMinerBTCoin = this.WindowMinerRef.WindowMiner.Document.GetElementById("window-my-coinamount");
         if (windowMinerBTCoin == null) return;
         this.WindowMinerRef.WindowMinerBTCoin = windowMinerBTCoin;

         HtmlElement windowMinerBTCoinGain = this.WindowMinerRef.WindowMiner.Document.GetElementById("window-my-gainamount");
         if (windowMinerBTCoinGain == null) return;
         this.WindowMinerRef.WindowMinerBTCoinGain = windowMinerBTCoinGain;
         #endregion

         #region Window Computer
         HtmlElement windowComputer = this.GamePage.Document.GetElementById("window-computer");
         if (windowComputer == null) return;
         this.WindowComputerRef.WindowComputer = windowComputer;

         HtmlElement windowComputerInputQuote = this.WindowComputerRef.WindowComputer.Document.GetElementById("playerquote-type-word");
         if (windowComputerInputQuote == null) return;
         this.WindowComputerRef.WindowComputerInputQuote = windowComputerInputQuote;

         HtmlElement windowComputerUpdateBtnQuote = this.WindowComputerRef.WindowComputer.Document.GetElementById("playerquote-button");
         if (windowComputerUpdateBtnQuote == null) return;
         this.WindowComputerRef.WindowComputerUpdateBtnQuote = windowComputerUpdateBtnQuote;
         // ports
         HtmlElement windowComputerPortA = this.WindowComputerRef.WindowComputer.Document.GetElementById("window-firewall-part1-amount");
         if (windowComputerPortA == null) return;
         this.WindowComputerRef.Ports.PortA = windowComputerPortA;

         HtmlElement windowComputerPortB = this.WindowComputerRef.WindowComputer.Document.GetElementById("window-firewall-part2-amount");
         if (windowComputerPortB == null) return;
         this.WindowComputerRef.Ports.PortB = windowComputerPortB;

         HtmlElement windowComputerPortC = this.WindowComputerRef.WindowComputer.Document.GetElementById("window-firewall-part3-amount");
         if (windowComputerPortC == null) return;
         this.WindowComputerRef.Ports.PortC = windowComputerPortC;
         // shop
         HtmlElement windowComputerShopCharge = this.WindowComputerRef.WindowComputer.Document.GetElementById("shop-firewall-charge5");
         if (windowComputerShopCharge == null) return;
         this.WindowComputerRef.Shop.Charge = windowComputerShopCharge;

         HtmlElement windowComputerShopMaxCharge = this.WindowComputerRef.WindowComputer.Document.GetElementById("shop-firewall-max_charge10");
         if (windowComputerShopMaxCharge == null) return;
         this.WindowComputerRef.Shop.MaxCharge = windowComputerShopMaxCharge;

         HtmlElement windowComputerShopDifficulty = this.WindowComputerRef.WindowComputer.Document.GetElementById("shop-firewall-difficulty");
         if (windowComputerShopDifficulty == null) return;
         this.WindowComputerRef.Shop.Difficulty = windowComputerShopDifficulty;

         HtmlElement windowComputerShopRegen = this.WindowComputerRef.WindowComputer.Document.GetElementById("shop-firewall-regen");
         if (windowComputerShopRegen == null) return;
         this.WindowComputerRef.Shop.Regen = windowComputerShopRegen;

         HtmlElement windowComputerShopBackBtn = this.WindowComputerRef.WindowComputer.Document.GetElementById("window-firewall-pagebutton");
         if (windowComputerShopBackBtn == null) return;
         this.WindowComputerRef.Shop.BackButton = windowComputerShopBackBtn;
         #endregion

         #region window tool
         HtmlElement windowTool = this.GamePage.Document.GetElementById("window-tool");
         if (windowTool == null) return;
         this.WindowToolRef.WindowTool = windowTool;

         HtmlElement windowTool_Progress = this.WindowToolRef.WindowTool.Document.GetElementById("progressbar-firewall-amount");
         if (windowTool_Progress == null) return;
         this.WindowToolRef.WindowToolProgress = windowTool_Progress;

         HtmlElement windowTool_input = this.WindowToolRef.WindowTool.Document.GetElementById("tool-type-word");
         if (windowTool_input == null) return;
         this.WindowToolRef.WindowToolInput = windowTool_input;
         #endregion
      }

      private HtmlElement GetGamePage() {
         return this.Browser.Document.GetElementById("game-page");
      }

      private HtmlElement GetLoginPage() {
         return this.Browser.Document.GetElementById("login-page");
      }

      public void RemoveAdBar() {
         dynamic htmldoc = this.Browser.Document.DomDocument as dynamic;
         dynamic adbar = htmldoc.getElementById("window-msg2") as dynamic;
         if (adbar != null)
            adbar.parentNode.removeChild(adbar);
      }

      public bool Logged() {
         if (this.LoginPage.Style != null)
            return (this.LoginPage.Style.Contains("display"));
         return false;
      }
      #endregion
   }
}
