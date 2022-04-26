using SatoConnector.Properties;
using SATOPrinterAPI;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SatoConnector
{
    public partial class SettingsForm : Form
    {
        MyAppContext context;

        public SettingsForm(MyAppContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            yaziciPortu.DisplayMember = "Name";
            var printers = context.printer.GetPrinters();
            foreach (var ptr in printers)
                yaziciPortu.Items.Add(ptr);
            if (!string.IsNullOrEmpty(Settings.Default.YaziciAdi))
                yaziciPortu.SelectedItem = printers.FirstOrDefault(x => x.Name == Settings.Default.YaziciAdi);

            sunucuIp.Text = Settings.Default.SunucuIp;
            musteriAdi.Text = Settings.Default.MusteriAdi;
            kullaniciAdi.Text = Settings.Default.KullaniciAdi;
            sifre.Text = Settings.Default.Sifre;
            sablonPath.Text = Settings.Default.SablonPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (yaziciPortu.SelectedItem != null)
            {
                Settings.Default.YaziciAdi = ((Printer.USBInfo)yaziciPortu.SelectedItem).Name;
                Settings.Default.YaziciPortu = ((Printer.USBInfo)yaziciPortu.SelectedItem).PortID;
            }
            else
                Settings.Default.YaziciPortu = "";
            Settings.Default.SunucuIp = sunucuIp.Text;
            Settings.Default.MusteriAdi = musteriAdi.Text;
            Settings.Default.KullaniciAdi = kullaniciAdi.Text;
            Settings.Default.Sifre = sifre.Text;
            Settings.Default.SablonPath = sablonPath.Text;
            Settings.Default.Save();
            context.trayIcon.ShowBalloonTip(3000, "Yazıcı Ayarları", "Ayarlar kaydedildi", ToolTipIcon.Info);
            context.Initialize();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sablonPath.Text = openFileDialog1.FileName;
            }
        }
    }
}
