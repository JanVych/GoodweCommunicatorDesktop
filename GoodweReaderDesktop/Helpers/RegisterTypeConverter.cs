using Microsoft.UI.Xaml.Data;
using System.ComponentModel;

namespace GoodweReaderDesktop.Helpers;

public enum RegisterType
{
    SignedInt16,
    UnsignedInt16,
    SignedInt32,
    UnsignedInt32,
}

public static class RegisterTypeExtensions
{
    public static string ToDisplayString(this RegisterType registerType)
    {
        return registerType switch
        {
            RegisterType.SignedInt16 => "Signed Int 16",
            RegisterType.UnsignedInt16 => "Unsigned Int 16",
            RegisterType.SignedInt32 => "Signed Int 32",
            RegisterType.UnsignedInt32 => "Unsigned Int 32",
            _ => throw new InvalidEnumArgumentException(nameof(registerType), (int)registerType, typeof(RegisterType))
        };
    }
}

public class RegisterTypeToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return value is RegisterType registerType ? registerType.ToDisplayString() : string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
