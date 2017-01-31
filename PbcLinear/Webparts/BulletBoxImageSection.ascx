<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BulletBoxImageSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.BulletBoxImageSection" %>

<section class="content-width industry-features clearfix">
    <div class="industry-features-list">
        <h1 class="standard-title clearfix">
            <asp:Literal ID="TSDSectionTitle" runat="server" /></h1>
        <ul>
            <li runat="server" ID="ListItem1" class="industry-feature">
                <asp:Literal ID="BulletTitle1" runat="server" />
                <span class="industry-feature__description"><asp:Literal ID="BulletDescription1" runat="server" /></span>
            </li>
            <li runat="server" ID="ListItem2" class="industry-feature">
                <asp:Literal ID="BulletTitle2" runat="server" />
                <span class="industry-feature__description"><asp:Literal ID="BulletDescription2" runat="server" /></span>
            </li>
            <li runat="server" ID="ListItem3" class="industry-feature">
                <asp:Literal ID="BulletTitle3" runat="server" />
                <span class="industry-feature__description"><asp:Literal ID="BulletDescription3" runat="server" /></span>
            </li>
            <li runat="server" ID="ListItem4" class="industry-feature">
                <asp:Literal ID="BulletTitle4" runat="server" />
                <span class="industry-feature__description"><asp:Literal ID="BulletDescription4" runat="server" /></span>
            </li>
        </ul>
    </div>
    <div class="industry-features-figure">
        <asp:Image runat="server" ID="BulletImage" CssClass="industry-features-figure__image" />
    </div>
</section>
