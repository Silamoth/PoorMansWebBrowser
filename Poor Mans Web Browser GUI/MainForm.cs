using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace Poor_Mans_Web_Browser_GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            sourceTextBox.Clear();

            String server = serverTextBox.Text;

            TcpClient client;

            try
            {
                client = new TcpClient(server, 80);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                return;
            }

            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());

            try
            {
                writer.WriteLine("GET / HTTP/1.0\n\n");
                writer.Flush();

                String data = reader.ReadLine();

                while (data != null)
                {
                    sourceTextBox.Text += data + Environment.NewLine;

                    data = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}