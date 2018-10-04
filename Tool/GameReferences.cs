using System.Collections.Generic;
using System.Windows.Forms;

namespace S0urce.io_tool.Tool {
   #region structs
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
      public HtmlElement ChargeCost;
      public HtmlElement MaxCharge;
      public HtmlElement MaxChargeCost;
      public HtmlElement Difficulty;
      public HtmlElement DifficultyCost;
      public HtmlElement Regen;
      public HtmlElement RegenCost;
      public HtmlElement BackButton;
      public HtmlElement BackButtonCost;
   }

   public struct WindowComputerReference {
      public HtmlElement WindowComputer;
      public HtmlElement WindowComputerInputQuote;
      public HtmlElement WindowComputerUpdateBtnQuote;
      public WindowComputerPortsReference Ports;
      public WindowcomputerShopReference Shop;
   }

   public struct WindowHackingSucessfulReference {
      public HtmlElement Window;
      public HtmlElement Input;
      public HtmlElement SendButton;
      public HtmlElement OkayButton;
   }

   public struct WindowBlackMarketReference {
      public HtmlElement Window;
      public HtmlElement BasicMinerButton;
      public HtmlElement BasicMinerButtonCost;
      public HtmlElement AdvancedMinerButton;
      public HtmlElement AdvancedMinerButtonCost;
      public HtmlElement MiningDrillButton;
      public HtmlElement MiningDrillButtonCost;
      public HtmlElement DataCenterButton;
      public HtmlElement DataCenterButtonCost;
      public HtmlElement BotNetButton;
      public HtmlElement BotNetButtonCost;
      public HtmlElement QuantumServerButton;
      public HtmlElement QuantumServerButtonCost;
   }
   #endregion

   public class GameReferences {
      #region varaibles
      public WebBrowser Browser;
      public WindowToolReference WindowToolRef;
      public WindowMinerReference WindowMinerRef;
      public WindowComputerReference WindowComputerRef;
      public WindowHackingSucessfulReference WindowHackSucessfulRef;
      public WindowBlackMarketReference WindowBlackMarketRef;

      private HtmlElement GamePage;
      private HtmlElement LoginPage;
      #endregion

      private HtmlElement getElementsByClassName(HtmlDocument doc, string className = "") {
         List<HtmlElement> list = new List<HtmlElement>();
         HtmlElementCollection collection = doc.GetElementsByTagName("div");
         for (int i = 0; i < collection.Count; i++) {
            if (collection[i].GetAttribute("className") == className) {
               list.Add(collection[i]);
            }
         }

         if (list.Count > 0) {
            return list[0];
         } else
            return null;
      }

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

         #region Window sucessful hack
         HtmlElement windowSucess = this.GamePage.Document.GetElementById("topwindow-success");
         if (windowSucess == null) return;
         this.WindowHackSucessfulRef.Window = windowSucess;

         HtmlElement sucessInput = this.WindowHackSucessfulRef.Window.Document.GetElementById("targetmessage-input");
         if (sucessInput == null) return;
         this.WindowHackSucessfulRef.Input = sucessInput;

         HtmlElement sucessSendButton = this.WindowHackSucessfulRef.Window.Document.GetElementById("targetmessage-button-send");
         if (sucessSendButton == null) return;
         this.WindowHackSucessfulRef.SendButton = sucessSendButton;

         HtmlElement sucessOkayButton = this.getElementsByClassName(this.WindowHackSucessfulRef.Window.Document, "button targetmessage-button-cancel");
         if (sucessOkayButton == null) return;
         this.WindowHackSucessfulRef.OkayButton = sucessOkayButton;
         #endregion
         
         #region black market
         HtmlElement windowBlackMarket = this.GamePage.Document.GetElementById("window-shop");
         if (windowBlackMarket == null) return;
         this.WindowBlackMarketRef.Window = windowBlackMarket;

         HtmlElement blackMarketBasicMiner = this.WindowBlackMarketRef.Window.Document.GetElementById("shop-basic-miner");
         if (blackMarketBasicMiner == null) return;
         this.WindowBlackMarketRef.BasicMinerButton = blackMarketBasicMiner;

         HtmlElement blackMarketBasicMinerCost = this.WindowBlackMarketRef.BasicMinerButton.Document.GetElementById("shop-basic-miner-value");
         if (blackMarketBasicMinerCost == null) return;
         this.WindowBlackMarketRef.BasicMinerButtonCost = blackMarketBasicMinerCost;

         HtmlElement blackMarketAdvancedMiner = this.WindowBlackMarketRef.Window.Document.GetElementById("shop-advanced-miner");
         if (blackMarketAdvancedMiner == null) return;
         this.WindowBlackMarketRef.AdvancedMinerButton = blackMarketAdvancedMiner;

         HtmlElement blackMarketAdvancedMinerCost = this.WindowBlackMarketRef.AdvancedMinerButton.Document.GetElementById("shop-advanced-miner-value");
         if (blackMarketAdvancedMinerCost == null) return;
         this.WindowBlackMarketRef.AdvancedMinerButtonCost = blackMarketAdvancedMinerCost;

         HtmlElement blackMarketMiningDrill = this.WindowBlackMarketRef.Window.Document.GetElementById("shop-mining-drill");
         if (blackMarketMiningDrill == null) return;
         this.WindowBlackMarketRef.MiningDrillButton = blackMarketMiningDrill;

         HtmlElement blackMarketMiningDrillCost = this.WindowBlackMarketRef.MiningDrillButton.Document.GetElementById("shop-mining-drill-value");
         if (blackMarketMiningDrillCost == null) return;
         this.WindowBlackMarketRef.MiningDrillButtonCost = blackMarketMiningDrillCost;

         HtmlElement blackMarketDataCenter = this.WindowBlackMarketRef.Window.Document.GetElementById("shop-data-center");
         if (blackMarketDataCenter == null) return;
         this.WindowBlackMarketRef.DataCenterButton = blackMarketDataCenter;

         HtmlElement blackMarketDataCenterCost = this.WindowBlackMarketRef.DataCenterButton.Document.GetElementById("shop-data-center-value");
         if (blackMarketDataCenterCost == null) return;
         this.WindowBlackMarketRef.DataCenterButtonCost = blackMarketDataCenterCost;

         HtmlElement blackMarketBotNet = this.WindowBlackMarketRef.Window.Document.GetElementById("shop-bot-net");
         if (blackMarketBotNet == null) return;
         this.WindowBlackMarketRef.BotNetButton = blackMarketBotNet;

         HtmlElement blackMarketBotNetCost = this.WindowBlackMarketRef.BotNetButton.Document.GetElementById("shop-bot-net-value");
         if (blackMarketBotNetCost == null) return;
         this.WindowBlackMarketRef.BotNetButtonCost = blackMarketBotNetCost;

         HtmlElement blackMarketQuantumServer = this.WindowBlackMarketRef.Window.Document.GetElementById("shop-quantum-server");
         if (blackMarketQuantumServer == null) return;
         this.WindowBlackMarketRef.QuantumServerButton = blackMarketQuantumServer;

         HtmlElement blackMarketQuantumServerCost = this.WindowBlackMarketRef.QuantumServerButton.Document.GetElementById("shop-quantum-server-value");
         if (blackMarketQuantumServerCost == null) return;
         this.WindowBlackMarketRef.QuantumServerButtonCost = blackMarketQuantumServerCost;
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

         HtmlElement windowComputerShopChargeCost = this.WindowComputerRef.Shop.Charge.Document.GetElementById("shop-firewall-charge5-value");
         if (windowComputerShopChargeCost == null) return;
         this.WindowComputerRef.Shop.ChargeCost = windowComputerShopChargeCost;

         HtmlElement windowComputerShopMaxCharge = this.WindowComputerRef.WindowComputer.Document.GetElementById("shop-firewall-max_charge10");
         if (windowComputerShopMaxCharge == null) return;
         this.WindowComputerRef.Shop.MaxCharge = windowComputerShopMaxCharge;

         HtmlElement windowComputerShopMaxChargeCost = this.WindowComputerRef.Shop.MaxCharge.Document.GetElementById("shop-firewall-max_charge10-value");
         if (windowComputerShopMaxChargeCost == null) return;
         this.WindowComputerRef.Shop.MaxChargeCost = windowComputerShopMaxChargeCost;

         HtmlElement windowComputerShopDifficulty = this.WindowComputerRef.WindowComputer.Document.GetElementById("shop-firewall-difficulty");
         if (windowComputerShopDifficulty == null) return;
         this.WindowComputerRef.Shop.Difficulty = windowComputerShopDifficulty;

         HtmlElement windowComputerShopDifficultyCost = this.WindowComputerRef.Shop.Difficulty.Document.GetElementById("shop-firewall-difficulty-value");
         if (windowComputerShopDifficultyCost == null) return;
         this.WindowComputerRef.Shop.DifficultyCost = windowComputerShopDifficultyCost;

         HtmlElement windowComputerShopRegen = this.WindowComputerRef.WindowComputer.Document.GetElementById("shop-firewall-regen");
         if (windowComputerShopRegen == null) return;
         this.WindowComputerRef.Shop.Regen = windowComputerShopRegen;

         HtmlElement windowComputerShopRegenCost = this.WindowComputerRef.Shop.Regen.Document.GetElementById("shop-firewall-regen-value");
         if (windowComputerShopRegenCost == null) return;
         this.WindowComputerRef.Shop.RegenCost = windowComputerShopRegenCost;

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

      public bool AdBarExist() {
         HtmlElement adbar = this.Browser.Document.GetElementById("window-msg2");
         return (adbar != null);
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
