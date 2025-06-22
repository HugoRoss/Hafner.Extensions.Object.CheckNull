namespace ManualTests;

using System;

internal sealed class Program {

    public static void Main(string[] args) {
        _ = args; //unused
        ConsoleWriter consoleWriter = new ConsoleWriter();
        consoleWriter.WriteLine();
        consoleWriter.WriteLine($"{FrameworkVersion}: ", ConsoleColor.Yellow);
        try {
            Tests test = new Tests(consoleWriter);
            bool success = true;
            success &= test.CheckNull_NullThrows_Parameter();
            success &= test.CheckNull_NullThrows_Expression();
            success &= test.CheckNull_NullThrows_Expression_ParameterNameProvided();
            success &= test.CheckNull_NullThrows_Parameter_ParameterNameNull();
            success &= test.CheckNull_NonNull_ReturnsObject();
            success &= test.CheckNull_NonNull_ReturnsObject_EvenIfParameterNameIsNull();
            if (success) {
                consoleWriter.WriteLine("All tests succeeded!", ConsoleColor.Green);
            } else {
                consoleWriter.WriteLine("Some tests failed!", ConsoleColor.Red);
            }
        } catch (Exception ex) {
            consoleWriter.WriteLine("An exception was thrown during the test run!", ConsoleColor.Red);
            consoleWriter.Write("The message was: ");
            consoleWriter.WriteLine(ex.Message.TrimEnd(), ConsoleColor.Red);
        }
    }

    private static string FrameworkVersion {
        get {
#if NET20
            return "Net 2.0";
#elif NET30
            return "Net 3.0";
#elif NET35
            return "Net 3.5";
#elif NET40
            return "Net 4.0";
#elif NET403
            return "Net 4.0.3";
#elif NET45
            return "Net 4.5";
#elif NET451
            return "Net 4.5.1";
#elif NET452
            return "Net 4.5.2";
#elif NET46
            return "Net 4.6";
#elif NET461
            return "Net 4.6.1";
#else
            return "Unknown";
#endif
        }
    }

}
