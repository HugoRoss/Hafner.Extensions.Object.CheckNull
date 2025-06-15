namespace Hafner.Tools.ManualTests;

using System;
using System.Windows.Forms;

internal sealed class Program {

    public static void Main(string[] args) {
        _ = args; //unused
        try {
            Tests.CheckNull_NullThrows_Parameter();
            Tests.CheckNull_NullThrows_Expression();
            Tests.CheckNull_NullThrows_Expression_ParameterNameProvided();
            Tests.CheckNull_NullThrows_Parameter_ParameterNameNull();
            Tests.CheckNull_NonNull_ReturnsObject();
            Tests.CheckNull_NonNull_ReturnsObject_EvenIfParameterNameIsNull();
            MessageBox.Show($"Manual tests succeeded!", Caption);
        } catch (Exception ex) {
            MessageBox.Show($"Manual tests failed!\r\n\r\n{ex.Message}", Caption);
        }
    }

    private static string Caption {
        get {
            string frameworkVersion = GetFrameworkVersion();
            return $"Manual Tests ({frameworkVersion})";
        }
    }

    private static string GetFrameworkVersion() {
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
