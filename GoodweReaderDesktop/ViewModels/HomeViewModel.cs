using CommunityToolkit.Mvvm.ComponentModel;

namespace GoodweReaderDesktop.ViewModels;

public partial class HomeViewModel : ObservableRecipient
{
    [ObservableProperty]
    public int _readRegisterValue;

    [ObservableProperty]
    public int _readRegisterAddress;

    [ObservableProperty]
    public int _writeRegisterValue;

    [ObservableProperty]
    public int _writeRegisterAddress;

    public HomeViewModel()
    {
    }
}
