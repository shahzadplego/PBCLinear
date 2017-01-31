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
    public partial class EightCardSection : CMSAbstractWebPart
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
            EightCardImage1.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImage1"], string.Empty);
            //EightCardImage1.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImageAlt1"], string.Empty);
            EightCardTitle1.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardTitle1"], string.Empty);
            EightCardDescription1.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardDescription1"], string.Empty);
            CTA1.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardCtaLink1"], string.Empty);
            CTA1.Text = "View " + EightCardTitle1.Text;


            EightCardImage2.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImage2"], string.Empty);
            //EightCardImage2.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImageAlt2"], string.Empty); 
            EightCardTitle2.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardTitle2"], string.Empty);
            EightCardDescription2.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardDescription2"], string.Empty);
            CTA2.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardCtaLink2"], string.Empty);
            CTA2.Text = "View " + EightCardTitle2.Text;


            EightCardImage3.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImage3"], string.Empty);
            //EightCardImage3.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImageAlt3"], string.Empty); 
            EightCardTitle3.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardTitle3"], string.Empty);
            EightCardDescription3.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardDescription3"], string.Empty);
            CTA3.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardCtaLink3"], string.Empty);
            CTA3.Text = "View " + EightCardTitle3.Text;

            EightCardImage4.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImage4"], string.Empty);
            //EightCardImage4.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImageAlt4"], string.Empty); 
            EightCardTitle4.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardTitle4"], string.Empty);
            EightCardDescription4.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardDescription4"], string.Empty);
            CTA4.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardCtaLink4"], string.Empty);
            CTA4.Text = "View " + EightCardTitle4.Text;

            EightCardImage5.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImage5"], string.Empty);
            //EightCardImage5.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImageAlt5"], string.Empty); 
            EightCardTitle5.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardTitle5"], string.Empty);
            EightCardDescription5.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardDescription5"], string.Empty);
            CTA5.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardCtaLink5"], string.Empty);
            CTA5.Text = "View " + EightCardTitle5.Text;

            EightCardImage6.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImage6"], string.Empty);
            //EightCardImage6.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImageAlt6"], string.Empty); 
            EightCardTitle6.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardTitle6"], string.Empty);
            EightCardDescription6.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardDescription6"], string.Empty);
            CTA6.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardCtaLink6"], string.Empty);
            CTA6.Text = "View " + EightCardTitle6.Text;

            EightCardImage7.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImage7"], string.Empty);
            //EightCardImage7.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImageAlt7"], string.Empty); 
            EightCardTitle7.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardTitle7"], string.Empty);
            EightCardDescription7.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardDescription7"], string.Empty);
            CTA7.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardCtaLink7"], string.Empty);
            CTA7.Text = "View " + EightCardTitle7.Text;

            EightCardImage8.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImage8"], string.Empty);
            //EightCardImage8.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardImageAlt8"], string.Empty); 
            EightCardTitle8.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardTitle8"], string.Empty);
            EightCardDescription8.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardDescription8"], string.Empty);
            CTA8.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["EightCardCtaLink8"], string.Empty);
            CTA8.Text = "View " + EightCardTitle8.Text;
        }
        #endregion
    }
}