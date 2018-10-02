using S0urce.io_tool.Tool;
using System;
using System.Windows.Forms;

namespace S0urce.io_tool {
   public partial class frmCrawler : Form {
      #region constants
      private const string STR_S0URCE_IO = "http://s0urce.io/";
      #endregion
      private ToolBot toolBot;

      public frmCrawler() {
         InitializeComponent();
         this.toolBot = new ToolBot();
         this.toolBot.References.Browser = webS0urceIo;
         this.SetVisualComponents();

         this.webS0urceIo.PreviewKeyDown += this.WebS0urceIo_PreviewKeyDown;
      }

      private void SetVisualComponents() {
         this.toolBot.State.stateLabel = lblStatus;

         this.toolBot.InfoBarController.DataMinerInfo.BTCoint = lblBTCoin;
         this.toolBot.InfoBarController.DataMinerInfo.Info = lblDataMinerInfo;

         this.toolBot.InfoBarController.MyComputerInfo.PortACharge = lblPortACharge;
         this.toolBot.InfoBarController.MyComputerInfo.PortADifficulty = lblPortADifficulty;
         this.toolBot.InfoBarController.MyComputerInfo.PortARegen = lblPortARegen;

         this.toolBot.InfoBarController.MyComputerInfo.PortBCharge = lblPortBCharge;
         this.toolBot.InfoBarController.MyComputerInfo.PortBDifficulty = lblPortBDifficulty;
         this.toolBot.InfoBarController.MyComputerInfo.PortBRegen = lblPortBRegen;

         this.toolBot.InfoBarController.MyComputerInfo.PortCCharge = lblPortCCharge;
         this.toolBot.InfoBarController.MyComputerInfo.PortCDifficulty = lblPortCDifficulty;
         this.toolBot.InfoBarController.MyComputerInfo.PortCRegen = lblPortCRegen;
      }

      private void WebS0urceIo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
         switch (e.KeyCode) {
            case Keys.F7:
               this.toolBot.DecreasyDelay();
               break;
            case Keys.F8:
               this.toolBot.IncreaseDelay();
               break;
            case Keys.F9:
               this.toolBot.Save();
               break;
            case Keys.F10:
               this.toolBot.Stop();
               Application.Exit();
               break;
            case Keys.F11:
               WindowState = FormWindowState.Maximized;
               break;
         }
      }

      private void frmCrawler_Shown(object sender, EventArgs e) {
         webS0urceIo.Navigate(STR_S0URCE_IO);
         this.toolBot.Start();
      }

      private void checkBox1_CheckedChanged(object sender, EventArgs e) {
         this.toolBot.SetAutoCharge(chbAutoCharge.Checked);
      }

      private void chbAutoFirewall_CheckedChanged(object sender, EventArgs e) {
         this.toolBot.SetAutoUpgrade(chbAutoFirewall.Checked);
      }
   }
}
