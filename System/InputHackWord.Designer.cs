namespace S0urce.io_Crawler.Crawler {
   partial class InputHackWord {
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
         this.lblWordID = new System.Windows.Forms.Label();
         this.txtHackWord = new System.Windows.Forms.TextBox();
         this.btnOk = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // lblWordID
         // 
         this.lblWordID.AutoSize = true;
         this.lblWordID.Location = new System.Drawing.Point(12, 9);
         this.lblWordID.Name = "lblWordID";
         this.lblWordID.Size = new System.Drawing.Size(35, 13);
         this.lblWordID.TabIndex = 0;
         this.lblWordID.Text = "label1";
         // 
         // txtHackWord
         // 
         this.txtHackWord.Location = new System.Drawing.Point(68, 6);
         this.txtHackWord.Name = "txtHackWord";
         this.txtHackWord.Size = new System.Drawing.Size(409, 20);
         this.txtHackWord.TabIndex = 1;
         this.txtHackWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHackWord_KeyPress);
         // 
         // btnOk
         // 
         this.btnOk.Location = new System.Drawing.Point(483, 4);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(82, 23);
         this.btnOk.TabIndex = 2;
         this.btnOk.Text = "Ok";
         this.btnOk.UseVisualStyleBackColor = true;
         this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(571, 4);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(82, 23);
         this.button1.TabIndex = 3;
         this.button1.Text = "Cancel";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // InputHackWord
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(662, 36);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.btnOk);
         this.Controls.Add(this.txtHackWord);
         this.Controls.Add(this.lblWordID);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "InputHackWord";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblWordID;
      private System.Windows.Forms.TextBox txtHackWord;
      private System.Windows.Forms.Button btnOk;
      private System.Windows.Forms.Button button1;
   }
}
