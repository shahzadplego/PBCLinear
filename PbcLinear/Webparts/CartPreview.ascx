<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartPreview.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.CartPreview" %>



 <%-- <a runat="server" class="cart-preview__cart" href="<asp:Literal runat=">
    <p><asp:Literal runat="server" ID="CartTotal"></asp:Literal></p>
  </a>--%>

<asp:HyperLink runat="server" class="cart-preview__cart" ID="CartUrl" >   
    <span class="cart-preview__label"><asp:Literal runat="server" ID="CartLabel"/></span>
    <span class="cart-preview__total" runat="server" ID="CartTotalContainer"><asp:Literal runat="server" ID="CartTotal" /></span>
    <span class="cart-preview__icon"><img src="/PbcLinear/img/svg/simple-cart.svg" alt="Shopping Cart" /></span>
</asp:HyperLink>

