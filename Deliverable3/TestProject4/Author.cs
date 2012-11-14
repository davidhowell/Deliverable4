using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RajUseCase12UnitTest
{
    class Author
    {
        private string p;
        private string[] publication;


        public Author(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
        public string name { get; set; }

        internal String getName()
        {
            throw new NotImplementedException();
        }


        internal string findPublications(string p) 
        {
            throw new NotImplementedException();
        }



        internal string[] getPublication()
        {
            throw new NotImplementedException();
        }

        internal bool checkName(string p)
        {
            throw new NotImplementedException();
        }
    }
}
