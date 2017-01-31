<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftEditorRightImage.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.LeftEditorRightImage" %>

<section class="content-width--margin-top clearfix">
    <div class="wysiwyg-nobg">
        <asp:Literal runat="server" ID="LETICopyAbove" />
    </div>
    <div runat="server" ID="ImageContainer" class="image-float__right">
        <asp:Image runat="server" ID="LETIImage" />
    </div>
    <div class="wysiwyg-nobg">
        <asp:Literal runat="server" ID="LETICopyBelow" />
    </div>
</section>
