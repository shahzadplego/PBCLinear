using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Ecommerce;
using CMS.PortalControls;
using CMS.SiteProvider;

namespace PbcLinear.Web.PbcLinear.Webparts
{
    public partial class CreateNewProduct : CMSAbstractWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CreateNewProduct.Text = "Create New Product";

        }

        protected void CreateProduct(Object sender, EventArgs e)
        {
            // Gets a department
            DepartmentInfo department = DepartmentInfoProvider.GetDepartmentInfo("AutoCreated", SiteContext.CurrentSiteName);

            // Creates a new product object
            SKUInfo newProduct = new SKUInfo();

            // Sets the product properties
            newProduct.SKUName = "NewProduct" + newProduct.SKUID;
            newProduct.SKUPrice = 120;
            newProduct.SKUEnabled = true;
            if (department != null)
            {
                newProduct.SKUDepartmentID = department.DepartmentID;
            }
            newProduct.SKUSiteID = SiteContext.CurrentSiteID;

            // Saves the product to the database
            // Note: Only creates the SKU object. You also need to create a connected product page to add the product to the site.
            SKUInfoProvider.SetSKUInfo(newProduct);
        }
    }
}