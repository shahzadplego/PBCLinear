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
    public partial class TitleSubDescriptionSection : CMSAbstractWebPart
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
            TSDSectionTitle.Text = ValidationHelper.GetString(
                DocumentContext.CurrentDocument["TSDSectionTitle"], string.Empty);
            TSDSectionSubTitle.Text =
                ValidationHelper.GetString(DocumentContext.CurrentDocument["TSDSectionSubtitle"],
                    string.Empty);
            TSDSectionDescription.Text =
                ValidationHelper.GetString(DocumentContext.CurrentDocument["TSDSectionDescription"],
                    string.Empty);

        }

        #endregion
    }
}