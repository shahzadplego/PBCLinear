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
    public partial class ContactUsTopSection : CMSAbstractWebPart
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

            ContactTitle.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["ContactTitle"], string.Empty);

            ContactIntro.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["ContactIntro"], string.Empty);

            ContactLeftAddress.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["ContactLeftAddress"], string.Empty);

            ContactRightPhone.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["ContactRightPhone"], string.Empty);
           



        }
        #endregion
    }
}