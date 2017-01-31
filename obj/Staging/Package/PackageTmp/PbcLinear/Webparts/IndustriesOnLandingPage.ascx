<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndustriesOnLandingPage.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.IndustriesOnLandingPage" %>

<section class="cleafix seventy-seven">
    <div class="clearfix two-cards center">
        <asp:Repeater runat="server" ID="Industries" OnItemDataBound="Industries_OnItemDataBound">
            <ItemTemplate>
                <section class="two-cards__card overlay-parent">
                    <div class="centered-background-image js-bg-image" style="background-image: url(<%#URLHelper.RemoveQuery(Eval("[IndustryThumbnail]").ToString())%>?maxsidesize=480)" />
                    <div class="overlay">
                        <h3>
                            <span class="border">
                                <asp:Literal runat="server" ID="IndustryTitle" /></span>
                        </h3>
                    </div>
                    </div>
            <div class="seventy overlay-content">
                <p>
                    <%#Eval("[IndustryShortDescription]") %>
                </p>
                <div class="overlay-link">
                    <asp:HyperLink ID="industryCtaLink" runat="server" />
                </div>
            </div>
                </section>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</section>
