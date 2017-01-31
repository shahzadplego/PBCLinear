<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetail.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.Products.ProductDetail" %>


<div class="productDetail">
  <p>
      <asp:Literal runat="server" ID="ProductDescription"></asp:Literal>    
 
  </p>
    <div runat="server" ID="SpecContainer">
  <h3>
      <asp:Literal runat="server" ID="SpecTitle" /></h3>
 <ul class="productDetail-specs" runat="server" ID="SpecList">
   <li runat="server" ID="SpecID"></li>
   <li runat="server" ID="SpecOD"></li>
   <li runat="server" ID="SpecSize"></li>
   <li runat="server" ID="SpecMaterial"></li>
   </ul>
    </div>
  <h3><asp:Literal runat="server" ID="TechTitle"></asp:Literal>
    
  </h3>
    <asp:Literal runat="server" ID="TechnicalInformation"></asp:Literal>

  
</div>