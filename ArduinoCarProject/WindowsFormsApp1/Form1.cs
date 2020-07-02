using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       // private SerialPort myport;

        public Form1()
        {
            InitializeComponent();
            //InitializePortConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                PortBox.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                serialPort1.Open();
                PortBox.SelectedIndex = 0;
                serialPort1.BaudRate = (9600);
                serialPort1.ReadTimeout = (2000);
                serialPort1.WriteTimeout = (2000);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void OnBtn_Click(object sender, EventArgs e)
        //{
        //    
        //}

        //private void OffBtn_Click(object sender, EventArgs e)
        //{
           
        //}

        private void PortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = PortBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.B)
            {
                // MessageBox.Show("Off should be triggered!");
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("back");
                    Console.WriteLine("back");
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // the diode should be on
            if (e.KeyCode == Keys.O)
            {
                // MessageBox.Show("On should be triggered!");
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("on");
                    Console.WriteLine("on");
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //the diode should be off
            if (e.KeyCode == Keys.F)
            {
                // MessageBox.Show("Off should be triggered!");
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("off");
                    Console.WriteLine("off");
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }

        //private void InitializePortConnection()
        //{
        //    myport = new SerialPort();
        //    myport.BaudRate = 9600;
        //    myport.
        //}
    }
}
