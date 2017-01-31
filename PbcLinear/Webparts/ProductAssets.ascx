<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductAssets.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ProductAssets" %>


<p runat="server" id="SchematicContainer" visible="false">
    <asp:HyperLink runat="server" ID="Schematic" Target="_blank"></asp:HyperLink>
</p>
<p runat="server" id="DataSheetContainer" visible="false">
    <asp:HyperLink runat="server" ID="DataSheet" Target="_blank"></asp:HyperLink>
</p>
<p runat="server" id="SelectionGuideContainer" visible="false">
    <asp:HyperLink runat="server" ID="SelectionGuide" Target="_blank"></asp:HyperLink>
</p>
<p runat="server" id="CatalogContainer" visible="false">
    <asp:HyperLink runat="server" ID="Catalog" Target="_blank"></asp:HyperLink>
</p>
<p runat="server" id="BrochureContainer" visible="false">
    <asp:HyperLink runat="server" ID="Brochure" Target="_blank"></asp:HyperLink>
</p>


<section class="eighty-five clearfix" id="divVideoOrImage" runat="server" visible="false">
    <div id="divVideoOrImageIframe" visible="false" runat="server" class="video__iframe">
        <img class="ratio" src="/PbcLinear/img/16x9.gif">
        <iframe runat="server" id="VideoOrImageEmbeddedVideo" visible="False"></iframe>
    </div>
</section>