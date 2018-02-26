using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotNew
{
    public class Users
    {
          public long id { get; set; }
          public string name { get;  set; }
          public int c_surah { get;  set; }
          public int c_ayah { get;  set; }
          public string langChoice { get; set; }

        public Users(long id, string name, int csurah, int cayah, string langChoice)
        {
            this.c_ayah = cayah;
            this.c_surah = csurah;
            this.id = id;
            this.name = name;
            this.langChoice = langChoice;
        }

        public Users(long id, string name, int csurah, int cayah)
        {
            this.c_ayah = cayah;
            this.c_surah = csurah;
            this.id = id;
            this.name = name;
            
        }

    }
}
