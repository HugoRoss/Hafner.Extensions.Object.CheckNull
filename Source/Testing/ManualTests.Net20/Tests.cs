namespace ManualTests;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Hafner.Extensions;

internal class Tests(ConsoleWriter consoleWriter) {

    /// <summary>
    /// Verifies that a null argument throws an <see cref="ArgumentNullException"/> with the parameter name.
    /// </summary>
    public bool CheckNull_NullThrows_Parameter() {
        object? sut = null;
        consoleWriter.Write($"Test: '{GetUnitTestName()}': ");
        try {
            sut.CheckNull();
            consoleWriter.WriteLine("Failed!\r\nNo exception was thrown!", ConsoleColor.Red);
            return false;
        } catch (ArgumentNullException expectedException) {
            string expected = "The argument for parameter 'sut' is mandatory and cannot be null!";
            string actual = expectedException.Message;
            int index = actual.IndexOf(expected, StringComparison.Ordinal);
            if (index < 0) {
                consoleWriter.WriteLine($"Failed!\r\nThe error message does not contain the expected text!\r\nExpected: {expected}\r\nActual: {actual}", ConsoleColor.Red);
                return false;
            }
        }
        consoleWriter.WriteLine($"Succeeded.", ConsoleColor.Green);
        return true;
    }

    /// <summary>
    /// Verifies that a null expression throws an <see cref="ArgumentNullException"/> containing the expression.
    /// </summary>
    public bool CheckNull_NullThrows_Expression() {
        consoleWriter.Write($"Test: '{GetUnitTestName()}': ");
        try {
            GetObject(returnNull: true).CheckNull();
            consoleWriter.WriteLine("Failed!\r\nNo exception was thrown!", ConsoleColor.Red);
            return false;
        } catch (ArgumentNullException expectedException) {
            string expected = "The result of expression 'GetObject(returnNull: true)' is mandatory and cannot be null!";
            string actual = expectedException.Message;
            int index = actual.IndexOf(expected, StringComparison.Ordinal);
            if (index < 0) {
                consoleWriter.WriteLine($"Failed!\r\nThe error message does not contain the expected text!\r\nExpected: {expected}\r\nActual: {actual}", ConsoleColor.Red);
                return false;
            }
        }
        consoleWriter.WriteLine($"Succeeded.", ConsoleColor.Green);
        return true;
    }

    /// <summary>
    /// Verifies that a null expression throws an <see cref="ArgumentNullException"/> with the given parameter name.
    /// </summary>
    public bool CheckNull_NullThrows_Expression_ParameterNameProvided() {
        consoleWriter.Write($"Test: '{GetUnitTestName()}': ");
        try {
            GetObject(returnNull: true).CheckNull("obj");
            consoleWriter.WriteLine("Failed!\r\nNo exception was thrown!", ConsoleColor.Red);
            return false;
        } catch (ArgumentNullException expectedException) {
            string expected = "The argument for parameter 'obj' is mandatory and cannot be null!";
            string actual = expectedException.Message;
            int index = actual.IndexOf(expected, StringComparison.Ordinal);
            if (index < 0) {
                consoleWriter.WriteLine($"Failed!\r\nThe error message does not contain the expected text!\r\nExpected: {expected}\r\nActual: {actual}", ConsoleColor.Red);
                return false;
            }
        }
        consoleWriter.WriteLine($"Succeeded.", ConsoleColor.Green);
        return true;
    }

    /// <summary>
    /// Verifies that a null argument throws an <see cref="ArgumentNullException"/> even if the parameter name is <see langword="null"/>.
    /// </summary>
    public bool CheckNull_NullThrows_Parameter_ParameterNameNull() {
        consoleWriter.Write($"Test: '{GetUnitTestName()}': ");
        object? sut = null;
        try {
            sut.CheckNull(null!);
            consoleWriter.WriteLine("Failed!\r\nNo exception was thrown!", ConsoleColor.Red);
            return false;
        } catch (ArgumentNullException expectedException) {
            string expected = "The argument is mandatory and cannot be null!";
            string actual = expectedException.Message;
            int index1 = actual.IndexOf(expected, StringComparison.Ordinal);
            if (index1 < 0) {
                consoleWriter.WriteLine($"Failed!\r\nThe error message does not contain the expected text!\r\nExpected: {expected}\r\nActual: {actual}", ConsoleColor.Red);
                return false;
            }

            expected = "(unknown)";
            int index2 = actual.IndexOf(expected, StringComparison.Ordinal);
            if (index2 <= index1) {
                consoleWriter.WriteLine($"Failed!\r\nThe error message does not contain the expected text at index {index1 + 1} or later!\r\nExpected: {expected}\r\nActual: {actual}", ConsoleColor.Red);
                return false;
            }
        }
        consoleWriter.WriteLine($"Succeeded.", ConsoleColor.Green);
        return true;
    }

    /// <summary>
    /// Verifies that a non-null argument is returned.
    /// </summary>
    public bool CheckNull_NonNull_ReturnsObject() {
        consoleWriter.Write($"Test: '{GetUnitTestName()}': ");
        InvalidOperationException sut = new InvalidOperationException("Just a non-null object.");
        InvalidOperationException result = sut.CheckNull();
        if (!Object.ReferenceEquals(sut, result)) {
            consoleWriter.WriteLine("Failed!\r\nThe same instance should have been returned!", ConsoleColor.Red);
            return false;
        }
        consoleWriter.WriteLine("Succeeded.", ConsoleColor.Green);
        return true;
    }

    /// <summary>
    /// Verifies that a non-null argument is returned (for an expression, even if the parameter name is <see langword="null"/>).
    /// </summary>
    public bool CheckNull_NonNull_ReturnsObject_EvenIfParameterNameIsNull() {
        consoleWriter.Write($"Test: '{GetUnitTestName()}': ");
        InvalidOperationException result = new InvalidOperationException().CheckNull(null!);
        if (result is null) {
            consoleWriter.WriteLine("Failed!\r\nThe given instance should have been returned!", ConsoleColor.Red);
            return false;
        }
        consoleWriter.WriteLine("Succeeded.", ConsoleColor.Green);
        return true;
    }

    private static object? GetObject(bool returnNull) {
        return returnNull ? null : new object();
    }

    private static string GetUnitTestName([CallerMemberName] string caller = "") {
        return $"{caller}";
    }

}
