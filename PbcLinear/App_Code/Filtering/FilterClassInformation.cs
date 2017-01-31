using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.Helpers;

namespace PbcLinear.App_Code.Filtering
{
    public class FilterClassInformation
    {
        public string ProductClassName { get; set; }
        public string ProductDbTableName { get; set; }
        public string ProductDbGuidColumnName { get; set; }
        public int ProductNodeLevel = 5;
        public List<FilterField> AllProductFields { get; private set; }
        public List<FilterGroup> FilterGroups { get; private set; }
        
        public const string ExcludedColumns =
            "ATT_MASTERSPEC_LINK|ATT_ARCAT_LINK|DisplayUrinalAttributes|DisplayToiletAttributes|DisplaySinkAttributes|" +
            "DisplayFlushValveAttributes|DisplayFaucetAttributes|DisplayBackflowAttributes|DisplayPressureAttributes|DisplayReliefAttributes|DisplayPEXAttributes";
        public IEnumerable<int> ProductCategoryDescedents { get; set; }
        private string ClassName { get; set; }

        public FilterClassInformation(TreeNode productFamilyDocument, string className, string classToFilterOn, string filterOptionColumns)
        {
            DataClassInfo dataClassInfo = DataClassInfoProvider.GetDataClassInfo("PbcLinear.Product");
            ProductDbTableName = dataClassInfo.ClassTableName;

            ClassName = className;
            AllProductFields = GetAllProductFields(classToFilterOn);
            FilterGroups = GetProductFilterGroups(GetClosestProductCategoryWithFilters(productFamilyDocument, classToFilterOn), filterOptionColumns);
            ProductCategoryDescedents = NodeIdsOfDescedents(productFamilyDocument.Children.ToList()).Distinct();
        }

        public List<int> NodeIdsOfDescedents(List<TreeNode> children)
        {
            var nodeIds = new List<int>();
            foreach (var child in children.Where(x => x.ClassName.Equals(ClassName)))
            {
                if (!nodeIds.Contains(child.NodeID))
                {
                    nodeIds.Add(child.NodeID);
                }
                if (child.Children.Any(x => x.ClassName.Equals(ClassName)))
                {
                    var childIds = NodeIdsOfDescedents(child.Children.ToList());
                    nodeIds.AddRange(childIds);
                }
            }
            return nodeIds;
        }
        public List<Guid> ProductCategoryNodeGuIdsOfDescedents(List<TreeNode> children)
        {
            var nodeIds = new List<Guid>();
            foreach (var child in children.Where(x => x.ClassName.Equals(ClassName)))
            {
                if (!nodeIds.Contains(child.NodeGUID))
                {
                    nodeIds.Add(child.NodeGUID);
                }
                if (child.Children.Any(x => x.ClassName.Equals(ClassName)))
                {
                    var childIds = ProductCategoryNodeGuIdsOfDescedents(child.Children.ToList());
                    nodeIds.AddRange(childIds);
                }
            }
            return nodeIds;
        }
        private static TreeNode GetClosestProductCategoryWithFilters(TreeNode currentDocument, string className)
        {
            if (!string.IsNullOrEmpty(ValidationHelper.GetString(currentDocument["ProductFilterOptionFields"], string.Empty)))
            {
                return currentDocument;
            }
            if (currentDocument.Parent != null && currentDocument.Parent.ClassName.Equals(className))
            {
                if (!string.IsNullOrEmpty(ValidationHelper.GetString(
                    currentDocument.Parent["ProductFilterOptionFields"], string.Empty)))
                {
                    return currentDocument.Parent;
                }
                else
                {
                    return GetClosestProductCategoryWithFilters(currentDocument.Parent, className);
                }
            }
            return null;
        }

        private static List<FilterField> GetAllProductFields(string classToFilterOn)
        {
            var allProductFields = new List<FilterField>();

            var productFamilyClassInfo = DataClassInfoProvider.GetDataClassInfo(classToFilterOn);
            string classFormDefinition = productFamilyClassInfo.ClassFormDefinition;

            var doc = new XmlDocument();
            doc.LoadXml(classFormDefinition);

            XmlNodeList nodes = doc.SelectNodes("form");
            XmlNode root = nodes[0];
            string lastCategory = string.Empty;
            //Iterate through class form definition and map column names and display names
            foreach (XmlNode xnode in root.ChildNodes)
            {
                string displayName = xnode.FirstChild.FirstChild.NextSibling == null ? xnode.FirstChild.FirstChild.InnerText : xnode.FirstChild.FirstChild.NextSibling.InnerText;
                //column names are not elements, but defined as follows:
                //<field column="PartNumber" columnsize="20" columntype="text" guid="174f39c3-3cce-4a81-b235-b7d3985f6515" isinherited="true" publicfield="false" visible="true">
                //<properties>
                //<fieldcaption>Part Number</fieldcaption>
                //</properties>
                //<settings>
                //<AutoCompleteEnableCaching>False</AutoCompleteEnableCaching>
                //<AutoCompleteFirstRowSelected>False</AutoCompleteFirstRowSelected>
                //<AutoCompleteShowOnlyCurrentWordInCompletionListItem>False</AutoCompleteShowOnlyCurrentWordInCompletionListItem>
                //<controlname>TextBoxControl</controlname>
                //<FilterMode>False</FilterMode>
                //<Trim>False</Trim>
                //</settings>
                //</field>
                var elements = xnode.OuterXml.Split(' ');
                var columnName = elements.FirstOrDefault(x => x.Contains("column"));
                if (columnName != null)
                {
                    columnName = columnName.Replace("column=\"", "").Replace("\"", "");
                }
                var fieldType = string.Empty;
                if (xnode.Attributes != null && xnode.Attributes["columntype"] != null)
                {
                    fieldType = xnode.Attributes["columntype"].InnerText;
                }
                if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(displayName))
                {
                    if (!ExcludedColumns.Contains(columnName))
                    {
                        allProductFields.Add(
                            new FilterField
                            {
                                FieldName = columnName,
                                DisplayName = displayName,
                                Category = lastCategory,
                                FieldType = fieldType
                            });
                    }
                }

                if (elements.FirstOrDefault(x => x.Contains("category")) != null)
                {
                    columnName = xnode.Attributes["name"].InnerText;
                    displayName = xnode.FirstChild.FirstChild.InnerText.ToUpper().Equals("TRUE")
                        ? columnName
                        : xnode.FirstChild.FirstChild.InnerText;
                    if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(displayName))
                    {
                        lastCategory = columnName;
                        allProductFields.Add(
                            new FilterField
                            {
                                FieldName = columnName,
                                DisplayName = displayName,
                                Category = columnName
                            });
                    }
                }
            }

            return allProductFields;
        }



        private List<FilterGroup> GetProductFilterGroups(TreeNode productCategoryDocument, string targetOptionsFieldName)
        {
            var productFilterGroups = new List<FilterGroup>();
            if (productCategoryDocument != null)
            {
                var delimitedOptions = ValidationHelper.GetString(productCategoryDocument[targetOptionsFieldName],
                    string.Empty);
                if (string.IsNullOrEmpty(delimitedOptions))
                {
                    return productFilterGroups;
                }

                var options = delimitedOptions.Trim().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var option in options)
                {
                    if (option.Trim().ToUpper() == "MISCELLANEOUSATTRIBUTES" || option.Trim().ToUpper() == "VERTICALS" ||
                        option.Trim().ToUpper() == "PEXPRODUCTATTRIBUTES")
                    {
                        string option1 = option;
                        var filterOptions = AllProductFields.Where(x => x.Category == option1.Trim());
                        foreach (var filterOption in filterOptions)
                        {
                            if (productFilterGroups.All(x => x.FieldName != filterOption.FieldName))
                            {
                                var newFilterOption = new FilterGroup
                                {
                                    DisplayName = filterOption.DisplayName,
                                    FieldName = filterOption.FieldName,
                                    Category = option.Trim(),
                                    IsCategoryGroup = true,
                                    FieldType = filterOption.FieldType
                                };
                                newFilterOption.IsCategory = !string.IsNullOrEmpty(newFilterOption.Category) &&
                                                             newFilterOption.FieldName == newFilterOption.Category;
                                productFilterGroups.Add(newFilterOption);

                            }
                        }
                        continue;
                    }

                    var field = AllProductFields.FirstOrDefault(x => x.FieldName.ToUpper() == option.Trim().ToUpper());
                    if (field != null && productFilterGroups.All(x => x.FieldName != field.FieldName))
                    {
                        var filterGroup = new FilterGroup
                        {
                            DisplayName = field.DisplayName,
                            FieldName = field.FieldName,
                            FieldType = field.FieldType
                        };
                        productFilterGroups.Add(filterGroup);
                    }
                }
            }
            return productFilterGroups;
        }

        private List<FilterField> GetFields(TreeNode productFamilyDocument, string targetOptionsFieldName)
        {
            var fields = new List<FilterField>();
            var delimitedOptions = ValidationHelper.GetString(productFamilyDocument[targetOptionsFieldName], string.Empty);
            if (string.IsNullOrEmpty(delimitedOptions))
            {
                return fields;
            }

            var options = delimitedOptions.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var option in options)
            {
                var field = AllProductFields.FirstOrDefault(x => String.Equals(x.FieldName, option.Trim(), StringComparison.CurrentCultureIgnoreCase));
                if (field != null)
                {
                    fields.Add(field);
                }
            }

            return fields;
        }
    }
}