﻿using System;

using CMS.Base;
using CMS.DocumentEngine;
using CMS.UIControls;
using CMS.ExtendedControls;
using CMS.Helpers;

public partial class CMSPages_PortalTemplate : PortalPage
{
    #region "Properties"

    /// <summary>
    /// Document manager
    /// </summary>
    public override ICMSDocumentManager DocumentManager
    {
        get
        {
            // Enable document manager
            docMan.Visible = true;
            docMan.StopProcessing = false;
            return docMan;
        }
    }


    /// <summary>
    /// Returns XHTML namespace if current page has XHTML DocType. Otherwise it returns empty string.
    /// </summary>
    protected string XHtmlNameSpace
    {
        get
        {
            return DocumentBase.IsHTML5 ? String.Empty : HTMLHelper.DEFAULT_XMLNS_ATTRIBUTE;
        }
    }

    #endregion


    #region "Methods"

    protected override void OnInit(EventArgs e)
    {
        var resolvedTemplatePage = URLHelper.ResolveUrl(URLHelper.PortalTemplatePage);
        if (RequestContext.RawURL.StartsWithCSafe(resolvedTemplatePage, true))
        {
            // Deny direct access to this page
            RequestHelper.Respond404();
        }

        base.OnInit(e);
    }


    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        // Init the header tags
        tags.Text = HeaderTags;
        tags.Text =
            tags.Text.Replace(
                "<link href=\"/CMSPages/GetResource.ashx?stylesheetname=EcommerceSite\" type=\"text/css\" rel=\"stylesheet\"/>",
                "");
        tags.Text =
            tags.Text.Replace(
                "<link href=\"/CMSPages/GetResource.ashx?stylesheetfile=/App_Themes/EcommerceSite/Skin.css\" type=\"text/css\" rel=\"stylesheet\"/>",
                "");



    }

    #endregion
}