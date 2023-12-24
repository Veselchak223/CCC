using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InputFiles;





namespace TelegramBotFirst
{
    
    class Program
    {
      
        public static Program program = new Program();
        public static int Jaba;
        public static Update up = new Update();
        static bool Buy;
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            var client = new TelegramBotClient("6966420938:AAHgupeOtA35jQxIn30hsA0rxgCMlKKQW70");
            var updateTypes = new UpdateType[]
            {
        UpdateType.Message,
        UpdateType.CallbackQuery,
                // ... other update types you need
            };

            client.OnUpdate += async (sender, e) =>
            {
                await Update(client, e.Update, default);
                 var message = up.Message;
                
            };

            client.StartReceiving(updateTypes);
            Console.ReadKey();
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            Console.WriteLine($"Error: {arg2.Message}");
            return Task.CompletedTask;
        }

        async static Task Update(ITelegramBotClient botclient, Update update, CancellationToken token)
        {
            var message = update.Message;

            if (message.Text != null)
            {
                Console.WriteLine($"{message.Chat.FirstName}: {message.Text}");
                if (message.Text.ToLower().Contains("привет"))
                {
                    SendPhoto(botclient, message.Chat.Id, "C:\\Users\\79125\\Downloads\\Privet.png", $"Привет! *{message.Chat.FirstName}*, Это Телеграм бот Черепухуса! Тут ты можешь приобрести себе модератора на ютуб канал или узнавать новые новости!");
                  
                   if(message.Chat.Username == "KadaiSo2")
                    {
                        Jaba = 10000;
                    }




               
                    return;
                }
                else
                {
                    if (message.Text == "Купить Модератора 💲")
                    {
                        await botclient.SendTextMessageAsync(message.Chat.Id, $"Цена модератора: 55р, Ссылка для оплаты: {@" https://www.donationalerts.com/r/cherepuhus"}  (В ОПИСАНИИ ОПЛАТЫ УКАЖИТЕ СВОЙ ЮЗЕРНЕЙМ НА ЮТУБЕ! ИМЕННО ЮЗЕРНЕЙМ!!)", replyMarkup: GetButtonsdonate());
                      
                        






                        return;
                    }
                    else
                    {
                        if (message.Text == "Назад")
                        {
                          
                            
                            
                           
                                await botclient.SendTextMessageAsync(message.Chat.Id, $"Главное меню:", replyMarkup: GetButtonsMain());
                                                        
                            return;
                        }
                        else
                        {
                            if (message.Text == "Кликнуть")
                            {

                                Random random = new Random();
                                int number = random.Next(1, 10);
                                Jaba += number;

                                await botclient.SendTextMessageAsync(message.Chat.Id, $"Вы получили +{number} Лягушек! 🐸");

                                return;
                            }
                            else
                            {
                                if (message.Text == "Мой Баланс")
                                {

                                    

                                    await botclient.SendTextMessageAsync(message.Chat.Id, $"На вашем балансе: {Jaba} жаб! 🐸", replyMarkup: GetButtonsdonate());

                                    return;
                                }
                                else
                                {
                                    if (message.Text == "Обменник")
                                    {



                                        await botclient.SendTextMessageAsync(message.Chat.Id, $"Выбери Товар:", replyMarkup: GetButtonsShop());

                                        return;
                                    }
                                    else
                                    {
                                        if (message.Text == "Отправить сообщение Черепухусу(1000 ЖАБ)")
                                        {
                                            
                                            if(Jaba >= 1000)
                                            {
                                                Jaba -= 1000;
                                                await botclient.SendTextMessageAsync(message.Chat.Id, $"Напишите ваше сообщение!");


                                                Buy = true;

                                            }
                                            else
                                            {
                                                await botclient.SendTextMessageAsync(message.Chat.Id, $"У вас не хватает жаб!", replyMarkup: GetButtonsShop());
                                            }


                                            

                                            return;
                                        }
                                        else
                                        {
                                            if (message.Text.ToLower().Contains("C:") || message.Text.ToLower().Contains("С:") || Buy == true)
                                            {
                                                var otvet = message.Text;

                                                await botclient.SendTextMessageAsync(1469235632, $"Вам прислали сообщение: {otvet}", replyMarkup: GetButtonsShop());
                                                Buy = false;







                                                return;
                                            }
                                            else
                                            {
                                                if (message.Text == "Купить бота")
                                                {



                                                    await botclient.SendTextMessageAsync(message.Chat.Id, $"По покупке бота обращайтесь сюда @KadaiSo2", replyMarkup: GetButtonsdonate());

                                                    return;
                                                }
                                                else
                                                {
                                                   

                                                    await botclient.SendTextMessageAsync(message.Chat.Id, "Я тебя не понимаю!", replyMarkup: GetButtonsMain());
                                                    return;
                                                }
                                            }
                                        }


                                       
                                    }
                                   
                                }
                                
                            }
                            
                        }
                       
                    }
                    
                }
                
                
            }








            else if (message.Audio != null)
            {
                // SendPhoto(botclient, message.Chat.Id, "D:\\Video\\IMG_20201203_101553.jpg", $"Fuck!");
                await botclient.SendTextMessageAsync(message.Chat.Id, "Я не могу слушать аудио!");
                return;
            }
            else if (message.Photo != null)
            {
                await botclient.SendTextMessageAsync(message.Chat.Id, "Я не умею смотреть картинки!");
                return;
            }
            else if (message.Video != null)
            {
                await botclient.SendTextMessageAsync(message.Chat.Id, "Я не могу смотреть видео!");
              //  SendPhoto(botclient, message.Chat.Id, "D:\\Video\\IMG_20201203_101622.jpg", $"Fuck!");
                return;
            }
            else if (message.Sticker != null)
            {
                await botclient.SendTextMessageAsync(message.Chat.Id, @"Я не умею читать стикеры!");
                //  SendPhoto(botclient, message.Chat.Id, "D:\\Video\\IMG_20201203_101622.jpg", $"Fuck!");
                return;
            }
        }

        private static async Task SendPhoto(ITelegramBotClient botclient, long chatId, string filePath, string caption = null)
        {
            if (System.IO.File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var fileToSend = new InputOnlineFile(stream);
                    await botclient.SendPhotoAsync(chatId, fileToSend, caption, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: GetButtonsMain());
                }
            }
            else
            {
                Console.WriteLine("Файл не найден: " + filePath);
            }
        }

        private static IReplyMarkup GetButtonsMain()
        {
            const string TEXT_1 = "Купить Модератора 💲";
            const string TEXT_2 = "Кликнуть";
            const string TEXT_3 = "Мой Баланс";
            const string TEXT_4 = "Обменник";
            const string TEXT_5 = "Купить бота";

            var button1 = CreateKeyboardButton(TEXT_1);
            var button2 = CreateKeyboardButton(TEXT_2);
            var button3 = CreateKeyboardButton(TEXT_3);
            var button4 = CreateKeyboardButton(TEXT_4);
            var button5 = CreateKeyboardButton(TEXT_5);

            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
            {
                new List<KeyboardButton> { button1, button2, button3 },
                 new List<KeyboardButton> { button4 },
                  new List<KeyboardButton> { button5 }
            },
                ResizeKeyboard = true
            };
        }
        private static IReplyMarkup GetButtonsShop()
        {
            const string TEXT_1 = "Отправить сообщение Черепухусу(1000 ЖАБ)";
            const string TEXT_2 = "Назад";


            var button1 = CreateKeyboardButton(TEXT_1);
            var button2 = CreateKeyboardButton(TEXT_2);


            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
            {
                new List<KeyboardButton> { button1 },
               new List<KeyboardButton> { button2 }
            },
                ResizeKeyboard = true
            };
        }
        private static IReplyMarkup GetButtonsdonate()
        {
            const string TEXT_1 = "Назад";
           

            var button1 = CreateKeyboardButton(TEXT_1);
           

            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
            {
                new List<KeyboardButton> { button1 }

            },
                ResizeKeyboard = true
            };
        }

        private static KeyboardButton CreateKeyboardButton(string buttonText)
        {
            return new KeyboardButton
            {
                Text = buttonText
            };
        }
        



    }
}

