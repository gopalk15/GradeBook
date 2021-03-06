using System;
using Xunit;

namespace GradeBook.Tests
{

    //Points to methods 
    public delegate string WriteLogDelegate(string logMessage);

    
    
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
           

            log += ReturnMessage;

            log += IncrementCount;


            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        
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

            Assert.Equal("New Name", book1.Name);


        }

        private void GetBookSetNameByRef(ref InMemoryBook book, string NewName)
        {
            book = new InMemoryBook(NewName);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.NotEqual("New Name", book1.Name);


        }

        private void GetBookSetName(InMemoryBook book, string NewName)
        {
            book = new InMemoryBook(NewName);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // C# always passes objects to methods by value
            Assert.Equal("New Name", book1.Name);


        }

        private void SetName(InMemoryBook book, string NewName)
        {
            book.Name = NewName;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);


        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);


        }
        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
