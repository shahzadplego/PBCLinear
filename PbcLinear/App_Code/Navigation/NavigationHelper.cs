using System;
using System.Collections.Generic;
using System.Linq;
using CMS.DocumentEngine;
using CMS.Helpers;

using TreeNode = CMS.DocumentEngine.TreeNode;

namespace PbcLinear.App_Code.Navigation
{
    public class NavigationColumn
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string ClassName { get; set; }
        public List<NavigationNode> NavigationNodes { get; set; }
    }

    public class NavigationNode
    {
        public string ClassName { get; set; }

        public string Section1Title { get; set; }
        public string Section1Link { get; set; }
        public string Section1Target { get; set; }
        public List<AssociatedPage> Section1Items { get; set; }
        public string Section2Title { get; set; }
        public string Section2Link { get; set; }
        public string Section2Target { get; set; }
        public List<AssociatedPage> Section2Items { get; set; }
        public string Section3Title { get; set; }
        public string Section3Link { get; set; }
        public string Section3Target { get; set; }
        public List<AssociatedPage> Section3Items { get; set; }

        public NavigationNode()
        {
            Section1Items = new List<AssociatedPage>();
            Section2Items = new List<AssociatedPage>();
            Section3Items = new List<AssociatedPage>();
        }
    }

    public class AssociatedPage
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Target { get; set; }
    }

    public class NavigationHelper
    {
        private const string relationshipRow1 = "Zurn.NavigationColumnComponent_5d429424-3b2b-4da2-b13b-e225d4a6b191";
        private const string relationshipRow2 = "Zurn.NavigationColumnComponent_4bb24dc4-0dbd-4ede-a8f5-d99783a75275";
        private const string relationshipRow3 = "Zurn.NavigationColumnComponent_8e6c6935-60f4-43f3-b6f8-9c296e772406";
        public static List<NavigationColumn> MegaMenuNodes { get; set; }
        public static TreeProvider tree = new TreeProvider();
        public NavigationHelper(string siteName, string cultureCode)
        {
            MegaMenuNodes = CacheHelper.Cache(x => LoadNavigationInformation(siteName, cultureCode),
                new CacheSettings(30, String.Format("zurn|{0}|navigation", cultureCode)));
        }

        private static List<NavigationColumn> LoadNavigationInformation(string siteName, string cultureCode)
        {
            var navItems = tree.SelectNodes(siteName, "/Navigation-Items/%", cultureCode, false, "Zurn_Navigation_Column.NavigationColumn;Zurn.NavigationColumnComponent", string.Empty, "NodeOrder", -1, true, -1, string.Empty);

            var items = new List<NavigationColumn>();

            foreach (var item in navItems.Where(x => x.ClassName.Equals("Zurn_Navigation_Column.NavigationColumn")))
            {
                var linkItem = tree.SelectSingleNode(ValidationHelper.GetGuid(item["TitleLink"], new Guid()), cultureCode, siteName);
                string link = string.Empty;
                if (linkItem != null)
                {
                    link = !string.IsNullOrEmpty(linkItem.DocumentMenuRedirectUrl)
                           ? linkItem.DocumentMenuRedirectUrl
                           : string.IsNullOrEmpty(linkItem.DocumentUrlPath)
                               ? linkItem.NodeAliasPath
                               : linkItem.DocumentUrlPath;
                    
                }
                var node = new NavigationColumn
                {
                    Name = ValidationHelper.GetString(item["Title"], string.Empty),
                    Link = link,
                    ClassName = item.ClassName,
                    NavigationNodes =
                        GetColumnNavigationNodes(
                            navItems.Items.Where(
                                x =>
                                    x.Parent.NodeID == item.NodeID &&
                                    x.ClassName.Equals("Zurn.NavigationColumnComponent")).ToList(), siteName,
                            cultureCode)
                };
                items.Add(node);
            }
            return items;
        }

        private static List<NavigationNode> GetColumnNavigationNodes(List<TreeNode> children, string siteName, string cultureCode)
        {
            var items = new List<NavigationNode>();
            foreach (var item in children)
            {
                if (item.ClassName.Equals("Zurn.NavigationColumnComponent"))
                {
                    var node = new NavigationNode();
                    node.Section1Title = ValidationHelper.GetString(item["Title1"], string.Empty);
                    TreeNode section1Link = tree.SelectSingleNode(ValidationHelper.GetGuid(item["TitleLink1"], new Guid()), cultureCode, siteName);
                    if (section1Link != null)
                    {
                        node.Section1Link = ResolveLinkSrc(section1Link);
                        node.Section1Target = ResolveLinkTarget(section1Link);
                    }

                    node.Section1Items = SetSectionItems(siteName, cultureCode, item, relationshipRow1);

                    node.Section2Title = ValidationHelper.GetString(item["Title2"], string.Empty);
                    TreeNode section2Link = tree.SelectSingleNode(ValidationHelper.GetGuid(item["TitleLink2"], new Guid()), cultureCode, siteName);
                    if (section2Link != null)
                    {
                        node.Section2Link = ResolveLinkSrc(section2Link);
                        node.Section2Target = ResolveLinkTarget(section2Link);
                    }
                    node.Section2Items = SetSectionItems(siteName, cultureCode, item, relationshipRow2);

                    node.Section3Title = ValidationHelper.GetString(item["Title3"], string.Empty);
                    TreeNode section3Link = tree.SelectSingleNode(ValidationHelper.GetGuid(item["TitleLink3"], new Guid()), cultureCode,
                            siteName);
                    if (section3Link != null)
                    {
                        node.Section3Link = ResolveLinkSrc(section3Link);
                        node.Section3Target = ResolveLinkTarget(section3Link);
                    }
                    node.Section3Items = SetSectionItems(siteName, cultureCode, item, relationshipRow3);
                    items.Add(node);
                }
            }
            return items;
        }

        private static List<AssociatedPage> SetSectionItems(string siteName, string cultureCode, TreeNode item, string row)
        {
            var sectionItems = tree.SelectNodes(siteName, "/%", cultureCode, false, string.Empty, string.Empty,
                string.Empty, -1, true, item.NodeGUID, row, true).Items.ToList();
            List<AssociatedPage> items = new List<AssociatedPage>();
            foreach (var sectionItem in sectionItems)
            {
                items.Add(new AssociatedPage
                {
                    Target = ResolveLinkTarget(sectionItem),
                    Name = sectionItem.DocumentName,
                    Link = ResolveLinkSrc(sectionItem)
                });
            }
            return items;
        }

        private static string ResolveLinkTarget(TreeNode item)
        {
            return !string.IsNullOrEmpty(item.DocumentMenuRedirectUrl)
                ? "_blank"
                : "";
        }

        private static string ResolveLinkSrc(TreeNode item)
        {
            return !string.IsNullOrEmpty(item.DocumentMenuRedirectUrl)
                ? URLHelper.EnsureURLPrefix(item.DocumentMenuRedirectUrl, "", "http://")
                : string.IsNullOrEmpty(item.DocumentUrlPath)
                    ? item.NodeAliasPath
                    : item.DocumentUrlPath;
        }
    }
}