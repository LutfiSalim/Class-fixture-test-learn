[CollectionDefinition("Calculator collection")]
public class CalculatorCollection : ICollectionFixture<CalculatorFixture>
{ // This class has no code, and is never created. Its purpose is simply 
  // to be the place to apply [CollectionDefinition] and all the 
  // ICollectionFixture<> interfaces.
}

public class CalculatorFixture : IDisposable
{
    public Calculator Calculator { get; private set; }

    public CalculatorFixture()
    {
        Calculator = new Calculator();
    }

    public void Dispose()
    {
        // Clean up any resources used by the CalculatorFixture class here
    }
}

public class Calculator
{
    public int Addition(int x, int y) { return x + y; }

    public int Subtraction(int x, int y)
    {
        return x - y;
    }

    public int Multiplication(int x, int y)
    {
        return x * y;
    }

    public int Division(int x, int y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        return x / y;
    }
}

[Collection("Calculator collection")]
public class CalculatorTests1
{
    private readonly Calculator _calculator;
    public CalculatorTests1(CalculatorFixture fixture)
    {
        _calculator = fixture.Calculator;
    }

    [Fact]
    public void TestAddition()
    {
        // Act
        var result1 = _calculator.Addition(2, 3);
        var result2 = _calculator.Addition(-2, 3);
        var result3 = _calculator.Addition(0, 0);

        // Assert
        Assert.Equal(5, result1);
        Assert.Equal(1, result2);
        Assert.Equal(0, result3);
    }

    [Fact]
    public void TestSubtraction()
    {
        // Act
        var result1 = _calculator.Subtraction(2, 3);
        var result2 = _calculator.Subtraction(4, 3);
        var result3 = _calculator.Subtraction(0, 0);

        // Assert
        Assert.Equal(-1, result1);
        Assert.Equal(1, result2);
        Assert.Equal(0, result3);
    }

    [Fact]
    public void TestMultiplication()
    {
        // Act
        var result1 = _calculator.Multiplication(2, 3);
        var result2 = _calculator.Multiplication(4, -3);
        var result3 = _calculator.Multiplication(0, 0);

        // Assert
        Assert.Equal(6, result1);
        Assert.Equal(-12, result2);
        Assert.Equal(0, result3);
    }

    [Fact]
    public void TestDivision()
    {
        // Act
        var result1 = _calculator.Division(8, 2);
        var result2 = _calculator.Division(10, -2);
        var result3 = _calculator.Division(8, 7);

        // Assert
        Assert.Equal(4, result1);
        Assert.Equal(-5, result2);
        Assert.Equal(1, result3);
    }


}

[Collection("Calculator collection")]
public class CalculatorTests2
{
    private readonly Calculator _calculator;

    public CalculatorTests2(CalculatorFixture fixture)
    {
        _calculator = fixture.Calculator;
    }

    [Fact]
    public void TestSubtraction()
    {
        // Act
        var result1 = _calculator.Subtraction(2, 3);
        var result2 = _calculator.Subtraction(4, 3);
        var result3 = _calculator.Subtraction(0, 0);

        // Assert
        Assert.Equal(-1, result1);
        Assert.Equal(1, result2);
        Assert.Equal(0, result3);
    }
}

[Collection("Calculator collection")]
public class CalculatorTests3
{
    private readonly Calculator _calculator;

    public CalculatorTests3(CalculatorFixture fixture)
    {
        _calculator = fixture.Calculator;
    }

    [Fact]
    public void TestMultiplication()
    {
        // Act
        var result1 = _calculator.Multiplication(2, 3);
        var result2 = _calculator.Multiplication(4, -3);
        var result3 = _calculator.Multiplication(0, 0);

        // Assert
        Assert.Equal(6, result1);
        Assert.Equal(-12, result2);
        Assert.Equal(0, result3);
    }
}

[Collection("Calculator collection")]
public class CalculatorTests4
{
    private readonly Calculator _calculator;

    public CalculatorTests4(CalculatorFixture fixture)
    {
        _calculator = fixture.Calculator;
    }

    [Fact]
    public void TestDivision()
    {
        // Act
        var result1 = _calculator.Division(8, 2);
        var result2 = _calculator.Division(10, -2);
        var result3 = _calculator.Division(8, 7);

        // Assert
        Assert.Equal(4, result1);
        Assert.Equal(-5, result2);
        Assert.Equal(1, result3);
    }
}



