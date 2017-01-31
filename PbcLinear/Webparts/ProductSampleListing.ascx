<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSampleListing.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.ProductSampleListing" %>


        <asp:Button Text="text" runat="server" ID="ButtonPostBack" AutoPostBack="true" style="display:none;"/>
               
<div class="open-grid content-width" onclick="checkableSection()">
    <section id="sampleOne" runat="server" class="open-grid__item js-checkable" >
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S1CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S1Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S1Image" CssClass="open-grid__image" />
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S1ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S1ProductDescription"></asp:Literal>
        </p>
    </section>

    <section id="sampleTwo" runat="server" class="open-grid__item js-checkable">
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S2CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S2Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S2Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S2ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S2ProductDescription"></asp:Literal></p>
    </section>

    <section id="sampleThree" runat="server" class="open-grid__item js-checkable">
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S3CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S3Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S3Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S3ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S3ProductDescription"></asp:Literal>
        </p>
    </section>

    <section id="sampleFour" runat="server" class="open-grid__item js-checkable">
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S4CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S4Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S4Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S4ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S4ProductDescription"></asp:Literal>
        </p>
    </section>

    <section id="sampleFive" runat="server" class="open-grid__item js-checkable">
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S5CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S5Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S5Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S5ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S5ProductDescription"></asp:Literal>
        </p>
    </section>

    <section id="sampleSix" runat="server" class="open-grid__item js-checkable">
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S6CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S6Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S6Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S6ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S6ProductDescription"></asp:Literal>
        </p>
    </section>

    <section id="sampleSeven" runat="server" class="open-grid__item js-checkable">
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S7CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S7Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S7Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S7ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S7ProductDescription"></asp:Literal>
        </p>
    </section>

    <section id="sampleEight" runat="server" class="open-grid__item js-checkable">
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S8CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S8Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S8Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S8ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S8ProductDescription"></asp:Literal>
        </p>
    </section>

    <section id="sampleNine" runat="server" class="open-grid__item js-checkable">
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S9CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S9Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S9Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S9ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S9ProductDescription"></asp:Literal>
        </p>
    </section>

    <section id="sampleTen" runat="server" class="open-grid__item js-checkable">
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S10CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S10Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S10Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S10ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S10ProductDescription"></asp:Literal>
        </p>
    </section>

    <section id="sampleEleven" runat="server" class="open-grid__item js-checkable">
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S11CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S11Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S11Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S11ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S11ProductDescription"></asp:Literal>
        </p>
    </section>

    <section id="sampleTwelve" runat="server" class="open-grid__item js-checkable">
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S12CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S12Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S12Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S12ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S12ProductDescription"></asp:Literal>
        </p>
    </section>

    <section id="sampleThirteen" runat="server" class="open-grid__item js-checkable" >
        <div class="open-grid__check">
            <asp:CheckBox runat="Server" ID="S13CheckBox" AutoPostBack="true" OnCheckedChanged="CheckBox_Changed" />
            <asp:Literal runat="Server" ID="S13Title"></asp:Literal>
        </div>
        <figure class="open-grid__figure">
            <asp:Image runat="Server" ID="S13Image" CssClass="open-grid__image"></asp:Image>
        </figure>
        <p class="open-grid__item-name">
            <asp:Literal runat="Server" ID="S13ProductName"></asp:Literal>
        </p>
        <p class="open-grid__item-desc">
            <asp:Literal runat="Server" ID="S13ProductDescription"></asp:Literal>
        </p>
    </section>
</div>


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



