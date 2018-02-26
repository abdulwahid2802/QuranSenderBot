using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotNew
{
    public class Surahs
    {
        public List<JsonValue> Ayahs = new List<JsonValue>();
        public JsonValue SurahNum;
        public JsonValue SurahNameAr;
        public JsonValue SurahNameEn;
        public JsonValue SurahRevType;
    }
}
