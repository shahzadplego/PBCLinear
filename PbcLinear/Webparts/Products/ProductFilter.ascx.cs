using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CMS;
using CMS.Base;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types;
using CMS.ExtendedControls;
using CMS.Helpers;
using CMS.Membership;
using CMS.PortalControls;
using Lucene.Net.Search;
using org.pdfclown.objects;
using PbcLinear.App_Code.Filtering;
using PbcLinear.App_Code.Products;
using TreeNode = CMS.DocumentEngine.TreeNode;

namespace PbcLinear.WebParts.Products
{
    public enum SortDirection
    {
        Ascending,
        Descending,
        None
    }

    public partial class ProductFilter : CMSAbstractWebPart
    {
        private const int PagerGroupSize = 2;
        private const int PageSize = 21;
        public string ProductCategoryRelationshipName = "PbcLinear.Product_3d628a37-7637-4a21-b0b4-e1dd1a00a3bc";
        
        private FilterCacheHelper _productCategoryHelper;

        public FilterCacheHelper ProductCategoryHelper
        {
            get
            {
                if (_productCategoryHelper == null)
                {
                    _productCategoryHelper = new FilterCacheHelper(CurrentDocument, "PbcLinear.ProductCategory", "PbcLinear.Product", "ProductFilterOptionFields");
                }
                return _productCategoryHelper;
            }
        }

        private TreeNodeHierarchyHelper _treeNodeHierarchyHelper;

        public TreeNodeHierarchyHelper TreeNodeHierarchyHelper
        {
            get
            {
                if (_treeNodeHierarchyHelper == null)
                {
                    _treeNodeHierarchyHelper = new TreeNodeHierarchyHelper(CurrentDocument, "/products", "PbcLinear.ProductCategory");
                }
                return _treeNodeHierarchyHelper;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                Session["SelectedProductCategoryId"] = CurrentDocument.NodeID;
                Session["SelectedCheckBoxFieldValues"] = new Dictionary<string, string>();
                SetupControl();
            }
            else
            {
                ScriptManager.RegisterStartupScript(
               UpdatePanel,
               this.GetType(),
               "toggleToolbarLinks",
               "deferLoadImages('.filter-results__figure img');",
               true);  
            }
            
           
        }

        private void SetupControl()
        {
            BindCategoryRadioSelector();
            BindProducts(1);
            BindFilterGroups();
            BuildPager(1, GetResultsCount());
            BindPageData();


        }

        private void BindPageData()
        {
            ltlProductCategoryFilterTitle.Text = String.Format("{0} Type", CurrentDocument.Parent.DocumentName );  
            ltlProductCategoryTitle.Text = CurrentDocument.DocumentName;
            ltlProductCount.Text = String.Format("({0} Products)", GetResultsCount());
            
            PTDSectionDescription.Text = ValidationHelper.GetString(DocumentContext.CurrentDocument["PTDSectionDescription"], string.Empty);
            
        }

        private void BindCategoryRadioSelector()
        {
            var currentParent = CurrentDocument.Parent;

            var siblingCategories = currentParent.Children.Where(
                    x => (x.ClassName.Equals("PbcLinear.ProductCategory") || x.ClassName.Equals("PbcLinear.ProductSubCategory")) && x.NodeLevel == CurrentDocument.NodeLevel).ToList();

            rptProductCategories.DataSource = siblingCategories;
            rptProductCategories.DataBind();
        }

        private void BindFilterGroups()
        {
            //if lower level and none selected, find the parent category and use those filter values

            FilterClassInformation productCategoryInformation = ProductCategoryHelper.FilterClassInfo;
            var filters = productCategoryInformation.FilterGroups.Where(x => !x.IsCategoryGroup || x.IsCategory);
           

        }

        private void BindProducts(int pageNumber)
        {
            SortDirection nameSortDirection = Session["SortDirectionName"] != null ? (Session["SortDirectionName"] is SortDirection ? (SortDirection)Session["SortDirectionName"] : SortDirection.Ascending) : SortDirection.Ascending;
            SortDirection popularitySortDirection = Session["SortDirectionPopularity"] != null ? (Session["SortDirectionPopularity"] is SortDirection ? (SortDirection)Session["SortDirectionPopularity"] : SortDirection.Ascending) : SortDirection.Ascending;
            int productCategoryNodeId;
            if (Session["SelectedProductCategoryId"] == null)
            {
                productCategoryNodeId = CurrentDocument.NodeID;
            }
            else
            {
                int.TryParse(Session["SelectedProductCategoryId"].ToString(), out productCategoryNodeId);
            }
            var skipAmount = (pageNumber - 1) * PageSize;
            var products = FindProductsByProductCategoryAndFilterStatement((int)productCategoryNodeId, nameSortDirection, popularitySortDirection, skipAmount);

            if (products.Tables[0].Rows.Count > 0)
            {
                divNoResultsMessage.Visible = false;
                rptProducts.Visible = true;
                rptProducts.DataSource = products;
                rptProducts.DataBind();
            }
            else
            {
                rptProducts.Visible = false;
                divNoResultsMessage.Visible = true;
            }
        }

        private string GenerateProductCategoryQuery(int productCategoryNodeId)
        {
            TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);
            var doc = tree.SelectSingleNode(productCategoryNodeId);
            var node = TreeNodeHierarchyHelper.FindNodeById(productCategoryNodeId, TreeNodeHierarchyHelper.Nodes);
            var ids = TreeNodeHierarchyHelper.ListNodesUnderId(node);//ProductCategoryHelper.ProductCategoryInfo.ProductCategoryNodeIdsOfDescedents(doc.Children.ToList());
            ids.Add(doc.NodeID);
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            int i = 1;
            foreach (var id in ids)
            {
                sb.AppendFormat("{0}", id);
                if (i < ids.Count)
                {
                    sb.Append(",");
                }
                i++;
            }
            
            sb.Append(")");
            return sb.ToString();
        }

        private DataSet FindProductsByProductCategoryAndFilterStatement(int productCategoryId, SortDirection nameSortDirection, SortDirection popularitySortDirection, int skipAmount)
        {
            QueryDataParameters parameters = new QueryDataParameters();
            string filterQuery = GenerateProductFilterQuery();
            if (!string.IsNullOrEmpty(filterQuery))
            {
                filterQuery = "AND " + filterQuery;
            }
            else
            {
                filterQuery = " ";
            }
            
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("select * from " +
                            "(select distinct   ROW_NUMBER() OVER(PARTITION BY rel.RightNodeId ORDER BY t.NodeId) AS rownumber, " +
                            "t.DocumentCulture, " +
                            "t.DocumentName, " +
                            "t.DocumentSKUShortDescription, " +
                            "s.SKUImagePath, " +
                            "s.SKUDescription, " +
                            "t.NodeId, " +
                            "t.DocumentUrlPath, " +
                            "t.NodeAliasPath, " +
                            "p.ID, " +
                            "p.OD, " +
                            "p.Size, " +
                            "p.Material, " +
                            "s.SKUPrice, " +
                            "rel.RightNodeID, " +
                            "w.StepType " +
                            "FROM CMS_RElationship rel ");
            sb.Append("inner join VIEW_CMS_TREE_JOINED t on rel.LeftNodeID = t.NodeId ");
            sb.Append("inner join COM_SKU s on t.DocumentSKUName = s.SKUNumber ");
            sb.Append("inner join PbcLinear_Product p on t.DocumentForeignKeyValue = p.ProductID ");
            sb.Append("left outer join CMS_WorkFlowStep w on t.DocumentWorkflowStepID = w.StepID ) as selectStatement ");
            sb.AppendFormat("where (selectStatement.StepType = 100 or selectStatement.StepType is null) and (RightNodeID in {0} {1} ) and DocumentCulture='{2}' ", GenerateProductCategoryQuery(productCategoryId), filterQuery, CurrentDocument.DocumentCulture);
            sb.AppendFormat("and selectStatement.rownumber between {0} and {1} ", skipAmount, (skipAmount + 21));
            sb.AppendFormat("order by {0} selectStatement.DocumentName {1} ", popularitySortDirection == SortDirection.Descending ? "selectStatment.CategorySortWeight DESC, " : " ", nameSortDirection == SortDirection.Ascending ? " ASC" : " DESC");
             
            
            

            DataSet ds = ConnectionHelper.ExecuteQuery(sb.ToString(), null, QueryTypeEnum.SQLQuery);
            TotalResultsCount.Value = ds.Tables[0].Rows.Count.ToString();
            return ds;
        }

        private string GenerateProductFilterQuery()
        {
            Dictionary<string, string> selectedCheckboxFieldValues = null;
            if (Session["SelectedCheckBoxFieldValues"] != null)
            {
                selectedCheckboxFieldValues = Session["SelectedCheckBoxFieldValues"] as Dictionary<string, string>;
            }
            if (selectedCheckboxFieldValues == null || !selectedCheckboxFieldValues.Any())
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            foreach (var filter in selectedCheckboxFieldValues)
            {
                if (filter.Value.Contains("|"))
                {
                    var items = filter.Value.Split('|');
                    string inItems = string.Empty;
                    foreach (var item in items)
                    {
                        inItems += String.Format("'{0}',", item);
                    }
                    inItems = inItems.Substring(0, inItems.LastIndexOf(','));
                    sb.AppendFormat("{0} IN ({1}) AND ", filter.Key, inItems);
                }
                else
                {
                    sb.AppendFormat("{0} = '{1}' AND ", filter.Key, filter.Value);
                }
            }
            return sb.ToString().Substring(0, sb.ToString().LastIndexOf(" AND"));

        }

        protected void FilterGroups_OnItemCreated(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void FilterGroups_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item &&
                e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }
            var item = (FilterGroup)e.Item.DataItem;
            var divFilterGroupWrapper = e.Item.FindControl("divFilterGroupWrapper");
            if (item.IsCategory && item.IsCategoryGroup)
            {
                //get defined options
                var rptFilterOptions = e.Item.FindControl("rptFilterOptions") as Repeater;
                if (rptFilterOptions != null)
                {
                    var filterOptions = ProductCategoryHelper.FilterClassInfo.FilterGroups.Where(
                            x => x.Category == item.Category && !x.IsCategory);
                    if (filterOptions.Any())
                    {
                        rptFilterOptions.DataSource = filterOptions;
                        rptFilterOptions.DataBind();
                    }
                    else
                    {
                        rptFilterOptions.Visible = false;
                        if (divFilterGroupWrapper != null)
                        {
                            divFilterGroupWrapper.Visible = false;
                        }
                    }
                }
            }
            else
            {
                //populate select list with product data that pertains to this filter option
                TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);
                var products = tree.SelectNodes(CurrentSiteName, "/Product-Bucket/%",
                    DocumentContext.CurrentDocumentCulture.CultureCode,
                    false, "PbcLinear.Product", string.Empty, string.Empty, -1, true,
                    CurrentDocument.NodeGUID, ProductCategoryRelationshipName, false);

                var rptFilterOptions = e.Item.FindControl("rptFilterOptions") as Repeater;
                if (rptFilterOptions != null)
                {
                    var ds = products.Where(
                        x =>
                            !string.IsNullOrEmpty(ValidationHelper.GetString(x[item.FieldName],
                                string.Empty)));

                    List<FilterGroup> filters = new List<FilterGroup>();
                    foreach (var d in ds)
                    {
                        if (filters.All(x => x.DisplayName != d[item.FieldName].ToString()))
                        {
                            filters.Add(new FilterGroup
                                {
                                    DisplayName = d[item.FieldName].ToString(),
                                    FieldName = item.FieldName,
                                    FieldType = item.FieldType
                                });
                        }
                    }
                    if (filters.Any())
                    {
                        rptFilterOptions.DataSource = filters;
                        rptFilterOptions.DataBind();
                    }
                    else
                    {
                        rptFilterOptions.Visible = false;
                        if (divFilterGroupWrapper != null)
                        {
                            divFilterGroupWrapper.Visible = false;
                        }
                    }
                }
            }
        }

        private bool CheckBoxWasSelected(string name)
        {
            Dictionary<string, string> selectedCheckboxFieldValues = null;
            if (Session["SelectedCheckBoxFieldValues"] != null)
            {
                selectedCheckboxFieldValues = Session["SelectedCheckBoxFieldValues"] as Dictionary<string, string>;
               
            }
            if (selectedCheckboxFieldValues == null || !selectedCheckboxFieldValues.Any())
            {
                return false;
            }
            return selectedCheckboxFieldValues.ContainsKey(name);
        }

        protected void chkbxlstFilterOptions_OnDataBound(object sender, EventArgs e)
        {
            //var item = 
        }

        protected void rptFilterOptions_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (FilterGroup)e.Item.DataItem;
            var chkbxFilterOption = e.Item.FindControl("chkbxFilterOption") as CheckBox;
            if (chkbxFilterOption != null)
            {
                chkbxFilterOption.InputAttributes.Add("FieldName", item.FieldName);
                chkbxFilterOption.InputAttributes.Add("Value", item.FieldType == "boolean" ? "True" : item.DisplayName);
                chkbxFilterOption.Checked = CheckBoxWasSelected(item.FieldName);
                chkbxFilterOption.CheckedChanged += ChkbxFilterOptionOnCheckedChanged;
            }
            var ltlFilterCount = e.Item.FindControl("ltlFilterCount") as Literal;
            if (ltlFilterCount != null)
            {
                ltlFilterCount.Text = String.Format("[{0}]",
                    GetCountForFilterField(item.FieldName, item.FieldType == "boolean" ? "True" : item.DisplayName));
               
            }
        }

        protected void ChkbxFilterOptionOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            var control = sender as CheckBox;
            if (control != null)
            {
                var field = control.InputAttributes["FieldName"];
                var val = control.InputAttributes["Value"];
                Dictionary<string, string> selectedCheckboxFieldValues = null;
                if (Session["SelectedCheckBoxFieldValues"] != null)
                {
                    selectedCheckboxFieldValues = Session["SelectedCheckBoxFieldValues"] as Dictionary<string, string>;
                }
                if (selectedCheckboxFieldValues == null)
                {
                    selectedCheckboxFieldValues = new Dictionary<string, string>();
                }

                if (control.Checked)
                {
                    if (selectedCheckboxFieldValues.ContainsKey(field))
                    {
                        //will be unwrapped in the query generation to perform an IN query
                        selectedCheckboxFieldValues[field] = selectedCheckboxFieldValues[field] + "|" + val;
                    }
                    else
                    {
                        selectedCheckboxFieldValues.Add(field, val);
                    }
                }
                if (!control.Checked && selectedCheckboxFieldValues.ContainsKey(field))
                {
                    if (selectedCheckboxFieldValues[field].Contains("|"))
                    {
                        string newVal = string.Empty;
                        foreach (var value in selectedCheckboxFieldValues[field].Split('|'))
                        {
                            if (value != val)
                            {
                                newVal += value + "|";
                            }
                        }
                        if (!string.IsNullOrEmpty(newVal))
                        {
                            selectedCheckboxFieldValues[field] = newVal.Substring(0,
                                newVal.LastIndexOf("|", System.StringComparison.Ordinal));
                        }
                        else
                        {
                            selectedCheckboxFieldValues[field] = string.Empty;
                        }
                    }
                    else
                    {
                        selectedCheckboxFieldValues.Remove(field);
                    }
                }
                Session["SelectedCheckBoxFieldValues"] = selectedCheckboxFieldValues;

                BindCategoryRadioSelector();
                BindProducts(1);
                var resultsCount = GetResultsCount();
                //SetResultsCountDisplay(resultsCount);

                BuildPager(1, resultsCount);
            }
        }

        protected void rptProductCategories_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as TreeNode;
            var radiobtnProductCategory = e.Item.FindControl("radiobtnProductCategory") as RadioButton;
            if (radiobtnProductCategory != null)
            {
                radiobtnProductCategory.InputAttributes.Add("Name", "type");
                radiobtnProductCategory.InputAttributes.Add("DocumentName", item.DocumentName);
                radiobtnProductCategory.InputAttributes.Add("NodeId", item.NodeID.ToString());
                if (Session["SelectedProductCategoryId"] != null)
                {
                    if (item.NodeID == Convert.ToInt32(Session["SelectedProductCategoryId"]))
                    {
                        radiobtnProductCategory.Checked = true;
                    }
                }
                //radiobtnProductCategory.CheckedChanged += radiobtnProductCategory_OnCheckedChanged;
            }
            
            var filterLink = e.Item.FindControl("FilterLink") as HyperLink;

            var ltlProductCategoryResultCount = e.Item.FindControl("ltlProductCategoryResultCount") as Literal;
            if (ltlProductCategoryResultCount != null && item != null)
            {
                ltlProductCategoryResultCount.Text = String.Format("[{0}]",GetCountForProductCategory(item.NodeID));
                filterLink.NavigateUrl = item.NodeAliasPath;
            }
            
        }

        protected void radiobtnProductCategory_OnCheckedChanged(object sender, EventArgs e)
        {
            //var control = sender as RadioButton;
            //if (control != null && control.Checked)
            //{
            //    var documentName = control.InputAttributes["DocumentName"];
            //    var nodeId = control.InputAttributes["NodeId"];
                
            //    Session["SelectedProductCategoryId"] = nodeId;
            //    CurrentPage.Value = "1";

            //    //BindCategoryRadioSelector();
            //    //BindProducts(1);
            //    //BindFilterGroups();
            //    //BuildPager(1, GetResultsCount());
            //}

        }

        protected void PagerClick(object sender, EventArgs e)
        {
            var pagerLink = sender as LinkButton;
            if (pagerLink == null)
            {
                return;
            }

            var targetPageNumberArgument = pagerLink.CommandArgument;
            if (string.IsNullOrEmpty(targetPageNumberArgument))
            {
                return;
            }

            int targetPageNumber = 0;
            if (!Int32.TryParse(targetPageNumberArgument, out targetPageNumber))
            {
                return;
            }

            CurrentPage.Value = targetPageNumber.ToString(CultureInfo.InvariantCulture);
            BindFilterGroups();
            BindProducts(targetPageNumber);
            
            var resultsCount = GetResultsCount();
            BuildPager(targetPageNumber, resultsCount);
        }

        private int GetResultsCount()
        {
            string filterQuery = GenerateProductFilterQuery();
            if (!string.IsNullOrEmpty(filterQuery))
            {
                filterQuery = "AND " + filterQuery;
            }
            else
            {
                filterQuery = " ";
            }
            int productCategoryId = 0;
            if (Session["SelectedProductCategoryId"] != null)
            {
                int.TryParse(Session["SelectedProductCategoryId"].ToString(), out productCategoryId);
            }
            else
            {
                productCategoryId = CurrentDocument.NodeID;
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("select Count(*) FROM CMS_RElationship rel ");
            sb.AppendFormat("inner join VIEW_CMS_TREE_JOINED t on rel.LeftNodeID = t.NodeId and t.DocumentCulture = '{0}' ", CurrentDocument.DocumentCulture);
            sb.Append("inner join PbcLinear_Product p on t.DocumentForeignKeyValue = p.ProductID ");
            sb.Append("left outer join CMS_WorkFlowStep w on t.DocumentWorkflowStepID = w.StepID ");
            sb.AppendFormat("where (w.StepType = 100 or w.StepType is null) and (RightNodeID in {0} {1})  and DocumentCulture='{2}' ", GenerateProductCategoryQuery(productCategoryId), filterQuery, CurrentDocument.DocumentCulture);
            
            DataSet ds = ConnectionHelper.ExecuteQuery(sb.ToString(), null, QueryTypeEnum.SQLQuery);
            int count; 
            int.TryParse(ds.Tables[0].Rows[0][0].ToString(), out count);
            return count;
        }

        private int GetCountForFilterField(string columnName, string value)
        {
            int productCategoryId = 0;
            if (Session["SelectedProductCategoryId"] != null)
            {
                int.TryParse(Session["SelectedProductCategoryId"].ToString(), out productCategoryId);
            }
            else
            {
                productCategoryId = CurrentDocument.NodeID;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("select COUNT(*) ");
            sb.Append("FROM CMS_RElationship rel ");
            sb.AppendFormat("inner join VIEW_CMS_TREE_JOINED t on rel.LeftNodeID = t.NodeId and t.DocumentCulture = '{0}' ", CurrentDocument.DocumentCulture);
            sb.Append("inner join PbcLinear_Product p on t.DocumentForeignKeyValue = p.ProductID ");
            sb.Append("left outer join CMS_WorkFlowStep w on t.DocumentWorkflowStepID = w.StepID ");
            sb.AppendFormat("where (w.StepType = 100 or w.StepType is null) and (RightNodeID in {0} AND {1} = '{2}')  and DocumentCulture='{3}' ", GenerateProductCategoryQuery(productCategoryId), columnName, value, CurrentDocument.DocumentCulture);
            DataSet ds = ConnectionHelper.ExecuteQuery(sb.ToString(), null, QueryTypeEnum.SQLQuery);
            int count;
            int.TryParse(ds.Tables[0].Rows[0][0].ToString(), out count);
            return count;
        }

        private int GetCountForProductCategory(int productCategoryNodeId)
        {
            
            string filterQuery = GenerateProductFilterQuery();
            if (!string.IsNullOrEmpty(filterQuery))
            {
                filterQuery = "AND " + filterQuery;
            }
            else
            {
                filterQuery = " ";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("select COUNT(*) ");
            sb.Append("FROM CMS_RElationship rel ");
            sb.AppendFormat("inner join VIEW_CMS_TREE_JOINED t on rel.LeftNodeID = t.NodeId and t.DocumentCulture = '{0}' ", CurrentDocument.DocumentCulture);
            sb.Append("inner join PbcLinear_Product p on t.DocumentForeignKeyValue = p.ProductID ");
            sb.Append("left outer join CMS_WorkFlowStep w on t.DocumentWorkflowStepID = w.StepID ");
            sb.AppendFormat("where (w.StepType = 100 or w.StepType is null) and  (RightNodeID in {0} ) and DocumentCulture='{1}' ", GenerateProductCategoryQuery(productCategoryNodeId), CurrentDocument.DocumentCulture);
            DataSet ds = ConnectionHelper.ExecuteQuery(sb.ToString(), null, QueryTypeEnum.SQLQuery);
            int count;
            int.TryParse(ds.Tables[0].Rows[0][0].ToString(), out count);
            return count;
        }

        protected void PagerPageNumbersItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item &&
                e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }

            var pagerPageNumber = e.Item.DataItem as PagerPageNumber;
            if (pagerPageNumber == null)
            {
                return;
            }

            var pagerPageNumberLink = e.Item.FindControl("PagerPageNumberLink") as LinkButton;
            if (pagerPageNumberLink == null)
            {
                return;
            }

            var pagerPageNumberCurrent = e.Item.FindControl("PagerPageNumberCurrent") as HtmlGenericControl;
            if (pagerPageNumberCurrent == null)
            {
                return;
            }

            if (!pagerPageNumber.IsCurrentPage)
            {
                pagerPageNumberLink.Visible = true;
                pagerPageNumberLink.Text = pagerPageNumber.PageNumber;
                pagerPageNumberLink.CommandName = "ShowPage";
                pagerPageNumberLink.CommandArgument = pagerPageNumber.PageNumber;

                pagerPageNumberCurrent.Visible = false;
            }
            else
            {
                pagerPageNumberLink.Visible = false;

                pagerPageNumberCurrent.Visible = true;
                pagerPageNumberCurrent.InnerText = pagerPageNumber.PageNumber;
            }
        }

        private void BuildPager(int pageNumber, int totalResultsCount)
        {
            int numberOfPages = (int) Math.Ceiling((double) totalResultsCount/(double) PageSize);
            int previousPage = pageNumber == 1 ? 1 : pageNumber - 1;
            int nextPage = pageNumber == numberOfPages ? pageNumber : pageNumber + 1;
            int currentGroup = (int) Math.Ceiling((double) (pageNumber)/(double) PagerGroupSize);
            int currentGroupStartingNumber = ((currentGroup - 1)*PagerGroupSize) + 1;
            int numberOfPageGroups = (int) Math.Ceiling((double) numberOfPages/(double) PagerGroupSize);

            if (pageNumber == 1)
            {
                PagerFirstPage.Visible = false;
                PagerPreviousPage.Visible = false;
            }
            else
            {
                PagerFirstPage.Visible = true;
                PagerFirstPage.CommandArgument = "1";

                PagerPreviousPage.Visible = true;
                PagerPreviousPage.CommandArgument = previousPage.ToString(CultureInfo.InvariantCulture);
            }

            if (currentGroup == 1)
            {
                PagerPreviousGroup.Visible = false;
            }
            else
            {
                PagerPreviousGroup.Visible = true;
                PagerPreviousGroup.CommandArgument =
                    (currentGroupStartingNumber - 1).ToString(CultureInfo.InvariantCulture);
            }

            int numberOfItemsInCurrentGroup = 5;
            if (currentGroup == numberOfPageGroups)
            {
                // Last page group...
                numberOfItemsInCurrentGroup = numberOfPages - (currentGroupStartingNumber - 1);
            }
            if (numberOfPages <= numberOfItemsInCurrentGroup)
            {
                numberOfItemsInCurrentGroup = numberOfPages;
            }

            var pagerPageNumbers = new List<PagerPageNumber>();
            var number = currentGroupStartingNumber;
            for (int i = 1; i <= numberOfItemsInCurrentGroup; i++)
            {
                var pagerPageNumber = new PagerPageNumber();
                pagerPageNumber.PageNumber = number.ToString(CultureInfo.InvariantCulture);

                if (number == pageNumber)
                {
                    pagerPageNumber.IsCurrentPage = true;
                }
                else
                {
                    pagerPageNumber.IsCurrentPage = false;
                }

                pagerPageNumbers.Add(pagerPageNumber);

                number++;
            }
            PagerPageNumbers.DataSource = pagerPageNumbers;
            PagerPageNumbers.DataBind();

            if (currentGroup < numberOfPageGroups)
            {
                PagerNextGroup.Visible = true;
                PagerNextGroup.CommandArgument = (currentGroupStartingNumber + PagerGroupSize).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                PagerNextGroup.Visible = false;
            }

            if (nextPage < numberOfPages)
            {
                PagerNextPage.Visible = true;
                PagerNextPage.CommandArgument = nextPage.ToString(CultureInfo.InvariantCulture);

                PagerLastPage.Visible = true;
                PagerLastPage.CommandArgument = numberOfPages.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                PagerNextPage.Visible = false;
                PagerLastPage.Visible = false;
            }
        }
        protected void PagerPageNumbersItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != "ShowPage")
            {
                return;
            }

            if (string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                return;
            }

            int targetPageNumber = 0;
            if (!Int32.TryParse(e.CommandArgument.ToString(), out targetPageNumber))
            {
                return;
            }

            CurrentPage.Value = targetPageNumber.ToString(CultureInfo.InvariantCulture);
            BindFilterGroups();
            BindProducts(targetPageNumber);
            
            var resultsCount = GetResultsCount();
            
            BuildPager(targetPageNumber, resultsCount);
        }

        protected void ResetButtonClick(object sender, EventArgs e)
        {
            Session["SelectedProductCategoryId"] = CurrentDocument.NodeID;
            Session["SelectedCheckBoxFieldValues"] = new Dictionary<string, string>();
            Session["SortDirectionName"] = SortDirection.Descending;
            Session["SortDirectionPopularity"] = SortDirection.Descending;
            BindCategoryRadioSelector();
            BindProducts(1);
            BindFilterGroups();
            BuildPager(1, GetResultsCount());
        }

        protected void rptProducts_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                var lnkProductDetail = e.Item.FindControl("lnkProductDetail") as HyperLink;
                if (lnkProductDetail != null)
                {
                    lnkProductDetail.NavigateUrl = ProductHelper.GetUrl(item);
                }
                
                var innerDValue = e.Item.FindControl("InnerDValue") as Literal;
                var innerDItem = e.Item.FindControl("InnerDItem") as HtmlGenericControl;
                var innerD = item.Row["ID"].ToString();
                if (innerD.Length > 0)
                {
                    innerDValue.Text = "ID: " + innerD;
                }
                if (innerDValue.Text.Length == 0)
                {
                    innerDItem.Visible = false;
                    
                }

                var outerDValue = e.Item.FindControl("OuterDValue") as Literal;
                var outerDItem = e.Item.FindControl("OuterDItem") as HtmlGenericControl;
                var outerD = item.Row["OD"].ToString();
                if (outerD.Length > 0)
                {
                    outerDValue.Text = "OD: " + outerD;
                }
                if (outerDValue.Text.Length == 0)
                {
                    outerDItem.Visible = false;

                }

                var sizeValue = e.Item.FindControl("SizeValue") as Literal;
                var sizeItem = e.Item.FindControl("SizeItem") as HtmlGenericControl;
                var size = item.Row["Size"].ToString();
                if (size.Length > 0)
                {
                    sizeValue.Text = "Size: " + size;
                }
                if (sizeValue.Text.Length == 0)
                {
                    sizeItem.Visible = false;

                }

                var materialValue = e.Item.FindControl("MaterialValue") as Literal;
                var materialItem = e.Item.FindControl("MaterialItem") as HtmlGenericControl;
                var material = item.Row["Material"].ToString();
                if (material.Length > 0)
                {
                    materialValue.Text = "Material: " + material;
                }
                if (materialValue.Text.Length == 0)
                {
                    materialItem.Visible = false;

                }

                var priceValue = e.Item.FindControl("PriceValue") as Literal;
                var priceItem = e.Item.FindControl("PriceItem") as HtmlGenericControl;
                var price = item.Row["SKUPrice"].ToString();
                if (price.Length > 0 || price != "0")
                {
                    priceValue.Text = "Price: $" + price;
                }
                if (priceValue.Text.Length == 0 || price == "0")
                {
                    priceItem.Visible = false;

                }
            }

        }

        protected void ddlSortByName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var control = (DropDownList)sender;
            if (control.SelectedValue == "asc")
            {
                Session["SortDirectionName"] = SortDirection.Ascending;
                Session["SortDirectionPopularity"] = SortDirection.None;
            }
            if (control.SelectedValue == "desc")
            {
                Session["SortDirectionName"] = SortDirection.Descending;
                Session["SortDirectionPopularity"] = SortDirection.None;
            }
            if (control.SelectedValue == "popularity desc")
            {
                Session["SortDirectionName"] = SortDirection.Descending;
                Session["SortDirectionPopularity"] = SortDirection.Descending;
            }
            CurrentPage.Value = "1";
            BindProducts(1);
            BindFilterGroups();
            BuildPager(1, GetResultsCount());

        }
    }
}