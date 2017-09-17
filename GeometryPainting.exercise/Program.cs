using GeometryTasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometryPainting
{
    static class Program
    {
        static List<Segment> CreateSegments()
        {
            var result = new List<Segment>();
            for (int i=0;i<=255;i++)
            {
                var segment = new Segment
                {
                    Begin = new Vector { X = 0, Y = i },
                    End = new Vector { X = 255, Y = i }
                };
                if (i != 0)
                {
                    segment.SetColor(Color.FromArgb(i, i, i));
                }
                result.Add(segment);
            }

            var segm = new Segment
            {
                Begin = new Vector { X = 0, Y = 1 },
                End = new Vector { X = 255, Y = 1 }
            };
            segm.SetColor(Color.FromArgb(2, 2, 2));
            result.Add(segm);
            return result;
        }

        private static void DrawSegments(object sender, PaintEventArgs e)
        {
            var segments = CreateSegments();
            foreach(var segment in segments)
            {
                Pen pen = null;
                pen = new Pen(segment.GetColor());
                e.Graphics.DrawLine(pen, (float)segment.Begin.X, (float)segment.Begin.Y, (float)segment.End.X, (float)segment.End.Y);
            }
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form();
            form.ClientSize = new Size(255, 255);
            form.Paint += DrawSegments;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            Application.Run(form);
        }

       
    }
}
