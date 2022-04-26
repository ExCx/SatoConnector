using SatoConnector.Properties;
using SATOPrinterAPI;
using System;
using System.Windows.Forms;

namespace SatoConnector
{
    public class MyAppContext : ApplicationContext
    {
        public NotifyIcon trayIcon;
        public PrinterManager printer;
        public ServerManager server;
        private IProgress<string> reporter;
        private System.Timers.Timer timer;

        public MyAppContext()
        {
            reporter = new Progress<string>(Report);
            printer = new PrinterManager(reporter);

            trayIcon = new NotifyIcon()
            {
                Icon = Resources.rfid,
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Ayarlar", ShowSettings),
                    new MenuItem("Kapat", Exit)
                }),
                Visible = true
            };

            if (!string.IsNullOrEmpty(Settings.Default.YaziciPortu))
                printer.Connect();

            if (string.IsNullOrEmpty(Settings.Default.SunucuIp))
                new SettingsForm(this).ShowDialog();
            else
            {
                Initialize();
            }
        }

        public async void Initialize()
        {
            server = new ServerManager(reporter);
            await server.Authenticate();
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
            timer = new System.Timers.Timer(5000);
            timer.AutoReset = true; // the key is here so it repeats
            timer.Elapsed += ControlAndPrint;
            timer.Start();
        }

        public bool IsBusy { get; set; } = false;
        private async void ControlAndPrint(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (printer.IsConnected && !IsBusy)
            {
                var assetsToPrint = await server.GetAllWaitingForPrint();
                if (assetsToPrint.Count > 0)
                {
                    IsBusy = true;
                    trayIcon.ShowBalloonTip(3000, "Etiketleme", assetsToPrint.Count + " adet etiket yazdırılıyor", ToolTipIcon.Info);
                    foreach (var asset in assetsToPrint)
                        printer.Print(asset);
                    await server.UpdateLabeledState(assetsToPrint);
                    IsBusy = false;
                }
            }
        }

        private void Report(string message)
        {
            trayIcon.ShowBalloonTip(3000, message.Split('|')[0], message.Split('|')[1], ToolTipIcon.Info);
        }

        private void ShowSettings(object sender, EventArgs e)
        {
            new SettingsForm(this).ShowDialog();
        }

        void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Environment.Exit(1);
        }
    }
}
