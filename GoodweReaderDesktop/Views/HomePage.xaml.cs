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
    }

    private void IntegerNumberBox_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
    {
        //if (HexTextBox != null)
        //{
        //    if (sender.Value % 1 != 0)
        //    {
        //        sender.Value = Math.Round(sender.Value);
        //    }

        //    var intValue = (int)sender.Value;
        //    HexTextBox.Text = intValue.ToString("X");
        //}
    }

    private void HexTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        //if (int.TryParse(HexTextBox.Text, System.Globalization.NumberStyles.HexNumber, null, out var decimalValue))
        //{
        //    if (decimalValue >= 0 && decimalValue <= 65535)
        //    {
        //        IntegerNumberBox.Value = decimalValue;
        //    }
        //}
    }
}
