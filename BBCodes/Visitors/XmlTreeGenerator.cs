﻿/*
 * User: elijah
 * Date: 3/15/2012
 * Time: 10:22 AM
 */
using System;
using System.Collections.Generic;
using System.Text;
using BBCodes.Nodes;

namespace BBCodes.Visitors
{
    /// <summary>
    /// Creates an XML tree from a list of nodes
    /// </summary>
    public class XmlTreeGenerator : IGenerator
    {
        StringBuilder output = new StringBuilder();
        int indent = 0;
        
        public XmlTreeGenerator()
        {
        }
        
        void Visit(Node n)
        {
            if (n is TextNode)
            {
                output.AppendLine(Rep() + "<TextNode>" + n.ToHTML() + "</TextNode>");
            }
            else if (n.InnerNodes.Count == 0)
            {
                output.Append(Rep());
                output.Append("<" + n.GetType().Name + " />");
                //output.Append(n.
            }
            else
            {
                output.Append(Rep());
                output.AppendLine("<" + n.GetType().Name + ">");
                indent++;
                foreach (Node n2 in n)
                    Visit(n2);
                indent--;
                output.AppendLine(Rep() + "</" + n.GetType().Name + ">");
            }
        }
        
        public string Generate(List<Node> nodes)
        {
            foreach (Node n in nodes)
            {
                Visit(n);
            }
            return output.ToString();
        }
        
        string Rep()
        {
            if (indent == 0)
                return "";
            string s = "";
            for (int i = 0; i < indent; i++)
                s += "    ";
            return s;
        }
    }
}
