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
    public partial class BulletBoxImageSection : CMSAbstractWebPart
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

            BulletTitle1.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["BulletTitle1"], string.Empty);
            BulletDescription1.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["BulletDescription1"], string.Empty);

            BulletTitle2.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["BulletTitle2"], string.Empty);
            BulletDescription2.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["BulletDescription2"], string.Empty);

            BulletTitle3.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["BulletTitle3"], string.Empty);
            BulletDescription3.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["BulletDescription3"], string.Empty);

            BulletTitle4.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["BulletTitle4"], string.Empty);
            BulletDescription4.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["BulletDescription4"], string.Empty);

            BulletImage.ImageUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["BulletImage"], string.Empty);
            BulletImage.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["BulletImageAlt"], string.Empty);
        }
        #endregion
    }
}