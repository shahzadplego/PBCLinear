<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResultsPageSearchBox.ascx.cs" Inherits="PbcLinear.Web.PbcLinear.Webparts.SearchResultsPageSearchBox" %>
<%@ Register Src="~/CMSWebParts/SmartSearch/SearchBox.ascx" TagName="SearchBox" TagPrefix="uc1" %>

<section class="content-width clearfix site-search-box">
    <uc1:SearchBox runat="server" ID="SearchPageSearchBox" />
</section>
<!--ProductHelper.GetUrl(item);-->

<script>
    $(document).ready(function () {
        var searchText = getUrlParameter('searchtext');
        $('.search_page_search_box').val(searchText);

    });

    var getUrlParameter = function getUrlParameter(sParam) {
        var sPageURL = decodeURIComponent(window.location.search.substring(1)),
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;

        for (i = 0; i < sURLVariables.length; i++) {
            sParameterName = sURLVariables[i].split('=');

            if (sParameterName[0] === sParam) {
                return sParameterName[1] === undefined ? true : sParameterName[1];
            }
        }
    };
</script>