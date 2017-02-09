using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace BotCU
{
    /*
     BCU CHAT BOT
     Based on Disco Bot for setup of Discord.NET API
     all other commands custom. Orginal project started 07/02/2017

      Current features
      @ Test command checks if bot is active
      @ Hi command picks a random greeting for bot to say


     Possible features
     @BCU CEBE tweets apear in chat
     @Dice Roller
     @Useful links for programming get IM'd if you @ the bot
     @Creates chat channels every year for new classes
     @Inside Joke commands
     @intgration of moodle information(not sure if possible)    
         
              
        
         
         */
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;
        Random rand;


        string[] RandomGreetings;



        public MyBot()
        {
            rand = new Random();

            RandomGreetings = new string[]
            {
                "Well Howdy, Stanger!",
                "Top O'the Monging To Ya!",
                "F*ck Off!!!",
                "Hey!",
            };



            discord = new DiscordClient(x => { //creates discord client
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });


            discord.UsingCommands(x => { //registers commands
                x.PrefixChar = '`'; //allows commands to be called with this key 
                x.AllowMentionPrefix = true; //allows @ing of the bot to trigger commands
            });

            commands = discord.GetService<CommandService>(); //creates commands service


            //LIST FUNCTIONS HERE

            RegisterTestCommand();
            RegisterHiCommand();






            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("Mjc4NTIzOTI5MzUyNDcwNTI5.C3tjNA.Jj_FLDVB-6u-KWZ4GadHb2ZqOpQ", TokenType.Bot); //this add the bot to the server using the token given on the discord website

            });

        }

        private void RegisterTestCommand()
        {
            commands.CreateCommand("test")
                .Do(async (e) => //creates function you only need to call here
                {
                   await e.Channel.SendMessage("Im Working!"); //sends messge in channel it was typed in
                });
        }

        private void RegisterHiCommand()
        {
            commands.CreateCommand("Hi")
                .Do(async (e) =>
                {
                    int RandomGreetingsIndex = rand.Next(RandomGreetings.Length);
                    string PostedGreeting = RandomGreetings[RandomGreetingsIndex];
                    await e.Channel.SendMessage(PostedGreeting);
                });
        }

        private void RegisterDiceCommand()//not yet used
        {
            commands.CreateCommand("r20")
                .Do(async (e) =>
                {
                    int Roll = rand.Next(20);
                    await e.Channel.SendMessage(Roll);
                });
        }



        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
