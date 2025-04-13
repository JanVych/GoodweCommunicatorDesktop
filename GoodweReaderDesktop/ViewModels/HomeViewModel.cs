using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoodweReaderDesktop.Helpers;
using GoodweReaderDesktop.Services;
using Microsoft.UI.Dispatching;

namespace GoodweReaderDesktop.ViewModels;


public partial class HomeViewModel : ObservableObject
{
    private readonly GoodweService _goodweService;
    private DispatcherQueue? _dispatcherQueue;

    [ObservableProperty]
    public double _readRegisterValue;

    [ObservableProperty]
    public ushort _readRegisterAddress;

    [ObservableProperty]
    public double _writeRegisterValue;

    [ObservableProperty]
    public ushort _writeRegisterAddress;

    [ObservableProperty]
    public string _ipAddress = string.Empty;

    [ObservableProperty]
    public int _port;

    [ObservableProperty]
    public byte _deviceAddress;

    [ObservableProperty]
    public bool _isInputEnabled = true;

    [ObservableProperty]
    public string _outputText = string.Empty;

    public List<RegisterType> RegisterTypesList { get; set; } = Enum.GetValues(typeof(RegisterType)).Cast<RegisterType>().ToList();

    [ObservableProperty]
    public RegisterType _readRegisterType;
    [ObservableProperty]
    public RegisterType _writeRegisterType;

    public HomeViewModel(GoodweService goodweService)
    {
        _goodweService = goodweService;
        _goodweService.LogAction = WriteLineConsole;
    }

    public void SetDispatcherQueue(DispatcherQueue dispatcherQueue)
    {
        _dispatcherQueue = dispatcherQueue;
    }

    [RelayCommand]
    public async Task ReadRegister()
    {
        WriteLineConsole($"Reading at: {ReadRegisterAddress}...");
        IsInputEnabled = false;
        _goodweService.ChangeSettings(DeviceAddress, IpAddress, Port);
        var task = Task.Run(() =>
        {
            ReadRegisterValue = ReadRegisterType switch
            {
                RegisterType.SignedInt16 => _goodweService.GetS16Register(ReadRegisterAddress) ?? 0,
                RegisterType.UnsignedInt16 => _goodweService.GetU16Register(ReadRegisterAddress) ?? 0,
                RegisterType.SignedInt32 => _goodweService.GetS32Register(ReadRegisterAddress) ?? 0,
                RegisterType.UnsignedInt32 => _goodweService.GetU32Register(ReadRegisterAddress) ?? 0,
                _ => 0 
            };
        });
        await task;
        IsInputEnabled = true;
    }

    [RelayCommand]
    public async Task WriteRegister()
    {
        WriteLineConsole($"Writing at: {WriteRegisterAddress}, value: {WriteRegisterValue}...");
        _goodweService.ChangeSettings(DeviceAddress, IpAddress, Port);
        IsInputEnabled = false;
        var task = Task.Run(() =>
        {
            switch (WriteRegisterType)
            {
                case RegisterType.SignedInt16:
                    _goodweService.SetS16Register(WriteRegisterAddress, (short)WriteRegisterValue);
                    break;
                case RegisterType.UnsignedInt16:
                    _goodweService.SetU16Register(WriteRegisterAddress, (ushort)WriteRegisterValue);
                    break;
                default:
                    break;
            }
        });
        await task;
        IsInputEnabled = true;
    }

    public void WriteLineConsole(string text)
    {
        if(_dispatcherQueue != null)
        {
            _dispatcherQueue.TryEnqueue(() =>
            {
                OutputText += $"{text}\n";
            });
        }
    }
}
