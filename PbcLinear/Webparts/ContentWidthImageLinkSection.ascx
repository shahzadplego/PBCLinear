﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentWidthImageLinkSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ContentWidthImageLinkSection" %>
<%@ Import Namespace="CMS.DocumentEngine" %>
<asp:HyperLink runat="server" ID="CwiCta" CssClass="content-width-link">
    <section class="clearfix content-width center">
        <picture runat="server" ID="Image">
            <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=960,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1920 2x" media="(min-width: 801px)" />
            <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=800,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1600 2x" media="(min-width: 601px)" />
            <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=600,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1200 2x" media="(min-width: 401px)" />
            <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=400,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=800 2x" media="(min-width: 300px)" />
            <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=300,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=600 2x" media="(min-width: 1px)" />
            <img srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %>, <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImage"], string.Empty).Replace("~", ""))) %> 2x" alt="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWISectionImageAlt"], string.Empty))) %>"  class="img-content-width--no-margin" />
        </picture>
        <p class="standard-title--no-margin clearfix center"><asp:Literal runat="server" ID="CWICtaText" /></p>
    </section>
</asp:HyperLink>