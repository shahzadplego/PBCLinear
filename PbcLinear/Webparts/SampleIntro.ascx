<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SampleIntro.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.SampleIntro" %>

<section class="content-width--margin-top">
    <h1 class="standard-title">
        <asp:Literal Text="text" runat="server" ID="SSTitle"></asp:Literal></h1>
    <div class="flex">
        <div class="intro-flex__content">
            <asp:Literal Text="text" runat="server" ID="SSDescription" />
        </div>
        <div class="intro-flex__cta">
            <span id="CTAWrap" runat="server" visible="false">
                <asp:HyperLink ID="CTA" runat="server" CssClass="button--border-text" />
            </span>
        </div>
    </div>
</section>
