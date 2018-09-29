namespace S0urce.io_tool {
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
         this.pan = new System.Windows.Forms.Panel();
         this.lblStatus = new System.Windows.Forms.Label();
         this.pan.SuspendLayout();
         this.SuspendLayout();
         // 
         // webS0urceIo
         // 
         this.webS0urceIo.Dock = System.Windows.Forms.DockStyle.Fill;
         this.webS0urceIo.Location = new System.Drawing.Point(0, 0);
         this.webS0urceIo.MinimumSize = new System.Drawing.Size(20, 20);
         this.webS0urceIo.Name = "webS0urceIo";
         this.webS0urceIo.Size = new System.Drawing.Size(1169, 558);
         this.webS0urceIo.TabIndex = 0;
         // 
         // pan
         // 
         this.pan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
         this.pan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pan.Controls.Add(this.lblStatus);
         this.pan.Dock = System.Windows.Forms.DockStyle.Top;
         this.pan.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.pan.ForeColor = System.Drawing.Color.White;
         this.pan.Location = new System.Drawing.Point(0, 0);
         this.pan.Name = "pan";
         this.pan.Padding = new System.Windows.Forms.Padding(7);
         this.pan.Size = new System.Drawing.Size(1169, 30);
         this.pan.TabIndex = 1;
         // 
         // lblStatus
         // 
         this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lblStatus.Location = new System.Drawing.Point(7, 7);
         this.lblStatus.Margin = new System.Windows.Forms.Padding(0);
         this.lblStatus.Name = "lblStatus";
         this.lblStatus.Size = new System.Drawing.Size(1153, 14);
         this.lblStatus.TabIndex = 0;
         this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // frmCrawler
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1169, 558);
         this.Controls.Add(this.pan);
         this.Controls.Add(this.webS0urceIo);
         this.Name = "frmCrawler";
         this.Text = "S0urce.io Tool - Bot - Version 0.2";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCrawler_FormClosed);
         this.Shown += new System.EventHandler(this.frmCrawler_Shown);
         this.pan.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.WebBrowser webS0urceIo;
      private System.Windows.Forms.Panel pan;
      private System.Windows.Forms.Label lblStatus;
   }
}

