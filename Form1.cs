﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DehotomiaM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double F(double x)
        {
            double f;
            f = (27 - 18 * x + 2 * Math.Pow(x, 2)) * Math.Exp(-(x / 3));
            return f;
        }
        double Proisvodnaya(double x)
        {
            double y = -1 * (2 * x * x * Math.Exp(-x / 3) / 3) + 10 * x * Math.Exp(-x / 3) - 27 * Math.Exp(-x / 3);
            return y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double Xi = Convert.ToDouble(textBox3.Text);
            Xi = (int)-Math.Log10(Xi);
            double max, min;
            double delta = Xi / 10;

            while (b - a >= Xi)
            {
                double middle = (a + b) / 2;
                double lambda = middle - delta, mu = middle + delta;
                if (F(lambda) < F(mu))
                    b = mu;
                else
                    a = lambda;
            }
            min =  (a + b) / 2;


            while (b - a >= Xi)
            {
                double middle = (a + b) / 2;
                double lambda = middle - delta, mu = middle + delta;
                if (-F(lambda) < -F(mu))
                    b = mu;
                else
                    a = lambda;
            }
            max = (a + b) / 2;

            MessageBox.Show($"минимум {min}; максимум {max}");
            this.chart1.Series[0].Points.Clear();
            double x = a;
            double y;
            while (x <= b)
            {
                y = F(x);
                this.chart1.Series[0].Points.AddXY(x, y);
                x += 0.1;
            }
        }
    }
}
