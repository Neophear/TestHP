using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace TestHP
{
    class Program
    {
        static string macAddress = string.Empty;
        static string outgoingPort = string.Empty;
        static string ipAddress = string.Empty;
        static TelnetConnection tc;

        static void Main(string[] args)
        {
            ipAddress = "10.1.13.2";
            FindMac("lol");
        }


        static void FindMac(string macAddress)
        {
            //telnetThread = new Thread(new ThreadStart(HandleComm));
            //telnetThread.Start();

            //login with user "root",password "rootpassword", using a timeout of 100ms, and show server output
            tc = new TelnetConnection(ipAddress, 23);
            string s = tc.Login("admin","XXXX", 1000);

            // server output should end with "$" or ">", otherwise the connection failed
            string prompt = s.TrimEnd();
            prompt = s.Substring(prompt.Length - 1, 1);
            //if (prompt != "$" && prompt != "#")
            //    throw new Exception();

            tc.WriteLine("show mac-address
            s = tc.Read();
            Console.WriteLine(s);
            Console.ReadKey();
            //tc.WriteLine(string.Format("show mac address-table address {0} | incl Gi|Fa", macAddress));
            //prompt = "";
        }

        private void SendCommand(string Command)
        {
            tc.WriteLine(Command);
        }

        public void Close()
        {

        }
    }
}
