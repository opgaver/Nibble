# Nibble

Dette er af de mere komplicerede opgaver. Dit job er at skabe en Nibble som en struct. En Nibble er en datastruktur som repræsenterer 4 bits. En byte er 8 bits, så en Nibble er altså halvdelen af en byte. Den skal fungere mere eller mindre som en byte bortset fra at den kun arbejder med værdier fra 0-15. Den skal kunne tildeles en værdi, aflæse en værdi, lægges sammen, trækkes fra, sammenlinges med videre.

Her er et par simple eksempler på hvordan den skal kunne bruges:

```csharp
Nibble a = 5;
Nibble b = 2;
var c = a * b;
Console.WriteLine(c);
if(a> b)
{
    Console.WriteLine("a is greater than b");
}
else
{
    Console.WriteLine("a is not greater than b");
}
```

Se eventuelt min løsning under /solution og leg lidt med strukturen inden du går videre.

## Test

Hvis du har lavet din Nibble korrekt, så skulle følgende test (XUnit) gerne passere - men det er ikke nødvendigt at de alle lys er grønne for at din løsning er korrekt. Se det som en hjælp til at sikre at din kode er korrekt.

```csharp
public class NibbleTests
{

    [Fact]
    public void Nibble_IsAStruct()
    {
        Assert.True(typeof(Nibble).IsValueType);
    }

    // Constructor tests
    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(15)]
    public void Constructor_ValidValue_AssignsValue(int value)
    {
        var nibble = new Nibble(value);
        Assert.Equal(value, nibble.Value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(16)]
    public void Constructor_InvalidValue_ThrowsArgumentOutOfRangeException(int value)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Nibble(value));
    }

    // Value property tests
    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(15)]
    public void Value_SetValidValue_UpdatesValue(int value)
    {
        var nibble = new Nibble(0);
        nibble.Value = value;
        Assert.Equal(value, nibble.Value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(16)]
    public void Value_SetInvalidValue_ThrowsArgumentOutOfRangeException(int value)
    {
        var nibble = new Nibble(0);
        Assert.Throws<ArgumentOutOfRangeException>(() => nibble.Value = value);
    }

    // Implicit conversion tests
    [Fact]
    public void ImplicitConversion_FromInt_CreatesNibble()
    {
        Nibble nibble = 5;
        Assert.Equal(5, nibble.Value);
    }

    [Fact]
    public void ImplicitConversion_ToInt_GetsValue()
    {
        var nibble = new Nibble(5);
        int value = nibble;
        Assert.Equal(5, value);
    }

    // Arithmetic operator tests
    [Theory]
    [InlineData(7, 3, 10)]
    [InlineData(14, 1, 15)]
    public void AdditionOperator_ValidValues_ReturnsCorrectResult(int value1, int value2, int expected)
    {
        var result = new Nibble(value1) + new Nibble(value2);
        Assert.Equal(new Nibble(expected), result);
    }

    [Theory]
    [InlineData(10, 5, 5)]
    [InlineData(1, 1, 0)]
    public void SubtractionOperator_ValidValues_ReturnsCorrectResult(int value1, int value2, int expected)
    {
        var result = new Nibble(value1) - new Nibble(value2);
        Assert.Equal(new Nibble(expected), result);
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(6, 2, 12)]
    public void MultiplicationOperator_ValidValues_ReturnsCorrectResult(int value1, int value2, int expected)
    {
        var result = new Nibble(value1) * new Nibble(value2);
        Assert.Equal(new Nibble(expected), result);
    }

    [Theory]
    [InlineData(6, 3, 2)]
    [InlineData(15, 5, 3)]
    public void DivisionOperator_ValidValues_ReturnsCorrectResult(int value1, int value2, int expected)
    {
        var result = new Nibble(value1) / new Nibble(value2);
        Assert.Equal(new Nibble(expected), result);
    }

    [Fact]
    public void DivisionOperator_Divide_ThrowsDivideByZeroException()
    {
        var nibble = new Nibble(5);
        Assert.Throws<DivideByZeroException>(() => nibble / new Nibble(0));
    }

    // Comparison operator tests
    [Theory]
    [InlineData(5, 6)]
    [InlineData(0, 1)]
    public void LessThanOperator_LessThan_ReturnsTrue(int value1, int value2)
    {
        var nibble1 = new Nibble(value1);
        var nibble2 = new Nibble(value2);
        Assert.True(nibble1 < nibble2);
    }

    [Theory]
    [InlineData(7, 6)]
    [InlineData(15, 0)]
    public void GreaterThanOperator_GreaterThan_ReturnsTrue(int value1, int value2)
    {
        var nibble1 = new Nibble(value1);
        var nibble2 = new Nibble(value2);
        Assert.True(nibble1 > nibble2);
    }

    [Theory]
    [InlineData(5, 5)]
    [InlineData(0, 1)]
    public void LessThanOrEqualOperator_LessThanOrEqual_ReturnsTrue(int value1, int value2)
    {
        var nibble1 = new Nibble(value1);
        var nibble2 = new Nibble(value2);
        Assert.True(nibble1 <= nibble2);
    }

    [Theory]
    [InlineData(6, 6)]
    [InlineData(15, 0)]
    public void GreaterThanOrEqualOperator_GreaterThanOrEqual_ReturnsTrue(int value1, int value2)
    {
        var nibble1 = new Nibble(value1);
        var nibble2 = new Nibble(value2);
        Assert.True(nibble1 >= nibble2);
    }

    [Theory]
    [InlineData(5, 5)]
    [InlineData(10, 10)]
    public void EqualityOperator_Equal_ReturnsTrue(int value1, int value2)
    {
        var nibble1 = new Nibble(value1);
        var nibble2 = new Nibble(value2);
        Assert.True(nibble1 == nibble2);
    }

    [Theory]
    [InlineData(5, 6)]
    [InlineData(1, 0)]
    public void InequalityOperator_NotEqual_ReturnsTrue(int value1, int value2)
    {
        var nibble1 = new Nibble(value1);
        var nibble2 = new Nibble(value2);
        Assert.True(nibble1 != nibble2);
    }

    // Equals method tests
    [Fact]
    public void Equals_SameValue_ReturnsTrue()
    {
        var nibble1 = new Nibble(5);
        var nibble2 = new Nibble(5);
        Assert.True(nibble1.Equals(nibble2));
    }

    [Fact]
    public void Equals_DifferentValue_ReturnsFalse()
    {
        var nibble1 = new Nibble(5);
        var nibble2 = new Nibble(6);
        Assert.False(nibble1.Equals(nibble2));
    }

    [Fact]
    public void Equals_DifferentType_ReturnsFalse()
    {
        var nibble = new Nibble(5);
        var notANibble = "not a nibble";
        Assert.False(nibble.Equals(notANibble));
    }

    // GetHashCode method tests
    [Fact]
    public void GetHashCode_SameValue_SameHashCode()
    {
        var nibble1 = new Nibble(5);
        var nibble2 = new Nibble(5);
        Assert.Equal(nibble1.GetHashCode(), nibble2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_DifferentValue_DifferentHashCode()
    {
        var nibble1 = new Nibble(5);
        var nibble2 = new Nibble(6);
        Assert.NotEqual(nibble1.GetHashCode(), nibble2.GetHashCode());
    }

    // ToString method tests
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    public void ToString_ReturnsStringValue(int value)
    {
        var nibble = new Nibble(value);
        Assert.Equal(value.ToString(), nibble.ToString());
    }

    // Addition tests
    [Theory]
    [InlineData(10, 6)] // 16 exceeds max value of 15
    [InlineData(15, 1)] // 16 exceeds max value of 15
    public void AdditionOperator_ResultExceedsRange_ThrowsArgumentOutOfRangeException(int value1, int value2)
    {
        var nibble1 = new Nibble(value1);
        var nibble2 = new Nibble(value2);
        Assert.Throws<ArgumentOutOfRangeException>(() => nibble1 + nibble2);
    }

    // Subtraction tests
    [Theory]
    [InlineData(0, 1)] // -1 is below min value of 0
    [InlineData(5, 6)] // -1 is below min value of 0
    public void SubtractionOperator_ResultBelowRange_ThrowsArgumentOutOfRangeException(int value1, int value2)
    {
        var nibble1 = new Nibble(value1);
        var nibble2 = new Nibble(value2);
        Assert.Throws<ArgumentOutOfRangeException>(() => nibble1 - nibble2);
    }

    // Multiplication tests
    [Theory]
    [InlineData(4, 4)] // 16 exceeds max value of 15
    [InlineData(3, 6)] // 18 exceeds max value of 15
    public void MultiplicationOperator_ResultExceedsRange_ThrowsArgumentOutOfRangeException(int value1, int value2)
    {
        var nibble1 = new Nibble(value1);
        var nibble2 = new Nibble(value2);
        Assert.Throws<ArgumentOutOfRangeException>(() => nibble1 * nibble2);
    }

}
```
