<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApplicationStoryDetailTopSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ApplicationStoryDetailTopSection" %>
<%@ Import Namespace="CMS.DocumentEngine" %>


<section class="content-width clearfix">
    <h2 class="standard-title--margin-top center clearfix">
        <asp:Literal ID="ASDHeading" runat="server" /></h2>

    <div class="flex--no-margin clearfix">
        <div class="flex__64">
            <asp:Literal ID="ASDDescription" runat="server" />
        </div>
        <div class="flex__36">
            <asp:Image runat="server" ID="ASDImage" />

            <figcaption>
                <asp:Literal runat="server" ID="ASDPictureCaption"></asp:Literal></figcaption>
        </div>
    </div>
</section>
