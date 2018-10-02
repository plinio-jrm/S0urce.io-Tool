using S0urce.io_tool.Harvesters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace S0urce.io_tool.BotControllers {
   public delegate void BTCoinChangeEvent(float amount);
   public delegate void FirewallPortGetEvent(FirewallPortInfo portInfo);

   #region structs
   public struct DataMinerInfo {
      public Label BTCoint;
      public Label Info;

      public void ProcessBTCoin(float amount) {
         this.BTCoint.Text = amount.ToString() + " BT Coin";
      }

      public void ProcessBTCoinGain(float amount) {
         this.Info.Text = "+ " + amount.ToString() + " per second";
      }
   }

   public struct MyComputerInfo {
      public Label PortACharge;
      public Label PortADifficulty;
      public Label PortARegen;

      public void PortAProcessCharge(int charge, int maxCharge) {
         this.PortACharge.Text = charge.ToString() + "/" + maxCharge.ToString();

         if (charge < maxCharge) {
            this.PortACharge.ForeColor = Color.FromArgb(255, 192, 192);
         } else
            this.PortACharge.ForeColor = Color.FromArgb(192, 255, 192);
      }

      public void PortAProcessDifficulty(int difficulty) {
         this.PortADifficulty.Text = difficulty.ToString();
      }

      public void PortAProcessRegen(int regen) {
         this.PortARegen.Text = regen.ToString();
      }

      public Label PortBCharge;
      public Label PortBDifficulty;
      public Label PortBRegen;

      public void PortBProcessCharge(int charge, int maxCharge) {
         this.PortBCharge.Text = charge.ToString() + "/" + maxCharge.ToString();

         if (charge < maxCharge) {
            this.PortBCharge.ForeColor = Color.FromArgb(255, 192, 192);
         } else
            this.PortBCharge.ForeColor = Color.FromArgb(192, 255, 192);
      }

      public void PortBProcessDifficulty(int difficulty) {
         this.PortBDifficulty.Text = difficulty.ToString();
      }

      public void PortBProcessRegen(int regen) {
         this.PortBRegen.Text = regen.ToString();
      }

      public Label PortCCharge;
      public Label PortCDifficulty;
      public Label PortCRegen;

      public void PortCProcessCharge(int charge, int maxCharge) {
         this.PortCCharge.Text = charge.ToString() + "/" + maxCharge.ToString();

         if (charge < maxCharge) {
            this.PortCCharge.ForeColor = Color.FromArgb(255, 192, 192);
         } else
            this.PortCCharge.ForeColor = Color.FromArgb(192, 255, 192);
      }

      public void PortCProcessDifficulty(int difficulty) {
         this.PortCDifficulty.Text = difficulty.ToString();
      }

      public void PortCProcessRegen(int regen) {
         this.PortCRegen.Text = regen.ToString();
      }
   }
   #endregion

   public enum MyComputerPorts {
      PortA,
      PortB,
      PortC
   }

   public class InfoBarController {
      #region variables
      public DataMinerInfo DataMinerInfo;
      public MyComputerInfo MyComputerInfo;
      #endregion
      #region methods
      public void SetBTCoin(float amount) {
         if (this.DataMinerInfo.BTCoint == null)
            return;

         if (this.DataMinerInfo.BTCoint.InvokeRequired) {
            this.DataMinerInfo.BTCoint.Invoke(new Action(
               () => {
                  this.DataMinerInfo.ProcessBTCoin(amount);
               }
            ));
         } else
            this.DataMinerInfo.ProcessBTCoin(amount);
      }

      public void SetBTCoinGain(float amount) {
         if (this.DataMinerInfo.Info == null)
            return;

         if (this.DataMinerInfo.Info.InvokeRequired) {
            this.DataMinerInfo.Info.Invoke(new Action(
               () => {
                  this.DataMinerInfo.ProcessBTCoinGain(amount);
               }
            ));
         } else
            this.DataMinerInfo.ProcessBTCoinGain(amount);
      }

      public void SetMyComputerPortA(FirewallPortInfo portInfo) {
         this.InvokeAtPortA(portInfo);
      }

      public void SetMyComputerPortB(FirewallPortInfo portInfo) {
         this.InvokeAtPortB(portInfo);
      }

      public void SetMyComputerPortC(FirewallPortInfo portInfo) {
         this.InvokeAtPortC(portInfo);
      }

      private void InvokeAtPortA(FirewallPortInfo portInfo) {
         if (this.MyComputerInfo.PortACharge.InvokeRequired) {
            this.MyComputerInfo.PortACharge.Invoke(new Action(
               () => {
                  this.MyComputerInfo.PortAProcessCharge(portInfo.Charge, portInfo.MaxCharge);
               }
            ));
         } else
            this.MyComputerInfo.PortAProcessCharge(portInfo.Charge, portInfo.MaxCharge);

         if (this.MyComputerInfo.PortADifficulty.InvokeRequired) {
            this.MyComputerInfo.PortADifficulty.Invoke(new Action(
               () => {
                  this.MyComputerInfo.PortAProcessDifficulty(portInfo.Difficulty);
               }
            ));
         } else
            this.MyComputerInfo.PortAProcessDifficulty(portInfo.Difficulty);

         if (this.MyComputerInfo.PortARegen.InvokeRequired) {
            this.MyComputerInfo.PortARegen.Invoke(new Action(
               () => {
                  this.MyComputerInfo.PortAProcessRegen(portInfo.Regen);
               }
            ));
         } else
            this.MyComputerInfo.PortAProcessRegen(portInfo.Regen);
      }

      private void InvokeAtPortB(FirewallPortInfo portInfo) {
         if (this.MyComputerInfo.PortBCharge.InvokeRequired) {
            this.MyComputerInfo.PortBCharge.Invoke(new Action(
               () => {
                  this.MyComputerInfo.PortBProcessCharge(portInfo.Charge, portInfo.MaxCharge);
               }
            ));
         } else
            this.MyComputerInfo.PortBProcessCharge(portInfo.Charge, portInfo.MaxCharge);

         if (this.MyComputerInfo.PortBDifficulty.InvokeRequired) {
            this.MyComputerInfo.PortBDifficulty.Invoke(new Action(
               () => {
                  this.MyComputerInfo.PortBProcessDifficulty(portInfo.Difficulty);
               }
            ));
         } else
            this.MyComputerInfo.PortBProcessDifficulty(portInfo.Difficulty);

         if (this.MyComputerInfo.PortBRegen.InvokeRequired) {
            this.MyComputerInfo.PortBRegen.Invoke(new Action(
               () => {
                  this.MyComputerInfo.PortBProcessRegen(portInfo.Regen);
               }
            ));
         } else
            this.MyComputerInfo.PortBProcessRegen(portInfo.Regen);
      }

      private void InvokeAtPortC(FirewallPortInfo portInfo) {
         if (this.MyComputerInfo.PortCCharge.InvokeRequired) {
            this.MyComputerInfo.PortCCharge.Invoke(new Action(
               () => {
                  this.MyComputerInfo.PortCProcessCharge(portInfo.Charge, portInfo.MaxCharge);
               }
            ));
         } else
            this.MyComputerInfo.PortCProcessCharge(portInfo.Charge, portInfo.MaxCharge);

         if (this.MyComputerInfo.PortCDifficulty.InvokeRequired) {
            this.MyComputerInfo.PortCDifficulty.Invoke(new Action(
               () => {
                  this.MyComputerInfo.PortCProcessDifficulty(portInfo.Difficulty);
               }
            ));
         } else
            this.MyComputerInfo.PortCProcessDifficulty(portInfo.Difficulty);

         if (this.MyComputerInfo.PortCRegen.InvokeRequired) {
            this.MyComputerInfo.PortCRegen.Invoke(new Action(
               () => {
                  this.MyComputerInfo.PortCProcessRegen(portInfo.Regen);
               }
            ));
         } else
            this.MyComputerInfo.PortCProcessRegen(portInfo.Regen);
      }
      #endregion
   }
}
