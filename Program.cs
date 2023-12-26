using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dcgx
{
    internal class Program
    {

        static WebClient wc = new WebClient();
        static string icon = wc.DownloadString("https://pastebin.com/raw/sNNqpXM7");


        static async Task Main()
        {
            Console.Title = "Gerador de Nitro do Opera GX - 0x6e33726479";
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                Console.WriteLine(icon + "\n");

                Console.WriteLine("Criado por: github.com/iagof-dev");
                Console.WriteLine("Links Gerados: " + Stuff.quantity);
                await Stuff.SendPostRequest();
                Console.Clear();
            }

        }
    }
}
