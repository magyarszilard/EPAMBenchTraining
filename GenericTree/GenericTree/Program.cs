﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTree
{
    class Program
    {
        static void Main(string[] args)
        {
            #region buildTree
            Tree<string> bootstrap = new Tree<string>("bootstrap");
            bootstrap.Add("less");
            bootstrap.Add("js");
            bootstrap.Add("fonts");
            Tree<string> dist = new Tree<string>("dist");

            Tree<string> css = new Tree<string>("css");
            css.Add("bootstrap.css");
            css.Add("bootstrap.min.css");
            css.Add("bootstrap-theme.css");
            css.Add("bootstrap-theme.min.css");
            Tree<string> js = new Tree<string>("js");
            js.Add("bootstrap.js");
            js.Add("bootstrap.min.js");
            Tree<string> fonts = new Tree<string>("fonts");
            fonts.Add("glyphicons-halflings-regular.eot");
            fonts.Add("glyphicons-halflings-regular.svg");
            fonts.Add("glyphicons-halflings-regular.ttf");
            fonts.Add("glyphicons-halflings-regular.woff");

            dist.Add(css);
            dist.Add(js);
            dist.Add(fonts);

            Tree<string> docs = new Tree<string>("docs");
            docs.Add("examples");

            bootstrap.Add(dist);
            bootstrap.Add(docs);
            #endregion

            bootstrap.Draw();
            /*foreach(var item in bootstrap.GetItemsDepthFirst())
            {
                Console.WriteLine(item.Value);
            }*/
            Console.Read();
        }
    }
}