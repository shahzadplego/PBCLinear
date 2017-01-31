<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApplicationPageApplicationStoriesSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ApplicationPageApplicationStoriesSection" %>

<section class="content-width application-stories clearfix">
    <h2 class="standard-title center">
        <asp:Literal runat="server" ID="ApplicationStoriesSectionTitle" /></h2>
    <div class="flex-3">
        <asp:Repeater runat="server" ID="FeaturedApplicationStories" OnItemDataBound="FeaturedApplicationStories_OnItemDataBound">
            <ItemTemplate>
                <div class="flex-3__item hovered-background">
                    <figure class="hovered-background__image">
                        <img src="<%#Eval("[ApplicationStoryThumbnail]") %>" alt="<%#Eval("[ApplicationStoryThumbnailAlt]") %> " />
                    </figure>
                    <div class="hovered-background__content">
                        <h3 class="sub-title">
                            <asp:Literal runat="server" ID="ApplicationStoryTitle" /></h3>
                        <p class="link">
                            <asp:HyperLink runat="server" ID="ApplicationStoryCTALink" />
                        </p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</section>