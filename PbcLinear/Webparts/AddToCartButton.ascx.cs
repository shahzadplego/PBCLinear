using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Base;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.PortalControls;

namespace PbcLinear.Web.PbcLinear.Webparts
{
    public partial class AddToCartButton : CMSAbstractWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            addItem.SKUID = ValidationHelper.GetInteger(DocumentContext.CurrentDocument["SKUID"], 0);
            addItem.SKUEnabled = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["SKUEnabled"], true);
           
        }
    }
}