using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S0urce.io_Crawler.Crawler {
   public class DatabaseSystem {
      private const string FILE_NAME = "dbs.dat";

      public void Save(Dictionary<string, string> words) {
         this.PreprareToSave();

         using (StreamWriter writer = new StreamWriter(FILE_NAME, true)) {
            string[] IDs = words.Keys.ToArray();
            for (int i = 0; i < IDs.Length; ++i) {
               string ID = IDs[i];
               string Word = words[ID];
               string line = ID + ";" + Word;

               writer.WriteLine(line);
            }
         }
      }

      public Dictionary<string, string> Load() {
         if (!this.DBExist())
            return null;

         Dictionary<string, string> words = new Dictionary<string, string>();

         using (StreamReader reader = new StreamReader(FILE_NAME)) {
            string line = string.Empty;
            while ((line = reader.ReadLine()) != null) {
               string[] Hack = line.Split(';');
               string ID = Hack[0];
               string word = Hack[1];

               if (words.ContainsKey(ID))
                  continue;

               words.Add(ID, word);
            }
         }

         return words;
      }

      private bool DBExist() {
         return (File.Exists(FILE_NAME));
      }

      private void PreprareToSave() {
         if (this.DBExist()) {
            File.Delete(FILE_NAME);
         }
      }
   }
}
