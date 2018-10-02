using S0urce.io_tool.BotControllers;
using S0urce.io_tool.BotSystem;
using System;

namespace S0urce.io_tool.Tool {
   public class ToolBot {
      #region variables
      public GameReferences References;
      public InfoBarController InfoBarController;
      public StateSystem State;

      private OverwatchSystem OverwatchSystem;
      private HackingSystem HackingSystem;
      private DataMinerSystem DataMinerSystem;
      private MyComputerSystem MyComputerSystem;
      private bool saveRequested = false;
      #endregion
      #region methods
      #region public methods
      public ToolBot() {
         this.References = new GameReferences();
         this.InfoBarController = new InfoBarController();
         this.State = new StateSystem();

         this.OverwatchSystem = new OverwatchSystem();

         this.HackingSystem = new HackingSystem();
         this.HackingSystem.SetReferences(this.References);
         this.HackingSystem.Setup();
         this.HackingSystem.OnStateChange += this.State.SetState;

         this.MyComputerSystem = new MyComputerSystem();
         this.MyComputerSystem.SetReferences(this.References);
         this.MyComputerSystem.Setup();
         this.MyComputerSystem.OnPortAGetInfo += this.InfoBarController.SetMyComputerPortA;
         this.MyComputerSystem.OnPortBGetInfo += this.InfoBarController.SetMyComputerPortB;
         this.MyComputerSystem.OnPortCGetInfo += this.InfoBarController.SetMyComputerPortC;

         this.DataMinerSystem = new DataMinerSystem();
         this.DataMinerSystem.SetReferences(this.References);
         this.DataMinerSystem.Setup();
         this.DataMinerSystem.OnBTCoinChange += this.InfoBarController.SetBTCoin;
         this.DataMinerSystem.OnBTCoinChange += this.MyComputerSystem.SetBTCoin;
         this.DataMinerSystem.OnBTCoinGainChange += this.InfoBarController.SetBTCoinGain;
      }

      public void Start() {
         this.State.SetState(ToolBot_State.Deactivated);

         this.OverwatchSystem.OnMainOverwatch += this.OverwatchPage;
         this.OverwatchSystem.OnHacking += this.HackingSystem.Process;
         this.OverwatchSystem.OnDataMiner += this.DataMinerSystem.Process;
         this.OverwatchSystem.OnMyComputer += this.MyComputerSystem.Process;
         this.OverwatchSystem.Start();

         this.State.SetState(ToolBot_State.Initializing);
         this.HackingSystem.LoadDatabase();
      }

      public void Stop() {
         this.OverwatchSystem.Stop();
      }

      public void IncreaseDelay() {
         this.OverwatchSystem.IncreasyDelay();
      }

      public void DecreasyDelay() {
         this.OverwatchSystem.DecreasyDelay();
      }

      public void Save() {
         this.saveRequested = true;
      }

      public void SetAutoCharge(bool value) {
         this.MyComputerSystem.Auto_Recharge = value;
      }

      public void SetAutoUpgrade(bool value) {
         this.MyComputerSystem.Auto_Upgrade = value;
      }
      #endregion
      #region private methods
      private bool OverwatchPage() {
         if (this.saveRequested) {
            this.saveRequested = false;
            this.HackingSystem.Save();
         }

         try {
            if (this.References.Browser != null) {
               this.References.Browser.Invoke(new Action(
                  () => {
                     this.ProcessPage();
                  }
               ));
            }
         } catch (Exception e) { }

         return true;
      }

      private void ProcessPage() {
         if (this.References.Browser.Document == null)
            return;

         if (!this.References.IsSet()) {
            this.State.SetState(ToolBot_State.Idle);
            this.HackingSystem.Set();
            this.References.LoadReferences();
            this.References.RemoveAdBar();
         }
      }
      #endregion
      #endregion
   }
}
