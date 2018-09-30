using System.Threading;

namespace S0urce.io_tool.BotSystem {
   public delegate void OverwatchMethodCall();

   public class OverwatchSystem {
      #region constants
      private const int DEFAULT_DELAY = 100;
      private const int HACKING_DELAY_CHANGE = 50;
      private const int HACKING_DELAY_MIN = 600;
      #endregion
      #region events
      public event OverwatchMethodCall OnMainOverwatch;
      public event OverwatchMethodCall OnHacking;
      public event OverwatchMethodCall OnDataMiner;
      #endregion
      #region variables
      private Thread mainThread;
      private Thread hackingThread;
      private Thread dataMinerThread;

      private int hackingDelayTime;
      #endregion

      public OverwatchSystem() {
         this.hackingDelayTime = 900;
      }

      #region public methods
      public void Start() {
         this.mainThread = new Thread(new ThreadStart(this.MainThreadMethod));
         this.hackingThread = new Thread(new ThreadStart(this.HackingThreadMethod));
         this.dataMinerThread = new Thread(new ThreadStart(this.DataMinerMethod));

         this.mainThread.Start();
         this.hackingThread.Start();
         this.dataMinerThread.Start();
      }

      public void Stop() {
         this.mainThread.Abort();
         this.hackingThread.Abort();
         this.dataMinerThread.Abort();
      }

      public void IncreasyDelay() {
         this.hackingDelayTime += HACKING_DELAY_CHANGE;
      }

      public void DecreasyDelay() {
         if (this.hackingDelayTime > HACKING_DELAY_MIN)
            this.hackingDelayTime -= HACKING_DELAY_CHANGE;
      }
      #endregion
      #region thread methods
      private void MainThreadMethod() {
         while (true) {
            if (this.OnMainOverwatch != null)
               this.OnMainOverwatch();
            Thread.Sleep(DEFAULT_DELAY);
         }
      }

      private void HackingThreadMethod() {
         while (true) {
            if (this.OnHacking != null)
               this.OnHacking();
            Thread.Sleep(this.hackingDelayTime);
         }
      }

      private void DataMinerMethod() {
         while (true) {
            if (this.OnDataMiner != null)
               this.OnDataMiner();
            Thread.Sleep(DEFAULT_DELAY);
         }
      }
      #endregion
   }
}
