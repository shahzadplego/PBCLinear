using System.Globalization;
using CMS.CustomTables;
using CMS.CustomTables.Types;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.UIControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PbcLinear.Web.PbcLinear.Admin
{
    public partial class ProductCategoryProductAssociationMapper : CMSPage
    {

        private const int productCategoryProductRelationshipID = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //DoStuff();
                SaveAllProducts();
            }
        }


        private void SaveAllProducts()
        {
            var products = DocumentHelper.GetDocuments("PbcLinear.Product").ToList();
            foreach (var product in products)
            {
                product.Update();
            }
        }

        private void DoStuff()
        {
            var products = DocumentHelper.GetDocuments("PbcLinear.Product");

            foreach (var product in products)
            {

                if (product != null)
                {
                    var stringSKU =
                        ValidationHelper.GetString(product.DocumentName, String.Empty, CultureInfo.CurrentCulture);

                    
                    // once we find product from step 3 we look up matching category from our list in step 2
                    var categoryRecord = CustomTableItemProvider.GetItems<ProductAssociationsItem>()
                        .FirstOrDefault(x => x.ProductSKUNumber == stringSKU);
                    // if product detail and product category are not null, add relationship to table mapping product detail node id and product category node id
                    if (categoryRecord != null)
                    {
                        ProcessCategory(product.NodeID, categoryRecord.ProductCategory1);
                        ProcessCategory(product.NodeID, categoryRecord.ProductCategory2);
                        ProcessCategory(product.NodeID, categoryRecord.ProductCategory3);
                    }
                }
            }
        }

        protected void ProcessCategory(int productNodeId, string categoryPath)
        {
            if (!string.IsNullOrEmpty(categoryPath))
            {
                var categoryItem = FindProductCategory(categoryPath);
                if (categoryItem != null)
                {
                    RelationshipInfoProvider.AddRelationship(productNodeId, categoryItem.NodeID,
                        productCategoryProductRelationshipID);

                }
                    // if product detail or product category are null log error and add to error tracker (add error tracking custom table)fields, product detail name, product category name and explanation of what's wrong 
                else
                {
                    // Prepares the code name (class name) of the custom table to which the data record will be added
                    string customTableClassName = "PbcLinear.ProcessCategoryErrors";

                    // Gets the custom table
                    DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(customTableClassName);
                    if (customTable != null)
                    {
                        // Creates a new custom table item 
                        CustomTableItem newCustomTableItem = CustomTableItem.New(customTableClassName);

                        // Sets the values for the fields of the custom table (ItemText in this case)
                        newCustomTableItem.SetValue("ProductNodeId", productNodeId);
                        newCustomTableItem.SetValue("CategoryPath", categoryPath);
                        newCustomTableItem.SetValue("Error", "categoryItem is null ");

                        if (productNodeId == 0)
                        {
                            var newError = newCustomTableItem.GetValue("Error") + " productNodeId is empty";
                            newCustomTableItem.SetValue("Error", newError);
                        }

                        if (!string.IsNullOrEmpty(categoryPath))
                        {
                            var newError = newCustomTableItem.GetValue("Error") + " categoryPath is empty";
                            newCustomTableItem.SetValue("Error", newError);

                        }

                        // Save the new custom table record into the database
                        newCustomTableItem.Insert();
                    }
                }
            }
        }

        protected CMS.DocumentEngine.TreeNode FindProductCategory(string nodeAliasPath)
        {
            string path = TreePathUtils.GetSafeNodeAliasPath(nodeAliasPath, CurrentSiteName);
            var subCategory = TreeHelper.GetDocument(CurrentSiteName, path, Culture, true,
                "PbcLinear.ProductSubCategory",
                true, true, CurrentUser);
            var category = TreeHelper.GetDocument(CurrentSiteName, path, Culture, true, "PbcLinear.ProductCategory",
                true, true, CurrentUser);
            var returnedCategory = new CMS.DocumentEngine.TreeNode();

            if (subCategory != null)
            {
                returnedCategory = subCategory;
            }


            if (category != null)
            {
                returnedCategory = category;
            }
            return returnedCategory;


        }

        protected void DeleteCustomTableItems()
        {
            // Prepares the code name (class name) of the custom table from which the record will be deleted
            string customTableClassName = "PbcLinear.ProductAssociations";

// Gets the custom table
            DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(customTableClassName);
            if (customTable != null)
            {
                // Gets the first custom table record whose value in the 'ItemText' starts with 'New text'
                CustomTableItem item = CustomTableItemProvider.GetItems(customTableClassName)
                    .WhereStartsWith("ItemText", "New text")
                    .FirstObject;

                if (item != null)
                {
                    // Deletes the custom table record from the database
                    item.Delete();
                }
            }
        }
    }
}