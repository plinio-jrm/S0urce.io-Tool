using System;
using System.Windows.Forms;

namespace S0urce.io_tool.Harvesters {
   public class WindowToolHarvester: BaseHarvester {
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
         string style = this.References.WindowToolRef.WindowToolProgress.Style;
         if (style.Equals(string.Empty))
            return -1;

         int startIndex = style.IndexOf(" ");
         int endIndex = style.IndexOf("%");
         startIndex++;

         int progress = Int32.Parse(style.Substring(startIndex, (endIndex - startIndex)));
         return progress;
      }

      private HtmlElement GetTooltip() {
         return this.References.WindowToolRef.WindowTool.Document.GetElementById("tool-type");
      }

      public bool WindowToolDisplayed() {
         return (!this.References.WindowToolRef.WindowTool.Style.Contains("display"));
      }

      public bool WindowToolTypingHintDisplayed() {
         HtmlElement tooltip = this.References.WindowToolRef.WindowTool.Document.GetElementById("tool-type");
         return (tooltip != null);
      }

      public void sendHackingWord(string word) {
         this.References.WindowToolRef.WindowToolInput.SetAttribute("value", word);
         this.References.WindowToolRef.WindowToolInput.Focus();
         SendKeys.SendWait("{ENTER}");
      }
   }
}
