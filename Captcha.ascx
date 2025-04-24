<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Captcha.ascx.cs" Inherits="Assignment5.Captcha" %>

<asp:Image ID="imgCaptcha" runat="server" />
<br />
<asp:TextBox ID="txtCaptcha" runat="server" />
<asp:Button ID="newCaptchaButton" runat="server" Text="New CAPTCHA" OnClick="newCaptchaButtonClick" />
<asp:Label ID="lblError" runat="server" ForeColor="Red" />

