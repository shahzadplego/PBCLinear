<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderCompleteDetails.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.Ecommerce.OrderCompleteDetails" %>


<section class="content-width--margin-bottom clearfix">
    <p>
        <span class="bold">Name:</span>
        <asp:Literal runat="server" ID="Name" />
    <p>
        <span class="bold">Order Number: </span>   
        <asp:Literal runat="server" ID="OrderNumber" />
    </p>

    <p>
        <span class="bold">PayPal Authorization Number:</span>
        <asp:Literal runat="server" ID="PaypalAuth" />
    </p>
    <p>
        <span class="bold">Payment Note:</span>     
        <asp:Literal runat="server" ID="PaymentSuccess" />
    </p>
    
     <p>
        <span class="bold">Total Price:</span> $<asp:Literal runat="server" ID="TotalPrice" />

     </p>
    <h2 class="standard-title center--mobile">
        <span class="bold">Order Details</span></h2>
    <asp:Repeater runat="server" ID="OrderItemDetails" OnItemDataBound="OrderItemDetails_OnItemDataBound">
        <ItemTemplate>
            <hr class="page-separator" />
            <p>
                <span class="bold">SKU Name:</span>       
                <asp:Literal runat="server" ID="OrderSku" />
            </p>
            <p>
                <span class="bold">Unit Price:</span>       
                <asp:Literal runat="server" ID="ItemPrice" />
            </p>
            <p>
               <span class="bold"> Quantity:</span>       
                <asp:Literal runat="server" ID="NumberofSku" />
            </p>
        </ItemTemplate>
    </asp:Repeater>
   
</section>
