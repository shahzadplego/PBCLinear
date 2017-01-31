<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactUsTopSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ContactUsTopSection" %>


<section class="clearfix content-width">
    <h1 class="standard-title--margin-top">
        <asp:Literal ID="ContactTitle" runat="server" /></h1>

    <hr  class="page-separator" />
    <asp:Literal ID="ContactIntro" runat="server" />

    <div class="flex">
        <div class="flex__half">
            <asp:Literal ID="ContactLeftAddress" runat="server" />
        </div>
        <div class="flex__half">
            <asp:Literal ID="ContactRightPhone" runat="server" />
        </div>
    </div>
    <hr class="page-separator" />
</section>
