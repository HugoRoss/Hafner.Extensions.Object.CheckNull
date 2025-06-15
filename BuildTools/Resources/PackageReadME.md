# Hafner.Extensions.Object.CheckNull

This micro package provides extension method `System.Object.CheckNull()` (restricted to reference types).

## Description

Package "Hafner.Extensions.Object.CheckNull" contains an extension method for a `System.Object` that checks whether it is null (Nothing in Visual Basic)
an in case it is, throws an `ArgumentNullException` with a speaking message (using the automatically filled in 2nd argument `parameterName`); 
otherwise, the object is returned.

## Edge cases:

<li /> If the object is a System.ValueType it cannot be called (compile error).
<li /> If the parameter name is null, empty or white-space, an ArgumentNullException with a generic message is thrown ("The argument cannot be null!")
<li /> If the parameter name is recognized as an expression, an ArgumentNullException with an according message is thrown ("The expression '{paramName}' cannot be null!")
<li /> If the parameter name is recognized as a parameter name, an ArgumentNullException with an according message is thrown ("The argument for parameter '{paramName}' cannot be null!")

## Supported Frameworks:

<li /> .NET framework versions <code>2.0</code>, <code>3.0</code>, <code>3.5</code>, <code>4.0</code>, <code>4.0.3</code>, <code>4.5</code>, <code>4.5.1</code>, <code>4.5.2</code>, <code>4.6</code>, <code>4.6.1</code>, <code>4.6.2</code>, <code>4.7</code>, <code>4.7.1</code>, <code>4.7.2</code>, <code>4.8</code>, <code>4.8.1</code>
<li /> .NET core versions <code>1.0</code>, <code>1.1</code>, <code>2.0</code>, <code>2.1</code>, <code>2.2</code>, <code>3.0</code>, <code>3.1</code>, <code>5.0</code>, <code>6.0</code>, <code>7.0</code>, <code>8.0</code>, <code>9.0</code>, <code>10.0</code>
<li /> .NET standard versions <code>1.0</code>, <code>1.1</code>, <code>1.2</code>, <code>1.3</code>, <code>1.4</code>, <code>1.5</code>, <code>1.6</code>, <code>2.0</code>, <code>2.1</code>
