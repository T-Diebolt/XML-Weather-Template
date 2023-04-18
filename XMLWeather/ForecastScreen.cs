using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using System.Net;
using XMLWeather.Properties;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {

        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            foreach (Control c in Controls)
            {
                if (c is Label)
                {
                    char x = c.Name[3];
                    int i = x - '0';

                    switch (c.Name[2])
                    {
                        case 'y':
                            c.Text = $"{Form1.days[i - 1].date}";
                            break;
                        case 'n':
                            c.Text = $"{Math.Round(Convert.ToDouble(Form1.days[i - 1].tempLow), 0)}°";
                            break;
                        case 'x':
                            c.Text = $"{Math.Round(Convert.ToDouble(Form1.days[i - 1].tempHigh), 0)}°";
                            break;
                        default:
                            break;
                    }
                }

                if (c is PictureBox)
                {
                    char x = c.Name[3];
                    int i = x - '0';

                    if (Convert.ToInt32(Form1.days[i - 1].condition) < 233)
                    {
                        c.BackgroundImage = Properties.Resources._11d_2x;
                    }
                    else if(Convert.ToInt32(Form1.days[i - 1].condition) < 322)
                    {
                        c.BackgroundImage = Properties.Resources._09d_2x;
                    }
                    else if (Convert.ToInt32(Form1.days[i - 1].condition) < 505)
                    {
                        c.BackgroundImage = Properties.Resources._10d_2x;
                    }
                    else if (Convert.ToInt32(Form1.days[i - 1].condition) == 511)
                    {
                        c.BackgroundImage = Properties.Resources._13d_2x;
                    }
                    else if (Convert.ToInt32(Form1.days[i - 1].condition) < 532)
                    {
                        c.BackgroundImage = Properties.Resources._09d_2x;
                    }
                    else if (Convert.ToInt32(Form1.days[i - 1].condition) < 623)
                    {
                        c.BackgroundImage = Properties.Resources._13d_2x;
                    }
                    else if (Convert.ToInt32(Form1.days[i - 1].condition) < 782)
                    {
                        c.BackgroundImage = Properties.Resources._50d_2x;
                    }
                    else if (Convert.ToInt32(Form1.days[i - 1].condition) == 800)
                    {
                        c.BackgroundImage = Properties.Resources._01d_2x;
                    }
                    else if (Convert.ToInt32(Form1.days[i - 1].condition) == 801)
                    {
                        c.BackgroundImage = Properties.Resources._02d_2x;
                    }
                    else if (Convert.ToInt32(Form1.days[i - 1].condition) == 802)
                    {
                        c.BackgroundImage = Properties.Resources._03d_2x;
                    }
                    else if (Convert.ToInt32(Form1.days[i - 1].condition) < 805)
                    {
                        c.BackgroundImage = Properties.Resources._04d_2x;
                    }
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }
    }
}
