<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HistoryPageTop.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.HistoryPageTop" %>
<%@ Import Namespace="CMS.DocumentEngine" %>

<section class="content-width--margin-top clearfix">
    <h2 class="standard-title center--mobile">
        <asp:Literal runat="server" ID="PageTitle"></asp:Literal></h2>


    <div class="flex--no-margin">
        <div class="flex__60">
            <asp:Literal runat="server" ID="HistoryText1"></asp:Literal>
        </div>
        <div runat="server" ID="ImageContainer1" class="flex__40">
            <img src="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HistoryTopImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=400" alt="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HistoryTopImageAlt"], string.Empty))) %>"  />
        </div>
    </div>

    <div class="flex--no-margin">
        <div class="flex__60">
            <asp:Literal runat="server" ID="HistoryText2"></asp:Literal>
        </div>
        <div runat="server" ID="ImageContainer2" class="flex__40">
            <img src="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HistoryBottomImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=400" alt="<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HistoryBottomImageAlt"], string.Empty))) %>" />
        </div>
    </div>
</section>

