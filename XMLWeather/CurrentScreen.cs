using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();


        }

        public void DisplayCurrent()
        {
            cityOutput.Text = $"{Form1.days[0].location}";
            tempOutput.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].currentTemp), 0)}°";
            minOutput.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].tempLow), 0)}°";
            maxOutput.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].tempHigh), 0)}°";
            if (Convert.ToInt32(Form1.days[1].condition) < 233)
            {
                c.BackgroundImage = Properties.Resources._11d_2x;
            }
            else if (Convert.ToInt32(Form1.days[1].condition) < 322)
            {
                c.BackgroundImage = Properties.Resources._09d_2x;
            }
            else if (Convert.ToInt32(Form1.days[1].condition) < 505)
            {
                c.BackgroundImage = Properties.Resources._10d_2x;
            }
            else if (Convert.ToInt32(Form1.days[1].condition) == 511)
            {
                c.BackgroundImage = Properties.Resources._13d_2x;
            }
            else if (Convert.ToInt32(Form1.days[1].condition) < 532)
            {
                c.BackgroundImage = Properties.Resources._09d_2x;
            }
            else if (Convert.ToInt32(Form1.days[1].condition) < 623)
            {
                c.BackgroundImage = Properties.Resources._13d_2x;
            }
            else if (Convert.ToInt32(Form1.days[1].condition) < 782)
            {
                c.BackgroundImage = Properties.Resources._50d_2x;
            }
            else if (Convert.ToInt32(Form1.days[1].condition) == 800)
            {
                c.BackgroundImage = Properties.Resources._01d_2x;
            }
            else if (Convert.ToInt32(Form1.days[1].condition) == 801)
            {
                c.BackgroundImage = Properties.Resources._02d_2x;
            }
            else if (Convert.ToInt32(Form1.days[1].condition) == 802)
            {
                c.BackgroundImage = Properties.Resources._03d_2x;
            }
            else if (Convert.ToInt32(Form1.days[1].condition) < 805)
            {
                c.BackgroundImage = Properties.Resources._04d_2x;
            }
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void locationInput_TextChanged(object sender, EventArgs e)
        {
            if (locationInput.Text == "") { inputCover.Visible = true; }
            else { inputCover.Visible = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.location = locationInput.Text;
            locationInput.Text = "";
            //Form1.days.Clear();

            try
            {
                Form1.ExtractForecast();
                Form1.days.RemoveRange(0, 8);
                Form1.ExtractCurrent();
            }
            catch
            {
                inputCover.Text = "LOCATION NOT FOUND";
                inputCover.ForeColor = Color.Plum;
                inputCover.Visible = true;
                Refresh();
                Thread.Sleep(1500);
                inputCover.Text = "Location (city, CC)";
                inputCover.ForeColor = Color.Thistle;
            }
            
            DisplayCurrent();
        }

        private void inputCover_Click(object sender, EventArgs e)
        {
            locationInput.Focus();
        }
    }
}
