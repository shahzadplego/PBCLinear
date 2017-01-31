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
    public partial class ContentWidthImageTitleSection : CMSAbstractWebPart
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
            //Plego
            CWITImageTitleLarge = CWITImageTitleSmall = CWITImageTitleSmall = CWITDescription = new Literal { };

            CWITImageTitleLarge.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["CWITImageTitleLarge"], string.Empty);
            CWITImageTitleSmall.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["CWITImageTitleSmall"], string.Empty);
            CWITTitle.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["CWITTitle"], string.Empty);
            CWITDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["CWITDescription"], string.Empty);

            if (!String.IsNullOrEmpty(CWITImageTitleSmall.Text))
            {
                SmallText.Visible = true;
            }
            

        }
        #endregion
    }
}