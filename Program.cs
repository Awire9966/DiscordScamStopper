﻿using System;
using System.Threading;
using Discord;
using Discord.Gateway;
using System.IO;

namespace MessageLogger
{
    class Program
    {
        static string logdirectory = Environment.CurrentDirectory + @"\logs\";
        static string[] blacklistedstuff = { "discrodsteam.ru", "discordapp.click", "steamnitro.com", "gave-nitro.com", "stleam-hype.ru", "dlscord-app.com", "discord-nltro.com", "discodnitro.info", "dlscord.click", "discordnitro.click", "discrod-glfts.com", "steamnltro.com", "nitro-drop.com", "discord-app.ru", "discord-airdrop.com", "dlscordgift.com", "dlscord-nitro.info", "discordsgift.info", "dlscord-nitro.link", "discord-give.ru", "dlscord-claim.com", "steam-nltro.ru", "steamnitros.ru", "steamnltros.ru", "steamdiscord.com", "dlscord-nitro.click", "dlscord-nltro.com", "discord-claim.com", "discord-gifts.shop", "discords-nitro.xyz", "discord-drop.xyz", "discorclapp.fun", "discord-app.live", "discord-game.ru", "discord-free-nitro.ru", "steamcomunity-nitro-free.ru", "discordapp.biz", "dlscordapp.info", "discord-click.shop", "discond-nitro.ru", "discrodapp.site", "discord-give.com", "steamdlscord.com", "discord-app.net", "discorcl.life", "discocrdapp.com", "discrodapp.ru", "gift-discord.shop", "discoapps.live", "dlscrodapp.ru", "discorcd.gift", "discorcl-app.fun", "discorcd.gifts", "dlscordgived.xyz", "dlscordsglfts.xyz", "dicsordgift.com", "axieroll.com", "steam-dlscord.com", "discord-up.ru", "discocrd-nitro.com", "discorcdapp.com", "steam-discords.com", "discords-app.com", "boost-discord.com", "discord-halloween.com", "dropskeys.com", "discordsteam.com", "discrod-up.ru", "discord-app.me", "telegra.ph", "apps-nitro.com", "discorclapp.com", "dlscordsteam.com", "nitro-up.com", "discord-apps.info", "discrodup.ru", "dlscord-app.info", "discord-give.org", "dlscord.org", "discocrd.gift", "discordcommunlty.com", "free nitro", "Free Nitro" };
        static void Main(string[] args)
        {
            DiscordSocketClient client = new DiscordSocketClient();
            client.OnLoggedIn += OnLoggedIn;
            client.OnMessageReceived += OnMessageReceived;

            Console.Write("Token: ");
            client.Login(Console.ReadLine());

            Thread.Sleep(-1);
        }


        private static void OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Console.WriteLine($"Logged into {args.User}");
        }


        private static void OnMessageReceived(DiscordSocketClient client, MessageEventArgs args)
        {
            

            DiscordChannel channel = client.GetChannel(args.Message.Channel.Id);

            if (!channel.InGuild)
            {
                for (int i = 0; i < blacklistedstuff.Length; i++)
                {

                    if (args.Message.Content.Contains(blacklistedstuff[i]))
                    {
                        DateTime localDate = DateTime.Now;

                        args.Message.Channel.SendMessageAsync("Your message contains a phrase that may mean its a scam. The message you sent has been loged as well as your id. This Message Was Generated By Andrew Cavallo's Discord Scam Protector. For more information, go to https://github.com/Awire9966/DiscordScamStopper.");
                        File.WriteAllText(logdirectory + localDate.Month + "." + localDate.Day + "." + localDate.Year + " at " + localDate.Hour + "." + localDate.Minute + ".log", args.Message.Content + "\n User id:" + args.Message.Author.User.Id);
                    }

                }
            }

        }
    }
}