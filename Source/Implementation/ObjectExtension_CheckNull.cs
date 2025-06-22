namespace Hafner.Extensions;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>
/// Class that provides an extension method to check if an object is <see langword="null"/> that throws an <see cref="ArgumentNullException"/> if it is.
/// </summary>
[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "It looks smarter.")]
public static class ObjectExtension_CheckNull {

    /// <summary>
    /// Extension method to check if an object is <see langword="null"/> that throws an <see cref="ArgumentNullException"/> if it is and otherwise returns the object.
    /// </summary>
    /// <typeparam name="T">The type of the object (a reference type).</typeparam>
    /// <param name="obj">The object (reference type) to check.</param>
    /// <param name="paramName">The name of the parameter which is filled in by the compiler.</param>
    /// <returns>The object that is guaranteed not to be <see langword="null"/>.</returns>
    /// <exception cref="ArgumentNullException">An <see cref="ArgumentNullException"/> is thrown if <paramref name="obj"/> is <see langword="null"/>.</exception>
    [SuppressMessage("Usage", "CA2208:Instantiate argument exceptions correctly", Justification = "Edge case when the received parameter name is null.")]
    public static T CheckNull<T>([NotNull] this T? obj, [CallerArgumentExpression(nameof(obj))] string paramName = "") where T : class {
        if (obj is null) {
            if (paramName is null) throw new ArgumentNullException("(unknown)", "The argument is mandatory and cannot be null!");
            if (paramName.IsExpression()) throw new ArgumentNullException(paramName, $"The result of expression '{paramName}' is mandatory and cannot be null!");
            throw new ArgumentNullException(paramName, $"The argument for parameter '{paramName}' is mandatory and cannot be null!");
        }
        return obj;
    }

}
