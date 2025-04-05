using System.Net.Sockets;
using System.Net;

namespace ModulesApp.Helpers;

public class ModbusRtuUdp
{
    //public class CrcException : Exception
    //{
    //    public CrcException(string message) : base(message) { }
    //    public CrcException(string message, Exception inner) : base(message, inner) { }
    //}

    //private byte DeviceAddress { get; set; }

    //public int ServerPort { get; set; }

    //public string ServerIp { get; set; }

    //public int ResponseHeaderSize { get; set; }
    //public int TimeoutMs { get; set; } = 2000;
    //public int NumberofAttempts { get; set; } = 4;

    //private UdpClient? _udpClient;

    //public ModbusRtuUdp(byte deviceAddress, int serverPort, string serverIp, int responseHeaderSize = 0)
    //{
    //    DeviceAddress = deviceAddress;
    //    ServerPort = serverPort;
    //    ServerIp = serverIp;
    //    ResponseHeaderSize = responseHeaderSize;
    //}

    //public float? ReadFLoatFromS16Register(ushort address)
    //{
    //    var value =  ReadS16Register(address);
    //    return value == null ? null : (float)value;
    //}

    //public ushort? ReadU16Register(ushort address)
    //{
    //    var value = ReadS16Registers(address, 1)?.FirstOrDefault();
    //    return value == null ? null : (ushort) value;
    //}

    //public short? ReadS16Register(ushort address)
    //{
    //    return ReadS16Registers(address, 1)?.FirstOrDefault();
    //}

    //public uint? ReadU32Register(ushort address)
    //{
    //    var registers = ReadS16Registers(address, 2);
    //    if (registers?.Length == 2)
    //    {
    //        var high = (uint)registers[0] << 16;
    //        var low = (uint)registers[1];
    //        return high | low;
    //    }
    //    return null;
    //}

    //public short[]? ReadS16Registers(ushort address, ushort ammount)
    //{
    //    try
    //    {
    //        var frame = BuildFrame(0x03, address, ammount);
    //        var bytes = SendAndReceive(frame);
    //        var registers = new short[ammount];
    //        for (int i = 0; i < ammount; i++)
    //        {
    //            registers[i] = (short) (bytes[i * 2 + 3] << 8 | bytes[i * 2 + 4]);
    //        }
    //        return registers;
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"ModbusRtuUdp, read registers: {ex.Message}\n");
    //        return null;
    //    }
    //}

    //public void WriteS16Register(ushort address, short registerValue)
    //{
    //    WriteU16Register(address, (ushort)registerValue);
    //}

    //public void WriteU16Register(ushort address, ushort registerValue)
    //{
    //    try
    //    {
    //        var frame = BuildFrame(0x06, address, registerValue);
    //        byte[] response = SendAndReceive(frame);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"ModbusRtuUdp, write register: {ex.Message}");
    //    }
    //}

    //private byte[] BuildFrame(byte functionCode, ushort address, ushort amountOrValue)
    //{
    //    var frame = new byte[8];
    //    frame[0] = DeviceAddress;
    //    frame[1] = functionCode;
    //    frame[2] = (byte)(address >> 8);
    //    frame[3] = (byte)address;
    //    frame[4] = (byte)(amountOrValue >> 8);
    //    frame[5] = (byte)amountOrValue;
    //    ushort crc = CalculateCrc(frame, 6);
    //    frame[6] = (byte)crc;
    //    frame[7] = (byte)(crc >> 8);
    //    return frame;
    //}

    //private byte[] SendAndReceive(byte[] data)
    //{
    //    UdpClient client;
    //    bool local = false;
    //    if (_udpClient == null)
    //    {
    //        local = true;
    //        client = new();
    //        client.Client.ReceiveTimeout = TimeoutMs;
    //        client.Connect(ServerIp, ServerPort);
    //    }
    //    else
    //    {
    //        client = _udpClient;
    //    }
    //    var bytes = TrySendAndRecive(client, data);

    //    if (bytes.Length == 5)
    //    {
    //        Console.WriteLine($"Frame sended: {string.Join(", ", data)}");
    //        Console.WriteLine($"Error frame recive: {string.Join(", ", bytes)}");
    //        Console.WriteLine();
    //    }

    //    if (local)
    //    {
    //        client.Close();
    //        client.Dispose();
    //    }
    //    return bytes;
    //}

    //private byte[] TrySendAndRecive(UdpClient client, byte[] data)
    //{
    //    for(int i = 1; i <= NumberofAttempts; i++)
    //    {
    //        try
    //        {
    //            client.Send(data, data.Length);
    //            IPEndPoint remoteEndPoint = new(IPAddress.Any, ServerPort);
    //            var bytes = client.Receive(ref remoteEndPoint);
    //            if (ResponseHeaderSize > 0)
    //            {
    //                bytes = bytes[ResponseHeaderSize..];
    //            }
    //            CheckCrc(bytes);
    //            return bytes;
    //        }
    //        catch (Exception)
    //        {
    //            Console.WriteLine(i);
    //            if (i == NumberofAttempts)
    //            {
    //                throw;
    //            }
    //        }
    //    }
    //    return [];
    //}

    //public bool Open()
    //{
    //    try
    //    {
    //        _udpClient = new UdpClient();
    //        _udpClient.Client.ReceiveTimeout = TimeoutMs;
    //        _udpClient.Connect(ServerIp, ServerPort);
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"ModbusRtuUdp, open: {ex.Message}\n");
    //        return false;
    //    }
    //}

    //public void Close()
    //{
    //    _udpClient?.Close();
    //    _udpClient?.Dispose();
    //    _udpClient = null;
    //}

    //private static void CheckCrc(byte[] data)
    //{
    //    //Console.WriteLine(string.Join(" ", data.Select(b => b.ToString("X2"))));
    //    ushort crc = CalculateCrc(data, data.Length - 2);
    //    ushort receivedCrc = (ushort)(data[^1] << 8 | data[^2]);
    //    if( !(crc == receivedCrc))
    //    {
    //        throw new CrcException("CRC check failed");
    //    }
    //}

    //public static ushort CalculateCrc(byte[] data, int length)
    //{
    //    ushort crc = 0xFFFF;
    //    for (int i = 0; i < length; i++)
    //    {
    //        crc ^= data[i];
    //        for (int j = 0; j < 8; j++)
    //        {
    //            if ((crc & 1) != 0)
    //            {
    //                crc >>= 1;
    //                crc ^= 0xA001;
    //            }
    //            else
    //            {
    //                crc >>= 1;
    //            }
    //        }
    //    }
    //    return crc;
    //}
}
