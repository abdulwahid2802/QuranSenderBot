using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotNew
{
    class OnInlineCallBackHandler
    {

        internal static void HandleSurahQuery(CallbackQueryEventArgs e, TelegramBotClient bot)
        {
            isPresent(e);

            JsonData.users[e.CallbackQuery.Message.Chat.Id].langChoice = e.CallbackQuery.Data;

            List<Surahs> surahTemp  = ChooseBook(e);

            Users userTemp = JsonData.users[e.CallbackQuery.Message.Chat.Id];

            SendAyah(bot, userTemp, ButtonsHandler.NavKB, e, surahTemp);


            OnMessageHandler.MoveAyah(e.CallbackQuery.Message.Chat.Id);

        }

        private static async void SendAyah(TelegramBotClient bot, Users userTemp, ReplyKeyboardMarkup navKB, CallbackQueryEventArgs e, List<Surahs> surahTemp)
        {
            long id = userTemp.id;
            int c_ayah = userTemp.c_ayah;
            int c_surah = userTemp.c_surah;


            if (c_ayah == 0)
            {
                string surahHeader = "Name: ";
                surahHeader += surahTemp[c_surah].SurahNameAr;
                surahHeader += "\nName English: ";
                surahHeader += surahTemp[c_surah].SurahNameEn;
                surahHeader += "\nNumber: ";
                surahHeader += surahTemp[c_surah].SurahNum.ToString();
                surahHeader += "\nRevelation Type: ";
                surahHeader += surahTemp[c_surah].SurahRevType;

                try
                {
                    await bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, surahHeader);
                }
                catch (Telegram.Bot.Exceptions.ApiRequestException ex)
                {
                    Console.WriteLine("EXCEPTION " + userTemp.name + ex.Message);
                }
            }

            //sending ayah text
            try
            {
                await bot.SendTextMessageAsync
                    (
                        e.CallbackQuery.Message.Chat.Id,
                        "Oyat Raqami: " + surahTemp[c_surah].Ayahs[c_ayah]["number"].ToString() + "\n" + surahTemp[c_surah].Ayahs[c_ayah]["text"]
                        );
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine("EXCEPTION " + userTemp.name + ex.Message);
            }

            // seding audio
            try
            {
                await bot.SendTextMessageAsync(
                    e.CallbackQuery.Message.Chat.Id, 
                    "http://cdn.alquran.cloud/media/audio/ayah/ar.alafasy/" + surahTemp[c_surah].Ayahs[c_ayah]["number"].ToString(),
                    Telegram.Bot.Types.Enums.ParseMode.Default,
                    false,
                    false,
                    0,
                    ButtonsHandler.NavKB
                    );
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine("EXCEPTION " + userTemp.name + ex.Message);
            }

        }

        private static List<Surahs> ChooseBook(CallbackQueryEventArgs e)
        {
            var data = e.CallbackQuery.Data; 

            

            if(ButtonsHandler.surahNamesUz.Contains(data))
            {
                return JsonData.surahsUz;
            }
            else if (ButtonsHandler.surahNamesAr.Contains(data))
            {
                return JsonData.surahsAr;
            }
            else return JsonData.surahsAr;
        }

        private static void isPresent(CallbackQueryEventArgs e)
        {
            long id = e.CallbackQuery.Message.Chat.Id;

            int i = SurahCoordinate(e);
            Console.WriteLine(i.ToString() + " " + e.CallbackQuery.Message.Chat.Id);
            if (!JsonData.users.ContainsKey(id))
            {
                Users user = new Users
                    (
                        id,
                        e.CallbackQuery.Message.From.LastName + " " + e.CallbackQuery.Message.From.FirstName,
                        i,
                        0
                    );
                JsonData.users.Add(id, user);
                Console.WriteLine(JsonData.users[id].ToString() +  " \n" + JsonData.users[id].c_surah + " " + JsonData.users[id].langChoice);
            }
            else
            {
                JsonData.users[id].c_surah = i;
                JsonData.users[id].c_ayah = 0;

                Console.WriteLine(JsonData.users[id].ToString() + " ISSOSSO" + i);
            }
        }

        private static int SurahCoordinate(CallbackQueryEventArgs e)
        {
            var data = e.CallbackQuery.Data;
            if (ButtonsHandler.surahNamesUz.Contains(data))
            {
                return Array.IndexOf(ButtonsHandler.surahNamesUz, data);
            }
            else if (ButtonsHandler.surahNamesAr.Contains(data))
            {
                return Array.IndexOf(ButtonsHandler.surahNamesAr, data);
            }
            else return 1;
        }
    }
}
