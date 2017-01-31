<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetailCartConfigure.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ProductDetailCartConfigure" %>
<%@ Register Src="~/CMSModules/Ecommerce/Controls/ProductOptions/ShoppingCartItemSelector.ascx" TagName="CartItemSelector" TagPrefix="uc1" %>


<div runat="server" ID="AddToCartContainer">
   <uc1:CartItemSelector ID="addItem" runat="server" AddToCartTooltip="Add to cart" AddToCartLinkText="Add to cart" ShowWishlistLink="false" ShowUnitsTextBox="true" AlwaysShowTotalPrice="true" TotalPriceLabel="PER UNIT" ShowProductOptions="false" StockVisible="false" UnavailableVariantInfoEnabled="false" UsedInProductDetail="true" CssClassNormal="normal" CssClassFade="fade" />
    </div>
<div runat="server" ID="ConfigureConatiner">
    <asp:HyperLink runat="server" ID="ConfigureHyperLink"></asp:HyperLink>
</div>
<div runat="server" ID="CallContainer">
    <asp:Literal runat="server" ID="CallInfo"></asp:Literal>
    <asp:Literal runat="server" ID="CallNumber"></asp:Literal>
</div>

<script>
    
</script>