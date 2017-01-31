<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwoFeatureSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.TwoFeatureSection" %>

<section class="content-width clearfix">
    <hr class="page-separator--extra-margin-mobile" />
    <div class="flex">
        <div class="flex__45--flex no-margin-top--mobile">
            <div>
                <h3 class="standard-title center">
                    <asp:Literal runat="server" ID="TFTitle1"></asp:Literal></h3>
                <div class="clearfix">
                    <asp:Literal runat="server" ID="TFDescription1"></asp:Literal>
                </div>
            </div>
            <asp:HyperLink runat="server" ID="TFLink1" CssClass="button clearfix"></asp:HyperLink>
        </div>
        <div class="flex__45--flex no-margin-top--mobile">
            <div>
                <h3 class="standard-title center">
                    <asp:Literal runat="server" ID="TFTitle2"></asp:Literal></h3>
                <div class="clearfix">
                    <asp:Literal runat="server" ID="TFDescription2"></asp:Literal>
                </div>
            </div>
            <asp:HyperLink runat="server" ID="TFLink2" CssClass="button clearfix"></asp:HyperLink>
        </div>
    </div>
    <hr class="page-separator" />
</section>
