<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeroImageSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.HeroImageSection" %>
<%@ Import Namespace="CMS.DocumentEngine" %>

<section>
    <div class="hero-background-image js-bg-image" style='background-image:url(<%=String.Format("{0}",URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["HeroImage"], string.Empty).Replace("~", ""))) %>?maxsidesize=1500);'>

            <h1 class="image-background__title"><span class="bold">
                <asp:Literal ID="H1LargeText" runat="server" /><br>
            </span>
                <asp:Literal ID="H1SmallText" runat="server" /></h1>

    </div>
</section>
