namespace S0urce.io_Crawler {
   partial class frmCrawler {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.webS0urceIo = new System.Windows.Forms.WebBrowser();
         this.SuspendLayout();
         // 
         // webS0urceIo
         // 
         this.webS0urceIo.Dock = System.Windows.Forms.DockStyle.Fill;
         this.webS0urceIo.Location = new System.Drawing.Point(0, 0);
         this.webS0urceIo.MinimumSize = new System.Drawing.Size(20, 20);
         this.webS0urceIo.Name = "webS0urceIo";
         this.webS0urceIo.Size = new System.Drawing.Size(725, 394);
         this.webS0urceIo.TabIndex = 0;
         // 
         // frmCrawler
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(725, 394);
         this.Controls.Add(this.webS0urceIo);
         this.Name = "frmCrawler";
         this.Text = "S0urce.io Crawler";
         this.Shown += new System.EventHandler(this.frmCrawler_Shown);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.WebBrowser webS0urceIo;
   }
}

