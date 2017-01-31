﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeroImageSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.HeroImageSection" %>
<%@ Import Namespace="CMS.DocumentEngine" %>


<div class="image-background clearfix" runat="server" id="divResponsiveImage">
    <section class="image-background__content">
        <h1 class="image-background__title"><span class="bold">
            <asp:Literal ID="H1LargeText" runat="server" /><br>
        </span>
            <asp:Literal ID="H1SmallText" runat="server" /></h1>
    </section>
    <picture>
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1500,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=3000 2x" media="(min-width: 1101px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1200,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=2400 2x" media="(min-width: 901px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=9900,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1980 2x" media="(min-width: 801px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=820,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1640 2x" media="(min-width: 601px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=600,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1200 2x" media="(min-width: 476px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=475,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=950 2x" media="(min-width: 400px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=400,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=800 2x" media="(min-width: 300px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=300,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=600 2x" media="(min-width: 1px)" />
    <img srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>, <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %> 2x" alt="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImageAlt"], string.Empty))) %>" />
</picture>
</div>
