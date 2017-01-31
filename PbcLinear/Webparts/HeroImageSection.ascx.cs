using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types;
using CMS.Helpers;
using CMS.PortalControls;

namespace PbcLinear.Web.PbcLinear.Webparts
{
    public partial class HeroImageSection : CMSAbstractWebPart
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
               
                //Hero Section
               
                H1LargeText.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["H1LargeText"],
                    string.Empty);
                H1SmallText.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["H1SmallText"],
                    string.Empty);
            

        }
        #endregion
    }
}