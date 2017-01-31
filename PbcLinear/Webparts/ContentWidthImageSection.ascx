<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentWidthImageSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ContentWidthImageSection" %>
<%@ Import Namespace="CMS.DocumentEngine" %>

<!--this section is page width, NOT conten width. Late modification did this -->
<section class="clearfix">
    <div class="hero-background-image--510 js-bg-image" style='background-image: url(<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1500);'>

            <h2 class="image-background__title"><span class="bold">
                <asp:Literal ID="CWITitle" runat="server" /><br>
            </span>
                <asp:Literal ID="CWISubTitle" runat="server" /></h2>
    </div>
    <div class="seventy-five--margin-top extra-margin--bottom center clearfix">
        <asp:Literal ID="CWIDescription" runat="server" />
        <div class="center" id="CTAWrap" runat="server" visible="false">
            <asp:HyperLink ID="CTA" runat="server" CssClass="button" />
        </div>
    </div>
</section>

