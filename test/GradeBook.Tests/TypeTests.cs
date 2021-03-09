using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {   
        /*
         Strings are immutable 
         Strings behave like Value Types
         Method won't change the string passed to the method 

        */
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Kaylin";
            string upper = MakeUpperCase(name);

            Assert.Equal("Kaylin", name);
            Assert.Equal("KAYLIN", upper);


        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }



        /* 
        C# is always pass by value when invoking a method.
        When SetInt() is invokes the value 3 is copied (from global class x variable) into the local method variable.
        Method then updates local variable to 42 and orginal global variable is unaffected.
        Therefore global x variable remains as 3.

        Must pass by reference to be able to change global class variable.
        */
        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;

        }

        [Fact]
        public void CSharpPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameByRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.BookName);


        }

        private void GetBookSetNameByRef(ref Book book, string NewName)
        {
            book = new Book(NewName);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.NotEqual("New Name", book1.BookName);


        }

        private void GetBookSetName(Book book, string NewName)
        {
            book = new Book(NewName);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // C# always passes objects to methods by value
            Assert.Equal("New Name", book1.BookName);


        }

        private void SetName(Book book, string NewName)
        {
            book.BookName = NewName;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.BookName);
            Assert.Equal("Book 2", book2.BookName);
            Assert.NotSame(book1, book2);


        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);


        }
        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
