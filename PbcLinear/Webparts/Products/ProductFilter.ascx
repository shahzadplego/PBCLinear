<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductFilter.ascx.cs" Inherits="PbcLinear.WebParts.Products.ProductFilter" %>


<section class="cleafix seventy-five--margin-top">
    <h1 class="standard-title center">
        <asp:Literal runat="server" ID="ltlProductCategoryTitle" /></h1>

    <%-- <p class="filter-results__returned">
            <asp:Literal runat="server" ID="ltlProductCount" />
        </p>--%>
    <p class="center--desktop">
        <asp:Literal runat="server" ID="PTDSectionDescription" />
    </p>
</section>
<hr class="page-seperator content-width clearfix" />
<asp:UpdateProgress ID="UpdateProgress" runat="server" DisplayAfter="1">
    <ProgressTemplate>
        <section class="loading clearfix">
            <p>
                <img src="~/PbcLinear/img/ajax-loader.gif" alt="Loading" />
            </p>
        </section>
    </ProgressTemplate>
</asp:UpdateProgress>

<cms:CMSUpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Always">
    <ContentTemplate>

        <div class="content-width clearfix">

            <section class="product-type-flex--no-bottom-margin">
                <nav class="product-type-nav">

                    <h2>
                        <asp:Literal runat="server" ID="ltlProductCategoryFilterTitle" /></h2>
                    <ul>
                        <asp:Repeater runat="server" ID="rptProductCategories" OnItemDataBound="rptProductCategories_OnItemDataBound">
                            <ItemTemplate>
                                <li>
                                    <asp:HyperLink runat="server" ID="FilterLink">

                                            <%#Eval("DocumentName") %>
                                            <%--<span class="results-found--small">
                                                <asp:Literal runat="server" ID="ltlProductCategoryResultCount" />
                                            </span>--%>

                                    </asp:HyperLink>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </nav>


                <div class="product-type-grid">

                    <asp:Repeater runat="server" ID="rptProducts" OnItemDataBound="rptProducts_OnItemDataBound">
                        <ItemTemplate>
                            <article class="product-type__item">
                                <div class="product-image-overlay--light">
                                    <img src="<%#Eval("SKUImagePath") %>" />
                                </div>
                                <h2 class="product-filter-item__title"><%#Eval("DocumentSKUShortDescription") %> - <%#Eval("DocumentName") %></h2>

                                <ul>
                                    <li runat="server" id="InnerDItem" class="bold">
                                        <asp:Literal ID="InnerDValue" runat="server" />
                                    </li>
                                    <li runat="server" id="OuterDItem">
                                        <asp:Literal ID="OuterDValue" runat="server" />
                                    </li>
                                    <li runat="server" id="SizeItem">
                                        <asp:Literal ID="SizeValue" runat="server" />
                                    </li>
                                    <li runat="server" id="MaterialItem">
                                        <asp:Literal ID="MaterialValue" runat="server" />
                                    </li>
                                    <li runat="server" id="PriceItem" class="price-bullet">
                                        <asp:Literal ID="PriceValue" runat="server" />
                                    </li>
                                </ul>

                                <asp:HyperLink runat="server" ID="lnkProductDetail">View Product</asp:HyperLink>
                            </article>
                        </ItemTemplate>
                    </asp:Repeater>

                    <div runat="server" id="divNoResultsMessage" visible="False">
                        No Results Found
                    </div>
                </div>
            </section>
            <div class="pagination right-flex-pagination">
                <asp:LinkButton ID="PagerFirstPage" runat="server" CssClass="pagination__first" title="First Page" OnClick="PagerClick"><img src="/PbcLinear/img/first-pag.png" alt="Beginning of Search Results" /></asp:LinkButton>
                <asp:LinkButton ID="PagerPreviousPage" runat="server" CssClass="pagination__previous" title="Previous Page" OnClick="PagerClick"><img src="/PbcLinear/img/left-pag.png" alt="Previous page of Search Results" /></asp:LinkButton>
                <asp:LinkButton ID="PagerPreviousGroup" runat="server" Text="..." CssClass="pagination__page" title="Previous Group" OnClick="PagerClick" />
                <asp:Repeater ID="PagerPageNumbers" runat="server" OnItemDataBound="PagerPageNumbersItemDataBound" OnItemCommand="PagerPageNumbersItemCommand">
                    <ItemTemplate>
                        <asp:LinkButton ID="PagerPageNumberLink" runat="server" CssClass="pagination__page" Visible="False" CommandName="PagerShowPage" />
                        <span id="PagerPageNumberCurrent" runat="server" class="pagination__page--current" visible="False"></span>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:LinkButton ID="PagerNextGroup" runat="server" Text="..." CssClass="pagination__page" title="Next Group" OnClick="PagerClick" />
                <asp:LinkButton ID="PagerNextPage" runat="server" CssClass="pagination__next" title="Next Page" OnClick="PagerClick"><img src="/PbcLinear/img/right-pag.png" alt="Next page of Search Results" /></asp:LinkButton>
                <asp:LinkButton ID="PagerLastPage" runat="server" CssClass="pagination__last" title="Last Page" OnClick="PagerClick"><img src="/PbcLinear/img/last-pag.png" alt="End of Search Results" /></asp:LinkButton>
                <asp:HiddenField ID="CurrentPage" runat="server" />
                <asp:HiddenField ID="TotalResultsCount" runat="server" />
                <br>
            </div>

        </div>
    </ContentTemplate>
</cms:CMSUpdatePanel>
