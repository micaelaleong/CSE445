using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpotifyTokenLib;

namespace Assignment5
{
    public partial class Default : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await SpotifyTokenCookie();
            }

        }

        protected void memberButtonClick(object sender, EventArgs e)
        {
            // to be added once member page is implemented
        }

        protected void staffButtonClick(object sender, EventArgs e)
        {
            // to be added once member page is implemented
        }
        protected void captchaButtonClick(object sender, EventArgs e)
        {
            if (captchaString.ValidateCaptcha()) // checks that the CAPATCHA string and user input match using function from Captcha.ascx
            {
                captchaResultLabel.ForeColor = System.Drawing.Color.Green;
                captchaResultLabel.Text = "CAPTCHA correct!";
            }
            else // if CAPATCHA and user input do not match
            {
                captchaResultLabel.ForeColor = System.Drawing.Color.Red;
                captchaResultLabel.Text = "CAPTCHA incorrect.";
            }
        }

        private async Task SpotifyTokenCookie()
        {
            HttpCookie tokenCookie = Request.Cookies["SpotifyToken"];

            // if token is already stored, print out token anme
            if (tokenCookie != null && !string.IsNullOrEmpty(tokenCookie.Value))
            {
                cookieLabelResult.Text = "Token found in cookie: " + tokenCookie.Value;
            }
            else
            {
                // temporary token information to test component (will be replaced with actual call to DLL component later)
                Random rnd = new Random();
                int tokenNumber = rnd.Next(1, 100);
                string token = "temp_token_" + tokenNumber.ToString();
                int expiresIn = 20; // expires in 20 seconds for testing purposes (will extend later)

                if (!string.IsNullOrEmpty(token))
                {
                    // create the cookie
                    HttpCookie newCookie = new HttpCookie("SpotifyToken", token); // create a new cookie with token name
                    newCookie.Expires = DateTime.UtcNow.AddSeconds(expiresIn); // set expiration data
                    newCookie.HttpOnly = true; // ensures that the cookie cannot be accessed by a client
                    Response.Cookies.Add(newCookie); // adds cookie

                    cookieLabelResult.Text = "Token fetched from DLL and stored in cookie.";
                }
                else
                {
                    cookieLabelResult.Text = "Failed to fetch token.";
                }
                
            }
        }


    }
}