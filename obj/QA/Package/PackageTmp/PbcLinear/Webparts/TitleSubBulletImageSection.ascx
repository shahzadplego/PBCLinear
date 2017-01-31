<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TitleSubBulletImageSection.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.TitleSubBulletImageSection" %>

<!--THIS PART NOT USED YET, VISUALLY REMOVING FOR BUILD PURPOSES-->

<div style="display: none;">
    <section class="clearfix content-width bullet-flex">
        <article class="bullet-flex__figure">
            <h2>
                <asp:Literal ID="TSBITitle" runat="server" /></h2>

            <p class="supporting-title">
                <asp:Literal ID="TSBISubTitle1" runat="server" /></p>
            <p class="supporting-title">
                <asp:Literal ID="TSBISubTitle2" runat="server" /></p>
            <p class="supporting-title">
                <asp:Literal ID="TSBISubTitle3" runat="server" /></p>

            <ul class="bullet-flex__list">
                <li class="bullet-flex__list-item">
                    <asp:Literal ID="TSBIBullet1" runat="server" /></li>
                <li class="bullet-flex__list-item">
                    <asp:Literal ID="TSBIBullet2" runat="server" /></li>
                <li class="bullet-flex__list-item">
                    <asp:Literal ID="TSBIBullet3" runat="server" /></li>
                <li class="bullet-flex__list-item">
                    <asp:Literal ID="TSBIBullet4" runat="server" /></li>
                <li class="bullet-flex__list-item">
                    <asp:Literal ID="TSBIBullet5" runat="server" /></li>
                <li class="bullet-flex__list-item">
                    <asp:Literal ID="TSBIBullet6" runat="server" /></li>
            </ul>
        </article>
        <figure class="bullet-flex__figure">
            <asp:Image ID="TSBIImage" runat="server" CssClass="bullet-flex__image" />
        </figure>
    </section>
</div>
