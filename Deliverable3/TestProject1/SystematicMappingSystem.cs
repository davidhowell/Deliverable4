using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject1
{
    /// <summary>
    /// SystematicMapping System Class
    /// Implemented for Story3
    /// </summary>
    class SystematicMappingSystem
    {
        List<Paper> papers = new List<Paper>();

        public SystematicMappingSystem()
        {
            
        }

        //Add a paper to end of list
        public void AddPaper(Paper somePaper)
        {
            papers.Add(somePaper);
        }

        //Search through with Keyword
        public int SearchByKeyword(Keyword expectedKeyword)
        {
            int count = 0;
            //String to compare to
            String expected = expectedKeyword.getKeyword();

            foreach (Paper p in papers)
            {
                Keyword[] temparray = p.getKeywords();
                for (int i = 0; i < temparray.Length; i++)
                {
                    if (temparray[i].getKeyword().Equals(expected))
                    {
                        count++;
                    }

                }
            }
            return count;
        }       
    }
}