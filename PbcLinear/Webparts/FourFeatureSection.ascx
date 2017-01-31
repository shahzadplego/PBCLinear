<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FourFeatureSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.FourFeatureSection" %>

<section class="content-width--margin-bottom clearfix">
    <div class="flex">
        <div class="flex__20--flex no-margin-top--mobile">
            <div>
                <h3 class="standard-title center">
                    <asp:Literal runat="server" ID="FFTitle1"></asp:Literal></h3>
                <div class="clearfix">
                    <asp:Literal runat="server" ID="FFDescription1"></asp:Literal>
                </div>
            </div>
            <asp:HyperLink runat="server" ID="FFLink1" CssClass="button clearfix"></asp:HyperLink>
        </div>
        <div class="flex__20--flex no-margin-top--mobile">
            <div>
                <h3 class="standard-title center">
                    <asp:Literal runat="server" ID="FFTitle2"></asp:Literal></h3>
                <div class="clearfix">
                    <asp:Literal runat="server" ID="FFDescription2"></asp:Literal>
                </div>
            </div>
            <asp:HyperLink runat="server" ID="FFLink2" CssClass="button clearfix"></asp:HyperLink>
        </div>

        <div class="flex__20--flex no-margin-top--mobile">
            <div>
                <h3 class="standard-title center">
                    <asp:Literal runat="server" ID="FFTitle3"></asp:Literal></h3>
                <div class="clearfix">
                    <asp:Literal runat="server" ID="FFDescription3"></asp:Literal>
                </div>
            </div>
            <asp:HyperLink runat="server" ID="FFLink3" CssClass="button clearfix"></asp:HyperLink>
        </div>
        <div class="flex__20--flex no-margin-top--mobile">
            <div>
                <h3 class="standard-title center">
                    <asp:Literal runat="server" ID="FFTitle4"></asp:Literal></h3>
                <div class="clearfix">
                    <asp:Literal runat="server" ID="FFDescription4"></asp:Literal>
                </div>
            </div>
            <asp:HyperLink runat="server" ID="FFLink4" CssClass="button clearfix"></asp:HyperLink>
        </div>
    </div>
</section>
