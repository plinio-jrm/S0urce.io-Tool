namespace S0urce.io_tool.Harvesters {
   public class WindowSucessHarvester: BaseHarvester {
      public bool Suceed() {
         return (!this.References.WindowHackSucessfulRef.Window.Style.Contains("display"));
      }

      public void SendHackingMessage(string hackingMessage) {
         this.References.WindowHackSucessfulRef.Input.SetAttribute("value", hackingMessage);
         this.SendHackingMessage();
      }

      public void SendHackingMessage(bool send = true) {
         if (send) {
            this.References.WindowHackSucessfulRef.SendButton.InvokeMember("click");
         } else
            this.References.WindowHackSucessfulRef.OkayButton.InvokeMember("click");
      }
   }
}
