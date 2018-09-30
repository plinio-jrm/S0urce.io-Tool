using S0urce.io_tool.Tool;
using System.Collections.Generic;

namespace S0urce.io_tool.BotSystem {
   public class HackingSystem: DefaultSystem {
      #region events
      public event stateChangeEvent OnStateChange;
      #endregion
      #region variables
      private string wordHack;
      private int hackingProgress;
      private int progressHaltCount;
      private int progressHaltCountStrikes;
      private Dictionary<string, string> dictionaryOfWords;
      #endregion

      public HackingSystem() {
         this.dictionaryOfWords = new Dictionary<string, string>();
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

      public override void Process() {
         if (!this.References.IsSet())
            return;

         if (!this.IsHackingSomeone()) {
            this.OnStateChange(ToolBot_State.Idle);
            return;
         }

         string wordID = this.References.GetToolTipID();
         if (wordID.Trim().Equals("")) {
            this.OnStateChange(ToolBot_State.Idle);
            return;
         }

         this.OnStateChange(ToolBot_State.Hacking);
         int hacking_Progress = this.References.GetHackingProgress();

         if (!this.dictionaryOfWords.ContainsKey(wordID)) {
            this.OnStateChange(ToolBot_State.HackingNewWord);
            InputHackWord.Show(OnNewWordInput, wordID);

            if (!this.wordHack.Equals(string.Empty)) {
               this.dictionaryOfWords.Add(wordID, this.wordHack);
               this.OnStateChange(ToolBot_State.Hacking);
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
