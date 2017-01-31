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
    public partial class FourCardSection : CMSAbstractWebPart
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

           // FourCardImage1.text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImage1"], string.Empty);
            //var card1Alt = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImageAlt1"], string.Empty);
            //if (!String.IsNullOrEmpty(card1Alt))
            //{
            //    FourCardImage1.AlternateText = card1Alt;
            //}
            FourCardBGImage1.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImage1"], string.Empty);
            FourCardTitle1.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardTitle1"], string.Empty);
            FourCardDescription1.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardDescription1"], string.Empty);
            FourCardCtaLink1.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardCtaLink1"], string.Empty);
            FourCardCtaLink1.Text = "View " + FourCardTitle1.Text;

            //FourCardImage2.ImageUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImage2"], string.Empty);
            //var card2Alt = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImageAlt2"], string.Empty);
            //if (!String.IsNullOrEmpty(card2Alt))
            //{
            //    FourCardImage2.AlternateText = card2Alt;
            //}
            FourCardBGImage2.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImage2"], string.Empty);
            FourCardTitle2.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardTitle2"], string.Empty);
            FourCardDescription2.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardDescription2"], string.Empty);
            FourCardCtaLink2.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardCtaLink2"], string.Empty);
            FourCardCtaLink2.Text = "View " + FourCardTitle2.Text;

            //FourCardImage3.ImageUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImage3"], string.Empty);
            //var card3Alt = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImageAlt3"], string.Empty);
            //if (!String.IsNullOrEmpty(card3Alt))
            //{
            //    FourCardImage3.AlternateText = card3Alt;
            //}
            FourCardBGImage3.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImage3"], string.Empty);
            FourCardTitle3.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardTitle3"], string.Empty);
            FourCardDescription3.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardDescription3"], string.Empty);
            FourCardCtaLink3.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardCtaLink3"], string.Empty);
            FourCardCtaLink3.Text = "View " + FourCardTitle3.Text;

            //FourCardImage4.ImageUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImage4"], string.Empty);
            //var card4Alt = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImageAlt4"], string.Empty);
            //if (!String.IsNullOrEmpty(card4Alt))
            //{
            //    FourCardImage4.AlternateText = card4Alt;
            //}
            FourCardBGImage4.Style["background-image"] = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardImage4"], string.Empty);
            FourCardTitle4.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardTitle4"], string.Empty);
            FourCardDescription4.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardDescription4"], string.Empty);
            FourCardCtaLink4.NavigateUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardCtaLink4"], string.Empty);
            FourCardCtaLink4.Text = "View " + FourCardTitle4.Text;

            var ctaText = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardSectionCtaText"], string.Empty);
            var ctaLink = ValidationHelper.GetString(DocumentContext.CurrentDocument["FourCardSectionCtaLink"], string.Empty);

            if (!String.IsNullOrEmpty(ctaText) && !String.IsNullOrEmpty(ctaLink))
            {
                CTAWrap.Visible = true;
                CTA.NavigateUrl = ctaLink;
                CTA.Text = ctaText;
            }
        }
        #endregion
    }
}