<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WysiwygImage.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.WysiwygImage" %>
<%@ Import Namespace="CMS.DocumentEngine" %>


<section class="content-width clearfix">
    <div class="flex--stretch">
        <div runat="server" ID="WysiwygContainer" class="flex__55 wysiwyg-img">
            <asp:Image runat="server" ID="WImage" />
        </div>
        <div class="flex__45 wysiwyg-content">
            <asp:Literal runat="server" ID="WDetails"></asp:Literal>
        </div>
    </div>
</section>

<%--<section class="content-width--margin-bottom clearfix">
    <div class="wysiwyg-floats">
        <div class="wysiwyg-img-float">
            
        </div>
        <div class="wysiwyg-content-float">
           
        </div>
    </div>
</section>--%>
