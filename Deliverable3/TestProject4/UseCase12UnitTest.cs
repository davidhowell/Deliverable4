using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RajUseCase12UnitTest;

/**This class is to be used in junction with a paper.cs class which will create an array of all author's. 
 * The array will store a pointer to each author's class. This is subject to change depending on the final implementation.
 * Author: Rajvir Jhawar
 * Class: SENG 301
 * Project part: 3
 * */
namespace RajUseCase12UnitTest
{
    [TestClass]
    public class UseCase12UnitTest
    {
        ///<summary>
        ///Test: Normal valid input 
        ///Info: Insert a author name and get his correct publication
        /// </summary>
        [TestMethod]
        public void AuthorPublication_NormalPath()
        {
            string[] publication = new string[1] {"publication1"};
            Author chosenAuthor = new Author("name1");
            bool correctName = chosenAuthor.checkName(chosenAuthor.name); //for this check i assume it will pass this test
            chosenAuthor.findPublications(chosenAuthor.getName()); // make a array of all publications 
            string[] authorPublication = chosenAuthor.getPublication(); //getter method for findPublication
            int i = 1;
            string expected = publication[i];
            string actual = authorPublication[i];
            Assert.Equals(expected, actual);
        }
        ///<summary> 
        /// Test: Normal valid input 
        /// Info: Insert a author name and get all his correct mutiple publications
        /// </summary>

         [TestMethod]
         public void AuthorPublication_mutiplePublications()
        {
            string[] publication = new string[3] {"publication1","publication2","publication3"};
            Author chosenAuthor = new Author("name2");
            bool correctName = chosenAuthor.checkName(chosenAuthor.name); //for this check i assume it will pass this test
            chosenAuthor.findPublications(chosenAuthor.getName()); // make a array of all publications
            string[] authorPublication = chosenAuthor.getPublication(); //getter method for findPublications
            for (int i = 0; i < 3; i++)
            {
                string expected = publication[i];
                string actual = authorPublication[i];
                Assert.Equals(expected, actual);
            }

        }
           
       ///<summary>
       ///Test: Normal valid input 
       ///Info: Insert a author name but author has no publications
       /// </summary>

        [TestMethod, ExpectedExceptionAttribute(typeof(ArgumentException), "Author has no publications")]
        public void AuthorPublication_noPublications()
        {
            //string[] publication = new string[1]; 
            Author chosenAuthor = new Author("name1");
            bool correctName = chosenAuthor.checkName(chosenAuthor.name); //for this check i assume it will pass this test
            chosenAuthor.findPublications(chosenAuthor.getName());// will throw the exception(not implemented)
            Assert.Fail();
         }

        ///<summary>
        ///Test: Normal valid input 
        ///Info: Insert a author name but author has no publications
        ///checks if publication array is still null to verify that author has no publications 
        ///(alternative route if I do not want to throw exception i can check for null array)
        /// </summary>
            
         [TestMethod]
         public void AuthorPublication_nullPublications() 
         {
             string[] publication = null; //assuming that by default publication array is set to null if no items are added
             Author chosenAuthor = new Author("name1");
             bool correctName = chosenAuthor.checkName(chosenAuthor.name); //for this check i assume it will pass this test
             chosenAuthor.findPublications(chosenAuthor.getName());// will throw the exception(not implemented)
             string[] authorPublication = chosenAuthor.getPublication(); //getter method for findPublication
             int i = 1;
             string expected = publication[i];
             string actual = authorPublication[i];
             Assert.Equals(expected, actual);
          }
        /// <summary>
        ///Test: Normal valid input 
        ///Author does not exits
        /// </summary>
          [TestMethod, ExpectedExceptionAttribute(typeof(ArgumentException), "Author doesn't exist")]
          public void AuthorPublication_authorDoesNotExist()
          {

              string fakeAuthor = "Joe";
              Author chosenAuthor = new Author(fakeAuthor);
              chosenAuthor.findPublications(chosenAuthor.getName());// will throw the exception(not implemented)
              Assert.Fail();
           }

        /// <summary>
        ///Test: invalid input 
        ///info: String of integers for author's name
        /// </summary>
          [TestMethod]
          public void AuthorPublication_invalidAuthorName()
          {
              string invalidName = "123";
              Author chosenAuthor = new Author(invalidName);
              bool correctName = chosenAuthor.checkName(chosenAuthor.name);
              Assert.IsFalse(correctName);
           }
          /// <summary>
          ///Test: invalid input 
          ///info: Empty string for author's name
          /// </summary>
           [TestMethod]
           public void AuthorPublication_invalidAuthorName_EmptyString()
           {
               string invalidName = "";
               Author chosenAuthor = new Author(invalidName);
               bool correctName = chosenAuthor.checkName(chosenAuthor.name);
               Assert.IsFalse(correctName);
           }

           /// <summary>
           ///Test: invalid input 
           ///info: Control characters for author's name
           /// </summary>
           [TestMethod]
           public void AuthorPublication_invalidAuthorName_controlCharacters()
           {
               string invalidName = "./(())())()()";
               Author chosenAuthor = new Author(invalidName);
               bool correctName = chosenAuthor.checkName(chosenAuthor.name);
               Assert.IsFalse(correctName);
           }
    }
}
