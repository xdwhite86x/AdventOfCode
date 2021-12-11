using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdventOfCode.Day5;

namespace Day5Plot
{
    public partial class Form1 : Form
    {
        private List<HydroThermalLine> pointsList = new();
        private Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            ParseLineDataFile();
            
            
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var p in pointsList)
            {
                if (p.isHorizontalOrVertical)
                {
                    var length = p.GetLineLength();

                    length *= 10;
                    
                    
                    var pen = new Pen(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)));
                    e.Graphics.DrawLine(pen, new Point(p.Start.X, p.Start.Y), new Point(p.End.X * 10, p.End.Y * 10));
                }
            }
        }

        private void ParseLineDataFile()
        {
            using StreamReader sr = new("./inputDay5-test.txt");
            while (!(sr.EndOfStream))
            {
                var hl = new HydroThermalLine(sr.ReadLine());
                pointsList.Add(hl);
            }
          
        }
    }
}