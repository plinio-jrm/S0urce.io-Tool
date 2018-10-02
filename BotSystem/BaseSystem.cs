using S0urce.io_tool.Tool;

namespace S0urce.io_tool.BotSystem {
   public class BaseSystem: AbstractSystem {
      #region variables
      protected GameReferences References;
      #endregion
      #region methods
      public override void Setup() { }

      public override bool Process() {
         if (!this.References.IsSet())
            return false;

         if (!this.References.Logged())
            return false;

         return true;
      }

      public void SetReferences(GameReferences references) {
         this.References = references;
      }
      #endregion
   }
}
