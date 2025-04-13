using System.Diagnostics;
using GoodweReaderDesktop.Helpers;
using GoodweReaderDesktop.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace GoodweReaderDesktop.Views;

public sealed partial class HomePage : Page
{
    public HomeViewModel ViewModel
    {
        get;
    }

    public HomePage()
    {
        ViewModel = App.GetService<HomeViewModel>();
        InitializeComponent();
        ViewModel.SetDispatcherQueue(DispatcherQueue);
    }

    private static void ConvertNumber(NumberBox numberBox, TextBox hexTextBox, RegisterType registerType)
    {
        if (hexTextBox != null)
        {
            var value = ClampValue((long)numberBox.Value, registerType);
            numberBox.Value = value;
            hexTextBox.Text = value.ToString("X");
        }
    }

    private static long ClampValue(long value, RegisterType registerType)
    {
        return registerType switch
        {
            RegisterType.SignedInt16 => Math.Clamp(value, short.MinValue, short.MaxValue),
            RegisterType.UnsignedInt16 => Math.Clamp(value, 0, ushort.MaxValue),
            RegisterType.SignedInt32 => Math.Clamp(value, int.MinValue, int.MaxValue),
            _ => Math.Clamp(value, 0, uint.MaxValue),
        };
    }

    private void ReadRegisterValue_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
    {
        if (ReadRegisterType.SelectedItem is RegisterType registerType)
        {
            ConvertNumber(sender, ReadRegisterValueHex, registerType);
        }
    }

    private void WriteRegisterValue_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
    {
        if (WriteRegisterType.SelectedItem is RegisterType registerType)
        {
            ConvertNumber(sender, WriteRegisterValueHex, registerType);
        }
    }

    private void WriteRegisterValueHex_TextChanged(object sender, TextChangedEventArgs args)
    {
        if (sender is TextBox textBox)
        {
            if (long.TryParse(textBox.Text, System.Globalization.NumberStyles.HexNumber, null, out var value))
            {
                if (WriteRegisterType.SelectedItem is RegisterType registerType)
                {
                    value = ClampValue(value, registerType);
                }
                WriteRegisterValue.Value = value;

                textBox.Text = value.ToString("X");
            }
        }
    }

    private void WriteRegisterType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox comboBox && comboBox.SelectedItem is RegisterType registerType)
        {
            ConvertNumber(WriteRegisterValue, WriteRegisterValueHex, registerType);
        }
    }
}
