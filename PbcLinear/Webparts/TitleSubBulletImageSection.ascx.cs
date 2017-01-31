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
    public partial class TitleSubBulletImageSection : CMSAbstractWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TSBITitle.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBITitle"], string.Empty);

            TSBISubTitle1.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBISubTitle1"], string.Empty);
            TSBISubTitle2.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBISubTitle2"], string.Empty);
            TSBISubTitle3.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBISubTitle3"], string.Empty);

            TSBIBullet1.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBIBullet1"], string.Empty);
            TSBIBullet2.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBIBullet2"], string.Empty);
            TSBIBullet3.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBIBullet3"], string.Empty);
            TSBIBullet4.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBIBullet4"], string.Empty);
            TSBIBullet5.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBIBullet5"], string.Empty);
            TSBIBullet6.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBIBullet6"], string.Empty);


            TSBIImage.ImageUrl = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBIImage"], string.Empty);
            TSBIImage.AlternateText = ValidationHelper.GetString(DocumentContext.CurrentDocument["TSBIImageAlt"], string.Empty);
        }
    }
}