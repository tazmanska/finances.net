using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Nancy.Hosting.Self;

namespace Finances.Net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            urlToolStripMenuItem.Text = UrlToApplication;
            new Thread(() =>
            {
                Thread.Sleep(1000);
                using (
                    var host =
                        new NancyHost(
                            new HostConfiguration()
                            {
                                UrlReservations = new UrlReservations() {CreateAutomatically = true}
                            },
                            new Uri(UrlToApplication)))
                {
                    host.Start();
                    OpenBrowser(UrlToApplication);
                    _autoResetEvent.WaitOne();
                    host.Stop();
                }
            }).Start();
        }

        private const string UrlToApplication = "http://localhost:11111";

        private readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _autoResetEvent.Set();
            }
            catch
            {
            }
        }

        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                string browser = GetDefaultBrowserPath();
                Process.Start(browser, url);
            }
        }

        private static string StringToPath(string str)
        {
            var chPathEnd = ' ';
            var diff = 0;
            if (str[0] == '"')
            {
                chPathEnd = '"';
                diff = 1;
            }

            for (var i = 1; i < str.Length; i++)
            {
                if (str[i] == chPathEnd)
                {
                    return str.Substring(diff, i - diff);
                }
            }
            return str;
        }

        private static string GetDefaultBrowserPath()
        {
            try
            {
                using (var registryKey = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command", false))
                {
                    if (registryKey != null)
                    {
                        var file = (string)registryKey.GetValue(null, null);
                        if (!string.IsNullOrEmpty(file))
                        {
                            return StringToPath(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            return "iexplore";
        }

        internal void _Close()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    Thread.Sleep(1000);
                    Close();
                }));
                return;
            }
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Close();
        }

        private void urlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenBrowser(UrlToApplication);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
