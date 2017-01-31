<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TitleSubDescriptionSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.TitleSubDescriptionSection" %>

<section class="content-width clearfix">
    <h1 class="standard-title clearfix">
        <asp:Literal ID="TSDSectionTitle" runat="server" /></h1>
    <p class="sub-title bold">
        <asp:Literal ID="TSDSectionSubTitle" runat="server" /></p>
    <div>
        <asp:Literal ID="TSDSectionDescription" runat="server" /></div>
</section>
