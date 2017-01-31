<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FullWidthImageSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.FullWidthImageSection" %>
<%@ Import Namespace="CMS.DocumentEngine" %>



<asp:Literal ID="FWISectionCtaText" runat="server" />
<asp:Literal ID="FWISectionCtaLink" runat="server" />


<section class="clearfix">
    <div class="hero-background-image--280 js-bg-image" style='background-image: url(<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1500);'>
        <div>
            <h2 class="image-background__title"><span class="bold">
                <asp:Literal ID="FWISectionImageTitle" runat="server" /><br>
            </span>
                <asp:Literal ID="FWISectionTitle" runat="server" /></h2>
        </div>
    </div>
    <div class="seventy-five--margin-top extra-margin--bottom center clearfix">
        <asp:Literal ID="FWISectionDescription" runat="server" />
        <div class="center" id="CTAWrap" runat="server" visible="false">
            <asp:HyperLink ID="CTA" runat="server" CssClass="button" />
        </div>
    </div>
</section>


