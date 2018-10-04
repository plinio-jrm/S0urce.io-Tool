using S0urce.io_tool.Harvesters;
using S0urce.io_tool.Tool;
using System;
using System.Collections.Generic;

namespace S0urce.io_tool.BotSystem {
   public class HackingSystem: BaseSystem {
      #region events
      public event stateChangeEvent OnStateChange;
      #endregion
      #region variables
      private WindowToolHarvester Harvester;
      private WindowSucessHarvester SucessHarvester;
      private string wordHack;
      private string hackingMessage;
      private bool hackingMessageActive;
      private int hackingProgress;
      private int progressHaltCount;
      private int progressHaltCountStrikes;
      private Dictionary<string, string> dictionaryOfWords;
      #endregion

      public HackingSystem() {
         this.dictionaryOfWords = new Dictionary<string, string>();
         this.Harvester = new WindowToolHarvester();
         this.SucessHarvester = new WindowSucessHarvester();
         this.hackingMessageActive = true;
      }

      public override void Setup() {
         this.Harvester.SetReference(this.References);
         this.SucessHarvester.SetReference(this.References);
      }

      public override bool Process() {
         if (!base.Process())
            return false;

         if (!this.IsHackingSomeone()) {
            this.OnStateChange(ToolBot_State.Idle);
            return false;
         }

         string wordID = this.Harvester.GetToolTipID();
         if (wordID.Trim().Equals("")) {
            this.CheckForSuccess();
            this.OnStateChange(ToolBot_State.Idle);
            return false;
         }

         this.OnStateChange(ToolBot_State.Hacking);
         int hacking_Progress = this.Harvester.GetHackingProgress();

         if (!this.dictionaryOfWords.ContainsKey(wordID)) {
            this.OnStateChange(ToolBot_State.HackingNewWord);
            InputHackWord.Show(OnNewWordInput, wordID);

            if (!this.wordHack.Equals(string.Empty)) {
               this.dictionaryOfWords.Add(wordID, this.wordHack);
               this.OnStateChange(ToolBot_State.Hacking);
            } else
               return false;
         } else {
            if (hacking_Progress == this.hackingProgress) {
               ++this.progressHaltCount;
               if (this.progressHaltCount < 2) {
                  return false;
               } else {
                  this.progressHaltCount = 0;
                  ++this.progressHaltCountStrikes;

                  // the word saved is wrong. Delete it to re-add
                  if (this.progressHaltCountStrikes >= 2) {
                     this.progressHaltCountStrikes = 0;
                     this.dictionaryOfWords.Remove(wordID);
                     return false;
                  }
               }
            } else {
               this.progressHaltCount = 0;
               this.progressHaltCountStrikes = 0;
            }

            this.wordHack = this.dictionaryOfWords[wordID];
         }

         this.Harvester.sendHackingWord(this.wordHack);
         this.wordHack = string.Empty;
         this.hackingProgress = hacking_Progress;
         return true;
      }

      #region methods
      public void LoadDatabase() {
         DatabaseSystem DBS = new DatabaseSystem();
         this.dictionaryOfWords = DBS.Load();

         if (this.dictionaryOfWords == null)
            this.dictionaryOfWords = new Dictionary<string, string>();
      }

      public void Save() {
         DatabaseSystem DBS = new DatabaseSystem();
         DBS.Save(dictionaryOfWords);
      }

      public void Set() {
         this.hackingProgress = -1;
         this.progressHaltCount = 0;
         this.progressHaltCountStrikes = 0;
      }

      public void SetHackingMessageActive(bool enable) {
         this.hackingMessageActive = enable;
      }

      public void SetHackingMessage(string message) {
         this.hackingMessage = message;
      }

      private void CheckForSuccess() {
         if (!this.SucessHarvester.Suceed())
            return;

         this.OnStateChange(ToolBot_State.HackingSucess);
         if (this.hackingMessageActive) {
            this.SucessHarvester.SendHackingMessage(this.hackingMessage);
         } else
            this.SucessHarvester.SendHackingMessage(false);

         this.Save();
      }

      private void OnNewWordInput(string word) {
         this.wordHack = word;
      }

      private bool IsHackingSomeone() {
         if (this.Harvester.WindowToolDisplayed()) {
            return (this.Harvester.WindowToolTypingHintDisplayed());
         }

         return false;
      }
      #endregion
   }
}
