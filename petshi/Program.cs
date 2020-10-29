using System;
using System.Threading.Tasks;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace petshi
{


    class Program
    {
        private static string Token = "373634438:AAHWMle6D4y93NOlnTX7cWN9Mxm7IZkMDBE";
        public static string x = "";
        private static int job = 1;

        static void Main(string[] args)
        {
            Task.Run(() => RunBot());

            while (true)
            {
                
                x = Console.ReadLine();


            }



        }

        public static async Task RunBot()
        {
            var bot = new TelegramBot(Token) { WebProxy = new System.Net.WebProxy("127.0.0.1:6661") };
            var me = await bot.MakeRequestAsync(new GetMe());
            Console.WriteLine("usename is {0}", me.Username);
            long offset = 0;
            int whilecount = 0;
            
            


            while (true)
            {

                whilecount++;
                var updates = await bot.MakeRequestAsync(new GetUpdates() { Offset = offset });

                Console.WriteLine("----------------------------------------");



                try
                {
                    foreach (var update in updates)
                    {   
                        offset = update.UpdateId + 1;
                        var text = update.Message.Text;
                        Console.WriteLine(update.Message.From.FirstName + " and ID is : " + update.Message.Chat.Id + " : " + text);

                        if (text == "/start")
                        {
                            var req = new SendMessage(update.Message.Chat.Id, "چی میخوای؟");
                            await bot.MakeRequestAsync(req);
                            continue;
                        }
                        else if (text.Contains("گمشو") && update.Message.From.Username == "infeXno")
                        {
                            var req = new SendMessage(update.Message.Chat.Id, "دیگه دوستتون ندارم :(");
                            await bot.MakeRequestAsync(req);
                            var leave = new LeaveChat(update.Message.Chat.Id);
                            await bot.MakeRequestAsync(leave);
                        }
                        else if (text == "job is")
                        {
                            string xxx = Convert.ToString(job);
                            var req = new SendMessage(update.Message.Chat.Id, "job value is : " + xxx);
                            await bot.MakeRequestAsync(req);
                            continue;

                        }
                        else if (text.Contains("دلار"))
                        {

                            if (update.Message.From.Username != "infeXno")
                            {
                                    WebClient n = new WebClient();
                                    var json = n.DownloadString("http://www.tgju.org/?act=sanarateservice&client=tgju&noview&type=json");
                                    Arz a1 = JsonConvert.DeserializeObject<Arz>(json);
                                    string dollar = a1.sana_buy_usd.price;
                                    string toman = dollar.Remove(6);
                                    string nocomma = toman.Replace(",", "");

                                    var req = new SendMessage(update.Message.Chat.Id, "الان قیمت هر دلار " +nocomma + " تومن هستش");
                                    req.ReplyToMessageId = update.Message.MessageId;
                                    await bot.MakeRequestAsync(req);
                            }
                            else
                            {
                               
                                    WebClient n = new WebClient();
                                    var json = n.DownloadString("http://www.tgju.org/?act=sanarateservice&client=tgju&noview&type=json");
                                    Arz a1 = JsonConvert.DeserializeObject<Arz>(json);
                                    string dollar = a1.sana_buy_usd.price;
                                    string toman = dollar.Remove(6);
                                    string nocomma = toman.Replace(",", "");

                                    var req = new SendMessage(update.Message.Chat.Id, "ددی الان قیمت هر دلار " + nocomma + " تومن هستش ^^♥");
                                    req.ReplyToMessageId = update.Message.MessageId;
                                    await bot.MakeRequestAsync(req);
                            }
                            continue;
                        }

                        else if (text.Contains("چندمه") || text.Contains("تاریخ") || text.Contains("time") || text.Contains("ساعت چنده"))
                        {
                            PersianDateTime time = PersianDateTime.Now;
                            string h = time.Hour.ToString();
                            string m = time.Minute.ToString();
                            string s = time.Second.ToString();
                            string hms = (h + ":" + m + ":" + s);
                            string date = time.ToString("dddd d MMMM yyyy ساعت ");
                            string t = (date + hms);


                            if (update.Message.From.Username != "infeXno")
                            {
                                var req = new SendMessage(update.Message.Chat.Id, t);
                                req.ReplyToMessageId = update.Message.MessageId;
                                await bot.MakeRequestAsync(req);
                            }
                            else
                            {
                                var req = new SendMessage(update.Message.Chat.Id, "ددی امروز " + t + " هستش ♥ ");
                                req.ReplyToMessageId = update.Message.MessageId;
                                await bot.MakeRequestAsync(req);
                            }

                            continue;
                        }

                        else if (text == "/hava" || text == "/hava@petshibot")
                        {
                            string s = "با این دستور میتونم وضعیت آب و هوا رو بهت بگم  این شکلی میتونی استفاده کنی : \n /hava 'نام شهر'";
                            var req = new SendMessage(update.Message.Chat.Id, s);
                            req.ReplyToMessageId = (update.Message.MessageId);
                            await bot.MakeRequestAsync(req);
                            continue;
                        }
                        else if (text.Contains("/hava"))
                        {
                            string s1 = text;
                            char[] ch = new char[] { ' ' };
                            string[] result;
                            result = s1.Split(ch, 2);
                            string location = result[1];
                            WebClient n = new WebClient();
                            var json = n.DownloadString("http://api.apixu.com/v1/current.json?key=1c5183723cba412ab6a102839182910&q=" + location);
                            weather w1 = JsonConvert.DeserializeObject<weather>(json);
                            string temp = Convert.ToString(Convert.ToInt32(w1.current.temp_c));
                            string stat = w1.current.condition.text;

                            switch (w1.current.condition.code)
                            {
                                case 1000:
                                    string s = "امروز اونجا " + temp + " درجست و هوا صاف هستش ^^";
                                    var req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req); break;
                                case 1003:
                                    s = "امروز اونجا " + temp + " درجست و هوا نیمه ابری هستش ^^";
                                    req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req); break;
                                case 1006:
                                    s = "امروز اونجا " + temp + " درجست و هوا ابری هستش ^^";
                                    req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req); break;
                                case 1009:
                                    s = "امروز اونجا " + temp + " درجست و هوا کاملا ابری هستش ^^";
                                    req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req); break;
                                case 1030:
                                    s = "امروز اونجا " + temp + " درجست و هوا مرطوبه ^^";
                                    req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req); break;
                                case 1135:
                                    s = "امروز اونجا " + temp + " درجست و هوا مه آلود هستش ^^";
                                    req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req); break;
                                case 1183:
                                    s = "امروز اونجا " + temp + " درجست و یکم بارون میاد ^^";
                                    req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req); break;
                                case 1186:
                                    s = "امروز اونجا " + temp + " درجست و بعضی وقتا بارون میاد ^^";
                                    req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req); break;
                                case 1189:
                                    s = "امروز اونجا " + temp + " درجست و یه مقدار بارون داریم ^^";
                                    req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req); break;
                                case 1192:
                                    s = "امروز اونجا " + temp + " درجست و بارون زیادی داریم ^^";
                                    req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req); break;
                                case 1195:
                                    s = "امروز اونجا " + temp + " درجست و بارون زیادی داریم ^^";
                                    req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req); break;
                                default:
                                    s = "امروز اونجا " + temp + "درجست و " +stat + " هستش";
                                    req = new SendMessage(update.Message.Chat.Id, s);
                                    req.ReplyToMessageId = (update.Message.MessageId);
                                    await bot.MakeRequestAsync(req);
                                    break;
                            }








                            continue;
                        }

                        else if (text == "/mani" || text == "/mani@petshibot")
                        {
                            string s = "با این دستور میتونم معنی هر کلمه ای رو بهت بگم ^^ این شکلی میتونی استفاده کنی : \n /mani 'کلمه'";
                            var req = new SendMessage(update.Message.Chat.Id, s);
                            req.ReplyToMessageId = (update.Message.MessageId);
                            await bot.MakeRequestAsync(req);
                            continue;
                        }
                        else if (text.Contains("/mani"))
                        {
                            string s1 = text;
                            char[] ch = new char[] { ' ' };
                            string[] result;
                            result = s1.Split(ch, 2);
                            string kalame = result[1];
                            WebClient n = new WebClient();
                            var json = n.DownloadString("http://api.urbandictionary.com/v0/define?term=" + kalame);
                            mani m1 = JsonConvert.DeserializeObject<mani>(json);

                            if (m1.list.Length > 0)
                            {
                                string man = m1.list[0].definition + "\n\n Examples : \n" + m1.list[0].example;
                                string edit = man.Replace("[", "");
                                string edit1 = edit.Replace("]", "");
                                string edit2 = edit1.Replace("â€™", "");
                                var req = new SendMessage(update.Message.Chat.Id, edit2);
                                req.ReplyToMessageId = update.Message.MessageId;
                                await bot.MakeRequestAsync(req);
                            }
                            else
                            {
                                string man = "معنی این کلمه رو نتونستم پیدا کنم :(";
                                var req = new SendMessage(update.Message.Chat.Id, man);
                                req.ReplyToMessageId = update.Message.MessageId;
                                await bot.MakeRequestAsync(req);
                            }
                            continue;
                        }





                        ///////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////
                        ///////////////////////////////////////////////////////////////////

                            /////////////////SEND MY MESSAGE COMMAND PART/////////////////////

                            ///////////////////////////////////////////////////////////////////
                            ///////////////////////////////////////////////////////////////////
                            ///////////////////////////////////////////////////////////////////                        


                            ///////SEND MESSAGE FROM COMMAND CENTER/////////
                        else if (update.Message.From.Username == "infeXno" && update.Message.Chat.Id == -224286003)
                        {
                            string s1 = text;
                            char[] ch = new char[] { ' ' };
                            string[] result;
                            result = s1.Split(ch, 2);
                            long target = Convert.ToInt64(result[0]);
                            string str = result[1];
                            var req = new SendMessage(target, str); //my messages goes here !
                            await bot.MakeRequestAsync(req);
                            continue;
                        }


                        //////////////////////////PRIVATE PART/////////////////////////////
                        //////////////////////////PRIVATE PART/////////////////////////////
                        //////////////////////////PRIVATE PART/////////////////////////////
                        //////////////////////////PRIVATE PART/////////////////////////////
                        //////////////////////////PRIVATE PART/////////////////////////////
                        //////////////////////////PRIVATE PART/////////////////////////////
                        //////////////////////////PRIVATE PART/////////////////////////////
                        //////////////////////////PRIVATE PART/////////////////////////////
                        //////////////////////////PRIVATE PART/////////////////////////////
                        //////////////////////////PRIVATE PART/////////////////////////////
                        //////////////////////////PRIVATE PART/////////////////////////////
                        //recieve privates 
                        //and answer them
                        else if (update.Message.Chat.Type == "private")
                        {
                            var req = new SendMessage(-224286003, update.Message.Chat.Id + "");
                            await bot.MakeRequestAsync(req);

                            var forw = new ForwardMessage(-224286003, update.Message.Chat.Id, update.Message.MessageId);
                            await bot.MakeRequestAsync(forw);

                            //////////////////////KNOWN PEOPLE//////////////////////

                          

                        ////////////////REGULAR GROUP SETTINGS//////////////////////
                        ////////////////REGULAR GROUP SETTINGS//////////////////////
                        ////////////////REGULAR GROUP SETTINGS//////////////////////
                        ////////////////REGULAR GROUP SETTINGS//////////////////////
                        ////////////////REGULAR GROUP SETTINGS//////////////////////
                        ////////////////REGULAR GROUP SETTINGS//////////////////////
                        ////////////////REGULAR GROUP SETTINGS//////////////////////
                        else if (update.Message.Chat.Type == "supergroup" || update.Message.Chat.Type == "group")
                        {

                            if (update.Message.From.Id == 226349493) /////this is ME
                            {

                                if (text.Contains("دختر") || text.Contains("ربات"))
                                {
                                    string[] asd = new string[] { " یس ددی", "ددیم ♥", " ♥:))" };
                                    Random rnd = new Random();
                                    int rand = rnd.Next(0, 2);


                                    var jvb = new SendMessage(update.Message.Chat.Id, asd[rand]);
                                    jvb.ReplyToMessageId = update.Message.MessageId;
                                    await bot.MakeRequestAsync(jvb);
                                }

                                else if (text.Contains("/off"))
                                {
                                    var req = new SendMessage(update.Message.Chat.Id, "ربات خاموش شد.");
                                    await bot.MakeRequestAsync(req);
                                    job = 0;
                                }
                                else if (text.Contains("/on"))
                                {
                                    var req = new SendMessage(update.Message.Chat.Id, "اماده خدمت :)");
                                    await bot.MakeRequestAsync(req);
                                    job = 1;
                                }
                                else if (update.Message.ReplyToMessage.From.Id == 373634438)
                                {
                                    string[] asd = new string[] { "لاو یو ددی", ":* بوچ بوچ", "^^", "+__+" };
                                    Random rnd = new Random();
                                    int rand = rnd.Next(0, 3);

                                    var jvb = new SendMessage(update.Message.Chat.Id, asd[rand]);
                                    jvb.ReplyToMessageId = update.Message.MessageId;
                                    await bot.MakeRequestAsync(jvb);
                                }
                                else if (update.Message.ReplyToMessage.From.Id == 373634438 && text.Contains("salam") || text.Contains("سلم") || text.Contains("سلام") || text.Contains("slm"))
                                {
                                    string[] asd = new string[] { " های ددی", " سلام ددیمون", " :))", "سلام ددی ♥ :))" };
                                    Random rnd = new Random();
                                    int rand = rnd.Next(0, 3);

                                    var req = new SendMessage(update.Message.Chat.Id, asd[rand]);
                                    req.ReplyToMessageId = update.Message.MessageId;
                                    await bot.MakeRequestAsync(req);
                                }
                            }
                            else if (text.Contains("ربات"))
                            {

                                string[] asd = new string[] { "؟؟", "چیه ", " بله" };
                                Random rnd = new Random();
                                int rand = rnd.Next(0, 2);

                                var jvb = new SendMessage(update.Message.Chat.Id, asd[rand]);
                                jvb.ReplyToMessageId = update.Message.MessageId;
                                await bot.MakeRequestAsync(jvb);
                            }
                            else if (update.Message.From.Username != "infeXno" && text.Contains("خوب") || text.Contains("بد") || text.Contains("اره"))
                            {
                                if (update.Message.ReplyToMessage.From.Id == 373634438)
                                {
                                    string[] asd = new string[] { " خوبه", " خدارو شکر", " :))" };
                                    Random rnd = new Random();
                                    int rand = rnd.Next(0, 5);

                                    if (rand <= 2)
                                    {
                                        var jvb = new SendMessage(update.Message.Chat.Id, asd[rand]);
                                        jvb.ReplyToMessageId = update.Message.MessageId;

                                        await bot.MakeRequestAsync(jvb);
                                    }
                                }
                            }
                        
                            else if (update.Message.ReplyToMessage.From.Id == 373634438 && text.Contains("salam") || text.Contains("سلم") || text.Contains("سلام") || text.Contains("slm"))
                            {

                                string[] asd = new string[] { " سلام", "  سلام :))", "های" };
                                Random rnd = new Random();
                                int rand = rnd.Next(0, 2);

                                var req = new SendMessage(update.Message.Chat.Id, asd[rand]);
                                req.ReplyToMessageId = update.Message.MessageId;
                                await bot.MakeRequestAsync(req);
                                continue;

                            }
                           
                            
                        }


                    }
                }
                catch (WebException)
                {

                        foreach (var update in updates)
                        {
                            var req = new SendMessage(update.Message.Chat.Id, "پیدا نکردم :(");
                            req.ReplyToMessageId = update.Message.MessageId;
                            await bot.MakeRequestAsync(req);
                        }


                }
                catch (Exception)
                {
                    continue;
                }

            }
        }
    }   
}
