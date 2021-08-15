using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(163, 142);

            Graphics graphics = Graphics.FromImage(bitmap);

            SolidBrush brush = new SolidBrush(Color.FromArgb(0, 217, 0));

            // Create points that define polygon.
            PointF point1 = new PointF(22.00F, 0.0F);
            PointF point2 = new PointF(141.0F, 0.0F);
            PointF point3 = new PointF(163.0F, 23.0F);
            PointF point4 = new PointF(163.0F, 120.0F);
            PointF point5 = new PointF(131.0F, 140.0F);
            PointF point6 = new PointF(14.0F, 63.0F);
            PointF point7 = new PointF(0.0F, 39.0F);
            PointF point8 = new PointF(0.0F, 25.0F);

            PointF[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7,
                 point8
             };

            graphics.FillEllipse(brush, 0, 0, 46, 46);
            graphics.FillEllipse(brush, 0, 18, 46, 46);
            graphics.FillEllipse(brush, 117, 00, 46, 46);
            graphics.FillEllipse(brush, 117, 96, 46, 46);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // Draw polygon curve to screen.
            graphics.FillPolygon(brush, curvePoints);
            bitmap.Save("result5.jpg");
            Bitmap bitmap2 = (Bitmap)Bitmap.FromFile(@"C:\Users\klark\Downloads\Group.png");

            bitmap2 = SetImageOpacity(bitmap2, 1.0f);

            Bitmap bitmap3 = new Bitmap(360, 640);

            var width = bitmap3.Width / 2 - bitmap2.Width / 2;
            var height = bitmap3.Height / 2 - bitmap2.Height / 2;

            Graphics g = Graphics.FromImage(bitmap3);
            g.DrawImageUnscaled(bitmap, bitmap3.Width /2 - bitmap2.Width / 4, bitmap3.Height / 2 - bitmap.Height);
            g.DrawImageUnscaled(bitmap2, bitmap3.Width / 2 - bitmap2.Width / 2, bitmap3.Height / 2 - bitmap2.Height / 2);
            bitmap3.Save("result.jpg");

        
        }

        public Bitmap SetImageOpacity(Image image, float opacity)
        {
            try
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(bmp))
                {

                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = opacity;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }

}
