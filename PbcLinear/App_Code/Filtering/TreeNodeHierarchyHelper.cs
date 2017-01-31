using System;
using System.Collections.Generic;
using System.Linq;
using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.Membership;

namespace PbcLinear.App_Code.Filtering
{
    public class TreeNodeHierarchyHelper
    {
        public List<Node> Nodes{ get; set; }
        
        public TreeNodeHierarchyHelper() { }
        public TreeNodeHierarchyHelper(TreeNode currentDocument, string rootPath, string className)
        {
            Nodes = CacheHelper.Cache(x => LoadTreeInformation(currentDocument, rootPath, className),
                new CacheSettings(30, String.Format("pbclinear|ProductCategories|{0}", currentDocument.DocumentCulture)));
        }

        private static List<Node> LoadTreeInformation(TreeNode currentDocument, string rootPath, string className)
        {
            TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);
            var rootProductDocument = tree.SelectSingleNode(currentDocument.Site.SiteName, rootPath,
                currentDocument.DocumentCulture);
            if (rootProductDocument != null)
            {
                List<Node> nodes = new List<Node>();
                nodes = GetDescedentInfo(rootProductDocument, className);
                return nodes;
            }
            return null;
        }
        private static List<Node> GetDescedentInfo(TreeNode currentNode, string className)
        {
            List<Node> nodes = new List<Node>();
            foreach (var child in currentNode.Children.Where(x => x.ClassName.Equals(className)))
            {
                Node node = new Node(child.NodeID, child.DocumentName, GetDescedentInfo(child, className));
                nodes.Add(node);
            }
            return nodes;
        }

        public Node FindNodeById(int id, List<Node> children)
        {
            foreach (var node in children)
            {
                if (node.NodeId == id)
                {
                    return node;
                }
                if (node.Children != null)
                {
                    var foundId = FindNodeById(id, node.Children);
                    if (foundId != null)
                    {
                        return foundId;
                    }
                }
            }
            return null;
        }

        public List<int> ListNodesUnderId(Node node)
        {
            var nodeIds = new List<int>();
            if (node != null)
            {
                foreach (var child in node.Children)
                {
                    if (!nodeIds.Contains(child.NodeId))
                    {
                        nodeIds.Add(child.NodeId);
                    }
                    if (child.Children.Any())
                    {
                        var childIds = ListNodesUnderId(child);
                        nodeIds.AddRange(childIds);
                    }
                }
            }
            return nodeIds;
        }

    }
    public class Node
    {
        public int NodeId { get; set; }
        public string NodeName { get; set; }
        public List<Node> Children { get; set; }

        public Node()
        {
            Children=new List<Node>();
        }

        public Node(int nodeId, string nodeName)
        {
            NodeId = nodeId;
            NodeName = nodeName;
            Children = new List<Node>();
        }
        public Node(int nodeId, string nodeName, List<Node> children)
        {
            NodeId = nodeId;
            NodeName = nodeName;
            Children = children;
        }
    }
}