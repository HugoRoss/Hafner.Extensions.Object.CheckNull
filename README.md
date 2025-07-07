# Hafner.Extensions.Object.CheckNull

This micro repository provides extension method `System.Object.CheckNull()` (restricted to reference types).

## Description

Package `Hafner.Extensions.Object.CheckNull` contains an extension method for a `System.Object` that checks whether it is null (Nothing in Visual Basic)
and in case it is, throws an `ArgumentNullException` with a speaking message (using the automatically filled in 2nd argument `parameterName`); 
otherwise, the object is returned.

This method is especially useful in conjunction with C#'s primary constructors where there is no built-in way to check the arguments before they are assigned.

```
public class Employee(int employeeNo, Person person) {

    public string EmployeeNo { get; } = employeeNo;
    public string Person { get; } = person.CheckNull();

}
```

## Behavior and Edge Cases:

 - If the object is a `System.ValueType` it cannot be called (compile error).
 - If the object is not `null`, the same instance is returned.
 - If the object is `null` and the parameter name is `null` an `ArgumentNullException` with a generic message is thrown ("The argument is mandatory and cannot be null!")
 - If the object is `null` and the parameter name is recognized as an expression, an `ArgumentNullException` with an according message is thrown ("The result of the expression '\{paramName}' is mandatory and cannot be null!")
 - If the object is `null` and the parameter name is recognized as a parameter name, an `ArgumentNullException` with an according message is thrown ("The argument for parameter '\{paramName}' is mandatory and cannot be null!")

## Supported Frameworks:

 - .NET Framework versions `2.0`, `3.0`, `3.5`, `4.0`, `4.0.3`, `4.5`, `4.5.1`, `4.5.2`, `4.6`, `4.6.1`, `4.6.2`, `4.7`, `4.7.1`, `4.7.2`, `4.8`, `4.8.1`
 - .NET Core versions `1.0`, `1.1`, `2.0`, `2.1`, `2.2`, `3.0`, `3.1`, `5.0`, `6.0`, `7.0`, `8.0`, `9.0`, `10.0`
 - .NET Standard versions `1.0`, `1.1`, `1.2`, `1.3`, `1.4`, `1.5`, `1.6`, `2.0`, `2.1`
