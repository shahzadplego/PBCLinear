<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PayPalRedirect.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.Payments.PayPalRedirect" %>

<p>Redirecting...</p>
    <asp:Literal runat="server" id="ltrPayPalForm"></asp:Literal>

    
    <script>document.getElementById('paypalForm').submit();</script>

THIS STUFF ISN"T NEEDED::::
<asp:Panel runat="server" ID="pnlPaymentDataContainer" CssClass="PaymentGatewayDataContainer tinyBox" />
<asp:Panel runat="server" ID="pnlPayment">
    <asp:Panel runat="server" ID="pnlError" CssClass="ErrorLabel" Visible="false">
        <asp:Label runat="server" ID="lblError" EnableViewState="false" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlInfo" CssClass="InfoLabel" Visible="false">
        <asp:Label runat="server" ID="lblInfo" EnableViewState="false" />
    </asp:Panel>
    <div class="BlockContent">
        <div class="OrderSummary">
            <cms:LocalizedLabel ResourceString="PaymentSummary.OrderId" ID="lblOrderId" runat="server" EnableViewState="false" />
            <asp:Label ID="lblOrderIdValue" runat="server" EnableViewState="false" />
        </div>
        <div class="PaymentSummary">
            <cms:LocalizedLabel ResourceString="PaymentSummary.Payment" ID="lblPayment" runat="server" EnableViewState="false" />
            <asp:Label ID="lblPaymentValue" runat="server" EnableViewState="false" />
        </div>
        <div class="PaymentPriceSummary">
            <cms:LocalizedLabel ResourceString="PaymentSummary.TotalPrice" ID="lblTotalPrice" runat="server" EnableViewState="false" />
            <asp:Label ID="lblTotalPriceValue" runat="server" EnableViewState="false" />
        </div>
    </div>
    <asp:Panel runat="server" ID="Panel1" CssClass="PaymentGatewayDataContainer tinyBox" />
</asp:Panel>
<cms:CMSButton runat="server" ID="btnProcessPayment" ButtonStyle="Primary" CssClass="ProcessPaymentButton" OnClick="btnProcessPayment_Click" Text="Process payment" />
