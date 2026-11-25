using Xunit;
using SchoolLibrary.Data.Repositories;
using SchoolLibrary.Services;


public class BookServiceTests
{
    [Fact]
    public void BorrowBook_WhenBookIsAvailable_MarksItAsBorrowed()
    {
        // Arrange: подготвяме хранилището и услугата.
        var repository = new InMemoryBookRepository();
        var service = new BookService(repository);

        // Act: заемаме книга № 1.
        string result = service.BorrowBook(1);

        // Assert: проверяваме резултата и състоянието.
        Assert.Equal("Книгата е заета успешно.", result);
        Assert.True(repository.GetById(1)!.IsBorrowed);
    }
    
    [Fact]
    public void BorrowBook_WhenBookIsAlreadyBorrowed_ReturnsMessage()
    {
        // Arrange
        var repository = new InMemoryBookRepository();
        var service = new BookService(repository);

        service.BorrowBook(1);

        // Act
        string result =  service.BorrowBook(1);

        // Assert
        Assert.Equal("Книгата вече е заета.", result);
    }
    
    [Fact]
    public void BorrowBook_WhenBookDoesNotExist_ReturnsNotFoundMessage()
    {
        // Arrange
        var repository = new InMemoryBookRepository();
        var service = new BookService(repository);

        // Act
        string result = service.BorrowBook(99);

        // Assert
        Assert.Equal("Книгата не е намерена.", result);
    }

    [Fact]
    public void ReturnBook_WhenBookIsBorrowed_MakesItAvailableAgain()
    {
        // Arrange
        var repository = new InMemoryBookRepository();
        var service = new BookService(repository);

        service.BorrowBook(1);

        // Act
        string result = service.ReturnBook(1); 

        // Assert
        Assert.Equal("Книгата е върната успешно.", result);
        Assert.False(repository.GetById(1)!.IsBorrowed);
    }

}

