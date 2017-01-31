<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndustryPageApplicationsSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.IndustryPageApplicationsSection" %>


<section class="clearfix content-width--margin-top">
    <h2 class="standard-title center clearfix" runat="server" ID="TitleContainer">
        <asp:Literal runat="server" ID="ApplicationSectionTitle" /></h2>
    <asp:Repeater runat="server" ID="FeaturedApplications" OnItemDataBound="FeaturedApplications_OnItemDataBound">
        <ItemTemplate>
            <article class="industry-application clearfix">
                <div class="industry-application__figure">
                    <img src="<%#URLHelper.RemoveQuery(Eval("[ApplicationThumbnail]").ToString())%>?maxsidesize=350" alt="<%#Eval("[ApplicationThumbnailImageAlt]") %>" class="industry-application__image" />
                </div>
                <div class="industry-application__content">
                    <h2 class="standard-title--no-margin regular-weight primary">
                        <asp:Literal runat="server" ID="ApplicationTitle" /></h2>
                    <div class="industry-application__description">
                        <%#Eval("[ApplicationShortDescription]") %>
                        <asp:HyperLink runat="server" ID="ApplicationCTALink" CssClass="link--primary bold" />
                    </div>
                </div>
            </article>
        </ItemTemplate>
    </asp:Repeater>
</section>
