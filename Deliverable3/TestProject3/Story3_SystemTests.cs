using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    /// <summary>
    /// SENG 301 - Deliverable 3
    /// By Kurtis Niedling
    /// 10038012
    /// 
    /// Story 3:
    /// As a principal investigator, I want to search for all papers with a given keyword so that I can find out how common keywords are.
    /// </summary>
    [TestClass]
    public class Story3_SystemTests
    {
        [TestMethod]    //NormalPath, Receives an expected keyword and searches papers with that keyword
        public void KeywordSearchTest_NormalPath()
        {
            //Create Keyword and Paper
            Keyword expectedKeyword = new Keyword("Testing");
            Paper expectedPaper = new Paper("Some Paper About Testing");
            //Add keyword to paper
            expectedPaper.AddKeyword(expectedKeyword);

            //A mapping system to store the papers in 
            SystematicMappingSystem sms = new SystematicMappingSystem();
            //Add paper to the system
            sms.AddPaper(expectedPaper);

            //Search by keyword for papers with keyword - Represent in a List
            List<Paper> papersWithKeyword = sms.SearchByKeyword(expectedKeyword);


            //Assert only one paper is found
            Assert.IsTrue(expectedPaper.Equals(papersWithKeyword.First()) && papersWithKeyword.Count() == 1);

        }


        [TestMethod]        //KeywordSearchTest_KeywordDoesNotExits, Receives a Keyword that does not exist
        public void KeywordSearchTest_KeywordDoesNotExist()
        {
            //Keyword that does not exist
            Keyword expectedKeyword = new Keyword("Does Not Exist");

            //Other keyword 
            Keyword otherKeyword = new Keyword("Other Keyword");
            Paper otherPaper = new Paper("Paper With Other Keywords");
            //Add otherKeyword to otherPaper
            otherPaper.AddKeyword(otherKeyword);

            //Create mapping system for papers
            SystematicMappingSystem sms = new SystematicMappingSystem();
            //Add otherPaper to system
            sms.AddPaper(otherPaper);

            //Search through papers with keyword - Represent in a list
            List<Paper> papersWithKeyword = sms.SearchByKeyword(expectedKeyword);

            //Assert that no papers are founde
            Assert.IsTrue(papersWithKeyword.Count() == 0);

        }

        [TestMethod]        //KeywordSearchTest_EmptyString, Receives and empty string as the Keyword
        public void KeywordSearchTest_EmptyString()
        {
            //The keyword is an empty string
            Keyword expectedKeyword = new Keyword("");

            //Create other keyword and add to paper
            Keyword otherKeyword = new Keyword("Other Keyword");
            Paper otherPaper = new Paper("Paper with Keywords");
            otherPaper.AddKeyword(otherKeyword);

            //Create mapping system for papers
            SystematicMappingSystem sms = new SystematicMappingSystem();
            //Add otherPaper to system
            sms.AddPaper(otherPaper);

            //Search through papers with the keyword
            List<Paper> papersWithKeyword = sms.SearchByKeyword(expectedKeyword);
            
            //Assert that no papers are found
            Assert.IsTrue(papersWithKeyword.Count() == 0);           
        }
    }
}