using System;
using System.Collections.Generic;
using System.Threading;

namespace S0urce.io_tool.Bot {
   public class ToolBot {
      #region variables
      public GameReferences References;
      public StateSystem State;

      private Dictionary<string, string> dictionaryOfWords;
      private Thread overwatchPageThread;
      private string wordHack;
      private int hackingProgress;
      private int progressHaltCount;
      private int progressHaltCountStrikes;

      private bool OverwatchStop = false;
      private bool databaseLoaded = false;
      private bool saveRequested = false;
      private int delayTime = 900;
      #endregion
      #region methods
      public ToolBot() {
         this.State = new StateSystem();
      }

      public void Start() {
         this.State.SetState(ToolBot_State.Deactivated);
         this.overwatchPageThread = new Thread(new ThreadStart(OverwatchPage));
         this.overwatchPageThread.Start();
         this.State.SetState(ToolBot_State.Initializing);
      }

      public void Stop() {
         this.overwatchPageThread.Abort();
      }

      public void IncreaseDelay() {
         this.delayTime += 50;
      }

      public void DecreasyDelay() {
         if (this.delayTime > 600)
            this.delayTime -= 50;
      }

      private void OverwatchPage() {
         this.LoadDatabase();

         while(!this.OverwatchStop) {
            if (this.saveRequested)
               this.SaveProgress();

            try {
               if (this.References.Browser != null) {
                  this.References.Browser.Invoke(new Action(
                     () => {
                        this.ProcessPage();
                     }
                  ));
               }
            } catch (Exception e) { }
            Thread.Sleep(this.delayTime);
         }
         this.SaveProgress();
      }

      private void LoadDatabase() {
         DatabaseSystem DBS = new DatabaseSystem();
         this.dictionaryOfWords = DBS.Load();

         if (this.dictionaryOfWords == null)
            this.dictionaryOfWords = new Dictionary<string, string>();
      }

      public void Save() {
         this.saveRequested = true;
      }

      private void SaveProgress() {
         this.saveRequested = false;
         DatabaseSystem DBS = new DatabaseSystem();
         DBS.Save(dictionaryOfWords);
      }

      private void ProcessPage() {
         if (this.References.Browser.Document == null)
            return;

         if (!this.References.IsSet()) {
            this.State.SetState(ToolBot_State.Idle);
            this.hackingProgress = -1;
            this.progressHaltCount = 0;
            this.progressHaltCountStrikes = 0;
            this.References.SetReferences();
            this.References.RemoveAdBar();
         }

         this.TryLoadDatabase();
         this.ProcessHacking();
      }

      private void TryLoadDatabase() {
         if (this.databaseLoaded)
            return;

         this.databaseLoaded = true;

      }

      private void ProcessHacking() {
         if (!this.IsHackingSomeone()) {
            this.State.SetState(ToolBot_State.Idle);
            return;
         }

         this.State.SetState(ToolBot_State.Hacking);
         string wordID = this.References.GetToolTipID();
         if (wordID.Trim().Equals(""))
            return;

         int hacking_Progress = this.References.GetHackingProgress();

         if (!this.dictionaryOfWords.ContainsKey(wordID)) {
            this.State.SetState(ToolBot_State.HackingNewWord);
            InputHackWord.Show(OnNewWordInput, wordID);

            if (!this.wordHack.Equals(string.Empty)) {
               this.dictionaryOfWords.Add(wordID, this.wordHack);
               this.State.SetState(ToolBot_State.Hacking);
            } else
               return;
         } else {
            if (hacking_Progress == this.hackingProgress) {
               ++this.progressHaltCount;
               if (this.progressHaltCount < 2) {
                  return;
               } else {
                  this.progressHaltCount = 0;
                  ++this.progressHaltCountStrikes;

                  // the word saved is wrong. Delete it to re-add
                  if (this.progressHaltCountStrikes >= 2) {
                     this.progressHaltCountStrikes = 0;
                     this.dictionaryOfWords.Remove(wordID);
                     return;
                  }
               }
            } else {
               this.progressHaltCount = 0;
               this.progressHaltCountStrikes = 0;
            }

            this.wordHack = this.dictionaryOfWords[wordID];
         }
         
         this.References.sendHackingWord(this.wordHack);
         this.wordHack = string.Empty;
         this.hackingProgress = hacking_Progress;
      }

      private void OnNewWordInput(string word) {
         this.wordHack = word;
      }

      private bool IsHackingSomeone() {
         if (this.References.WindowToolDisplayed()) {
            return (this.References.WindowToolTypingHintDisplayed());
         }

         return false;
      }
      #endregion
   }
}
