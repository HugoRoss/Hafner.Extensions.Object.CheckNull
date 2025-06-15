# Hafner.Extensions.Object.CheckNull

This micro package provides extension method `System.Object.CheckNull()` (restricted to reference types).

## Description

Package "Hafner.Extensions.Object.CheckNull" contains an extension method for a `System.Object` that checks whether it is null (Nothing in Visual Basic)
an in case it is, throws an `ArgumentNullException` with a speaking message (using the automatically filled in 2nd argument `parameterName`); 
otherwise, the object is returned.

## Edge cases:

 - If the object is a System.ValueType it cannot be called (compile error).
 - If the parameter name is null, empty or white-space, an ArgumentNullException with a generic message is thrown ("The argument cannot be null!")
 - If the parameter name is recognized as an expression, an ArgumentNullException with an according message is thrown ("The expression '{paramName}' cannot be null!")
 - If the parameter name is recognized as a parameter name, an ArgumentNullException with an according message is thrown ("The argument for parameter '{paramName}' cannot be null!")

## Supported Frameworks Versions:

 - .NET Framework: `2.0`, `3.0`, `3.5`, `4.0`, `4.0.3`, `4.5`, `4.5.1`, `4.5.2`, `4.6`, `4.6.1`, `4.6.2`, `4.7`, `4.7.1`, `4.7.2`, `4.8`, `4.8.1`
 - .NET Core: `1.0`, `1.1`, `2.0`, `2.1`, `2.2`, `3.0`, `3.1`, `5.0`, `6.0`, `7.0`, `8.0`, `9.0`, `10.0`
 - .NET Standard: `1.0`, `1.1`, `1.2`, `1.3`, `1.4`, `1.5`, `1.6`, `2.0`, `2.1`
