<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactUsTopSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ContactUsTopSection" %>


<section class="clearfix content-width">
    
    <div class="">
                <h1 class="standard-title">
            <asp:Literal ID="ContactTitle" runat="server" /></h1>
        <div class="">
            <asp:Literal ID="ContactIntro" runat="server" />

        </div>
        <div class="">
            <asp:Literal ID="ContactLeftAddress" runat="server" />
        </div>
         <div class="">
            <asp:Literal ID="ContactRightPhone" runat="server" />
        </div>
    </div>
</section>