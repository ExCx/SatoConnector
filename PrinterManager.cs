using SatoConnector.Properties;
using SATOPrinterAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatoConnector
{
    public class PrinterManager
    {
        Printer printer;
        Driver driver;
        public IProgress<string> reporter;
        public bool IsConnected { get; set; } = false;

        public PrinterManager(IProgress<string> reporter)
        {
            this.reporter = reporter;
            printer = new Printer();
            driver = new Driver();
            printer.Interface = Printer.InterfaceType.USB;
            printer.PermanentConnect = true;
        }

        public List<Printer.USBInfo> GetPrinters()
        {
            return printer.GetUSBList();
        }

        public void Connect()
        {
            printer.USBPortID = Settings.Default.YaziciPortu;
            try
            {
                printer.Connect();
                reporter.Report("Bağlantı Durumu|Yazıcı bağlantısı kuruldu");
                IsConnected = true;
            }
            catch (Exception ex)
            {
                reporter.Report("Yazıcı Hatası|" + ex.Message);
                IsConnected = false;
            }
        }

        internal void Print(ServerManager.AssetPrintDto asset)
        {
            string prn;
            using (var sr = new StreamReader(Settings.Default.SablonPath, Encoding.Default, true))
                prn = sr.ReadToEnd();
            var productName = asset.AssetTypeDefinition;
            productName = productName.Replace("Ü", "U");
            productName = productName.Replace("Ö", "O");
            productName = productName.Replace("Ç", "C");
            productName = productName.Replace("Ş", "S");
            productName = productName.Replace("Ğ", "G");
            productName = productName.Replace("İ", "I");
            //productName = productName.Replace(" ", "_");
            prn = prn.Replace("TASINIRADITASINIRADI", CenterBySpace("TASINIRADITASINIRADI", productName));
            //prn = prn.Replace("TASINIRADITASINIRADITASINIRADI", productName);
            var budgetAbbr = "" + asset.BudgetTypeDefinition.Split(' ')[0][0] + asset.BudgetTypeDefinition.Split(' ')[1][0];
            prn = prn.Replace("BUTCETURU", budgetAbbr);
            prn = prn.Replace("ESKIDEMIRBASNO", asset.RemoteId2);
            prn = prn.Replace("YENIDEMIRBASNO", asset.RemoteId);
            prn = prn.Replace("9876543210", asset.Id.ToString().PadRight(10));
            prn = prn.Replace("ABCDABCDABCDABCDABCDABCD", "C05E" + asset.Id.ToString("D20"));
            //prn = prn.Replace("SICILSICILSICILSICILSICILSICIL", asset.RemoteId);
            try
            {
                printer.Send(Utils.StringToByteArray(prn));
            }
            catch (Exception ex)
            {
                reporter.Report("Yazıcı Hatası|" + ex.Message);
            }
        }

        private string CenterBySpace(string replacee, string replacer)
        {
            if (replacee.Length <= replacer.Length)
                return replacer.Substring(0, replacee.Length);
            var textSpace = "";
            for (int i = 0; i < (replacee.Length - replacer.Length) / 2; i++)
                textSpace += " ";
            return textSpace + replacer;
        }
    }
}