using S0urce.io_tool.Tool;
using System;
using System.Windows.Forms;

namespace S0urce.io_tool.BotSystem {
   public delegate void stateChangeEvent(ToolBot_State newState);
   public class StateSystem {
      #region variables
      public Label stateLabel;

      private ToolBot_State BotState;
      #endregion
      #region methods
      public void SetState(ToolBot_State newState) {
         this.BotState = newState;
         if (this.stateLabel == null)
            return;

         this.stateLabel.Invoke(new Action(
            () => {
               this.ProcessState(this.BotState);
            }
         ));
      }

      private void ProcessState(ToolBot_State state) {
         string stateText = string.Empty;
         switch (state) {
            case ToolBot_State.Deactivated:
               stateText = "Bot system is deactivated";
               break;
            case ToolBot_State.Initializing:
               stateText = "Bot initializing";
               break;
            case ToolBot_State.Idle:
               stateText = "System ready! Waitting for port to hack";
               break;
            case ToolBot_State.Hacking:
               stateText = "hacking in process";
               break;
            case ToolBot_State.HackingNewWord:
               stateText = "hacking in process - New word require identification";
               break;
            default:
               break;
         }
         this.stateLabel.Text = stateText;
      }
      #endregion
   }
}
