﻿using S0urce.io_Crawler.Crawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S0urce.io_Crawler {
   public partial class frmCrawler : Form {
      #region constants
      private const string STR_S0URCE_IO = "http://s0urce.io/";
      #endregion
      private Crawler2 crawler2;

      public frmCrawler() {
         InitializeComponent();
         this.crawler2 = new Crawler2();
         this.crawler2.References.Browser = webS0urceIo;

         this.webS0urceIo.PreviewKeyDown += this.WebS0urceIo_PreviewKeyDown;
      }

      private void WebS0urceIo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
         switch (e.KeyCode) {
            case Keys.F7:
               this.crawler2.DecreasyDelay();
               break;
            case Keys.F8:
               this.crawler2.IncreaseDelay();
               break;
            case Keys.F9:
               this.crawler2.Save();
               break;
            case Keys.F10:
               this.crawler2.Stop();
               Application.Exit();
               break;
         }
      }

      private void frmCrawler_Shown(object sender, EventArgs e) {
         webS0urceIo.Navigate(STR_S0URCE_IO);
         this.crawler2.Start();
      }
   }
}
