using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.DocumentEngine;
using CMS.PortalControls;
using TreeNode = CMS.DocumentEngine.TreeNode;

namespace PbcLinear.WebParts.Products
{
    public partial class ProductLanding : CMSAbstractWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindProductCategories();
            }
        }

        private void BindProductCategories()
        {
            var productCategories = DocumentHelper.GetDocuments("Zurn.ProductCategory")
                .Columns("ThumbnailImage, DocumentName, NodeAliasPath, DocumentUrlPath")
                .OnCurrentSite()
                .Path("/products", PathTypeEnum.Children)
                .Published()
                .CombineWithDefaultCulture(false)
                .NestingLevel(1)
                .ToList();
            rptProducts.DataSource = productCategories;
            rptProducts.DataBind();
        }

        protected void rptProducts_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (TreeNode)e.Item.DataItem;
            if (item != null)
            {
                var lnkProductCategory = e.Item.FindControl("lnkProductCategory") as HyperLink;
                if (lnkProductCategory != null)
                {
                    lnkProductCategory.NavigateUrl = string.IsNullOrEmpty(item.DocumentUrlPath) ? item.NodeAliasPath : item.DocumentUrlPath;
                }
            }
        }
    }
}