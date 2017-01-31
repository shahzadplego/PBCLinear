<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentWidthImageTitleSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ContentWidthImageTitleSection" %>
<%@ Import Namespace="CMS.DocumentEngine" %>




<div class="image-background--unrestricted clearfix">
    <section class="image-background__content">
        <h2 class="image-background__title">
            <span class="bold"><asp:Literal ID="CWITImageTitleLarge" runat="server" /></span>
            <span class="image-background__title--small" id="SmallText" runat="server" visible="false"><asp:Literal ID="CWITImageTitleSmall" runat="server" /></span>
        </h2>
    </section>
    <picture>
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=960,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1920 2x" media="(min-width: 801px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=800,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1600 2x" media="(min-width: 601px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=600,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1200 2x" media="(min-width: 401px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=400,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=800 2x" media="(min-width: 300px)" />
    <source srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=300,  <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=600 2x" media="(min-width: 1px)" />
    <img srcset="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %>, <%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImage"], string.Empty).Replace("~", ""))) %> 2x" alt="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIImageAlt"], string.Empty))) %>" class="img-content-width" />
</picture>
</div>
<section class="clearfix content-width center">
    <div class="seventy-five">
        <h2 class="standard-title">
            <asp:Literal ID="CWITTitle" runat="server" />
        </h2>
        <p>
            <asp:Literal ID="CWITDescription" runat="server" />
        </p>
    </div>
</section>




