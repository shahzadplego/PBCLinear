<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RFQTopSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.RFQTopSection" %>


<section class="content-width--margin-top">
    <h1 class="standard-title center--mobile">
        <asp:Literal ID="RFQTitle" runat="server" />
    </h1>
    <asp:Literal ID="RFQIntro" runat="server" />
    <div class="flex-links">
        <asp:HyperLink ID="RFQStandard" runat="server" class="flex-links__button" />
        <asp:HyperLink ID="RFQEngineered" runat="server" class="flex-links__button" />
    </div>
<hr/>
</section>
