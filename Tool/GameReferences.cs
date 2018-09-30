using System;
using System.Windows.Forms;

namespace S0urce.io_tool.Tool {
   public class GameReferences {
      #region varaibles
      public WebBrowser Browser;
      public HtmlElement WindowTool;
      public HtmlElement WindowToolProgress;
      public HtmlElement WindowToolInput;

      public HtmlElement WindowMiner;
      public HtmlElement WindowMinerBTCoin;
      public HtmlElement WindowMinerBTCoinGain;

      private HtmlElement GamePage;
      #endregion
      #region class methods
      public bool IsSet() {
         return (this.WindowToolInput != null);
      }

      public void SetReferences() {
         #region game page
         HtmlElement gamepage = this.GetGamePage();
         if (gamepage == null) return;
         this.GamePage = gamepage;
         #endregion
         #region window miner
         HtmlElement windowMiner = this.GamePage.Document.GetElementById("window-miner");
         if (windowMiner == null) return;
         this.WindowMiner = windowMiner;

         HtmlElement windowMinerBTCoin = this.WindowMiner.Document.GetElementById("window-my-coinamount");
         if (windowMinerBTCoin == null) return;
         this.WindowMinerBTCoin = windowMinerBTCoin;

         HtmlElement windowMinerBTCoinGain = this.WindowMiner.Document.GetElementById("window-my-gainamount");
         if (windowMinerBTCoinGain == null) return;
         this.WindowMinerBTCoinGain = windowMinerBTCoinGain;
         #endregion
         #region window tool
         HtmlElement windowTool = this.GamePage.Document.GetElementById("window-tool");
         if (windowTool == null) return;
         this.WindowTool = windowTool;

         HtmlElement windowTool_Progress = this.WindowTool.Document.GetElementById("progressbar-firewall-amount");
         if (windowTool_Progress == null) return;
         this.WindowToolProgress = windowTool_Progress;

         HtmlElement windowTool_input = this.WindowTool.Document.GetElementById("tool-type-word");
         if (windowTool_input == null) return;
         this.WindowToolInput = windowTool_input;
         #endregion
      }

      private HtmlElement GetGamePage() {
         return this.Browser.Document.GetElementById("game-page");
      }

      public void RemoveAdBar() {
         dynamic htmldoc = this.Browser.Document.DomDocument as dynamic;
         dynamic adbar = htmldoc.getElementById("window-msg2") as dynamic;
         if (adbar != null)
            adbar.parentNode.removeChild(adbar);
      }
      #endregion
      #region Window tool
      public bool WindowToolDisplayed() {
         return (!this.WindowTool.Style.Contains("display"));
      }

      public bool WindowToolTypingHintDisplayed() {
         HtmlElement tooltip = GetTooltip();
         return (tooltip != null);
      }

      public string GetToolTipID() {
         HtmlElement tooltip = this.GetTooltip();
         string innerHTML = tooltip.InnerHtml;

         int startIndexPos = innerHTML.IndexOf("src=\"../client/img/word/");
         if (startIndexPos < 0) {
            return string.Empty;
         } else {
            int endIndexPos = innerHTML.IndexOf("\">");
            startIndexPos += 24;

            return innerHTML.Substring(startIndexPos, (endIndexPos - startIndexPos));
         }
      }

      public int GetHackingProgress() {
         string style = this.WindowToolProgress.Style;
         if (style.Equals(string.Empty))
            return -1;

         int startIndex = style.IndexOf(" ");
         int endIndex = style.IndexOf("%");
         startIndex++;

         int progress = Int32.Parse(style.Substring(startIndex, (endIndex - startIndex) ));
         return progress;
      }

      public void sendHackingWord(string word) {
         this.WindowToolInput.SetAttribute("value", word);
         this.WindowToolInput.Focus();
         SendKeys.SendWait("{ENTER}");
      }

      private HtmlElement GetTooltip() {
         return this.WindowTool.Document.GetElementById("tool-type");
      }
      #endregion
      #region Window miner
      public float GetBTCoin() {
         string sBTCoin = this.WindowMinerBTCoin.InnerText;
         try {
            return float.Parse(sBTCoin.Replace('.', ','));
         } catch (Exception e) {
            return -1;
         }
      }

      public float GetBTCoinGain() {
         string sBTCoin = this.WindowMinerBTCoinGain.InnerText;
         try {
            return float.Parse(sBTCoin.Replace('.', ','));
         } catch (Exception e) {
            return -1;
         }
      }
      #endregion
   }
}
