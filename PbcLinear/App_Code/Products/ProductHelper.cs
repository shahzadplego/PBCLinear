using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CMS.DocumentEngine;
using CMS.Helpers;

namespace PbcLinear.App_Code.Products
{
    public static class ProductHelper
    {
        public static string GetUrl(TreeNode item)
        {
            var aliases = DocumentAliasInfoProvider.GetDocumentAliases(String.Format("AliasNodeID ='{0}'", item["NodeID"]), "").ToList();
            var alias = aliases.FirstOrDefault(x => x.AliasURLPath.Contains(RequestContext.CurrentRelativePath));
            if (alias != null)
            {
                return alias.AliasURLPath;
            }
            else if (aliases.FirstOrDefault() != null)
            {
                return aliases.FirstOrDefault().AliasURLPath;
            }
            else
            {
                return string.IsNullOrEmpty(item["DocumentUrlPath"].ToString())
                    ? item["NodeAliasPath"].ToString()
                    : item["DocumentUrlPath"].ToString();
            }
        }
        public static string GetUrl(DataRowView item)
        {
            var aliases = DocumentAliasInfoProvider.GetDocumentAliases(String.Format("AliasNodeID ='{0}'", item["NodeID"]), "").ToList();
            var alias = aliases.FirstOrDefault(x => x.AliasURLPath.Contains(RequestContext.CurrentRelativePath));
            if (alias != null)
            {
                return alias.AliasURLPath;
            }
            else if (aliases.FirstOrDefault() != null)
            {
                return aliases.FirstOrDefault().AliasURLPath;
            }
            else
            {
                return string.IsNullOrEmpty(item["DocumentUrlPath"].ToString())
                    ? item["NodeAliasPath"].ToString()
                    : item["DocumentUrlPath"].ToString();
            }
        }
    }
}