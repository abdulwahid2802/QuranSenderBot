using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotNew
{
    public static class OnMessageHandler
    { 
        static ReplyKeyboardMarkup kb = new ReplyKeyboardMarkup();

        private static string initMessage = "*****************************" +
                                            "* Assalomu Aleykum, mening  \n*" +
                                            "*ismim Qur'onSender. Vazifam\n*" +
                                            "*    sizga Qur'oni Karimni  \n*" +
                                            "* telfonizga yetkazish.     \n*" +
                                            "*****************************\n" +
                                            "1. Tilni tanlang\n" +
                                            "2. Surani tanlang\n" +
                                            "3. Suralar oyatma oyat keladi" +
                                            "4. Oyatni tugatgach NEXT ni \nbosing" +
                                            "5. Boshga qaytish uchun /start \nso'zini yuboring!" +
                                            "ALL PRAISES DUE TO ALLAH ALONE!";


        public static void MessageHandler(object sender, MessageEventArgs e, TelegramBotClient bot)
        {
            var cid = e.Message.Chat.Id;
            var name = e.Message.Chat.LastName + " " + e.Message.Chat.FirstName;
            var username = e.Message.From.Username;
            var txt = e.Message.Text;
            var userId = e.Message.Chat.Id;


            isPresent(userId, e);


            Console.WriteLine(cid.ToString() + " " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + " " + txt);


            switch (txt)
            {
                case "/start":
                    FirsTime(e, bot);
                    break;
                case "English":
                    SendInlineKeyBoard(e, bot);
                    break;
                case "O'zbek tili":
                    SendInlineKeyBoard(e, bot);
                    break;
                case "русский":
                    SendInlineKeyBoard(e, bot);
                    break;
                case "Arabic":
                    SendInlineKeyBoard(e, bot);
                    break;
                case "Boshiga":
                    FirsTime(e, bot);
                    break;
                case "ortga":
                    SendInlineKeyBoard(e, bot);
                    break;
                case "keyingi":
                    NextAyahHandler(e, bot);
                    break;
                default:
                    break;
            }



        }

        private static void NextAyahHandler(MessageEventArgs e, TelegramBotClient bot)
        {
            if(isPresent(e.Message.Chat.Id, e))
            {
                List<Surahs> surahTemp = ChooseBook(e);

                Users userTemp = JsonData.users[e.Message.Chat.Id];

                //SendAyah(e, bot, surahTemp, userTemp);

                MoveAyah(e.Message.Chat.Id);
            }
            else
            {
                SendInlineKeyBoard(e, bot);
            }
        }

        public static void MoveAyah(long id)
        {
            if (!((JsonData.users[id].c_ayah + 1) == JsonData.surahsAr[JsonData.users[id].c_surah].Ayahs.Count))
            {
                JsonData.users[id].c_ayah += 1;
            }
            else
            {
                JsonData.users[id].c_ayah = 0;

                if (JsonData.users[id].c_surah != 113)
                    JsonData.users[id].c_surah += 1;
                else
                    JsonData.users[id].c_surah = 0;
            }
        }

        private static async void SendAyah(MessageEventArgs e, TelegramBotClient bot, List<Surahs> surahTemp, Users userTemp)
        {
            long id = userTemp.id;
            int c_ayah = userTemp.c_ayah;
            int c_surah = userTemp.c_surah;

            //sending ayah text
            try
            {
                await bot.SendTextMessageAsync
                    (
                        e.Message.Chat.Id,
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
                    e.Message.Chat.Id,
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

        private static List<Surahs> ChooseBook(MessageEventArgs e)
        {
            var data = JsonData.users[e.Message.Chat.Id].langChoice;

            if (ButtonsHandler.surahNamesUz.Contains(data))
            {
                return JsonData.surahsUz;
            }
            else if (ButtonsHandler.surahNamesAr.Contains(data))
            {
                return JsonData.surahsAr;
            }
            else return JsonData.surahsAr;
        }

        private static bool isPresent(long userId, MessageEventArgs e)
        {
            if(!JsonData.users.ContainsKey(userId))
            {
                Users user = new Users(userId, e.Message.From.LastName + " " + e.Message.From.FirstName, 0, 0);

                JsonData.users.Add(userId, user);
                Console.WriteLine("New added" + e.Message.Chat.Id);

                return false;
            }

            return true;
        }

        private static async void SendInlineKeyBoard(MessageEventArgs e, TelegramBotClient bot)
        {
            List<InlineKeyboardMarkup> km = new List<InlineKeyboardMarkup>();
            switch(e.Message.Text)
            {
                case "O'zbek tili":
                    km = ButtonsHandler.SurahKeysUz;
                    break;
                case "Arabic":
                    km = ButtonsHandler.SurahKeysAr;
                    break;
                case "English":
                    km = ButtonsHandler.SurahKeysEn;
                    break;
                default:
                    km = ButtonsHandler.SurahKeysRu;
                    break;
            }

            try
            {
                await bot.SendTextMessageAsync(e.Message.Chat.Id, "Surani tanlang", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, e.Message.MessageId, km[0]);
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(e.Message.Chat.Id + " EXCEPTION" + ex.Message);
            };


            try
            {
                await  bot.SendTextMessageAsync(e.Message.Chat.Id, "Surani tanlang", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, e.Message.MessageId, km[1]);
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(e.Message.Chat.Id + " EXCEPTION" + ex.Message);
            };


        }

        private static async void FirsTime(MessageEventArgs e, TelegramBotClient bot)
        {
            //sends the keyboard that is made in initvalues method
            try
            {
                await bot.SendTextMessageAsync(e.Message.Chat.Id, initMessage, Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonsHandler.LangKB);
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(e.Message.Chat.Id + " EXCEPTION" + ex.Message);
            };
        }



    }
}
