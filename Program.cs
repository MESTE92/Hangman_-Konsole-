using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hangman__Konsole_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Mainmenu();

                

            
            

            

        }


        static void Mainmenu()
        {
            while (true)
            {


                bool end = false;
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                SchreibeZentriert("\n\n");
                SchreibeZentriert("HANGMAN");
                Console.Write("\n\n\n");
                Console.ForegroundColor = ConsoleColor.Black;
                SchreibeZentriert("[1] Spiel starten    [2] Beenden\n\n\n");
                SchreibeZentriert("Auswahl:   ");

                string eingabe = Console.ReadLine();
                int auswahl;
                while (!int.TryParse(eingabe, out auswahl) || auswahl < 1 || auswahl > 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    SchreibeZentriert("\n\n");
                    SchreibeZentriert("HANGMAN");
                    Console.Write("\n\n\n");
                    Console.ForegroundColor = ConsoleColor.Black;
                    SchreibeZentriert("[1 = Spiel starten]     [2 = Beenden]\n\n\n");
                    SchreibeZentriert("Auswahl:   ");

                    eingabe = Console.ReadLine();
                }

                bool end_game = false;

                switch (auswahl)
                {
                    case 1: start_game(); break;
                    case 2: end_game = true; break;
                }

                if (end_game)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    SchreibeZentriert("\n\n\n\n");
                    SchreibeZentriert("Das Spiel wird beendet !");
                    Thread.Sleep(2500);
                    break;
                    
                }

                Console.Clear();

            }
        }

        static void start_game()
        {
            string[] woerter = new string[]
            {
                "Hund",
                "Katze",
                "Brot",
                "Regen",
                "Lehrer",
                "Hexe",
                "Ball",
                "Strand",
                "Auto",
                "Zauberer",
                "Sonne",
                "Lampe",
                "Keks",
                "Fuchs",
                "Maus",
                "Arzt",
                "Schokolade",
                "Wolke",
                "Clown",
                "Boot",
                "Suppe",
                "Fee",
                "Wal",
                "Schmetterling",
                "Rose",
                "Zombie",
                "Pilot",
                "Uhr",
                "Weide",
                "Stadt",
                "Ratte",
                "Tanne",
                "Radio",
                "Apfel",
                "Taschenlampe",
                "Koch",
                "Kino",
                "Herz",
                "Magie",
                "Fußballschuh",
                "Haus",
                "Bauer",
                "Löwe",
                "Tasse",
                "Überraschung",
                "Bär",
                "Geist",
                "Gabel",
                "Park",
                "Dorf",
                "Esel",
                "Schaf",
                "Markt",
                "Baum",
                "Zahnarztstuhl",
                "Zug",
                "Sänger",
                "Gras",
                "Stern",
                "Rucksack",
                "Maler",
                "Pizza",
                "Bäcker",
                "Drache",
                "Milch",
                "Alge",
                "Sternschnuppe",
                "Erde",
                "Wind",
                "Tisch",
                "Stuhl",
                "Honig",
                "Kamel",
                "Korn",
                "Garten",
                "Troll",
                "Schule",
                "Richter",
                "Tiger",
                "Ritter",
                "Blume",
                "Moos",
                "Wurst",
                "Feuer",
                "Glocke",
                "Käse",
                "Traum",
                "Handy",
                "Regenbogen",
                "Elf",
                "Überraschung"
            };

            Random wortwahl = new Random();
            int index = wortwahl.Next(0, woerter.Length);

            string word = woerter[index].ToLower();

            Game_Loop(word);
        }


        static void Game_Loop(string word)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            int lives = 10;
            string hidden_word = "";

            for (int i = 0; i < word.Length; i++)
            {
                hidden_word += "_";
            }

            while (true)
            {
                Console.Clear();
                Console.Write("\n\n");
                SchreibeZentriert($"Geuschtes Wort:  {hidden_word}\n\n");
                SchreibeZentriert("übrige Versuche:  ");

                for (int i = 0; i < lives; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\u2665");
                    
                }

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\n\n\n");
                SchreibeZentriert("Buchstabe:   ");
                char buchstabe = Convert.ToChar(Console.ReadLine().ToLower());
               
                bool gefundener_buchstabe = false;  

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == buchstabe)
                    {
                        gefundener_buchstabe = true;
                        break;
                    }
                }

                string temporäres_wort = hidden_word;
                hidden_word = "";

                if (gefundener_buchstabe == true)
                {
                    for (int i = 0;i < word.Length;i++)
                    {
                        if (word[i]==buchstabe)
                        {
                            hidden_word += buchstabe;
                        }
                        else if (temporäres_wort[i] != '_')
                        {
                            hidden_word += temporäres_wort[i];
                        }
                        else
                        {
                            hidden_word += '_';
                        }  

                    }


                    if (hidden_word == word)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        SchreibeZentriert("\n\n\n\n\n\n\n");
                        SchreibeZentriert("Herzlichen Glückwunsch, du hast GEWONNEN !!!\n\n\n");
                        SchreibeZentriert($" Das gesuchte Wort war:   {word}");
                        Thread.Sleep(8000);
                        Console.ResetColor();
                        break;
                    }


                } // ende der if abfrage nach dem gesuchten wort
                else
                {
                    hidden_word = temporäres_wort;

                    if (lives > 0)
                    {
                        lives -= 1;

                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        SchreibeZentriert("\n\n\n\n\n\n\n\n");
                        SchreibeZentriert("GAME OVER");
                        Thread.Sleep(6000);
                        break;
                    }
                }

                

            } // ende der schleife


        } // ende der methode


        public static void SchreibeZentriert(string text)
        {
            int fensterBreite = Console.WindowWidth;                                          // Breite der Konsole ermitteln
            int textBreite = text.Length;                                                    // Länge des Textes
            int leerzeichenLinks = (fensterBreite - textBreite) / 2;                        // Anzahl Leerzeichen links berechnen

            if (leerzeichenLinks < 0) leerzeichenLinks = 0;                               // Falls der Text länger ist als die Konsole

            Console.SetCursorPosition(leerzeichenLinks, Console.CursorTop);
            Console.Write(text);
        }
    }
}
