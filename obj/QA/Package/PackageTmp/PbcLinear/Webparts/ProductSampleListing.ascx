<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSampleListing.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ProductSampleListing" %>

<section id="sampleOne" runat="server">
    <asp:CheckBox runat="Server" ID="S1CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S1Title"></asp:Literal>
    <asp:Image runat="Server" ID="S1Image" />
    <asp:Literal runat="Server" ID="S1ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S1ProductDescription"></asp:Literal>
</section>

<section id="sampleTwo" runat="server">
    <asp:CheckBox runat="Server" ID="S2CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S2Title"></asp:Literal>
    <asp:Image runat="Server" ID="S2Image"></asp:Image>
    <asp:Literal runat="Server" ID="S2ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S2ProductDescription"></asp:Literal>
</section>

<section id="sampleThree" runat="server">
    <asp:CheckBox runat="Server" ID="S3CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S3Title"></asp:Literal>
    <asp:Image runat="Server" ID="S3Image"></asp:Image>
    <asp:Literal runat="Server" ID="S3ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S3ProductDescription"></asp:Literal>
</section>

<section id="sampleFour" runat="server">
    <asp:CheckBox runat="Server" ID="S4CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S4Title"></asp:Literal>
    <asp:Image runat="Server" ID="S4Image"></asp:Image>
    <asp:Literal runat="Server" ID="S4ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S4ProductDescription"></asp:Literal>
</section>

<section id="sampleFive" runat="server">
    <asp:CheckBox runat="Server" ID="S5CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S5Title"></asp:Literal>
    <asp:Image runat="Server" ID="S5Image"></asp:Image>
    <asp:Literal runat="Server" ID="S5ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S5ProductDescription"></asp:Literal>
</section>

<section id="sampleSix" runat="server">
    <asp:CheckBox runat="Server" ID="S6CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S6Title"></asp:Literal>
    <asp:Image runat="Server" ID="S6Image"></asp:Image>
    <asp:Literal runat="Server" ID="S6ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S6ProductDescription"></asp:Literal>
</section>

<section id="sampleSeven" runat="server">
    <asp:CheckBox runat="Server" ID="S7CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S7Title"></asp:Literal>
    <asp:Image runat="Server" ID="S7Image"></asp:Image>
    <asp:Literal runat="Server" ID="S7ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S7ProductDescription"></asp:Literal>
</section>

<section id="sampleEight" runat="server">
    <asp:CheckBox runat="Server" ID="S8CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S8Title"></asp:Literal>
    <asp:Image runat="Server" ID="S8Image"></asp:Image>
    <asp:Literal runat="Server" ID="S8ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S8ProductDescription"></asp:Literal>
</section>

<section id="sampleNine" runat="server">
    <asp:CheckBox runat="Server" ID="S9CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S9Title"></asp:Literal>
    <asp:Image runat="Server" ID="S9Image"></asp:Image>
    <asp:Literal runat="Server" ID="S9ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S9ProductDescription"></asp:Literal>
</section>

<section id="sampleTen" runat="server">
    <asp:CheckBox runat="Server" ID="S10CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S10Title"></asp:Literal>
    <asp:Image runat="Server" ID="S10Image"></asp:Image>
    <asp:Literal runat="Server" ID="S10ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S10ProductDescription"></asp:Literal>
</section>

<section id="sampleEleven" runat="server">
    <asp:CheckBox runat="Server" ID="S11CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S11Title"></asp:Literal>
    <asp:Image runat="Server" ID="S11Image"></asp:Image>
    <asp:Literal runat="Server" ID="S11ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S11ProductDescription"></asp:Literal>
</section>

<section id="sampleTwelve" runat="server">
    <asp:CheckBox runat="Server" ID="S12CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S12Title"></asp:Literal>
    <asp:Image runat="Server" ID="S12Image"></asp:Image>
    <asp:Literal runat="Server" ID="S12ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S12ProductDescription"></asp:Literal>
</section>

<section id="sampleThirteen" runat="server">
    <asp:CheckBox runat="Server" ID="S13CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
    <asp:Literal runat="Server" ID="S13Title"></asp:Literal>
    <asp:Image runat="Server" ID="S13Image"></asp:Image>
    <asp:Literal runat="Server" ID="S13ProductName"></asp:Literal>
    <asp:Literal runat="Server" ID="S13ProductDescription"></asp:Literal>
</section>

<section class="form-content clearfix">
    <cms:BizForm ID="viewBiz" runat="server" />
</section>

<asp:HiddenField runat="server" ID="S1" />
<asp:HiddenField runat="server" ID="S2" />
<asp:HiddenField runat="server" ID="S3" />
<asp:HiddenField runat="server" ID="S4" />
<asp:HiddenField runat="server" ID="S5" />
<asp:HiddenField runat="server" ID="S6" />
<asp:HiddenField runat="server" ID="S7" />
<asp:HiddenField runat="server" ID="S8" />
<asp:HiddenField runat="server" ID="S9" />
<asp:HiddenField runat="server" ID="S10" />
<asp:HiddenField runat="server" ID="S11" />
<asp:HiddenField runat="server" ID="S12" />
<asp:HiddenField runat="server" ID="S13" />



