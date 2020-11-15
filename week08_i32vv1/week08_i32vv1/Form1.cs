﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week08_i32vv1
{
    public partial class Form1 : Form
    {
        private Toy _nextToy;
    
        private List<Toy> _toys = new List<Toy>();
        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set
            {
                _factory = value;
                DisplayNext();
            }
        }
        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();

        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add(toy);
            toy.Left = -toy.Width;
            mainPanel.Controls.Add(toy);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                    maxPosition = toy.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestBall = _toys[0];
                mainPanel.Controls.Remove(oldestBall);
                _toys.Remove(oldestBall);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory()
            {
                BallColor = button.BackColor
            };
        }
        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 50;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorpicker = new ColorDialog();

            colorpicker.Color = button.BackColor;
            if (colorpicker.ShowDialog() != DialogResult.OK)
                return;
            button.BackColor = colorpicker.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory()
            {
                BoxColor = button4.BackColor,
                RibbonColor = button5.BackColor
            };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorpicker = new ColorDialog();

            colorpicker.Color = button.BackColor;
            if (colorpicker.ShowDialog() != DialogResult.OK)
                return;
            button5.BackColor = colorpicker.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorpicker = new ColorDialog();

            colorpicker.Color = button.BackColor;
            if (colorpicker.ShowDialog() != DialogResult.OK)
                return;
            button4.BackColor = colorpicker.Color;
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
