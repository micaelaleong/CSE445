using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Drawing2D;

namespace Assignment5
{
    public partial class Captcha : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
            }
        }

        private void GenerateCaptcha()
        {
            // creates Guid (globally unique identifier)
            string captcha = Guid.NewGuid().ToString("N").Substring(0, 6);
            ViewState["Captcha"] = captcha;

            Random random = new Random();
            Bitmap bitmap = new Bitmap(100, 30);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            // various different HatchStyle's to be randomly selected as the background
            HatchStyle[] bkg = new HatchStyle[] {
                HatchStyle.BackwardDiagonal, HatchStyle.Cross, HatchStyle.DashedDownwardDiagonal, HatchStyle.DashedHorizontal,
                HatchStyle.DashedVertical, HatchStyle.DiagonalBrick, HatchStyle.DiagonalCross
            };

            RectangleF rectangleArea = new RectangleF(0, 0, 250, 250);
            Brush designBrush = new HatchBrush(bkg[random.Next(bkg.Length - 1)], Color.Blue, Color.Pink); // choose one of the HatchStyles in pink and blue
            graphics.FillRectangle(designBrush, rectangleArea);
            graphics.DrawString(captcha, new Font("Times New Roman", 16), Brushes.Black, new PointF(10, 5));

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                imgCaptcha.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            }
        }

        protected void newCaptchaButtonClick(object sender, EventArgs e)
        {
            GenerateCaptcha(); // generate a new CAPATCHA
        }

        public bool ValidateCaptcha()
        {
            // checks whether CAPTCHA string and user input match
            return txtCaptcha.Text == (string)ViewState["Captcha"];
        }
    }
}