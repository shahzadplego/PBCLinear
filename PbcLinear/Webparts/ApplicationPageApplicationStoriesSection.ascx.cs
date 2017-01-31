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
    public partial class ApplicationPageApplicationStoriesSection : CMSAbstractWebPart
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
                ApplicationStoriesSectionTitle.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["ApplicationStoriesSectionTitle"], string.Empty);
                BindRelatedApplicationStories();
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


        private void BindRelatedApplicationStories()
        {

            var applicationStories =

                DocumentHelper.GetDocuments("PbcLinear.ApplicationStoryDetail")
                    .Columns("ApplicationStoryThumbnail, ApplicationStoryThumbnailAlt, DocumentName, DocumentUrlPath, NodeAliasPath")
                    .OnCurrentSite()
                    .Path(CurrentPageInfo.NodeAliasPath, PathTypeEnum.Children)
                    .Published()
                    .TopN(3)
                    .ToList();

            FeaturedApplicationStories.DataSource = applicationStories;
            FeaturedApplicationStories.DataBind();


        }

        #endregion

        protected void FeaturedApplicationStories_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (TreeNode)e.Item.DataItem;
            if (item != null)
            {
                var applicationStoryTitle = e.Item.FindControl("ApplicationStoryTitle") as Literal;
                if (applicationStoryTitle != null)
                {
                    applicationStoryTitle.Text = item.DocumentName;
                }
                var applicationStoryCTALink = e.Item.FindControl("ApplicationStoryCTALink") as HyperLink;
                if (applicationStoryCTALink != null)
                {
                    applicationStoryCTALink.NavigateUrl = item.NodeAliasPath;
                    applicationStoryCTALink.Text = "Learn More";
                }

            }


        }
    }
}