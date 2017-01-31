using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.CustomTables;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types;
using CMS.Helpers;
using CMS.PortalControls;
using TreeNode = CMS.DocumentEngine.TreeNode;

namespace PbcLinear.Web.PbcLinear.Webparts
{
    public partial class IndustryPageApplicationsSection : CMSAbstractWebPart
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
                ApplicationSectionTitle.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["ApplicationSectionTitle"], string.Empty);
                BindRelatedApplications();
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


        private void BindRelatedApplications()
        {
            var currentPage = CurrentDocument.DocumentName;
           
            var applications =

                DocumentHelper.GetDocuments("PbcLinear.ApplicationDetail")
                    .Columns("ApplicationShortDescription, ApplicationThumbnail, ApplicationThumbnailImageAlt, RelatedIndustries, DocumentName, NodeAliasPath")
                    .OnCurrentSite()
                    .Path("/Applications", PathTypeEnum.Children)
                    .Published()
                    .CombineWithDefaultCulture(false)
                    .NestingLevel(1)
                    .TopN(4)
                    .ToList();

            List<object> applicationList = new List<object>();
            foreach (var application in applications)
            {
                var relatedIndustries = application.GetProperty("RelatedIndustries");
                var riString = "";
                if (relatedIndustries != null)
                {
                    riString = relatedIndustries.ToString();
                }

                if (riString.IndexOf(currentPage) > -1)
                    {
                        applicationList.Add(application);
                    }
               
                
            }

           

            FeaturedApplications.DataSource = applicationList;
            FeaturedApplications.DataBind();


        }

        #endregion

        protected void FeaturedApplications_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (TreeNode)e.Item.DataItem;
            if (item != null)
            {
                var applicationTitle = e.Item.FindControl("ApplicationTitle") as Literal;
                if (applicationTitle != null)
                {
                    applicationTitle.Text = item.DocumentName;
                }
                var applicationLink = e.Item.FindControl("ApplicationCTALink") as HyperLink;
                if (applicationLink != null)
                {
                    applicationLink.NavigateUrl = item.NodeAliasPath;
                    applicationLink.Text = "Learn More";
                }

            }
           

        }
    }
}