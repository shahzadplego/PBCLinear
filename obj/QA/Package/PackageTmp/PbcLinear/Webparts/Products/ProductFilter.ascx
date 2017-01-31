<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductFilter.ascx.cs" Inherits="PbcLinear.WebParts.Products.ProductFilter" %>
<section class="content-width--margin-top  clearfix">
    <h1 class="standard-title center">
        <asp:Literal runat="server" ID="ltlProductCategoryTitle" /></h1>
   
    <p class="filter-results__returned">
        
        <asp:Literal runat="server" ID="ltlProductCount" />
    </p>
     <p><asp:Literal runat="server" ID="PTDSectionDescription"/></p>
    <hr/>
</section>
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
            <aside class="product-category-filters form-wrapper--no-padding" style="float:left; width:40%">
                <section class="filters radio-group">
                    <h3 class="secondary-heading bold">
                        <asp:Literal runat="server" ID="ltlProductCategoryFilterTitle" /></h3>
                        

                    <div class="form-group">

                        <asp:Repeater runat="server" ID="rptProductCategories" OnItemDataBound="rptProductCategories_OnItemDataBound">
                            <ItemTemplate>
                                <div class="form-row">
                                    <div class="form-input--radio">
                                        <asp:HyperLink runat="server" ID="FilterLink">
                                        
                                            <%#Eval("DocumentName") %> 
                                            <span class="results-found--small">
                                                <asp:Literal runat="server" ID="ltlProductCategoryResultCount" />
                                            </span>

                                        </asp:HyperLink>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                </section>
            </aside>

            <section class="filter-main" style="float:left;">
                <div class="filter-sort clearfix">
                    <h4 class="filter-sort__title">Sort By</h4>
                    <div class="form-input--sort">
                        <asp:DropDownList runat="server" ID="ddlSortByName" OnSelectedIndexChanged="ddlSortByName_OnSelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="asc">A-Z</asp:ListItem>
                            <asp:ListItem Value="desc">Z-A</asp:ListItem>
<%--                            <asp:ListItem Value="popularity desc">Most Popular</asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="filtered-results">
                    <asp:Repeater runat="server" ID="rptProducts" OnItemDataBound="rptProducts_OnItemDataBound">
                        <ItemTemplate>
                            <article class="filter-results__item">
                                <asp:HyperLink runat="server" ID="lnkProductDetail">
                                    <figure class="filter-results__figure">
                                        <img src="<%#Eval("SKUImagePath") %>" />
                                       
                                    </figure>
                                    <p class="filter-results__detail"><%#Eval("DocumentSKUShortDescription") %> - <%#Eval("DocumentName") %></p>
                                    
                                        <ul class="filter-results__detail">
                                            <li runat="server" ID="InnerDItem">
                                                <asp:Literal ID="InnerDValue" runat="server" />
                                            </li>
                                            <li runat="server" ID="OuterDItem">
                                                <asp:Literal ID="OuterDValue" runat="server" />
                                            </li>
                                            <li runat="server" ID="SizeItem">
                                                <asp:Literal ID="SizeValue" runat="server" />
                                            </li>
                                            <li runat="server" ID="MaterialItem">
                                                <asp:Literal ID="MaterialValue" runat="server" />
                                            </li>
                                            <li runat="server" ID="PriceItem">
                                                <asp:Literal ID="PriceValue" runat="server" />
                                            </li>
                                           
                                        
                                        </ul>
                                   
                                    <p class="link-reveal__arrow">View Product</p>
                                </asp:HyperLink>
                            </article>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div runat="server" id="divNoResultsMessage" visible="False">
                    No Results Found
                </div>
                <div class="pagination">
                    <asp:LinkButton ID="PagerFirstPage" runat="server" CssClass="pagination__first" title="First Page" OnClick="PagerClick"><img src="/PbcLinear/img/svg/to_end.svg" alt="Beginning of Search Results" /></asp:LinkButton>
                    <asp:LinkButton ID="PagerPreviousPage" runat="server" CssClass="pagination__previous" title="Previous Page" OnClick="PagerClick"><img src="/PbcLinear/img/svg/arrow.svg" alt="Previous page of Search Results" /></asp:LinkButton>
                    <asp:LinkButton ID="PagerPreviousGroup" runat="server" Text="..." CssClass="pagination__page" title="Previous Group" OnClick="PagerClick" />
                    <asp:Repeater ID="PagerPageNumbers" runat="server" OnItemDataBound="PagerPageNumbersItemDataBound" OnItemCommand="PagerPageNumbersItemCommand">
                        <ItemTemplate>
                            <asp:LinkButton ID="PagerPageNumberLink" runat="server" CssClass="pagination__page" Visible="False" CommandName="PagerShowPage" />
                            <span id="PagerPageNumberCurrent" runat="server" class="pagination__page--current" visible="False"></span>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:LinkButton ID="PagerNextGroup" runat="server" Text="..." CssClass="pagination__page" title="Next Group" OnClick="PagerClick" />
                    <asp:LinkButton ID="PagerNextPage" runat="server" CssClass="pagination__next" title="Next Page" OnClick="PagerClick"><img src="/PbcLinear/img/svg/arrow.svg" alt="Next page of Search Results" /></asp:LinkButton>
                    <asp:LinkButton ID="PagerLastPage" runat="server" CssClass="pagination__last" title="Last Page" OnClick="PagerClick"><img src="/PbcLinear/img/svg/to_end.svg" alt="End of Search Results" /></asp:LinkButton>
                    <asp:HiddenField ID="CurrentPage" runat="server" />
                    <asp:HiddenField ID="TotalResultsCount" runat="server" />
                    <br>
                </div>
    </ContentTemplate>
</cms:CMSUpdatePanel>
