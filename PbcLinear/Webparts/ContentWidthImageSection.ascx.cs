using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.PortalControls;

namespace PbcLinear.Web.PbcLinear.Webparts
{
    public partial class ContentWidthImageSection : CMSAbstractWebPart
    {

        #region "Methods"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindContent();
            }
        }

        private void BindContent()
        {
            CWIDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["CWIDescription"], string.Empty);
            var ctaText = ValidationHelper.GetString(DocumentContext.CurrentDocument["CWICtaText"], string.Empty);
            var ctaLink = ValidationHelper.GetString(DocumentContext.CurrentDocument["CWICtaLink"], string.Empty);



            if (!String.IsNullOrEmpty(ctaText) && !String.IsNullOrEmpty(ctaLink))
            {
                CTAWrap.Visible = true;
                CTA.NavigateUrl = ctaLink;
                CTA.Text = ctaText;
            }
        }
        #endregion
    }
}