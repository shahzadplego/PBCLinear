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
    public partial class ContentWidthImageLinkSection : CMSAbstractWebPart
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

            CwiCta.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["CWICtaLink"], string.Empty);
            CWICtaText.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["CWICtaText"], string.Empty);

        }
        #endregion
    }
}