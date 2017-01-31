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
    public partial class TitleDescriptionSeparatorSection : CMSAbstractWebPart
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
            TDSSectionTitle.Text = CurrentDocument.DocumentName;
            TDSSectionDescription.Text =
                ValidationHelper.GetString(DocumentContext.CurrentDocument["TDSSectionDescription"],
                    string.Empty);

        }

        #endregion
    }
}