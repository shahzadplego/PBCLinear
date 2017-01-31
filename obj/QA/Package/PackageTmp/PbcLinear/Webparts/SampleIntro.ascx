<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SampleIntro.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.SampleIntro" %>


<asp:Literal Text="text" runat="server" ID="SSTitle"></asp:Literal>

<asp:Literal Text="text" runat="server" ID="SSDescription"/>

<p id="CTAWrap" runat="server" Visible="false">
            <asp:HyperLink ID="CTA" runat="server" CssClass="button" />
</p>