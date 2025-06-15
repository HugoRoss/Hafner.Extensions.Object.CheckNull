namespace Hafner.Tools.ManualTests;

using System;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("Usage", "CA2201:Do not raise reserved exception types", Justification = $"It's good enough, minimal effort to write the '{nameof(Assert)}' class.")]
internal static class Assert {

    public static void AreEqual(int expected, int actual) {
        if (expected == actual) return;
        throw new Exception($"{expected} ({nameof(expected)} is not equal to {actual} ({nameof(actual)})!");
    }

    public static void IsTrue(bool value, string? errorMessage = null) {
        if (value) return;
        if (String.IsNullOrEmpty(errorMessage)) errorMessage = "The condition is not true!";
        throw new Exception(errorMessage);
    }

    public static void AreSame(object a, object b, string? errorMessage = null) {
        if (Object.ReferenceEquals(a, b)) return;
        if (String.IsNullOrEmpty(errorMessage)) errorMessage = "The two instances must be the same!";
        throw new Exception(errorMessage);
    }

    public static void AreNotSame(object a, object b, string? errorMessage = null) {
        if (!Object.ReferenceEquals(a, b)) return;
        if (String.IsNullOrEmpty(errorMessage)) errorMessage = "The two instances cannot be the same!";
        throw new Exception(errorMessage);
    }

}
