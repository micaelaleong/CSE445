<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5.Default" Async="true"%>
<%@ Register Src="~/Captcha.ascx" TagName="Captcha" TagPrefix="uc" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CSE445 Assignment 5 - Group 49</title>
</head>
<style>
    .div1{
        h1 {text-align: center;}
        p {text-align: center;}
    }
</style>
<body>
    <form id="form1" runat="server">
        <div class="div1">
            <h1>
                Spotify Trends
            </h1>
        </div>
        <div class="div1">
            <p>
                This app allows members to explore global and regional Top 50 tracks from Spotify.
                The staff regularly curates featured tracks, which are also accesible to members.
            </p>
        </div>

        <div>
            <asp:Button ID="memberButton" runat="server" Text="Member Login" OnClick="memberButtonClick" />
            <asp:Button ID="staffButton" runat="server" Text="Staff Login" OnClick="staffButtonClick" />
        </div>
        <br />
        <div>
            <h2>CAPTCHA Component</h2>
            <h3>
                Testing Instructions:
            </h3>
            <p>
                This component is temporarily held here to demonstrate its usability. It will later be moved to the member page, where users 
                will have to pass the CAPTCHA verifiction before being able to register. To test this component, simply enter in the string 
                of characters you see. 
            </p>
            <uc:Captcha ID="captchaString" runat="server" />
            <asp:Button ID="captchaButton" runat="server" Text="Enter" OnClick="captchaButtonClick" />
            <asp:Label ID="captchaResultLabel" runat="server" ForeColor="Green" />
        </div>
        <br />
        <div>
            <h2>Spotify Token Cookie</h2>
            <h3>
                Testing Instructions:
            </h3>
            <p>
                This token stores a token and later reuses it. Currently, it is given a temporary token (temp_token_...), 
                which is stored when the page is first loaded. Once the page is reloaded, the stored token is shown.
            </p>
            <p>
                To test again, you can clear your browser cookies and then reload the page.
                You can also wait 20 seconds for the cookie to expire and then reload the page. 
                A new example token number will be shown.
            </p>
            <p>
                This component will later use another group member's token fetching and parsing DLL component 
                to actually store and reuse the relevant token.
            </p>
            <br />
            <asp:Label ID="cookieLabelResult" runat="server" />
        </div>
    </form>
</body>
</html>
