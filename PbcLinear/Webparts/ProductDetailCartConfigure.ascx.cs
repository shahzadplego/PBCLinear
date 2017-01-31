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
    public partial class ProductDetailCartConfigure : CMSAbstractWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            addItem.SKUID = ValidationHelper.GetInteger(DocumentContext.CurrentDocument["SKUID"], 0);
            addItem.SKUEnabled = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["SKUEnabled"], true);

            var configure = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["Configure"], false);
            var ecommerce = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["Ecommerce"], false);
            
            
            var configureURL = ValidationHelper.GetString(DocumentContext.CurrentDocument["ConfigureURL"], string.Empty);
             
            ConfigureHyperLink.Text = "Configure and Quote";
            

            CallInfo.Text = "Call to Configure";
            CallNumber.Text = "1-888-389-6266";

            AddToCartContainer.Visible = false;
            ConfigureConatiner.Visible = false;
            CallContainer.Visible = false;


            if (configure)
            {
                if (string.IsNullOrEmpty(configureURL))
                {
                    ConfigureHyperLink.NavigateUrl = configureURL;
                    ConfigureConatiner.Visible = true;
                }
            }
            if (ecommerce)
            {
                AddToCartContainer.Visible = true;
                
            }
            if (!ecommerce && !configure)
            {
                CallContainer.Visible = true;
            }




        }
    }
}