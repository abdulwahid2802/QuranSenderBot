using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using System.Net.Http;
using System.Data.SqlClient;

namespace TelegramBotNew
{
    class Program
    {
        static TelegramBotClient bot;


        static void Main(string[] args)
        {

            Console.WriteLine("Json is loading...");
            try
            {
                JsonData.InitJson();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "I GOT YOU");
            }

            try
            {
                bot = new TelegramBotClient("365015286:AAED8kb8oncNHdruQcDpTk_WaRNFjeHm8Lo");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "I GOT YOU");
            }


            try
            {
            bot.StartReceiving();
            bot.OnMessage += Bot_OnMessage;
            bot.OnCallbackQuery += Bot_OnCallbackQuery;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "I GOT YOU");
            }
            //bot.OnInlineQuery += Bot_OnInlineQuery;
            Console.ReadLine();

        }



        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            OnMessageHandler.MessageHandler(sender, e, bot);
        }



        private static async void Bot_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.CallbackQuery.Data))
            {
                var data = e.CallbackQuery.Data;
                var cid = e.CallbackQuery.Message.Chat.Id;
                var cbid = e.CallbackQuery.Id;




                Console.WriteLine(e.CallbackQuery.Message.Chat.FirstName + " " + e.CallbackQuery.Message.Chat.LastName + " " + e.CallbackQuery.Data);

                OnInlineCallBackHandler.HandleSurahQuery(e, bot);

                try
                {
                    await bot.AnswerCallbackQueryAsync(cbid, data);
                }
                catch (Telegram.Bot.Exceptions.ApiRequestException ex)
                {
                    Console.WriteLine(e.CallbackQuery.Message.Chat.Id + " EXCEPTION" + ex.Message);
                };

            }
        }

       

    }
}
