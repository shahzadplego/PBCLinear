using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.CustomTables;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.Membership;
using CMS.PortalControls;
using Microsoft.Ajax.Utilities;
using org.pdfclown.documents.contents.fonts;
using DocumentContext = CMS.DocumentEngine.DocumentContext;
using TreeNode = CMS.DocumentEngine.TreeNode;

namespace PbcLinear.WebParts.Products
{
    public partial class ProductDetail : CMSAbstractWebPart
    {
        private const string CategoryNameRelationshipName = " Zurn.Product_3d628a37-7637-4a21-b0b4-e1dd1a00a3bc";
        private const string SpecSheetsRelationshipName = "Zurn.Product_bc6943e1-d17c-40ee-be52-1680ab97b7f6";
        private const string ModelsRelationshipName = "Zurn.Product_f2c58cb8-9b29-4e3c-8c1a-4ed7e2557229";
        private const string VideosRelationshipName = "Zurn.Product_a6825126-f706-4da2-9794-54aaf378c23b";
        private const string PdfsRelationshipName = "Zurn.Product_6adb5bde-0ac2-4ba2-bf3b-1db01759019c";
        private const string RelatedProductsRelationshipName = "Zurn.Product_f03e03ca-c7ac-4371-8748-5caa6fedd247";

        public class TupleList<T1, T2> : List<Tuple<T1, T2>>
        {
            public void Add(T1 item, T2 item2)
            {
                Add(new Tuple<T1, T2>(item, item2));
            }
        }

        private TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindProduct();
                Page.Header.Controls.Add(
                    new LiteralControl(
                        "<link rel=\"canonical\" href=\"" + DocumentContext.CurrentDocument.AbsoluteURL + "\" />"
                    )
                );

            }
        }

        private void BindProduct()
        {
            ProductTitle.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["ProductTitle"], string.Empty);
            ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["Description"], string.Empty);
            var optionsLink = ValidationHelper.GetString(DocumentContext.CurrentDocument["OptionsLink"], string.Empty);
            var optionsText = ValidationHelper.GetString(DocumentContext.CurrentDocument["OptionsTitle"], string.Empty);
            if (!String.IsNullOrEmpty(optionsLink))
            {
                OptionsLink.NavigateUrl = optionsLink;
                if (!String.IsNullOrEmpty(optionsText))
                {
                    OptionsLink.Text = optionsText;
                }
                else
                {
                    OptionsLink.Text = "Options";
                }

                OptionsContainer.Visible = true;
            }
            else
            {
                OptionsContainer.Visible = false;
            }
            BindProductImages();
            BindProductFeatures();
            BindProductAttributes();
            BindProductBadges();
            BindProductAssets();
            BindRelatedProducts();
            BindProductFaqs();

        }

        private void BindProductFeatures()
        {
            var features = new List<string>();

            features.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["Feature1"], string.Empty));
            features.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["Feature2"], string.Empty));
            features.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["Feature3"], string.Empty));
            features.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["Feature4"], string.Empty));
            features.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["Feature5"], string.Empty));
            features.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["Feature6"], string.Empty));
            features.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["Feature7"], string.Empty));
            features.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["Feature8"], string.Empty));
            features.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["Feature9"], string.Empty));
            features.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["Feature10"], string.Empty));
            features = features.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            FeaturesList.DataSource = features;
            FeaturesList.DataBind();
        }

        private void BindProductAttributes()
        {
            var displayToiletAttributes = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["DisplayToiletAttributes"], false);
            if (displayToiletAttributes)
            {
                var toiletAttributes = new List<string>();

                toiletAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_TOILET_INSTALLATION"], string.Empty));
                toiletAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_TOILET_FLOWRATE"], string.Empty));
                toiletAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_TOILET_BOWLSHAPE"], string.Empty));
                toiletAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_TOILET_COLLECTION"], string.Empty));
                toiletAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_TOILET_COLORFINISH"], string.Empty));
                toiletAttributes = toiletAttributes.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                ToiletAttributeList.DataSource = toiletAttributes;
                ToiletAttributeList.DataBind();
            }
            else
            {
                ToiletAttributeSection.Visible = false;
            }

            var displaySinkAttributes = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["DisplaySinkAttributes"], false);
            if (displaySinkAttributes)
            {
                var sinkAttributes = new List<string>();
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_SINKS_LAVATORY"], false)) sinkAttributes.Add("Lavatory Sinks");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_SINKS_INSTITUTIONAL"], false)) sinkAttributes.Add("Institutional Sinks");

                sinkAttributes = sinkAttributes.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                SinkAttributeList.DataSource = sinkAttributes;
                SinkAttributeList.DataBind();
            }
            else
            {
                SinkAttributeSection.Visible = false;
            }

            var displayUrinalAttributes = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["DisplayUrinalAttributes"], false);
            if (displayUrinalAttributes)
            {
                var urinalAttributes = new List<string>();

                urinalAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_URINALS_COLLECTION"], string.Empty));
                urinalAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_URINALS_FLOWRATE"], string.Empty));
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_URINALS_WATERSENSE"], false)) urinalAttributes.Add("WaterSense");
                urinalAttributes = urinalAttributes.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                UrinalAttributeList.DataSource = urinalAttributes;
                UrinalAttributeList.DataBind();
            }
            else
            {
                UrinalAttributeSection.Visible = false;
            }

            var displayFlushValveAttributes = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["DisplayFlushValveAttributes"], false);
            if (displayFlushValveAttributes)
            {
                var flushValveAttributes = new List<string>();

                flushValveAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FLUSHVALVES_COLLECTION"], string.Empty));
                flushValveAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FLUSHVALVES_COLORFINISH_CATEGORY"], string.Empty));
                flushValveAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FLUSHVALVES_FLOWRATE"], string.Empty));
                flushValveAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FLUSHVALVES_HANDLETYPE"], string.Empty));
                flushValveAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FLUSHVALVES_HEIGHT"], string.Empty));
                flushValveAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FLUSHVALVES_LENGTH"], string.Empty));
                flushValveAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FLUSHVALVES_MATERIAL"], string.Empty));
                flushValveAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FLUSHVALVES_POWERSOURCE"], string.Empty));
                flushValveAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FLUSHVALVES_VALVESIZE"], string.Empty));
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_FLUSHVALVES_WATERSENSE"], false)) flushValveAttributes.Add("Watersense");
                flushValveAttributes = flushValveAttributes.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                FlushValveAttributeList.DataSource = flushValveAttributes;
                FlushValveAttributeList.DataBind();
            }
            else
            {
                FlushValveAttributeSection.Visible = false;
            }

            var displayFaucetAttributes = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["DisplayFaucetAttributes"], false);
            if (displayFaucetAttributes)
            {
                var faucetAttributes = new List<string>();

                faucetAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FAUCETS_COLLECTION"], string.Empty));
                faucetAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FAUCETS_MOUNT"], string.Empty));
                faucetAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FAUCETS_TYPE"], string.Empty));
                faucetAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FAUCETS_INSTALLATION"], string.Empty));
                faucetAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FAUCETS_FLOWRATE"], string.Empty));
                faucetAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FAUCETS_HANDLETYPE"], string.Empty));
                faucetAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_FAUCETS_NUMBERHANDLES"], string.Empty));
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_FAUCETS_WATERSENSE"], false)) faucetAttributes.Add("Watersense");
                faucetAttributes = faucetAttributes.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                FaucetAttributeList.DataSource = faucetAttributes;
                FaucetAttributeList.DataBind();
            }
            else
            {
                FaucetAttributeSection.Visible = false;
            }

            var displayBackflowAttributes = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["DisplayBackflowAttributes"], false);
            if (displayBackflowAttributes)
            {
                var backflowAttributes = new List<string>();

                backflowAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_BACKFLOW_ENDCONNECTION1"], string.Empty));
                backflowAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_BACKFLOW_MATERIAL"], string.Empty));
                backflowAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_BACKFLOW_VALVESIZE"], string.Empty));
                backflowAttributes = backflowAttributes.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                BackflowAttributeList.DataSource = backflowAttributes;
                BackflowAttributeList.DataBind();
            }
            else
            {
                BackflowAttributeSection.Visible = false;
            }

            var displayPressureAttributes = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["DisplayPressureAttributes"], false);
            if (displayPressureAttributes)
            {
                var pressureAttributes = new List<string>();

                pressureAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_PRESSUREREDUCING_ENDCONNECTION1"], string.Empty));
                pressureAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_PRESSUREREDUCING_ENDCONNECTION2"], string.Empty));
                pressureAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_PRESSUREREDUCING_MATERIAL"], string.Empty));
                pressureAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_PRESSUREREDUCING_MATERIALTYPE"], string.Empty));
                pressureAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_PRESSUREREDUCING_VALVESIZE"], string.Empty));
                pressureAttributes = pressureAttributes.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                PressureAttributeList.DataSource = pressureAttributes;
                PressureAttributeList.DataBind();
            }
            else
            {
                PressureAttributeSection.Visible = false;
            }

            var displayReliefAttributes = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["DisplayReliefAttributes"], false);
            if (displayReliefAttributes)
            {
                var reliefAttributes = new List<string>();

                reliefAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_RELIEF_MAXIMUMPRESSURE"], string.Empty));
                reliefAttributes.Add(ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_RELIEF_VALVESIZE"], string.Empty));
                reliefAttributes = reliefAttributes.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                ReliefAttributeList.DataSource = reliefAttributes;
                ReliefAttributeList.DataBind();
            }
            else
            {
                ReliefAttributeSection.Visible = false;
            }

            var displayPexAttributes = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["DisplayPEXAttributes"], false);
            if (displayPexAttributes)
            {
                var pexProductAttributes = new List<string>();
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_BRASS"], false)) pexProductAttributes.Add("Brass");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_COPPER"], false)) pexProductAttributes.Add("Copper");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_STAINLESS_STEEL"], false)) pexProductAttributes.Add("Stainless Steel");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_ALUMICOR"], false)) pexProductAttributes.Add("Alumicor");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_PERFORMA"], false)) pexProductAttributes.Add("Performa");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_HYPERTUBE"], false)) pexProductAttributes.Add("Hypertube");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_ZBITE"], false)) pexProductAttributes.Add("Z-Bite");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_QICKCLAMP"], false)) pexProductAttributes.Add("Qick Clamp");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_QICKSERT"], false)) pexProductAttributes.Add("Qick Sert");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_QICKPORT"], false)) pexProductAttributes.Add("Qick Port");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_QICKZONE"], false)) pexProductAttributes.Add("Qick Zone");
                if (ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_ACCUFLOW"], false)) pexProductAttributes.Add("Accuflow");


                pexProductAttributes = pexProductAttributes.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                PexProductAttributeList.DataSource = pexProductAttributes;
                PexProductAttributeList.DataBind();
            }
            else
            {
                PexProductAttributeSection.Visible = false;
            }

        }

        private void BindProductBadges()
        {
            Badge1.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_ADA_COMPLIANT"], false);
            Badge2.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_LEAD_FREE"], false);
            Badge3.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_BUY_AMERICAN"], false);
            Badge4.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_RETROFIT_REPLACEMENT"], false);

            Badge5.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_MASTERSPEC"], false);
            Badge5.HRef = ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_MASTERSPEC_LINK"], string.Empty);

            Badge6.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_ARCAT"], false);
            Badge6.HRef = ValidationHelper.GetString(DocumentContext.CurrentDocument["ATT_ARCAT_LINK"], string.Empty);

            Badge7.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_NSF_ANSI"], false);
            Badge8.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_CA_MANDATORY_WATER_REDUCTION"], false);
            Badge9.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_DISCONTINUED"], false);

            Badge10.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_Z_ONE_SPEC"], false);
            Badge11.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_LIGHT_DRAINAGE"], false);
            Badge12.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_EZSHIP"], false);
            Badge13.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_ZURN_WILKINS"], false);
            Badge14.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_LOW_LEAD_IAPMORT"], false);
            Badge15.Visible = ValidationHelper.GetBoolean(DocumentContext.CurrentDocument["ATT_GREEN_TURTLE"], false);
        }

        private void BindProductImages()
        {

            var thumbnailOne = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["ThumbnailImage1"], string.Empty));
            if (String.IsNullOrEmpty(thumbnailOne))
            {
                thumbnailOne = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["LargeImage"], string.Empty));
            }
            if (!String.IsNullOrEmpty(thumbnailOne))
            {
                PrimaryImage.Src = String.Format("{0}?maxsidesize=40", thumbnailOne);
                PrimaryImage.Attributes.Add("data-src", String.Format("{0}?maxsidesize=330", thumbnailOne));

                ProductThumbnail1.Visible = true;
                ProductThumbnail1.Attributes.Add("data-src", String.Format("{0}?maxsidesize=330", thumbnailOne));
                ProductThumbnail1.Src = String.Format("{0}?maxsidesize=40", thumbnailOne);
            }
            else
            {
                ProductThumbnails.Visible = false;
                return;
            }

            var thumbnailTwo = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["ThumbnailImage2"], string.Empty));
            if (!String.IsNullOrEmpty(thumbnailTwo))
            {
                ProductThumbnail2.Visible = true;
                ProductThumbnail2.Attributes.Add("data-src", String.Format("{0}?maxsidesize=330", thumbnailTwo));
                ProductThumbnail2.Src = String.Format("{0}?maxsidesize=40", thumbnailTwo);
            }
            else
            {
                ProductThumbnail2.Visible = false;
            }
            var thumbnailThree = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["ThumbnailImage3"], string.Empty));
            if (!String.IsNullOrEmpty(thumbnailThree))
            {
                ProductThumbnail3.Visible = true;
                ProductThumbnail3.Attributes.Add("data-src", String.Format("{0}?maxsidesize=330", thumbnailThree));
                ProductThumbnail3.Src = String.Format("{0}?maxsidesize=40", thumbnailThree);
            }
            else
            {
                ProductThumbnail3.Visible = false;
            }
            var thumbnailFour = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["ThumbnailImage4"], string.Empty));
            if (!String.IsNullOrEmpty(thumbnailFour))
            {
                ProductThumbnail4.Visible = true;
                ProductThumbnail4.Attributes.Add("data-src", String.Format("{0}?maxsidesize=330", thumbnailFour));
                ProductThumbnail4.Src = String.Format("{0}?maxsidesize=40", thumbnailFour);
            }
            else
            {
                ProductThumbnail4.Visible = false;
            }

            if (string.IsNullOrEmpty(thumbnailTwo) && string.IsNullOrEmpty(thumbnailThree) &&
                string.IsNullOrEmpty(thumbnailFour))
            {
                ProductThumbnails.Visible = false;
            }
        }

        private void BindProductAssets()
        {
            TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);


            var specSheets = tree.SelectNodes(CurrentSiteName, "/Media-Library/%",
                "en-US",
                false, "CMS.File", string.Empty, "NodeOrder", -1, true, CurrentDocument.NodeGUID, SpecSheetsRelationshipName,
                true).ToList();
            if (specSheets.Any())
            {
                SpecAssets.DataSource = specSheets;
                SpecAssets.DataBind();
                SpecsContainer.Visible = true;
            }
            else
            {
                SpecsContainer.Visible = false;
            }



            var models = tree.SelectNodes(CurrentSiteName, "/Media-Library/%",
                "en-US",
                false, "CMS.File", string.Empty, "NodeOrder", -1, true, CurrentDocument.NodeGUID, ModelsRelationshipName,
                true).ToList();


            if (models.Any())
            {
                ModelAssets.DataSource = models;
                ModelAssets.DataBind();
                ModelContainer.Visible = true;
            }
            else
            {
                ModelContainer.Visible = false;
            }

            var bimLink = ValidationHelper.GetString(DocumentContext.CurrentDocument["BIMLink"], String.Empty);
            var bimTitle = ValidationHelper.GetString(DocumentContext.CurrentDocument["BIMTitle"], "BIM");

            if (!String.IsNullOrEmpty(bimLink) && !String.IsNullOrEmpty(bimTitle))
            {
                BIMLink.NavigateUrl = bimLink;
                BIMLink.Text = bimTitle;
                BIMLink.Visible = true;
                ModelContainer.Visible = true;
            }
            else
            {
                BIMLink.Visible = false;
            }

            var videos = tree.SelectNodes(CurrentSiteName, "/Media-Library/%",
                "en-US",
                false, "CMS.File", string.Empty, "NodeOrder", -1, true, CurrentDocument.NodeGUID, VideosRelationshipName,
                true).ToList();

            if (videos.Any())
            {
                VideoAssets.DataSource = videos;
                VideoAssets.DataBind();
                VideoContainer.Visible = true;
            }
            else
            {
                VideoContainer.Visible = false;
            }


            var pdfs = tree.SelectNodes(CurrentSiteName, "/Media-Library/%",
                "en-US",
                false, "CMS.File", string.Empty, "NodeOrder", -1, true, CurrentDocument.NodeGUID, PdfsRelationshipName,
                true).ToList();

            if (pdfs.Any())
            {
                PDFAssets.DataSource = pdfs;
                PDFAssets.DataBind();
                PDFContainer.Visible = true;
            }
            else
            {
                PDFContainer.Visible = false;
            }

            if (!specSheets.Any() && !models.Any() && !videos.Any() && !pdfs.Any())
            {
                ResourcesContainer.Visible = false;
            }



        }

        protected void Specs_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }

            var spec = e.Item.DataItem as TreeNode;
            if (spec == null)
            {
                return;
            }

            var specControl = e.Item.FindControl("SpecLink") as HyperLink;
            if (specControl != null)
            {
                specControl.NavigateUrl = string.IsNullOrEmpty(spec.DocumentUrlPath)
                    ? spec.NodeAliasPath
                    : spec.DocumentUrlPath;
                if (spec["FriendlyFileName"] != null && !string.IsNullOrEmpty(spec["FriendlyFileName"].ToString()))
                {
                    specControl.Text = spec["FriendlyFileName"].ToString();
                }
                else
                {
                    specControl.Text = spec.DocumentName;
                }
            }
        }
        protected void Models_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }

            var model = e.Item.DataItem as TreeNode;
            if (model == null)
            {
                return;
            }

            var modelControl = e.Item.FindControl("ModelLink") as HyperLink;
            if (modelControl != null)
            {
                modelControl.NavigateUrl = string.IsNullOrEmpty(model.DocumentUrlPath)
                            ? model.NodeAliasPath
                            : model.DocumentUrlPath;

                if (model["FriendlyFileName"] != null && !string.IsNullOrEmpty(model["FriendlyFileName"].ToString()))
                {
                    modelControl.Text = model["FriendlyFileName"].ToString();
                }
                else
                {
                    modelControl.Text = model.DocumentName;
                }


            }
        }
        protected void Videos_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }

            var video = e.Item.DataItem as TreeNode;
            if (video == null)
            {
                return;
            }

            var videoControl = e.Item.FindControl("VideoLink") as HyperLink;
            if (videoControl != null)
            {
                videoControl.NavigateUrl = string.IsNullOrEmpty(video.DocumentUrlPath)
                            ? video.NodeAliasPath
                            : video.DocumentUrlPath;
                if (video["FriendlyFileName"] != null && !string.IsNullOrEmpty(video["FriendlyFileName"].ToString()))
                {
                    videoControl.Text = video["FriendlyFileName"].ToString();
                }
                else
                {
                    videoControl.Text = video.DocumentName;
                }
            }
        }
        protected void PDFs_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }

            var pdf = e.Item.DataItem as TreeNode;
            if (pdf == null)
            {
                return;
            }

            var pdfControl = e.Item.FindControl("PDFLink") as HyperLink;
            if (pdfControl != null)
            {
                pdfControl.NavigateUrl = string.IsNullOrEmpty(pdf.DocumentUrlPath)
                            ? pdf.NodeAliasPath
                            : pdf.DocumentUrlPath;

                if (pdf["FriendlyFileName"] != null && !string.IsNullOrEmpty(pdf["FriendlyFileName"].ToString()))
                {
                    pdfControl.Text = pdf["FriendlyFileName"].ToString();
                }
                else
                {
                    pdfControl.Text = pdf.DocumentName;
                }
            }
        }

        private void BindRelatedProducts()
        {
            var relatedProducts = tree.SelectNodes(CurrentSiteName, "/Product-Bucket/%",
                DocumentContext.CurrentDocumentCulture.CultureCode,
                false, "Zurn.Product", string.Empty, "NodeOrder", -1, true, CurrentDocument.NodeGUID, RelatedProductsRelationshipName,
                true).ToList();

            if (relatedProducts.Any())
            {
                RelatedProducts.DataSource = relatedProducts;
                RelatedProducts.DataBind();
            }
            else
            {
                RelatedProductSection.Visible = false;
            }

        }

        private void BindProductFaqs()
        {

            //var faqs = DocumentHelper
            //    .GetDocuments("Zurn.ProductFAQ")
            //    .Columns("DocumentName, NodeAlias, Question, Answer")
            //    .OnCurrentSite()
            //    .Published()
            //    .Culture(DocumentContext.CurrentDocumentCulture.CultureCode)
            //    .Path(string.Concat(DocumentContext.CurrentDocument.NodeAliasPath, "/%"))
            //    .OrderBy("NodeOrder")
            //    .ToList();


            //var customTableFAQs = CustomTableItemProvider.GetItems<FAQItem>()
            //       .Columns("ProductNumber, Question, Answer")
            //       .WhereEquals("ProductNumber", ValidationHelper.GetString(DocumentContext.CurrentDocument["ProductNumber"], string.Empty))
            //       .Distinct()
            //       .ToList();


            //var faqList = new TupleList<string, string>();
            //foreach (var faq in faqs)
            //{
            //    if (faq != null && faq["Question"] != null && faq["Answer"] != null)
            //    {
            //        faqList.Add(faq["Question"].ToString(), faq["Answer"].ToString());
            //    }
            //}

            //foreach (var faq in customTableFAQs)
            //{
            //    if (faq != null && faq["Question"] != null && faq["Answer"] != null)
            //    {
                    
            //        faqList.Add(faq["Question"].ToString(), faq["Answer"].ToString());
            //    }
            //}

            //if (faqList.Any())
            //{
            //    ProductFAQSection.Visible = true;
            //    ProductFAQs.DataSource = faqList;
            //    ProductFAQs.DataBind();
            //    divShowMore.Visible = faqList.Count >= 4;
            //}
            //else
            //{
            //    ProductFAQSection.Visible = false;
            //}
        }

        protected void ProductFAQs_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }

            var faq = e.Item.DataItem as Tuple<string, string>;
            if (faq == null)
            {
                return;
            }

            var question = e.Item.FindControl("FAQQuestion") as Literal;
            var answer = e.Item.FindControl("FAQAnswer") as Literal;
            if (question != null && answer != null)
            {
                question.Text = faq.Item1;
                answer.Text = faq.Item2;
            }

        }
    }
}