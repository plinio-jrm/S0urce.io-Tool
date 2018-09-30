using S0urce.io_tool.Tool;

namespace S0urce.io_tool.BotSystem {
   public abstract class DefaultSystem {
      #region variables
      protected GameReferences References;
      #endregion
      #region methods
      public abstract void Process();

      public void SetReferences(GameReferences references) {
         this.References = references;
      }
      #endregion
   }
}
