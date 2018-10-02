using S0urce.io_tool.Tool;

namespace S0urce.io_tool.Harvesters {
   public class BaseHarvester {
      protected GameReferences References;

      public void SetReference(GameReferences references) {
         this.References = references;
      }
   }
}
