using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject2
{
    class SystematicMappingSystem
    {
        List<Paper> papers = new List<Paper>();

        internal void AddPaper(TestProject2.Paper paper)
        {
            papers.Add(paper);
        }

        internal List<Keyword> GetKeywordsFromPaper(string p)
        {
            foreach (Paper paper in papers)
            {
                if (paper.paperTitle == p)
                {
                    return new List<Keyword>(paper.getKeywords());
                }
            }

            // paper p does not exist.
            throw new ArgumentException("paper " + p + " not found");
        }
    }
}
