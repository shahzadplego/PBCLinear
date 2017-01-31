<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TitleDescriptionImageSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.TitleDescriptionImageSection" %>


<section class="clearfix content-width industry-application">
    <figure class="industry-application__figure">
        <asp:Image runat="server" ID="TDIImage" class="industry-application__image" />
    </figure>
    <div class="industry-application__content">
        <h1 class="standard-title blue">
            <asp:Literal ID="TDITitle" runat="server" /></h1>
        <div class="industry-application__description">
            <asp:Literal ID="TDIDescription" runat="server" />
        </div>
    </div>
</section>
