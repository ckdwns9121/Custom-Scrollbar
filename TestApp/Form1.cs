using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TestApp
{
    public partial class Form1 : Form
    {

        Point pt;

        public Form1()
        {
            InitializeComponent();

            Button b = new Button();
            b.Location = new Point(0, 300);
            b.Text = "test";
            this.innerPanel.Controls.Add(b);


            Button c = new Button();
            c.Location = new Point(0, 600);
            c.Text = "test";
            this.innerPanel.Controls.Add(c);


            Button a = new Button();
            a.Location = new Point(0, 900);
            a.Text = "test";
            this.innerPanel.Controls.Add(a);


            Button t = new Button();
            t.Location = new Point(0, 1900);
            t.Text = "tes@@@t";
            this.innerPanel.Controls.Add(t);

           // pt = new Point(this.innerPanel.AutoScrollPosition.X, this.innerPanel.AutoScrollPosition.Y);
            this.customScrollbar1.Minimum = 0;
            this.customScrollbar1.Maximum = this.innerPanel.DisplayRectangle.Height;
            //this.customScrollbar1.Maximum = 200;

            this.customScrollbar1.LargeChange = customScrollbar1.Maximum / customScrollbar1.Height + this.innerPanel.Height;
            this.customScrollbar1.SmallChange = 15;
            this.customScrollbar1.Value = Math.Abs(this.innerPanel.AutoScrollPosition.Y);

            this.BasicScroll.Minimum = 0;
            this.BasicScroll.Maximum = this.innerPanel.DisplayRectangle.Height;
            this.BasicScroll.LargeChange = BasicScroll.Maximum / BasicScroll.Height + this.innerPanel.Height;
            this.BasicScroll.SmallChange = 15;
            this.BasicScroll.Value = Math.Abs(this.innerPanel.AutoScrollPosition.Y);
            Console.WriteLine(this.innerPanel.DisplayRectangle.Height);
        }


        private void customScrollbar1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            //customScrollbar1.Value = 100;
        }

        private void customScrollbar1_Scroll(object sender, EventArgs e)
        {
            try
            {

                innerPanel.AutoScrollPosition = new Point(0, customScrollbar1.Value);
                Console.WriteLine("custom: " + customScrollbar1.Value.ToString());
                BasicScroll.Value = customScrollbar1.Value;
                customScrollbar1.Invalidate();
                Application.DoEvents();
                Console.WriteLine("드래그 vscroll: " + BasicScroll.Value.ToString() + "  custom: " + customScrollbar1.Value.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            innerPanel.AutoScrollPosition = new Point(0, BasicScroll.Value);
            customScrollbar1.Value = BasicScroll.Value;
            Application.DoEvents();
            Debug.WriteLine("vscroll: " + BasicScroll.Value.ToString() + "  custom: " + customScrollbar1.Value.ToString());
        }

        private void btnHidePanelScrollbar_Click(object sender, EventArgs e)
        {
            if (btnHidePanelScrollbar.Text == "Hide Panel Scrollbar")
            {
                outerPanel.Width -= 20;
                customScrollbar1.Left -= 20;
                btnHidePanelScrollbar.Text = "Show Panel Scrollbar";
            }
            else
            {
                outerPanel.Width += 20;
                customScrollbar1.Left += 20;
                btnHidePanelScrollbar.Text = "Hide Panel Scrollbar";
            }
        }

        private void ts(object sender, MouseEventArgs e)
        {

            customScrollbar1.Value = innerPanel.AutoScrollPosition.Y * -1;
            Console.WriteLine("리스트 스크롤 밸류" + innerPanel.AutoScrollPosition.Y * -1);
            innerPanel.AutoScrollPosition = new Point(0, customScrollbar1.Value);
            customScrollbar1.Invalidate();
            Application.DoEvents();

        }

        private void realScroll(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                customScrollbar1.Value = (innerPanel.AutoScrollPosition.Y + 120) * -1;
                Console.WriteLine("커스텀 스크롤 밸류 업" + (innerPanel.AutoScrollPosition.Y + 120) * -1);
                innerPanel.AutoScrollPosition = new Point(0, customScrollbar1.Value);
                customScrollbar1.Invalidate();
                Application.DoEvents();
            }
            else
            {
                customScrollbar1.Value = (innerPanel.AutoScrollPosition.Y - 120) * -1;
                Console.WriteLine("커스텀 스크롤 밸류 다운" + (innerPanel.AutoScrollPosition.Y - 120)* -1);
                innerPanel.AutoScrollPosition = new Point(0, customScrollbar1.Value);
                customScrollbar1.Invalidate();
                Application.DoEvents();
            }

        }

    }
}