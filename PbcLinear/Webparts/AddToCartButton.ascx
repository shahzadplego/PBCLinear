<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddToCartButton.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.AddToCartButton" %>
<%@ Register Src="~/CMSModules/Ecommerce/Controls/ProductOptions/ShoppingCartItemSelector.ascx" TagName="CartItemSelector" TagPrefix="uc1" %>

   <uc1:CartItemSelector ID="addItem" runat="server" AddToCartTooltip="Add to cart" AddToCartLinkText="Add to cart" ShowWishlistLink="false" ShowUnitsTextBox="true" AlwaysShowTotalPrice="true" TotalPriceLabel="Total price:" ShowProductOptions="false" StockVisible="false" UnavailableVariantInfoEnabled="false" UsedInProductDetail="true" CssClassNormal="normal" CssClassFade="fade" />


<%--For Reference Shopping Cart Preview Code
<div class="shopping-cart-mini-preview">
    <a class="cartLink" href="{%Settings.CMSShoppingCartURL#%}">
      	 Shopping cart
      <span class="SmallTextLabel">
        {% ECommerceContext.CurrentShoppingCart.TotalUnits|(resolver)WebPartRender #%} 
        {% (ECommerceContext.CurrentShoppingCart.TotalUnits == 1)? "item for" : "items for" |(resolver)WebPartRender #%} 
        {% FormatPrice(ECommerceContext.CurrentShoppingCart.TotalPrice)|(resolver)WebPartRender #%}
      </span>
    </a>
</div>--%>


