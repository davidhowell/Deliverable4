﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject2
{
    class Paper
    {
        //Paper class consists of a string
        public string paperTitle;

        //List to view all keywords with that paper
        private List<Keyword> k;

        //Points to next paper in the Systematic Mapping System
        public Paper next;

        //Create a paper object, consists of a string.
        public Paper(string paperTitle)
        {
            this.paperTitle = paperTitle;
            k = new List<Keyword>();
        }

        //Add a keyword to the paper
       public void AddKeyword(Keyword newkeyword)
        {
            k.Add(newkeyword);
        }

        public Keyword[] getKeywords()
        {
            Keyword[] array = k.ToArray();
            return array;
        }

        public bool findKeyword()
        {
            return true;
        }
    }
}
