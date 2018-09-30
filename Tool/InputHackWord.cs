using System;
using System.Windows.Forms;

namespace S0urce.io_tool.Tool {
   public partial class InputHackWord: Form {
      public delegate void OnOkPress(string hackWord);
      public event OnOkPress OnOk;

      public InputHackWord() {
         InitializeComponent();
      }

      public static void Show(OnOkPress onOkEvent, string ID) {
         InputHackWord input = new InputHackWord();
         input.lblWordID.Text = ID;
         input.OnOk += onOkEvent;
         input.StartPosition = FormStartPosition.CenterParent;
         input.ShowDialog();
      }

      private void btnOk_Click(object sender, EventArgs e) {
         string word = txtHackWord.Text;
         if (!word.Equals(string.Empty)) {
            this.OnOk(word);
            this.Close();
         }
      }

      private void button1_Click(object sender, EventArgs e) {
         this.OnOk(string.Empty);
         this.Close();
      }

      private void txtHackWord_KeyPress(object sender, KeyPressEventArgs e) {
         if (e.KeyChar.Equals((char) 13))
            this.btnOk.PerformClick();
      }
   }
}
