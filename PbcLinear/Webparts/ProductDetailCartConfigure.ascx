<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetailCartConfigure.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ProductDetailCartConfigure" %>
<%@ Register Src="~/CMSModules/Ecommerce/Controls/ProductOptions/ShoppingCartItemSelector.ascx" TagName="CartItemSelector" TagPrefix="uc1" %>


<div runat="server" ID="AddToCartContainer">
   <uc1:CartItemSelector ID="addItem" runat="server" AddToCartTooltip="Add to cart" AddToCartLinkText="Add to cart" ShowWishlistLink="false" ShowUnitsTextBox="true" AlwaysShowTotalPrice="true" TotalPriceLabel=" " ShowProductOptions="false" StockVisible="false" UnavailableVariantInfoEnabled="false" UsedInProductDetail="true" CssClassNormal="normal" CssClassFade="fade" AutoPostBack="true" />
    </div>
<div runat="server" ID="ConfigureConatiner" class="cartless-product">
    <asp:HyperLink runat="server" ID="ConfigureHyperLink" CssClass="button uppercase"></asp:HyperLink>
</div>
<div runat="server" ID="CallContainer" class="cartless-product">
    <a href="tel:18158395600" class="button--tel-link uppercase"><asp:Literal runat="server" ID="CallInfo"/></a>
    <div class="cartless-product__text"><a href="tel:18158395600" class="tel-link">+1-815-389-5600</a></div>
</div>

