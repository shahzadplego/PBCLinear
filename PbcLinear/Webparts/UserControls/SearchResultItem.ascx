<%@ Control Language="C#" Inherits="CMS.Controls.CMSAbstractTransformation" %>
<%@ Import Namespace="CMS.DocumentEngine" %>
<%@ Import Namespace="PbcLinear.App_Code.Products" %>

<script runat="server">
    protected string GetSearchResultTitle()
    {
        var title = HTMLHelper.HTMLEncode(DataHelper.GetNotEmpty(Eval("Title"), "/"));
        return title;
    }
    
    protected string GetSearchResultUrl()
    {
        var id = Eval("id");
        var tree = new TreeProvider();
        var t = id.ToString().Split(';')[0];
        var doc = tree.SelectSingleDocument(Convert.ToInt32(t));
            
        if(doc != null && doc.ClassName.Equals("PbcLinear.Product"))
        {
            return ProductHelper.GetUrl(doc);
        }
        else
        {
            return SearchResultUrl(true).ToLower();
        }
    }

    protected string GetImage()
    {
        var id = Eval("id");
        var tree = new TreeProvider();
        var t = id.ToString().Split(';')[0];
        var doc = tree.SelectSingleDocument(Convert.ToInt32(t));

        if (doc != null && doc.ClassName.Equals("PbcLinear.Product"))
        {
            return ValidationHelper.GetString(doc["ThumbnailImage1"], ValidationHelper.GetString(doc["LargeImage"], string.Empty));
        }
        else
        {
            return  string.Empty;
        }
    }

</script>
<ul class="search-result__list">
    <li class="search-result__list-item search-result__list-item--flex-container">
    <%-- Search result title --%>
        <div class="search-result__flex-item search-result__flex-item--image">
            <img src="<%# GetImage() %>"/>
        </div>
        <div class="search-result__flex-item">
            <a class="search-result__title" <%# IfEmpty(GetSearchResultUrl(), "", "") %> href='<%# IfEmpty(GetSearchResultUrl(), "#", GetSearchResultUrl()) %>'>
                <%# SearchHighlight(HTMLHelper.HTMLEncode(GetSearchResultTitle()), "<span style=\"font-weight:bold;\">", "</span>") %>
            </a>
            <%-- Search result content --%>
            <p><%# SearchHighlight(HTMLHelper.HTMLEncode(TextHelper.LimitLength(HttpUtility.HtmlDecode(HTMLHelper.StripTags(GetSearchedContent(DataHelper.GetNotEmpty(Eval("Content"), "")), false, " ")), 280, "...")), "<span class=\"search__highlight\">", "</span>") %></p>
        </div>
    </li>
</ul>

<div style="margin-bottom: 30px;">
  <%-- Search result image --%>
        <div style="float: left; border: solid 1px #eeeeee; width: 90px; height:90px; margin-right: 5px;">
           <img src="<%# GetSearchImageUrl("/CMSModules/CMS_SmartSearch/no_image.gif",90) %>" alt="" />
        </div>
        <div style="float: left">
            <%-- Search result title --%>
            <div>
                <a style="font-weight: bold" href='<%# SearchResultUrl() %>'>
                    <%#SearchHighlight(HTMLHelper.HTMLEncode(CMS.ExtendedControls.ControlsHelper.RemoveDynamicControls(DataHelper.GetNotEmpty(Eval("Title"), "/"))), "<span style='font-weight:bold;'>", "</span>")%>
                </a>
            </div>
            <%-- Search result content --%>
            <div style="margin-top: 5px; width: 590px;min-height:40px">
                <%#SearchHighlight(HTMLHelper.HTMLEncode(TextHelper.LimitLength(HttpUtility.HtmlDecode(HTMLHelper.StripTags(CMS.ExtendedControls.ControlsHelper.RemoveDynamicControls(GetSearchedContent(DataHelper.GetNotEmpty(Eval("Content"), ""))), false, " ")), 280, "...")), "<span style='background-color: #FEFF8F'>", "</span>")%><br />
            </div>
            <%-- Relevance, URL, Creattion --%>
            <div style="margin-top: 5px;">
                <%-- Relevance --%>
                <div title="Relevance: <%# Convert.ToInt32(ValidationHelper.GetDouble(Eval("Score"), 0) * 100) %>%"
                    style="width: 50px; border: solid 1px #aaaaaa; margin-top: 7px; margin-right: 6px;
                    float: left; color: #0000ff; font-size: 2pt; line-height: 4px; height: 4px;">
                    <div style="<%# "background-color:#a7d3a7;width:" + Convert.ToString(Convert.ToInt32(ValidationHelper.GetDouble(Eval("Score"), 0) * 50)) + "px;height:4px;line-height: 4px;" %>">
                    </div>
                </div>
                <%-- URL --%>
                <span style="color: #008000">
                    <%# TextHelper.BreakLine(SearchHighlight(SearchResultUrl(),"<strong>","</strong>"),75,"<br />") %>
                </span>
                <%-- Creation --%>
                <span style="padding-left:5px;color: #888888; font-size: 9pt">
                    <%# GetDateTimeString(ValidationHelper.GetDateTime(Eval("Created"), DateTimeHelper.ZERO_TIME), true) %>
                </span>
            </div>
        </div>
        <div style="clear: both">
        </div>
    </div>