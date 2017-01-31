using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.PortalControls;
using TreeNode = CMS.DocumentEngine.TreeNode;

namespace PbcLinear.Web.PbcLinear.Webparts
{
    public partial class IndustriesOnLandingPage : CMSAbstractWebPart
    {
        #region "Methods"

        /// <summary>
        /// Content loaded event handler.
        /// </summary>
        public override void OnContentLoaded()
        {
            base.OnContentLoaded();
            SetupControl();
        }


        /// <summary>
        /// Initializes the control properties.
        /// </summary>
        protected void SetupControl()
        {
            if (this.StopProcessing)
            {
                // Do not process
            }
            else
            {
             
                BindIndustries();
            }
        }



        /// <summary>
        /// Reloads the control data.
        /// </summary>
        public override void ReloadData()
        {
            base.ReloadData();

            SetupControl();
        }


        private void BindIndustries()
        {

            var industries =

                DocumentHelper.GetDocuments("PbcLinear.IndustryDetail")
                    .Columns("IndustryShortDescription, IndustryThumbnail, IndustryThumbnailImageAlt, DocumentName, NodeAliasPath")
                    .OnCurrentSite()
                    .Path("/Industry-Landing", PathTypeEnum.Children)
                    .Published()
                    .CombineWithDefaultCulture(false)
                    .TopN(8)
                    .ToList();

            Industries.DataSource = industries;
            Industries.DataBind();


        }

        #endregion

        protected void Industries_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (TreeNode)e.Item.DataItem;
            if (item != null)
            {
                var industryTitle = e.Item.FindControl("IndustryTitle") as Literal;
                if (industryTitle != null)
                {
                    industryTitle.Text = item.DocumentName;
                }
                var industryCtaLink = e.Item.FindControl("IndustryCTALink") as HyperLink;
                if (industryCtaLink != null)
                {
                    industryCtaLink.NavigateUrl = item.NodeAliasPath;
                    industryCtaLink.Text = "View " + item.DocumentName;
                }
                

            }


        }
    }
}