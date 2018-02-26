using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotNew
{
    public class ButtonsHandler
    {
        public static string[] surahNamesUz = new[] {
        "Fotiha",
        "Baqara",
        "Oli Imron",
        "Niso",
        "Moida",
        "An\'om",
        "A\'rof",
        "Anfol",
        "Tavba",
        "Yunus",
        "Hud",
        "Yusuf",
        "Ra\'d",
        "Ibdohim",
        "Xijr",
        "Nahl",
        "Isro",
        "Kahf",
        "Maryam",
        "Toxo",
        "Anbiyo",
        "Haj",
        "Mo\'minun",
        "Nur",
        "Furqon",
        "Shuaro",
        "Naml",
        "Qasos",
        "Ankabut",
        "Rum",
        "Luqmon",
        "Sajda",
        "Ahzob",
        "Saba\'",
        "Fotir",
        "Yosin",
        "As-Saffot",
        "Sod",
        "Zumar",
        "Gʻofir",
        "Fussilat",
        "Shuro",
        "Zuhruf",
        "Duxon",
        "Josiya",
        "Ahqof",
        "Muhammad",
        "Fath",
        "Hujurot",
        "Qof",
        "Zariyat",
        "Tur",
        "Najm",
        "Qamar",
        "Rahmon",
        "Voqea",
        "Hadid",
        "Mujodala",
        "Xashr",
        "Mumtahana",
        "Saf",
        "Juma",
        "Munofiqun",
        "Tagʻobun",
        "Taloq",
        "Tahrim",
        "Mulk",
        "Qalam",
        "Haaqqah",
        "Ma\'orij",
        "Nuh",
        "Jin",
        "Muzzammil",
        "Muddassir",
        "Qiyomat",
        "Inson",
        "Mursalat",
        "Naba",
        "Naziyat",
        "Abasa",
        "Takvir",
        "Infitor",
        "Mutaffifun",
        "Inshiqoq",
        "Buruj",
        "Toriq",
        "A\'lo",
        "Gʻoshiya",
        "Fajr",
        "Balad",
        "Shams",
        "Layl",
        "Zuho",
        "Sharh",
        "Tiyn",
        "Alaq",
        "Qadr",
        "Bayyina",
        "Zalzala",
        "Odiyot",
        "Qori\'a",
        "Takasur",
        "Asr",
        "Humaza",
        "Fil",
        "Quraysh",
        "Mo\'un",
        "Kavsar",
        "Kofirun",
        "Nasr",
        "Masad",
        "Ixlos",
        "Falaq",
        "Nos"
        };
        public static string[] surahNamesRu = new[]
        {
            "Аль-Фатиха",
    "Аль-Бакара",
    "Аль \'Имран",
    "Ан-Ниса\'",
    "Аль-Ма\'ида",
    "Аль-Ан\'ам",
    "Аль-А\'раф",
    "Аль-Анфаль",
    "Ат-Тауба",
    "Йунус",
    "Худ",
    "Йусуф",
    "Ар-Ра\'д",
    "Ибрахим",
    "Аль-Хиджр",
    "Ан-Нахль",
    "Аль-Исра\'",
    "Аль-Кахф",
    "Марйам",
    "Та Ха",
    "Аль-Анбийа\'",
    "Аль-Хаджж",
    "Аль-Му\'МИНУН",
    "Ан-Нур",
    "Аль-Фуркан",
    "Аш-Шу\'ара\'",
    "Ан-Намль",
    "Аль-Касас",
    "Аль-\'Нкабут",
    "Ар-Рум",
    "Лукман",
    "Ас-Саджда",
    "Аль-Ахзаб",
    "Саба\'",
    "Фатыр",
    "Йа Син",
    "Ас-Саффат",
    "Сад",
    "Аз-Зумар",
    "Гафер",
    "Фуссилат",
    "Аш-Шура",
    "Аз-Зухруф",
    "Ад-Духан",
    "Аль-Джасийа",
    "Аль-Ахкаф",
    "Мухаммад",
    "Аль-Фатх",
    "Аль-Худжурат",
    "Каф",
    "Аз-Зарийат",
    "Ат-Тур",
    "Ан-Наджм",
    "Аль-Камар",
    "Ар-Рахман",
    "Аль-Ваки\'а",
    "Аль-Хадид",
    "Аль-Муджадала",
    "Аль-Хашр",
    "Аль-Мумтахана",
    "Ас-Сафф",
    "Аль-Джуму\'а",
    "Аль-Мунафикун",
    "Ат-Тагабун",
    "Ат-Талак",
    "Ат-Тахрим",
    "Аль-Мульк",
    "Аль-Калам",
    "Аль-Хакка",
    "Аль-Ма\'аридж",
    "Нух",
    "Аль-Джинн",
    "Аль-Муззаммиль",
    "Аль-Мудассир",
    "Аль-Кийама",
    "Аль-Инсан",
    "Аль-Мурсалят",
    "Ан-Наба\'",
    "Ан-Нази\'ат",
    "\'Абаса",
    "Ат-Таквир",
    "Аль-Инфитар",
    "Аль-Мутаффифин",
    "Аль-Иншикак",
    "Аль-Бурудж",
    "Ат-Тарик",
    "Аль-А\'ла",
    "Аль-Гашийа",
    "Аль-Фаджр",
    "Аль-Балад",
    "Аш-Шамс",
    "Аль-Лайл",
    "Ад-Духа",
    "Аш-Шарх",
    "Ат-Тин",
    "Аль-Алак",
    "Аль-Кадр",
    "Аль-Баййина",
    "Аз-Залзала",
    "Аль-Адийат",
    "Аль-Кари\'а",
    "Ат-Такасур",
    "Аль-\'Аср",
    "Аль-Хумаза",
    "Аль-Филь",
    "Курайш",
    "Аль-Ма\'ун",
    "Аль-Каусар",
    "Аль-Кафирун",
    "Ан-Наср",
    "Аль-Масад",
    "Аль-Ихлас",
    "Аль-Фалак",
    "Ан-Нас",
        };
        public static string[] surahNamesEn = new[]
        {
            "Al-Fatihah",
    "Al-Baqarah",
    "Aal-E-Imran",
    "An-Nisa\'",
    "Al-Ma\'idah",
    "Al-An\'am",
    "Al-A\'raf",
    "Al-Anfal",
    "At-Tawbah",
    "Yunus",
    "Hud",
    "Yusuf",
    "Ar-Ra\'d",
    "Ibrahim",
    "Al-Hijr",
    "An-Nahl",
    "Al-Isra\'",
    "Al-Kahf",
    "Maryam",
    "Ta-Ha",
    "Al-Anbiya\'",
    "Al-Hajj",
    "Al-Mu\'minun",
    "An-Nur",
    "Al-Furqan",
    "Ash-Shu\'ara",
    "An-Naml",
    "Al-Qasas",
    "Al-Ankabut",
    "Ar-Rum",
    "Luqman",
    "As-Sajdah",
    "Al-Ahzab",
    "Saba\'",
    "Fatir",
    "Ya-Seen",
    "As-Saaffat",
    "Sad",
    "Az-Zumar",
    "Ghafir",
    "Fussilat",
    "Ash-Shura",
    "Az-Zukhruf",
    "Ad-Dukhan",
    "Al-Jathiya",
    "Al-Ahqaf",
    "Muhammad",
    "Al-Fath",
    "Al-Hujurat",
    "Qaf",
    "Adh-Dhariyat",
    "At-Tur",
    "An-Najm",
    "Al-Qamar",
    "Ar-Rahman",
    "Al-Waqi\'ah",
    "Al-Hadid",
    "Al-Mujadila",
    "Al-Hashr",
    "Al-Mumtahana",
    "As-Saf",
    "Al-Jumu\'ah",
    "Al-Munafiqun",
    "At-Taghabun",
    "At-Talaq",
    "At-Tahrim",
    "Al-Mulk",
    "Al-Qalam",
    "Al-Haqqah",
    "Al-Ma\'arij",
    "Nuh",
    "Al-Jinn",
    "Al-Muzzammil",
    "Al-Muddaththir",
    "Al-Qiyamah",
    "Al-Insan",
    "Al-Mursalat",
    "An-Naba\'",
    "An-Nazi\'at",
    "\'Abasa",
    "At-Takwir",
    "Al-Infitar",
    "Al-Mutaffifin",
    "Al-Inshiqaq",
    "Al-Buruj",
    "At-Tariq",
    "Al-A\'la",
    "Al-Ghashiyah",
    "Al-Fajr",
    "Al-Balad",
    "Ash-Shams",
    "Al-Layl",
    "Ad-Dhuhaa",
    "Al-Sharh",
    "At-Tin",
    "Al-Alaq",
    "Al-Qadr",
    "Al-Bayyinah",
    "Az-Zalzalah",
    "Al-Adiyat",
    "Al-Qari\'ah",
    "At-Takathur",
    "Al-Asr",
    "Al-Humazah",
    "Al-Fil",
    "Quraysh",
    "Al-Ma\'un",
    "Al-Kawthar",
    "Al-Kafirun",
    "An-Nasr",
    "Al-Masad",
    "Al-Ikhlas",
    "Al-Falaq",
    "An-Nas"
        };
        public static string[] surahNamesAr = new[]
        {
            "الفاتحة",
        "البقرة",
        "آل عمران",
        "النساء",
        "المائدة",
        "اﻷنعام",
        "اﻷعراف",
        "اﻷنفال",
        "التوبة",
        "يونس",
        "هود",
        "يوسف",
        "الرعد",
        "إبراهيم",
        "الحجر",
        "النحل",
        "اﻹسراء",
        "الكهف",
        "مريم",
        "طه",
        "اﻷنبياء",
        "الحج",
        "المؤمنون",
        "النور",
        "الفرقان",
        "الشعراء",
        "النمل",
        "القصص",
        "العنكبوت",
        "الروم",
        "لقمان",
        "السجدة",
        "اﻷحزاب",
        "سبأ",
        "فاطر",
        "يس",
        "الصافات",
        "ص",
        "الزمر",
        "غافر",
        "فصلت",
        "الشورى",
        "الزخرف",
        "الدخان",
        "الجاثية",
        "اﻷحقاف",
        "محمد",
        "الفتح",
        "الحجرات",
        "ق",
        "الذاريات",
        "الطور",
        "النجم",
        "القمر",
        "الرحمن",
        "الواقعة",
        "الحديد",
        "المجادلة",
        "الحشر",
        "الممتحنة",
        "الصف",
        "الجمعة",
        "المنافقون",
        "التغابن",
        "الطلاق",
        "التحريم",
        "الملك",
        "القلم",
        "الحاقة",
        "المعارج",
        "نوح",
        "الجن",
        "المزمل",
        "المدثر",
        "القيامة",
        "اﻹنسان",
        "المرسلات",
        "النبأ",
        "النازعات",
        "عبس",
        "التكوير",
        "الانفطار",
        "المطففين",
        "الانشقاق",
        "البروج",
        "الطارق",
        "اﻷعلى",
        "الغاشية",
        "الفجر",
        "البلد",
        "الشمس",
        "الليل",
        "الضحى",
        "الشرح",
        "التين",
        "العلق",
        "القدر",
        "البينة",
        "الزلزلة",
        "العاديات",
        "القارعة",
        "التكاثر",
        "العصر",
        "الهمزة",
        "الفيل",
        "قريش",
        "الماعون",
        "الكوثر",
        "الكافرون",
        "النصر",
        "المسد",
        "اﻹخلاص",
        "الفلق",
        "الناس",
        };


        public static ReplyKeyboardMarkup LangKB = new ReplyKeyboardMarkup();
        public static ReplyKeyboardMarkup NavKB = new ReplyKeyboardMarkup();

        public static List<InlineKeyboardMarkup> SurahKeysUz = new List<InlineKeyboardMarkup>();
        public static List<InlineKeyboardMarkup> SurahKeysAr = new List<InlineKeyboardMarkup>();
        public static List<InlineKeyboardMarkup> SurahKeysRu = new List<InlineKeyboardMarkup>();
        public static List<InlineKeyboardMarkup> SurahKeysEn = new List<InlineKeyboardMarkup>();

        public static void SurahKeysInit()
        {

            // Initializing the Uzbek surahs keyboard
            string[] surahNames1 = surahNamesUz.Take<string>(surahNamesUz.Length / 2).ToArray<string>();
            SurahKeysUz.Add(new InlineKeyboardMarkup(GetInlineKeyboard(surahNames1)));
            string[] surahNames2 = surahNamesUz.Skip<string>(surahNamesUz.Length / 2).ToArray<string>();
            SurahKeysUz.Add(new InlineKeyboardMarkup(GetInlineKeyboard(surahNames2)));

            surahNames1 = null;
            surahNames2 = null;

            // Initializing the Arabic surahs keyboard
            surahNames1 = surahNamesAr.Take<string>(surahNamesAr.Length / 2).ToArray<string>();
            SurahKeysAr.Add(new InlineKeyboardMarkup(GetInlineKeyboard(surahNames1)));
            surahNames2 = surahNamesAr.Skip<string>(surahNamesAr.Length / 2).ToArray<string>();
            SurahKeysAr.Add(new InlineKeyboardMarkup(GetInlineKeyboard(surahNames2)));

            surahNames1 = null;
            surahNames2 = null;
            // Initializing the English surahs keyboard
            surahNames1 = surahNamesEn.Take<string>(surahNamesEn.Length / 2).ToArray<string>();
            SurahKeysEn.Add(new InlineKeyboardMarkup(GetInlineKeyboard(surahNames1)));
            surahNames2 = surahNamesEn.Skip<string>(surahNamesEn.Length / 2).ToArray<string>();
            SurahKeysEn.Add(new InlineKeyboardMarkup(GetInlineKeyboard(surahNames2)));

            surahNames1 = null;
            surahNames2 = null;
            // Initializing the Russian surahs keyboard
            surahNames1 = surahNamesRu.Take<string>(surahNamesRu.Length / 2).ToArray<string>();
            SurahKeysRu.Add(new InlineKeyboardMarkup(GetInlineKeyboard(surahNames1)));
            surahNames2 = surahNamesRu.Skip<string>(surahNamesRu.Length / 2).ToArray<string>();
            SurahKeysRu.Add(new InlineKeyboardMarkup(GetInlineKeyboard(surahNames2)));


        }

        private static InlineKeyboardButton[][] GetInlineKeyboard(string[] buttonItem)
        {
            var keyboardInline = new InlineKeyboardButton[19][];


            int k = 0;
            for (var j = 0; j < 19; j++)
            {
                var keyboardButtons = new InlineKeyboardButton[3];
                for (var i = 0; i < 3; i++)
                {
                    keyboardButtons[i] = new InlineKeyboardButton
                    {
                        Text = buttonItem[k],
                        CallbackData = buttonItem[k++],
                    };
                }
                keyboardInline[j] = keyboardButtons;
            }

            return keyboardInline;
        }

        public static void LanguagesButton()
        {
            LangKB.ResizeKeyboard = true;
            LangKB.Keyboard = new KeyboardButton[][]
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("O'zbek tili"),
                    new KeyboardButton("English")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("русский"),
                    new KeyboardButton("Arabic")
                }
            };
        }

        public static void NavigationButtons()
        {
            NavKB.ResizeKeyboard = true;
            NavKB.Keyboard = new KeyboardButton[][]
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("Boshiga")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("ortga"),
                    new KeyboardButton("keyingi")
                }
            };
        }

    }
}
