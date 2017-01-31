<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayPalRedirect.aspx.cs" Inherits="PbcLinear.Web.PayPal.PayPalRedirect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <p>Redirecting...</p>
    <asp:Literal runat="server" id="ltrPayPalForm"></asp:Literal>

    
    <script>document.getElementById('paypalForm').submit();</script>
</body>
</html>
