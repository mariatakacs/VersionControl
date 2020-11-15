﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week08_i32vv1.Abstractions
{
    public class Toy : Label
    {
        public Toy()
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Toy_Paint;
        }

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        private void DrawImage(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        protected abstract void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }

        public virtual void MoveToy()
        {
            Left += 1;
        }
    }
}