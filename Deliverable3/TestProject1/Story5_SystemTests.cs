using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject1;

namespace TestProject1
{

    /// <summary>
    ///  As a research assistant, I want to see the top N keywords for each year in the database so that I can see how topics change over time.
    /// </summary>
    [TestClass]
    public class Story5_SystemTests
    {
        [TestMethod]
        public void TopNKeywords_NormalPath()
        {
            //Setup papers and keywords in database
            int year = 1999;
            Keyword someKeyword = new Keyword("top");
            Keyword someOtherKeyword = new Keyword("other");
            Paper somePaper = new Paper("Name of paper", year);
            somePaper.addKeyWord(someKeyword);
            Paper someOtherPaper = new Paper("Name of other paper", year);
            someOtherPaper.addKeyWord(someKeyword);
            someOtherPaper.addKeyWord(someOtherKeyword);
            SystematicMappingSystem sms = new SystematicMappingSystem();
            //Add papers to mapping system
            sms.AddPaper(somePaper);
            sms.AddPaper(someOtherPaper);

            //now we will get the top 2 keywords from the SystematicMappingSystem stored as a list
            int N = 2;

            List<Keyword> keywords = sms.GetTopNKeywordsForYear(N, year);

            //Check that there are two keywords in the list
            Assert.Equals(keywords.Count, N);
            //Check that it returned the top keywords in order
            Assert.IsTrue(keywords.ElementAt(0).Equals(someKeyword));
            Assert.IsTrue(keywords.ElementAt(1).Equals(someOtherKeyword));

        }

        [TestMethod]
        public void TopNKeywords_NBiggerThanNumberOfKeywords()
        {
            //Setup papers and keywords in database
            int year = 1999;
            Keyword someKeyword = new Keyword("top");
            Keyword someOtherKeyword = new Keyword("other");
            Paper somePaper = new Paper("Name of paper", year);
            somePaper.addKeyWord(someKeyword);
            Paper someOtherPaper = new Paper("Name of other paper", year);
            someOtherPaper.addKeyWord(someKeyword);
            someOtherPaper.addKeyWord(someOtherKeyword);
            SystematicMappingSystem sms = new SystematicMappingSystem();
            //Add papers to mapping system
            sms.AddPaper(somePaper);
            sms.AddPaper(someOtherPaper);

            //now we will get the top 3 keywords from the SystematicMappingSystem stored as a list
            int N = 3;
            //this should return a list of size 2 since there are only 2 keywords for this year
            List<Keyword> keywords = sms.GetTopNKeywordsForYear(N, year);

            //Check that there are two keywords in the list
            Assert.Equals(keywords.Count, 2);
            //Check that it returned the top keywords in order
            Assert.IsTrue(keywords.ElementAt(0).Equals(someKeyword));
            Assert.IsTrue(keywords.ElementAt(1).Equals(someOtherKeyword));

        }

        [TestMethod,ExpectedExceptionAttribute(typeof(ArgumentException),"Invalid Year For Database")]
        public void TopNKeywords_InvalidYear()
        {
            //Setup papers and keywords in database
            int year = 1999;
            Keyword someKeyword = new Keyword("top");
            Keyword someOtherKeyword = new Keyword("other");
            Paper somePaper = new Paper("Name of paper", year);
            somePaper.addKeyWord(someKeyword);
            Paper someOtherPaper = new Paper("Name of other paper", year);
            someOtherPaper.addKeyWord(someKeyword);
            someOtherPaper.addKeyWord(someOtherKeyword);
            SystematicMappingSystem sms = new SystematicMappingSystem();
            //Add papers to mapping system
            sms.AddPaper(somePaper);
            sms.AddPaper(someOtherPaper);

            //now we will get the top 2 keywords from the SystematicMappingSystem stored as a list for year 0, which is invalid
            int N = 2;

            List<Keyword> keywords = sms.GetTopNKeywordsForYear(N, 0);

            Assert.Fail();

        }

        [TestMethod, ExpectedExceptionAttribute(typeof(ArgumentException), "Invalid Year For Database")]
        public void TopNKeywords_InvalidFutureYear()
        {
            //Setup papers and keywords in database
            int year = 1999;
            Keyword someKeyword = new Keyword("top");
            Keyword someOtherKeyword = new Keyword("other");
            Paper somePaper = new Paper("Name of paper", year);
            somePaper.addKeyWord(someKeyword);
            Paper someOtherPaper = new Paper("Name of other paper", year);
            someOtherPaper.addKeyWord(someKeyword);
            someOtherPaper.addKeyWord(someOtherKeyword);
            SystematicMappingSystem sms = new SystematicMappingSystem();
            //Add papers to mapping system
            sms.AddPaper(somePaper);
            sms.AddPaper(someOtherPaper);

            //now we will query for keywords to papers for a year in the future
            int N = 2;

            List<Keyword> keywords = sms.GetTopNKeywordsForYear(N, 2020);

            Assert.Fail();

        }

        [TestMethod]
        public void TopNKeywords_NoKeywordsForYear()
        {
            //Setup papers and keywords in database
            //We still add these just in case it returns these instead of nothing
            int year = 1999;
            Keyword someKeyword = new Keyword("top");
            Keyword someOtherKeyword = new Keyword("other");
            Paper somePaper = new Paper("Name of paper", year);
            somePaper.addKeyWord(someKeyword);
            Paper someOtherPaper = new Paper("Name of other paper", year);
            someOtherPaper.addKeyWord(someKeyword);
            someOtherPaper.addKeyWord(someOtherKeyword);
            SystematicMappingSystem sms = new SystematicMappingSystem();
            //Add papers to mapping system
            sms.AddPaper(somePaper);
            sms.AddPaper(someOtherPaper);

            //now we will get the top 2 keywords from the SystematicMappingSystem stored as a list for year 1998, which has no papers
            int N = 2;

            List<Keyword> keywords = sms.GetTopNKeywordsForYear(N, 1998);
            //There should be no keywords for this year;
            Assert.Equals(keywords.Count,0);
        }

        [TestMethod]
        public void TopNKeywords_Top0Keywords()
        {
            //Setup empty database
            
            SystematicMappingSystem sms = new SystematicMappingSystem();

            //now we will get the top 0 keywords and make sure it returns a null list
            int N = 0;

            List<Keyword> keywords = sms.GetTopNKeywordsForYear(N, 1998);
            //There should be no keywords for this year;
            Assert.IsNull(keywords);
        }
    }
}
