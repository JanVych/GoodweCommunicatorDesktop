using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoodweReaderDesktop.Helpers;
using GoodweReaderDesktop.Services;

namespace GoodweReaderDesktop.ViewModels;


public partial class HomeViewModel : ObservableObject
{
    private readonly GoodweService _goodweService;

    [ObservableProperty]
    public int _readRegisterValue;

    [ObservableProperty]
    public int _readRegisterAddress;

    [ObservableProperty]
    public int _writeRegisterValue;

    [ObservableProperty]
    public int _writeRegisterAddress;

    public List<RegisterType> RegisterTypesList { get; set; } = Enum.GetValues(typeof(RegisterType)).Cast<RegisterType>().ToList();

    [ObservableProperty]
    public RegisterType _readRegisterType;
    [ObservableProperty]
    public RegisterType _writeRegisterType;

    public HomeViewModel(GoodweService goodweService)
    {
        _goodweService = goodweService;
    }

    [RelayCommand]
    public void ReadRegister()
    {
        // Implement the logic to read the register value here
        // For example, you can use a service to communicate with the device
        // and update the ReadRegisterValue property accordingly.
        // This is just a placeholder implementation.
        ReadRegisterValue = 1234; // Replace with actual read value
    }

    [RelayCommand]
    public void WriteRegister()
    {
        // Implement the logic to write the register value here
        // For example, you can use a service to communicate with the device
        // and update the WriteRegisterValue property accordingly.
        // This is just a placeholder implementation.
        // Replace with actual write logic
    }

    [RelayCommand]
    public void Connect()
    {
        // Implement the logic to connect to the device here
        // For example, you can use a service to establish a connection
        // and update the connection status accordingly.
        // This is just a placeholder implementation.
    }
}
