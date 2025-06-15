namespace Hafner.Tools.Tests;

using System;
using FluentAssertions;
using Hafner.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Ensures correct functionality of the <see cref="ObjectExtension_CheckNull.CheckNull">Object.CheckNull()</see> extension method.
/// </summary>
[TestClass]
public class Test_ObjectExtension_CheckNull {

    /// <summary>
    /// Verifies that a null argument throws an <see cref="ArgumentNullException"/> with the parameter name.
    /// </summary>
    [TestMethod]
    public void CheckNull_NullThrows_Parameter() {
        object? sut = null;
        ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => sut.CheckNull());
        exception.Message.Should().Match("The argument for parameter 'sut' is mandatory and cannot be null!*Parameter *sut*");
    }

    /// <summary>
    /// Verifies that a null expression throws an <see cref="ArgumentNullException"/> containing the expression.
    /// </summary>
    [TestMethod]
    public void CheckNull_NullThrows_Expression() {
        ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => GetObject(returnNull: true).CheckNull());
        exception.Message.Should().Match("The result of expression 'GetObject(returnNull: true)' cannot be null!*Parameter *GetObject(returnNull: true)*");
    }

    /// <summary>
    /// Verifies that a null expression throws an <see cref="ArgumentNullException"/> with the given parameter name.
    /// </summary>
    [TestMethod]
    public void CheckNull_NullThrows_Expression_ParameterNameProvided() {
        ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => GetObject(returnNull: true).CheckNull("obj"));
        exception.Message.Should().Match("The argument for parameter 'obj' is mandatory and cannot be null!*Parameter *obj*");
    }

    /// <summary>
    /// Verifies that a null argument throws an <see cref="ArgumentNullException"/> even if the parameter name is <see langword="null"/>.
    /// </summary>
    [TestMethod]
    public void CheckNull_NullThrows_Parameter_ParameterNameNull() {
        object? sut = null;
        ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => sut.CheckNull(null!));
        exception.Message.Should().Match("The argument cannot be null!*Parameter *(unknown)*");
    }

    /// <summary>
    /// Verifies that a non-null argument is returned.
    /// </summary>
    [TestMethod]
    public void CheckNull_NonNull_ReturnsObject() {
        ArgumentNullException sut = new ArgumentNullException();
        ArgumentNullException result = sut.CheckNull();
        result.Should().BeSameAs(sut);
    }

    /// <summary>
    /// Verifies that a non-null argument is returned (for an expression, even if the parameter name is <see langword="null"/>).
    /// </summary>
    [TestMethod]
    public void CheckNull_NonNull_ReturnsObject_EvenIfParameterNameIsNull() {
        ArgumentNullException result = new ArgumentNullException().CheckNull(null!);
        result.Should().NotBeNull();
    }

    private static object? GetObject(bool returnNull) {
        return returnNull ? null : new object();
    }

}
