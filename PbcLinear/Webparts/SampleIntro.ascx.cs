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
    public partial class SampleIntro : CMSAbstractWebPart
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
          

            SSTitle.Text = CurrentDocument.DocumentName;
            SSDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["SSDescription"], string.Empty); 

            var ctaText = ValidationHelper.GetString(DocumentContext.CurrentDocument["SSctaText"], string.Empty);
            var ctaLink = ValidationHelper.GetString(DocumentContext.CurrentDocument["SSctaLink"], string.Empty);

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