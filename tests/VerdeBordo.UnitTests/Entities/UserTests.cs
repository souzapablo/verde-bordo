namespace VerdeBordo.UnitTests.Entities;

public class UserTests
{
    [Fact(DisplayName = "Given only a new FirstName UpdateUser should update FirstName")]
    public void GivenANewFirstNameWhenUpdateIsCalledShouldUpdateFirstName()
    {
        // Arrange
        var sut = FakeUserFactory.FakeUser();
        var initialDate = sut.LastUpdate;
        
        // Act
        sut.UpdateUser("Olga", null, null);

        // Assert
        sut.FirstName.Should().Be("Olga");
        sut.LastName.Should().Be(sut.LastName);
        sut.Username.Should().Be(sut.Username);
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }

    [Fact(DisplayName = "Given only a new LastName UpdateUser should update only LastName")]
    public void GivenANewLastNameWhenUpdateIsCalledShouldUpdateLastName()
    {
        // Arrange
        var sut = FakeUserFactory.FakeUser();
        var initialDate = sut.LastUpdate;
        
        // Act
        sut.UpdateUser(null, "Benário", null);

        // Assert
        sut.FirstName.Should().Be(sut.FirstName);
        sut.LastName.Should().Be("Benário");
        sut.Username.Should().Be(sut.Username);
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }
    
    [Fact(DisplayName = "Given only a new Username UpdateUser should update only Username")]
    public void GivenANewUsernameWhenUpdateIsCalledShouldUpdateUsername()
    {
        // Arrange
        var sut = FakeUserFactory.FakeUser();
        var initialDate = sut.LastUpdate;
        
        // Act
        sut.UpdateUser(null, null, "olga.ben");

        // Assert
        sut.FirstName.Should().Be(sut.FirstName);
        sut.LastName.Should().Be(sut.LastName);
        sut.Username.Should().Be("olga.ben");
        sut.LastUpdate.Should().NotBeSameDateAs(initialDate);
    }
}