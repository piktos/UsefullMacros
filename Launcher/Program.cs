using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyCustomApplicationContext());
        }
    }

    public class MyCustomApplicationContext : ApplicationContext
    {
        public NotifyIcon trayIcon;
        Form1 frm = new Form1();

        public MyCustomApplicationContext()
        {



            trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.duck,
                ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Info", Open),new MenuItem("Beenden", Exit) }),
                Visible = true,
                Text = "HotKeyManager"
            };

        }

        private void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            //await Klassen.Data.Management.CreateBooking("GE");
            Application.Exit();
        }

        private void Open(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            frm.Show();
            frm.FormClosing += cls;
        }
        private void cls(object sender, FormClosingEventArgs e)
        {
            frm = new Form1();
            trayIcon.Visible = true;
        }
    }
}
