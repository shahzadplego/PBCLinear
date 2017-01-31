<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductLanding.ascx.cs" Inherits="PbcLinear.WebParts.Products.ProductLanding" %>
<div class="content-width clearfix">
    <section class="flex-3 grid__flex-container flex-start--thirty">
        <asp:Repeater runat="server" ID="rptProducts" OnItemDataBound="rptProducts_OnItemDataBound">
            <ItemTemplate>
                <article class="flex-3__item flex-3--arrow">
                    <asp:HyperLink runat="server" ID="lnkProductCategory">
                        <figure class="filter-results__figure flex-3__image">
                            <img data-src="<%#Eval("[ThumbnailImage]") %>" src="/Zurn/Content/images/10x10.png" alt="alt text" />
                        </figure>
                        <h3 class="filter-results__title related-product__title"><%#Eval("DocumentName") %></h3>
                        <p class="button__text">View</p>
                    </asp:HyperLink>
                </article>
            </ItemTemplate>
        </asp:Repeater>
    </section>
</div>