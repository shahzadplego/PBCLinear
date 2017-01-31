<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetail.old.ascx.cs" Inherits="PbcLinear.WebParts.Products.ProductDetail.Old" %>

<script src="/CMSPages/GetResource.ashx?scriptfile=/Zurn/Content/Scripts/product.js" defer></script>

<div class="product clearfix">
    <section class="product-image">
        <figure class="product-image__enlarged">
            <img id="PrimaryImage" runat="server" />
        </figure>
        <div id="ProductThumbnails" runat="server" class="product-thumbs">
            <img class="product-thumbs__item" id="ProductThumbnail1" runat="server" alt="another image" />
            <img class="product-thumbs__item" id="ProductThumbnail2" runat="server" alt="another image" />
            <img class="product-thumbs__item" id="ProductThumbnail3" runat="server" alt="another image" />
            <img class="product-thumbs__item" id="ProductThumbnail4" runat="server" alt="another image" />
        </div>
    </section>
    <section class="product-details">
        <h2 class="standard-title">
            <asp:Literal ID="ProductTitle" runat="server" /></h2>
        <p>
            <asp:Literal ID="ProductDescription" runat="server" /></p>

        <h3 class="content-separating-title--no-bottom-margin uppercase bold">Features & Benefits</h3>
        <ul class="bulleted-list">
            <cms:BasicRepeater ID="FeaturesList" runat="server">
                <ItemTemplate>
                    <li><%# Container.DataItem.ToString() %></li>
                </ItemTemplate>
            </cms:BasicRepeater>
        </ul>

        <section class="badges">
            <img id="Badge1" runat="server" src="/Zurn/Content/images/svg/icons/ada_designed_desc.svg" alt="ADA Compliant" class="badge--compliance" />
            <img id="Badge2" runat="server" src="/Zurn/Content/images/svg/icons/xl_lead_desc.svg" alt="Lead Free" />
            <img id="Badge3" runat="server" src="/Zurn/Content/images/svg/icons/USA_desc.svg" alt="Buy American" />
            <img id="Badge4" runat="server" src="/Zurn/Content/images/svg/icons/retrofit_desc.svg" alt="Retrofit or Replacement" />
            <a id="Badge5" runat="server" target="_blank">
                <img src="/Zurn/Content/images/svg/icons/master-spec_desc.svg" alt="MasterSPEC" /></a>
            <a id="Badge6" runat="server" target="_blank">
                <img src="/Zurn/Content/images/svg/icons/arcat.svg" alt="ARCAT" /></a>
            <img id="Badge7" runat="server" src="/Zurn/Content/images/svg/icons/NSF_desc.svg" alt="NSF ANSI" />
            <img id="Badge8" runat="server" src="/Zurn/Content/images/svg/icons/water_savings_desc.svg" alt="California Mandatory Water" />
            <img id="Badge9" runat="server" src="/Zurn/Content/images/svg/icons/discontinued_desc.svg" alt="Discontinued" />
            
            <img id="Badge10" runat="server" src="/Zurn/Content/images/svg/icons/zurn_one_desc.svg" alt="Zurn One"/>
            <img id="Badge11" runat="server" src="/Zurn/Content/images/svg/icons/light_drainage.svg" alt="Drainage"/>
            <img id="Badge12" runat="server" src="/Zurn/Content/images/svg/icons/EZ_ship_desc.svg" alt="EZ Ship"/>
            <img id="Badge13" runat="server" src="/Zurn/Content/images/svg/icons/zurn_wilkins.svg" alt="Zurn Wilkins"/>
            <img id="Badge14" runat="server" src="/Zurn/Content/images/svg/icons/low_lead.svg" alt="Low Lead Iapmort"/>
            <img id="Badge15" runat="server" src="/Zurn/Content/images/svg/icons/green_turtle.svg" alt="Green Turtle"/>

        </section>



        <section id="ToiletAttributeSection" runat="server" class="product-attributes">
            <h3 class="product-attributes__heading">Toilet Attributes</h3>
            <ul class="product-attributes__list">
                <cms:BasicRepeater ID="ToiletAttributeList" runat="server">
                    <ItemTemplate>
                        <li><%# Container.DataItem.ToString() %></li>
                    </ItemTemplate>
                </cms:BasicRepeater>
            </ul>
        </section>

        <section id="SinkAttributeSection" runat="server" class="product-attributes">
            <h3 class="product-attributes__heading">Sink Attributes</h3>
            <ul class="product-attributes__list">
                <cms:BasicRepeater ID="SinkAttributeList" runat="server">
                    <ItemTemplate>
                        <li><%# Container.DataItem.ToString() %></li>
                    </ItemTemplate>
                </cms:BasicRepeater>
            </ul>
        </section>

        <section id="UrinalAttributeSection" runat="server" class="product-attributes">
            <h3 class="product-attributes__heading">Urinal Attributes</h3>
            <ul class="product-attributes__list">
                <cms:BasicRepeater ID="UrinalAttributeList" runat="server">
                    <ItemTemplate>
                        <li><%# Container.DataItem.ToString() %></li>
                    </ItemTemplate>
                </cms:BasicRepeater>
            </ul>
        </section>

        <section id="FlushValveAttributeSection" runat="server" class="product-attributes">
            <h3 class="product-attributes__heading">Flush Valve Attributes</h3>
            <ul class="product-attributes__list">
                <cms:BasicRepeater ID="FlushValveAttributeList" runat="server">
                    <ItemTemplate>
                        <li><%# Container.DataItem.ToString() %></li>
                    </ItemTemplate>
                </cms:BasicRepeater>
            </ul>
        </section>

        <section id="FaucetAttributeSection" runat="server" class="product-attributes">
            <h3 class="product-attributes__heading">Faucet Attributes</h3>
            <ul class="product-attributes__list">
                <cms:BasicRepeater ID="FaucetAttributeList" runat="server">
                    <ItemTemplate>
                        <li><%# Container.DataItem.ToString() %></li>
                    </ItemTemplate>
                </cms:BasicRepeater>
            </ul>
        </section>

        <section id="BackflowAttributeSection" runat="server" class="product-attributes">
            <h3 class="product-attributes__heading">Backflow Attributes</h3>
            <ul class="product-attributes__list">
                <cms:BasicRepeater ID="BackflowAttributeList" runat="server">
                    <ItemTemplate>
                        <li><%# Container.DataItem.ToString() %></li>
                    </ItemTemplate>
                </cms:BasicRepeater>
            </ul>
        </section>

        <section id="PressureAttributeSection" runat="server" class="product-attributes">
            <h3 class="product-attributes__heading">Pressure Reducing Attributes</h3>
            <ul class="product-attributes__list">
                <cms:BasicRepeater ID="PressureAttributeList" runat="server">
                    <ItemTemplate>
                        <li><%# Container.DataItem.ToString() %></li>
                    </ItemTemplate>
                </cms:BasicRepeater>
            </ul>
        </section>

        <section id="ReliefAttributeSection" runat="server" class="product-attributes">
            <h3 class="product-attributes__heading">Relief Attributes</h3>
            <ul class="product-attributes__list">
                <cms:BasicRepeater ID="ReliefAttributeList" runat="server">
                    <ItemTemplate>
                        <li><%# Container.DataItem.ToString() %></li>
                    </ItemTemplate>
                </cms:BasicRepeater>
            </ul>
        </section>

        <section id="PexProductAttributeSection" runat="server" class="product-attributes">
            <h3 class="product-attributes__heading">PEX Product Attributes</h3>
            <ul class="product-attributes__list">
                <cms:BasicRepeater ID="PexProductAttributeList" runat="server">
                    <ItemTemplate>
                        <li><%# Container.DataItem.ToString() %></li>
                    </ItemTemplate>
                </cms:BasicRepeater>
            </ul>
        </section>

    </section>
</div>
<hr class="full-width-hr" />
<section id="ResourcesContainer" runat="server" class="content-width--margin-bottom  clearfix">
    <h3 class="secondary-heading bold">Product Resources</h3>
    <div id="SpecsContainer" runat="server" class="product-resources clearfix">
        <h4 class="product-resources__heading">Spec Sheets & Install</h4>
        <ul class="product-resources__list clearfix">
            <cms:BasicRepeater ID="SpecAssets" runat="server" OnItemDataBound="Specs_OnItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="SpecLink" runat="server" Target="_blank" />
                    </li>
                </ItemTemplate>
            </cms:BasicRepeater>
        </ul>
    </div>
    <div id="ModelContainer" runat="server" class="product-resources clearfix">
        <h4 class="product-resources__heading">BIM / 3D Models / 2D Drawings</h4>
        <ul class="product-resources__list clearfix">
            <li><asp:HyperLink ID="BIMLink" runat="server" Target="_blank" /></li>
            <cms:BasicRepeater ID="ModelAssets" runat="server" OnItemDataBound="Models_OnItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="ModelLink" runat="server" Target="_blank" />
                    </li>
                </ItemTemplate>
            </cms:BasicRepeater>
        </ul>
    </div>
    <div id="OptionsContainer" runat="server" class="product-resources clearfix">
        <h4 class="product-resources__heading">Options</h4>
        <ul class="product-resources__list clearfix">
            <li><asp:HyperLink id="OptionsLink" runat="server" CssClass="magnific-iframe" /></li>
        </ul>
    </div>
    <div id="VideoContainer" runat="server" class="product-resources clearfix">
        <h4 class="product-resources__heading">Videos</h4>
        <ul class="product-resources__list clearfix">
            <cms:BasicRepeater ID="VideoAssets" runat="server" OnItemDataBound="Videos_OnItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="VideoLink" CssClass="magnific-video" runat="server" />
                    </li>
                </ItemTemplate>
            </cms:BasicRepeater>
        </ul>
    </div>
    <div id="PDFContainer" runat="server" class="product-resources clearfix">
        <h4 class="product-resources__heading">Related Documents</h4>
        <ul class="product-resources__list clearfix">
            <cms:BasicRepeater ID="PDFAssets" runat="server" OnItemDataBound="PDFs_OnItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="PDFLink" runat="server" Target="_blank" />
                    </li>
                </ItemTemplate>
            </cms:BasicRepeater>
        </ul>
    </div>
</section>

<section id="ProductFAQSection" runat="server" class="product-faq">
    <div class="content-width--margin-bottom clearfix">
        <img class="faq-icon" src="/Zurn/Content/images/svg/FAQ.svg" />
        <h3 class="secondary-heading bold">Product FAQ</h3>
        <cms:BasicRepeater ID="ProductFAQs" runat="server" OnItemDataBound="ProductFAQs_OnItemDataBound">
            <ItemTemplate>
                <div class="product-resources clearfix">
                    <h4 class="product-resources__heading"><asp:Literal ID="FAQQuestion" runat="server" /></h4>
                    <ul class="product-resources__list clearfix">
                        <li><asp:Literal ID="FAQAnswer" runat="server" /></li>
                    </ul>
                </div>
            </ItemTemplate>
        </cms:BasicRepeater>
        <div runat="server" id="divShowMore">
        <a class="view-all-faq" href="javascript:void(0);" onclick="showFAQ();">View All FAQ</a>
            </div>
    </div>
</section>



<section id="RelatedProductSection" runat="server" class="clearfix content-width add-margin-top">
    <h3 class="secondary-heading bold">Related Products & Accessories</h3>
    <div class="related-products">
        <article class="related-product">
            <cms:BasicRepeater ID="RelatedProducts" runat="server">
                <ItemTemplate>
                    <figure class="related-product__image">
                        <img src="<%#Eval("[ThumbnailImage1]") != null && !string.IsNullOrEmpty(Eval("[ThumbnailImage1]").ToString())?Eval("[ThumbnailImage1]"):Eval("[LargeImage]") %>" alt="<%#Eval("[ProductTitle]") %>" />
                    </figure>
                    <div class="related-product__content">
                        <h4 class="related-product__title"><%#Eval("[ProductTitle]") %></h4>
                        <p class="related-product__description"><%#Eval("[Description]") %></p>
                        <p class="related-product__link"><a href="<%#Eval("[NodeAliasPath]") %>">View Product</a></p>
                    </div>
                </ItemTemplate>
            </cms:BasicRepeater>
        </article>
    </div>
</section>--%>
