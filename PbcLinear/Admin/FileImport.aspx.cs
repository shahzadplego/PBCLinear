using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.Membership;
using CMS.SiteProvider;
using CMS.UIControls;
using FileInfo = CMS.IO.FileInfo;


namespace PbcLinear.Web.PbcLinear.Admin
{
    public class Node
    {
        public string Path { get; set; }
        public string NodeAliasPath { get; set; }
        public Node Parent { get; set; }
        public List<Node> Children { get; set; }
        public bool IsFolder { get; set; }
        public Node()
        {
        }

        public Node(string path, Node parent)
        {
            Parent = parent;
            Path = path;
            NodeAliasPath = "/media-library" + path.Replace("C:\\content.pbclinear.com", "").Replace('\\', '/');
        }
    }

    public partial class FileImport : CMSPage
    {
        List<Node> directoryInfo = new List<Node>();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAssets("C:\\content.pbclinear.com\\DataSheet", new Node { NodeAliasPath = "/Media-Library/Data-Sheets" });
            var t = directoryInfo.Where(x => !x.IsFolder);

            ProcessList(t);


            DeleteDuplicates();
        }

        private void DeleteDuplicates()
        {
            var duplicates =
                DocumentHelper.GetDocuments("cms.file")
                    .Path("/Media-Library", PathTypeEnum.Children)
                    .Where(x => x.NodeAliasPath.Contains("-(") && x.NodeAliasPath.Contains(")"));
            TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);

            
            foreach (var duplicate in duplicates)
            {
                TreeNode page = tree.SelectSingleNode(SiteContext.CurrentSiteName, duplicate.NodeAliasPath, "en-us");
                if(page!= null)
                page.Destroy();
            }

        }

        private void ProcessList(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                if (node.IsFolder)
                {
                    CreateFolder(node);
                    if (node.Children.Any())
                    {
                        ProcessList(node.Children);
                    }
                }
                else
                {
                    CreateFile(node);
                }
            }
        }

        private void GetAssets(string rootPath, Node parent)
        {
            try
            {
                var assets = Directory.GetFileSystemEntries(rootPath, "*", SearchOption.TopDirectoryOnly);
                foreach (var asset in assets)
                {
                    var currentAsset = new Node(asset, parent);
                    
                    if (asset.Split('\\').Last().Contains("."))
                    {
                        //GetAssets(asset, currentAsset);
                        //currentAsset.IsFolder = true;
                        //currentAsset.Children = GetChildren(currentAsset);
                        directoryInfo.Add(currentAsset);
                    }
                }
            }
            catch (Exception e)
            {
                var t = e;
            }
        }

        private List<Node> GetChildren(Node currentNode)
        {
            try
            {
                List<Node> kids = new List<Node>();
                var assets = Directory.GetFileSystemEntries(currentNode.Path, "*", SearchOption.TopDirectoryOnly);
                foreach (var asset in assets)
                {
                    var currentAsset = new Node(asset, currentNode);

                    if (!asset.Split('\\').Last().Contains("."))
                    {
                        currentAsset.Children = GetChildren(currentAsset);
                        currentAsset.IsFolder = true;
                    }
                    kids.Add(currentAsset);
                }
                return kids;
            }
            catch (Exception e)
            {
                var t = e;
            }
            return new List<Node>();
        }


        private void CreateFolder(Node node)
        {
            TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);

            // Gets the current site's root "/" page, which will serve as the parent page
            TreeNode parentPage = tree.SelectSingleNode(SiteContext.CurrentSiteName, node.Parent.NodeAliasPath, "en-us");
            TreeNode thisPage = tree.SelectSingleNode(SiteContext.CurrentSiteName,  node.NodeAliasPath, "en-us");
            if (parentPage != null && thisPage == null)
            {
                // Creates a new page of the "CMS.MenuItem" page type
                TreeNode newPage = TreeNode.New(SystemDocumentTypes.Folder, tree);

                // Sets the properties of the new page
                newPage.DocumentName = node.Path.Split('\\').Last().Replace("_Code_PDF", "");
                newPage.DocumentCulture = "en-us";

                // Inserts the new page as a child of the parent page
                newPage.Insert(parentPage);

            }
        }

        private void CreateFile(Node node)
        {

            TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);

            //Different folders GUID's
            //Product Images = AC97E28C-98AF-4060-82B7-E3333A5CA7F3
            //Schematics = C9615399-B088-44BE-8C26-C69F70867AEF
            //Selection Guides = 92B1EE7D-3E05-4D2F-9A95-2D1CED7C965E
            //Data Sheets = 7468DB7F-B830-4CC3-8A45-D89E35C52CA7
            //Catalogs = 07127465-2D28-4C26-A73A-E854036D640B


            //TreeNode parentPage = node.Parent.NodeAliasPath;
            TreeNode parentPage = tree.SelectNodes()
                .WhereLike("DocumentGUID", "7468DB7F-B830-4CC3-8A45-D89E35C52CA7")
                .OnCurrentSite()
                .Culture("en-us")
                .FirstObject;

            TreeNode newPage = TreeNode.New(SystemDocumentTypes.File, tree);
            string nodePath = node.Path.Split('\\').Last();
            int index = nodePath.IndexOf(".");
            if (index > 0)
            {
                nodePath = nodePath.Substring(0, index);
            }
            newPage.DocumentName = nodePath;

            //newNode.SetValue("FileDate", DateTime);
            DocumentHelper.InsertDocument(newPage, parentPage);

            AttachmentInfo newAttachment = null;
           
            // Path to the file to be inserted. This example uses an explicitly defined file path. However, you can use an object of the HttpPostedFile type (uploaded via an upload control).
            //string filePath = MediaLibraryPath + @"\" + mediaFile.FileName + mediaFile.FileExtension;

            // Insert the attachment and update the document with its GUID
            newAttachment = DocumentHelper.AddUnsortedAttachment(newPage, Guid.NewGuid(), node.Path, tree, ImageHelper.AUTOSIZE, ImageHelper.AUTOSIZE, ImageHelper.AUTOSIZE);

            // attach the new attachment to the page/document
            newPage.SetValue("FileAttachment", newAttachment.AttachmentGUID);
            DocumentHelper.UpdateDocument(newPage);
            newPage.Update();

            

            // Gets the current site's root "/" page, which will serve as the parent page
            
            //TreeNode thisPage = tree.SelectSingleNode(SiteContext.CurrentSiteName, node.NodeAliasPath.Replace('.', '-'), "en-us");
            //CMS.IO.FileInfo file = CMS.IO.FileInfo.New(node.Path);
            //if (parentPage != null && file != null && thisPage == null)
            //{

            //    // Creates a new page of the "CMS.MenuItem" page type
            //    //TreeNode newPage = TreeNode.New(SystemDocumentTypes.File, tree);

            //    // Sets the properties of the new page
            //    newPage.DocumentName = node.Path.Split('\\').Last().Replace(".", "-");
            //    newPage.DocumentCulture = "en-us";
            //    //newPage.Insert(parentPage);
            //    AttachmentInfo attachment = null;
            //    attachment = DocumentHelper.AddAttachment(newPage, "FileAttachment", node.Path, tree);
            //    // Inserts the new page as a child of the parent page
            //    newPage.Update();

            //}
        }

        private void InsertAttachment(Node node)
        {
            // Creates a new instance of the Tree provider
            TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);

            // Gets a page
            TreeNode page = tree.SelectNodes()
                .WhereLike("NodeAliasPath", node.NodeAliasPath)
                .FirstObject;

            if (page != null)
            {
                AttachmentInfo attachment = null;

                // Prepares the path of the file
                string file = System.Web.HttpContext.Current.Server.MapPath(node.Path);

                // Inserts the attachment into the "MenuItemTeaserImage" field and updates the page
                attachment = DocumentHelper.AddAttachment(page, "FileAttachment", file, tree);
                page.Update();
            }
        }
    }
}