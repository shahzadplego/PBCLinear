using System;
using System.Linq;
using CMS.Base;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.Membership;
using CMS.SiteProvider;

[CustomDocumentEvents]
public partial class CMSModuleLoader
{
    private class CustomDocumentEventsAttribute : CMSLoaderAttribute
    {
        public const string ProductCategoryRelationshipName = "PbcLinear.Product_7eee3c99-4634-4810-be37-11b0d17d9022";
        public override void Init()
        {
            // Assigns custom handlers to events
            DocumentEvents.Update.After += Document_Update_After;
        }

        private void Document_Update_After(object sender, DocumentEventArgs e)
        {
            if (e.Node.ClassName.Equals("PbcLinear.Product"))
            {
                TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);
                var relatedProductCategories = tree.SelectNodes(SiteContext.CurrentSiteName, "/Products/%",
                    e.Node.DocumentCulture,
                    false, "PbcLinear.ProductSubCategory", string.Empty, "NodeOrder", -1, true, e.Node.NodeGUID,
                    ProductCategoryRelationshipName,
                    true).ToList();

                DocumentAliasInfoProvider.DeleteNodeAliases(e.Node.NodeID);
                foreach (var category in relatedProductCategories)
                {
                    DocumentAliasInfoProvider.SetDocumentAliasInfo(new DocumentAliasInfo
                    {
                        AliasNodeID = e.Node.NodeID,
                        AliasURLPath = TreePathUtils.GetSafeNodeAliasPath(string.Format("{0}/{1}", category.NodeAliasPath, e.Node.DocumentName), "PbcLinear"),
                        AliasSiteID = SiteContext.CurrentSiteID,
                        AliasCulture = "",
                        AliasExtensions = ""
                    }, SiteContext.CurrentSiteName);
                }
            }
        }
    }
}