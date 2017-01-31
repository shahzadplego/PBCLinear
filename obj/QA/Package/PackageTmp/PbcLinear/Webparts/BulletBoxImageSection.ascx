<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BulletBoxImageSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.BulletBoxImageSection" %>

<section class="content-width clearfix industry-features">
    <ul class="industry-features-list">
        <li class="industry-feature"><span class="industry-feature__title">
            <asp:Literal ID="BulletTitle1" runat="server" /></span>
            <span class="industry-feature__description"><asp:Literal ID="BulletDescription1" runat="server" /></span>
        </li>

        <li class="industry-feature"><span class="industry-feature__title">
            <asp:Literal ID="BulletTitle2" runat="server" /></span>
            <span class="industry-feature__description"><asp:Literal ID="BulletDescription2" runat="server" /></span>
        </li>

        <li class="industry-feature"><span class="industry-feature__title">
            <asp:Literal ID="BulletTitle3" runat="server" /></span>
            <span class="industry-feature__description"><asp:Literal ID="BulletDescription3" runat="server" /></span>
        </li>

        <li class="industry-feature"><span class="industry-feature__title">
            <asp:Literal ID="BulletTitle4" runat="server" /></span>
            <span class="industry-feature__description"><asp:Literal ID="BulletDescription4" runat="server" /></span>
        </li>
    </ul>
    <figure class="industry-features-figure">
        <asp:Image runat="server" ID="BulletImage" CssClass="industry-features-figure__image" />
    </figure>
</section>
