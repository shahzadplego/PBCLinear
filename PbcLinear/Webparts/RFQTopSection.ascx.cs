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
    public partial class RFQTopSection : CMSAbstractWebPart
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

            RFQTitle.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["RFQTitle"], string.Empty);

            RFQIntro.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["RFQIntro"], string.Empty);

            var rfqStandardLink = ValidationHelper.GetString(DocumentContext.CurrentDocument["RfqStandardLink"], string.Empty);
            RFQStandard.Visible = false;
            if (!String.IsNullOrEmpty(rfqStandardLink))
            {
                RFQStandard.Visible = true;
                RFQStandard.Text = "Request a STANDARD Sample";
                RFQStandard.NavigateUrl = rfqStandardLink;
            }

            var rfqEngineeredLink = ValidationHelper.GetString(DocumentContext.CurrentDocument["RfqEngineeredLink"], string.Empty);
            RFQEngineered.Visible = false;
            if (!String.IsNullOrEmpty(rfqEngineeredLink))
            {
                RFQEngineered.Visible = true;
                RFQEngineered.Text = "Brochure";
                RFQEngineered.NavigateUrl = rfqEngineeredLink;
            }




        }
        #endregion
    }
}