using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.PortalControls;
using CMS.OnlineForms;
using CMS.DataEngine;
using CMS.SiteProvider;
using CMS.Helpers;

namespace PbcLinear.Web.PbcLinear.Webparts
{
    public partial class ProductSampleListing : CMSAbstractWebPart
    {
        
        #region "Methods"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindContent();
            }
           
        }

       

        protected override void OnLoad(EventArgs e)
        {
            viewBiz.OnBeforeSave += viewBiz_OnBeforeSave;
            base.OnLoad(e);
        }


        /// <summary>
        /// Content loaded event handler.
        /// </summary>
        public override void OnContentLoaded()
        {
            base.OnContentLoaded();
            SetupControl();
        }


        /// <summary>
        /// Reloads data for partial caching.
        /// </summary>
        public override void ReloadData()
        {
            base.ReloadData();
            SetupControl();
        }


        /// <summary>
        /// Initializes the control properties.
        /// </summary>
        protected void SetupControl()
        {

            if (StopProcessing)
            {
                // Do nothing
                viewBiz.StopProcessing = true;
            }
            else
            {

                BizFormInfo bi = BizFormInfoProvider.GetBizFormInfo("RequestAStandardSample", SiteContext.CurrentSiteID);
               

                // Set BizForm properties
                viewBiz.FormName = "RequestAStandardSample";
                viewBiz.UseColonBehindLabel = true;
               
            }
        }

        private void viewBiz_OnBeforeSave(object sender, EventArgs e)
        {

            var s1 = S1.Value;
            var s2 = S2.Value;
            var s3 = S3.Value;
            var s4 = S4.Value;
            var s5 = S5.Value;
            var s6 = S6.Value;
            var s7 = S7.Value;
            var s8 = S8.Value;
            var s9 = S9.Value;
            var s10 = S10.Value;
            var s11 = S11.Value;
            var s12 = S12.Value;
            var s13 = S13.Value;

            string samplesRequested = String.Empty;

            if (!(viewBiz.Data.GetValue("Samples") == null))
            {
                samplesRequested = viewBiz.Data.GetValue("Samples").ToString();

            }

            string newSamples = samplesRequested;

            if (!String.IsNullOrEmpty(s1))
            {
                newSamples = newSamples + s1;
            }
            if (!String.IsNullOrEmpty(s2))
            {
                newSamples = newSamples + "; " + s2;
            }
            if (!String.IsNullOrEmpty(s3))
            {
                newSamples = newSamples + "; " + s3;
            }
            if (!String.IsNullOrEmpty(s4))
            {
                newSamples = newSamples + "; " + s4;
            }
            if (!String.IsNullOrEmpty(s5))
            {
                newSamples = newSamples + "; " + s5;
            }
            if (!String.IsNullOrEmpty(s6))
            {
                newSamples = newSamples + "; " + s6;
            }
            if (!String.IsNullOrEmpty(s7))
            {
                newSamples = newSamples + "; " + s7;
            }
            if (!String.IsNullOrEmpty(s8))
            {
                newSamples = newSamples + "; " + s8;
            }
            if (!String.IsNullOrEmpty(s9))
            {
                newSamples = newSamples + "; " + s9;
            }
            if (!String.IsNullOrEmpty(s10))
            {
                newSamples = newSamples + "; " + s10;
            }
            if (!String.IsNullOrEmpty(s11))
            {
                newSamples = newSamples + "; " + s11;
            }
            if (!String.IsNullOrEmpty(s12))
            {
                newSamples = newSamples + "; " + s12;
            }
            if (!String.IsNullOrEmpty(s13))
            {
                newSamples = newSamples + "; " + s13;
            }

            viewBiz.Data.SetValue("Samples", newSamples);
        }

        private void BindContent()
        {
            var s1ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S1ProductName"], string.Empty); 
            S1Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S1Title"], string.Empty); 
            S1Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S1ImageUrl"], string.Empty));
            S1Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S1ImageAlt"], string.Empty);
            S1ProductName.Text = s1ProductName;
            S1ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S1ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s1ProductName))
            {
                sampleOne.Visible = false;
            }



            var s2ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S2ProductName"], string.Empty);
            S2Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S2Title"], string.Empty);
            S2Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S2ImageUrl"], string.Empty));
            S2Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S2ImageAlt"], string.Empty);
            S2ProductName.Text = s2ProductName;
            S2ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S2ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s2ProductName))
            {
                sampleTwo.Visible = false;
            }


           
            var s3ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S3ProductName"], string.Empty);
            S3Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S3Title"], string.Empty);
            S3Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S3ImageUrl"], string.Empty));
            S3Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S3ImageAlt"], string.Empty);
            S3ProductName.Text = s3ProductName;
            S3ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S3ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s3ProductName))
            {
                sampleThree.Visible = false;
            }


           
            var s4ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S4ProductName"], string.Empty);
            S4Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S4Title"], string.Empty);
            S4Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S4ImageUrl"], string.Empty));
            S4Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S4ImageAlt"], string.Empty);
            S4ProductName.Text = s4ProductName;
            S4ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S4ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s4ProductName))
            {
                sampleFour.Visible = false;
            }


           
            var s5ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S5ProductName"], string.Empty);
            S5Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S5Title"], string.Empty);
            S5Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S5ImageUrl"], string.Empty));
            S5Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S5ImageAlt"], string.Empty);
            S5ProductName.Text = s5ProductName;
            S5ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S5ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s5ProductName))
            {
                sampleFive.Visible = false;
            }


           
            var s6ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S6ProductName"], string.Empty);
            S6Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S6Title"], string.Empty);
            S6Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S6ImageUrl"], string.Empty));
            S6Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S6ImageAlt"], string.Empty);
            S6ProductName.Text = s6ProductName;
            S6ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S6ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s6ProductName))
            {
                sampleSix.Visible = false;
            }


           
            var s7ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S7ProductName"], string.Empty);
            S7Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S7Title"], string.Empty);
            S7Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S7ImageUrl"], string.Empty));
            S7Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S7ImageAlt"], string.Empty);
            S7ProductName.Text = s7ProductName;
            S7ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S7ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s7ProductName))
            {
                sampleSeven.Visible = false;
            }


           
            var s8ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S8ProductName"], string.Empty);
            S8Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S8Title"], string.Empty);
            S8Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S8ImageUrl"], string.Empty));
            S8Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S8ImageAlt"], string.Empty);
            S8ProductName.Text = s8ProductName;
            S8ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S8ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s8ProductName))
            {
                sampleEight.Visible = false;
            }


           
            var s9ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S9ProductName"], string.Empty);
            S9Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S9Title"], string.Empty);
            S9Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S9ImageUrl"], string.Empty));
            S9Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S9ImageAlt"], string.Empty);
            S9ProductName.Text = s9ProductName;
            S9ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S9ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s9ProductName))
            {
                sampleNine.Visible = false;
            }


           
            var s10ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S10ProductName"], string.Empty);
            S10Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S10Title"], string.Empty);
            S10Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S10ImageUrl"], string.Empty));
            S10Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S10ImageAlt"], string.Empty);
            S10ProductName.Text = s10ProductName;
            S10ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S10ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s10ProductName))
            {
                sampleTen.Visible = false;
            }


           
            var s11ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S11ProductName"], string.Empty);
            S11Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S11Title"], string.Empty);
            S11Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S11ImageUrl"], string.Empty));
            S11Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S11ImageAlt"], string.Empty);
            S11ProductName.Text = s11ProductName;
            S11ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S11ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s11ProductName))
            {
                sampleEleven.Visible = false;
            }


           
            var s12ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S12ProductName"], string.Empty);
            S12Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S12Title"], string.Empty);
            S12Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S12ImageUrl"], string.Empty));
            S12Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S12ImageAlt"], string.Empty);
            S12ProductName.Text = s12ProductName;
            S12ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S12ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s12ProductName))
            {
                sampleTwelve.Visible = false;
            }


           
            var s13ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S13ProductName"], string.Empty);
            S13Title.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S13Title"], string.Empty);
            S13Image.ImageUrl = URLHelper.RemoveQuery(ValidationHelper.GetString(DocumentContext.CurrentDocument["S13ImageUrl"], string.Empty));
            S13Image.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["S13ImageAlt"], string.Empty);
            S13ProductName.Text = s13ProductName;
            S13ProductDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["S13ProductDescription"], string.Empty);

            if (String.IsNullOrEmpty(s13ProductName))
            {
                sampleThirteen.Visible = false;
            }


           
        }

        protected void CheckBox_Changed(object sender, EventArgs e)
        {
            var s1ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S1ProductName"], string.Empty);
            var s2ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S2ProductName"], string.Empty);
            var s3ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S3ProductName"], string.Empty);
            var s4ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S4ProductName"], string.Empty);
            var s5ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S5ProductName"], string.Empty);
            var s6ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S6ProductName"], string.Empty);
            var s7ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S7ProductName"], string.Empty);
            var s8ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S8ProductName"], string.Empty);
            var s9ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S9ProductName"], string.Empty);
            var s10ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S10ProductName"], string.Empty);
            var s11ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S11ProductName"], string.Empty);
            var s12ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S12ProductName"], string.Empty);
            var s13ProductName = ValidationHelper.GetString(DocumentContext.CurrentDocument["S13ProductName"], string.Empty);

            S1.Value = S1CheckBox.Checked ? s1ProductName : string.Empty;
            S2.Value = S2CheckBox.Checked ? s2ProductName : string.Empty;
            S3.Value = S3CheckBox.Checked ? s3ProductName : string.Empty;
            S4.Value = S4CheckBox.Checked ? s4ProductName : string.Empty;
            S5.Value = S5CheckBox.Checked ? s5ProductName : string.Empty;
            S6.Value = S6CheckBox.Checked ? s6ProductName : string.Empty;
            S7.Value = S7CheckBox.Checked ? s7ProductName : string.Empty;
            S8.Value = S8CheckBox.Checked ? s8ProductName : string.Empty;
            S9.Value = S9CheckBox.Checked ? s9ProductName : string.Empty;
            S10.Value = S10CheckBox.Checked ? s10ProductName : string.Empty;
            S11.Value = S11CheckBox.Checked ? s11ProductName : string.Empty;
            S12.Value = S12CheckBox.Checked ? s12ProductName : string.Empty;
            S13.Value = S13CheckBox.Checked ? s13ProductName : string.Empty;
  
        }

       
        #endregion
    }
}