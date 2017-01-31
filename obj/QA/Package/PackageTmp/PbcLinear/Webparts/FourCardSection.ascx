<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FourCardSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.FourCardSection" %>

<section class="cleafix seventy-seven">
    <div class="clearfix two-cards center">
        <section class="two-cards__card overlay-parent">
            <div class="centered-background-image js-bg-image" id="FourCardBGImage1" runat="server">
                <div class="overlay">
                    <h3>
                        <span class="border">
                            <asp:Literal ID="FourCardTitle1" runat="server" /></span>
                    </h3>
                </div>
            </div>
            <div class="seventy overlay-content">
                <p>
                    <asp:Literal ID="FourCardDescription1" runat="server" />
                </p>
                <div class="overlay-link">
                    <asp:HyperLink ID="FourCardCtaLink1" runat="server" />
                </div>
            </div>
        </section>

        <section class="two-cards__card overlay-parent">
            <div class="centered-background-image js-bg-image" id="FourCardBGImage2" runat="server">
                <div class="overlay">
                    <h3>
                        <span class="border">
                            <asp:Literal ID="FourCardTitle2" runat="server" /></span></h3>
                </div>
            </div>
            <div class="seventy overlay-content">
                <p>
                    <asp:Literal ID="FourCardDescription2" runat="server" />
                </p>
                <div class="overlay-link">
                    <asp:HyperLink ID="FourCardCtaLink2" runat="server" />
                </div>
            </div>
        </section>
        <section class="two-cards__card overlay-parent">
            <div class="centered-background-image js-bg-image" id="FourCardBGImage3" runat="server">
                <div class="overlay">
                    <h3>
                        <span class="border">
                            <asp:Literal ID="FourCardTitle3" runat="server" /></span></h3>
                </div>
            </div>
            <div class="seventy overlay-content">
                <p>
                    <asp:Literal ID="FourCardDescription3" runat="server" />
                </p>
                <div class="overlay-link">
                    <asp:HyperLink ID="FourCardCtaLink3" runat="server" />
                </div>
            </div>
        </section>
        <section class="two-cards__card overlay-parent">
            <div class="centered-background-image js-bg-image" id="FourCardBGImage4" runat="server">
                <div class="overlay">
                    <h3>
                        <span class="border">
                            <asp:Literal ID="FourCardTitle4" runat="server" /></span></h3>
                </div>
            </div>
            <div class="seventy overlay-content">
                <p>
                    <asp:Literal ID="FourCardDescription4" runat="server" />
                </p>
                <div class="overlay-link">
                    <asp:HyperLink ID="FourCardCtaLink4" runat="server" />
                </div>
            </div>
        </section>
    </div>
    <p class="center" id="CTAWrap" runat="server" visible="false">
        <asp:HyperLink ID="CTA" runat="server" CssClass="button" />
    </p>
</section>
