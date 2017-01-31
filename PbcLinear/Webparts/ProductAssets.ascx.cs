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
    public partial class ProductAssets : CMSAbstractWebPart
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

           
            var schematicURL = ValidationHelper.GetString(DocumentContext.CurrentDocument["Schematic"], string.Empty);
            SchematicContainer.Visible = false;
            if (!String.IsNullOrEmpty(schematicURL))
            {
                Schematic.Text = "Schematic";
                Schematic.NavigateUrl = schematicURL;
                SchematicContainer.Visible = true;
            }
           


            var dataSheet = ValidationHelper.GetString(DocumentContext.CurrentDocument["DataSheet"], string.Empty);
            DataSheetContainer.Visible = false;
            if (!String.IsNullOrEmpty(dataSheet))
            {
                DataSheetContainer.Visible = true;
                DataSheet.Text = "Data Sheet";
                DataSheet.NavigateUrl = dataSheet;
            }
           


            var video = ValidationHelper.GetString(DocumentContext.CurrentDocument["Video"], string.Empty);
            VideoContainer.Visible = false;
            if (!String.IsNullOrEmpty(video))
            {
                VideoContainer.Visible = true;
                Video.Text = "Video";
                Video.NavigateUrl = video;
            }
           


            var selectionGuide = ValidationHelper.GetString(DocumentContext.CurrentDocument["SelectionGuide"], string.Empty);
            SelectionGuideContainer.Visible = false;
            if (!String.IsNullOrEmpty(selectionGuide))
            {
                SelectionGuideContainer.Visible = true;
                SelectionGuide.Text = "Selection Guide";
                SelectionGuide.NavigateUrl = selectionGuide;
            }


            var catalog = ValidationHelper.GetString(DocumentContext.CurrentDocument["Catalog"], string.Empty);
            SelectionGuideContainer.Visible = false;
            if (!String.IsNullOrEmpty(catalog))
            {
                CatalogContainer.Visible = true;
                Catalog.Text = "Catalog";
                Catalog.NavigateUrl = catalog;
            }

            var brochure = ValidationHelper.GetString(DocumentContext.CurrentDocument["Brochure"], string.Empty);
            BrochureContainer.Visible = false;
            if (!String.IsNullOrEmpty(brochure))
            {
                BrochureContainer.Visible = true;
                Brochure.Text = "Brochure";
                Brochure.NavigateUrl = brochure;
            }
           

            
            


        }
        #endregion
    }
}