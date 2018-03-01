using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TelegramBotNew
{
    class JsonData
    {
        public static Dictionary<long, Users> users = new Dictionary<long, Users>();

        private static string pathToJsonUz = "http://api.alquran.cloud/quran/uz.sodik";
        private static string pathToJsonAr = "http://api.alquran.cloud/quran/quran-uthmani";

        public string headerheaderMsg = "";

        public static JsonValue jsonUz;
        public static JsonValue jsonAr;

        public static JsonValue jsonUz_data;
        public static JsonValue jsonAr_data;

        public static JsonValue jsonUz_surahs;
        public static JsonValue jsonAr_surahs;


        public static List<Surahs> surahsUz = new List<Surahs>();
        public static List<Surahs> surahsAr = new List<Surahs>();





        public static void InitValues()
        {
            
            //data field
            jsonUz_data = jsonUz["data"];
            jsonAr_data = jsonAr["data"];

            //surahs field of json data
            jsonUz_surahs = jsonUz_data["surahs"];
            jsonAr_surahs = jsonAr_data["surahs"];

            foreach (JsonValue surah in jsonUz_surahs)
            {
                Surahs mSurah = new Surahs();

                mSurah.SurahNameAr = surah["name"];
                mSurah.SurahNameEn = surah["englishName"];
                mSurah.SurahNum = surah["number"];
                mSurah.SurahRevType = surah["revelationType"];

                JsonValue Ayahs = surah["ayahs"];
                foreach(JsonValue ayah in Ayahs)
                {
                    mSurah.Ayahs.Add(ayah);
                }
                surahsUz.Add(mSurah);

            }

            foreach (JsonValue surah in jsonAr_surahs)
            {
                Surahs mSurah = new Surahs();

                mSurah.SurahNameAr = surah["name"];
                mSurah.SurahNameEn = surah["englishName"];
                mSurah.SurahNum = surah["number"];
                mSurah.SurahRevType = surah["revelationType"];

                JsonValue Ayahs = surah["ayahs"];
                foreach (JsonValue ayah in Ayahs)
                {
                    mSurah.Ayahs.Add(ayah);
                }
                surahsAr.Add(mSurah);

            }

            

        }

        private static string GetHeader(JsonValue json, int index)
        {

            string headerMsg = "";

            JsonValue data = json["data"];
            JsonValue surahs = data["surahs"];
            JsonValue number = surahs[index]["number"];
            headerMsg += ("Number: " + number.ToString() + "\n");
            JsonValue name = surahs[index]["name"];
            headerMsg += ("Name: " + name + "\n");
            JsonValue englishName = surahs[index]["englishName"];
            headerMsg += ("English Name: " + englishName + "\n");
            JsonValue englishNameTranslation = surahs[index]["englishNameTranslation"];
            headerMsg += ("English Name Translation: " + englishNameTranslation + "\n");
            JsonValue revelationType = surahs[index]["revelationType"];
            headerMsg += ("Revelation Type: " + revelationType + "\n\n\n");

            return headerMsg;

        }

        public static async void InitJson()
        {
            ButtonsHandler.LanguagesButton();
            ButtonsHandler.SurahKeysInit();
            ButtonsHandler.NavigationButtons();

            jsonUz = await Task.Run(() =>  FetchSurahsAsync(pathToJsonUz));
            jsonAr = await Task.Run(() => FetchSurahsAsync(pathToJsonAr));

            Console.WriteLine("Json successfully loaded from net!");
            InitValues();

        }

        private static async Task<JsonValue> FetchSurahsAsync(string url)
        {
            //// Get a stream representation of the HTTP web response:
            //using (Stream stream = File.OpenRead(path))
            //{
            //    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));

            //    // Return the JSON document:
            //    return jsonDoc;
            //}
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));

                    // Return the JSON document:
                    return jsonDoc;
                }
            }

        }




    }
}
