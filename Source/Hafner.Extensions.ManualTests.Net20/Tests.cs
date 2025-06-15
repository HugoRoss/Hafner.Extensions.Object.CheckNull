namespace Hafner.Tools.ManualTests;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Hafner.Extensions;

[SuppressMessage("Usage", "CA2201:Do not raise reserved exception types", Justification = $"It's good enough, minimal effort to write the '{nameof(Tests)}' class.")]
internal static class Tests {

    /// <summary>
    /// Verifies that a null argument throws an <see cref="ArgumentNullException"/> with the parameter name.
    /// </summary>
    public static void CheckNull_NullThrows_Parameter() {
        object? sut = null;
        try {
            sut.CheckNull();
        } catch (ArgumentNullException expectedException) {
            string errorMessage = expectedException.Message;
            int index1 = errorMessage.IndexOf("The argument for parameter 'sut' is mandatory and cannot be null!", StringComparison.Ordinal);
            Assert.IsTrue(index1 >= 0, "The error message does not contain the expected text!");
        }
    }

    /// <summary>
    /// Verifies that a null expression throws an <see cref="ArgumentNullException"/> containing the expression.
    /// </summary>
    public static void CheckNull_NullThrows_Expression() {
        try {
            GetObject(returnNull: true).CheckNull();
        } catch (ArgumentNullException expectedException) {
            string errorMessage = expectedException.Message;
            int index1 = errorMessage.IndexOf("The result of expression 'GetObject(returnNull: true)' cannot be null!", StringComparison.Ordinal);
            Assert.IsTrue(index1 >= 0, "The error message does not contain the expected text!");
        }
    }

    /// <summary>
    /// Verifies that a null expression throws an <see cref="ArgumentNullException"/> with the given parameter name.
    /// </summary>
    public static void CheckNull_NullThrows_Expression_ParameterNameProvided() {
        try {
            GetObject(returnNull: true).CheckNull("obj");
        } catch (ArgumentNullException expectedException) {
            string errorMessage = expectedException.Message;
            int index1 = errorMessage.IndexOf("The argument for parameter 'obj' is mandatory and cannot be null!", StringComparison.Ordinal);
            Assert.IsTrue(index1 >= 0, "The error message does not contain the expected text!");
        }
    }

    /// <summary>
    /// Verifies that a null argument throws an <see cref="ArgumentNullException"/> even if the parameter name is <see langword="null"/>.
    /// </summary>
    public static void CheckNull_NullThrows_Parameter_ParameterNameNull() {
        object? sut = null;
        try {
            sut.CheckNull(null!);
        } catch (ArgumentNullException expectedException) {
            string errorMessage = expectedException.Message;
            int index1 = errorMessage.IndexOf("The argument cannot be null!", StringComparison.Ordinal);
            Assert.IsTrue(index1 >= 0, "The error message does not contain the expected text!");
            int index2 = errorMessage.IndexOf("(unknown)", StringComparison.Ordinal);
            Assert.IsTrue(index2 > index1);
        }
    }

    /// <summary>
    /// Verifies that a non-null argument is returned.
    /// </summary>
    public static void CheckNull_NonNull_ReturnsObject() {
        InvalidOperationException sut = new InvalidOperationException("Just a non-null object.");
        InvalidOperationException result = sut.CheckNull();
        Assert.AreSame(sut, result);
    }

    /// <summary>
    /// Verifies that a non-null argument is returned (for an expression, even if the parameter name is <see langword="null"/>).
    /// </summary>
    public static void CheckNull_NonNull_ReturnsObject_EvenIfParameterNameIsNull() {
        InvalidOperationException result = new InvalidOperationException().CheckNull(null!);
        Assert.IsTrue(result is not null);
    }

    private static object? GetObject(bool returnNull) {
        return returnNull ? null : new object();
    }

}
