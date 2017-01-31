<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RFQTopSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.RFQTopSection" %>


<section class="clearfix content-width">
    
    <div class="">
                <h1 class="standard-title">
            <asp:Literal ID="RFQTitle" runat="server" /></h1>
        <div class="">
            <asp:Literal ID="RFQIntro" runat="server" />

        </div>
        <div class="">
            <asp:HyperLink ID="RFQStandard" runat="server" />
       
            <asp:HyperLink ID="RFQEngineered" runat="server" />
        </div>
    </div>
</section>