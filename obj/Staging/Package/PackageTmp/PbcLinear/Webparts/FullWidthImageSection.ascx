<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FullWidthImageSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.FullWidthImageSection" %>
<%@ Import Namespace="CMS.DocumentEngine" %>



<asp:Literal ID="FWISectionCtaText" runat="server" />
<asp:Literal ID="FWISectionCtaLink" runat="server" />

<div class="image-background clearfix">
    <section class="image-background__content">
        <h2 class="image-background__title">
            <asp:Literal ID="FWISectionImageTitle" runat="server" /></h2>
    </section>
    <picture>
<source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1500,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=3000 2x" media="(min-width: 1101px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1200,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=2400 2x" media="(min-width: 901px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=9900,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1980 2x" media="(min-width: 801px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=820,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1640 2x" media="(min-width: 601px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=600,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1200 2x" media="(min-width: 476px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=475,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=950 2x" media="(min-width: 400px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=400,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=800 2x" media="(min-width: 300px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=300,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=600 2x" media="(min-width: 1px)" />
    <img srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %>, <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImage"], string.Empty).Replace("~", ""))) %> 2x" alt="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImageAlt"], string.Empty))) %>" />
</picture>
</div>

<section class="clearfix seventy-five center">
    <h2 class="standard-title">
        <asp:Literal ID="FWISectionTitle" runat="server" /></h2>
    <p>
        <asp:Literal ID="FWISectionDescription" runat="server" />
    </p>
    <p class="center" id="CTAWrap" runat="server" visible="false">
        <asp:HyperLink ID="CTA" runat="server" CssClass="button" />
    </p>
</section>
