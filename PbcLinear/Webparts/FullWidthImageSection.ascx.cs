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
    public partial class FullWidthImageSection : CMSAbstractWebPart
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

            FWISectionImageTitle.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionImageTitle"], string.Empty);
            FWISectionTitle.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionTitle"], string.Empty);
            FWISectionDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionDescription"], string.Empty);

            var ctaText = ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionCtaText"], string.Empty);
            var ctaLink = ValidationHelper.GetString(DocumentContext.CurrentDocument["FWISectionCtaLink"], string.Empty);

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