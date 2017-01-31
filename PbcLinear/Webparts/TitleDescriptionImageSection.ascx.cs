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
    public partial class TitleDescriptionImageSection : CMSAbstractWebPart
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

            TDITitle.Text = CurrentDocument.DocumentName;
            TDIDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["TDIDescription"], string.Empty);


            TDIImage.ImageUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["TDIImage"], string.Empty);
            TDIImage.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["TDIImageAlt"], string.Empty);



        }
        #endregion
    }
}