using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S0urce.io_Crawler.Crawler {
   public struct GameReferences {
      public WebBrowser Browser;
      public HtmlElement WindowTool;
      public HtmlElement WindowToolProgress;
      public HtmlElement WindowToolInput;

      public bool IsSet() {
         return (this.WindowToolInput != null);
      }

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

      public void SetReferences() {
         HtmlElement gamepage = this.GetGamePage();
         if (gamepage == null) return;

         HtmlElement windowTool = gamepage.Document.GetElementById("window-tool");
         if (windowTool == null) return;
         this.WindowTool = windowTool;

         HtmlElement windowTool_Progress = this.WindowTool.Document.GetElementById("progressbar-firewall-amount");
         if (windowTool_Progress == null) return;
         this.WindowToolProgress = windowTool_Progress;

         HtmlElement windowTool_input = this.WindowTool.Document.GetElementById("tool-type-word");
         if (windowTool_input == null) return;
         this.WindowToolInput = windowTool_input;
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

      private HtmlElement GetGamePage() {
         return this.Browser.Document.GetElementById("game-page");
      }
   }
}
