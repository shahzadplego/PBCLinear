<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentWidthImageSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ContentWidthImageSection" %>
<%@ Import Namespace="CMS.DocumentEngine" %>

<section class="clearfix content-width center">
    <picture>
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=960,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1920 2x" media="(min-width: 801px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=800,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1600 2x" media="(min-width: 601px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=600,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1200 2x" media="(min-width: 401px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=400,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=800 2x" media="(min-width: 300px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=300,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=600 2x" media="(min-width: 1px)" />
    <img srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>, <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %> 2x" alt="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImageAlt"], string.Empty))) %>" class="img-content-width--no-margin" />
</picture>
    <div class="seventy-five">
        <h2 class="standard-title">
            <asp:Literal ID="CWITitle" runat="server" />
        </h2>
        <h3 class="sub-title">
            <asp:Literal ID="CWISubTitle" runat="server" /></h3>
        <asp:Literal ID="CWIDescription" runat="server" />
        <p class="center" id="CTAWrap" runat="server" visible="false">
            <asp:HyperLink ID="CTA" runat="server" CssClass="button" />
        </p>
    </div>
</section>
