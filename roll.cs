using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using TerraTex_RL_RPG.Lib.Helper;
using GrandTheftMultiplayer.Server.Constant;
using MySql.Data.MySqlClient;
using TerraTex_RL_RPG.Lib.User.Management;
using System;


namespace TerraTex_RL_RPG.Lib.Enviroment.NPC
{
    class radl : Script
    {
        public radl()
        {
            API.onServerResourceStart += onServerResourceStartHandler;
        }
        public void onServerResourceStartHandler(string resource)
        {
            if (resource == "goto")
            {
                Vector3 radlnpc = new Vector3(-1613.619, -1076.322, 13.01853);
                PedHash Denise = PedHash.Denise;
                API.createPed(Denise, radlnpc, 65);
                API.consoleOutput("Denise is da");
            }

        }
        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
        [Command("rad", SensitiveInfo = false)]
        public void RadDrehCommand(Client player)
        {
            Vector3 currentpos = player.position;
            double X = currentpos.X;
            double Y = currentpos.Y;
            double Z = currentpos.Z;
            if (X < -1603.619 && X > -1623.619 && Y < 1066.322 && Y > -1086.322 && Z > 3.01853 && Z < 23.01853)
            {
                float playermoney = MoneyManager.GetPlayerMoney(player);
                if (playermoney < 50)
                {
                    API.sendChatMessageToPlayer(player, "Du brauchst 50 Dollar um am Rad zu drehen!");
                }
                else
                {
                    MoneyManager.ChangePlayerMoney(player, -50, false, MoneyManager.Categorys.Other, "Rad gedreht", "");
                    double Chooser = GetRandomNumber(0.0, 100.0);
                    if (Chooser < 1)
                    {
                        API.sendChatMessageToPlayer(player, "Glückwunsch! Du hast den Jackpot gewonnen! 250€!!");
                        MoneyManager.ChangePlayerMoney(player, 300, false, MoneyManager.Categorys.Other, "Rad Gewinn", "");
                    }
                    if (Chooser < 20 && Chooser >= 1)
                    {
                        API.sendChatMessageToPlayer(player, "Glückwunsch! Du hast den gewonnen! 100€!!");
                        MoneyManager.ChangePlayerMoney(player, 150, false, MoneyManager.Categorys.Other, "Rad Gewinn", "");
                    }
                    else
                    {
                        API.sendChatMessageToPlayer(player, "Schade, hast wohl nix gewonnen");
                    }
                }
            }
            else
            {
                API.sendChatMessageToPlayer(player, "Du stehst nicht am Glücksrad!");
            }
        }
        [Command("enter", SensitiveInfo = false)]
        public void BahamaEnterCommand(Client player)
        {
            Vector3 currentpos = player.position;
            double X = currentpos.X;
            double Y = currentpos.Y;
            double Z = currentpos.Z;
            if (X < -1378.77 && X > -1398.77 && Y < -576.3922 && Y > -596.3922 && Z > 20.2195 && Z < 40.2195)
            {
                Vector3 bahama = new Vector3(-1387.08f, -588.4f, 30.3195f);
                player.position = bahama;
            }
            else if (X < 121.8381 && X > 101.8381 && Y < -617.3054  && Y > -637.3054 && Z > 43 && Z < 45)
            {
                Vector3 iaa = new Vector3(116.2942, -636.2047, 206.0467);
                player.position = iaa;
            }
            else
            {
                API.sendChatMessageToPlayer(player, "Du stehst an keinem Gebäude!");
            }
        }
    }


  



    }
