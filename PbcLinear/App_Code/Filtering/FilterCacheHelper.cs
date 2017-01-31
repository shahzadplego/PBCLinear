using System;
using CMS.DocumentEngine;
using CMS.Helpers;

namespace PbcLinear.App_Code.Filtering
{
    public class FilterCacheHelper
    {
        public FilterClassInformation FilterClassInfo { get; set; }
        public FilterCacheHelper() { }
        public FilterCacheHelper(TreeNode productCategoryDocument, string className, string classToFilterOn, string filterOptionColumns)
        {
            FilterClassInfo = CacheHelper.Cache(x => LoadClassInformation(productCategoryDocument, className, classToFilterOn, filterOptionColumns),
                new CacheSettings(30, String.Format("pbclinear|{0}|{1}",className, productCategoryDocument.NodeAlias)));
        }

        private static FilterClassInformation LoadClassInformation(TreeNode productFamilyDocument, string className, string classToFilterOn, string filterOptionColumns)
        {
            return new FilterClassInformation(productFamilyDocument, className, classToFilterOn, filterOptionColumns);
        }
    }
}