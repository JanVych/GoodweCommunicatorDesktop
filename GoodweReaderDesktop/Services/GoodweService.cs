using ModulesApp.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodweReaderDesktop.Services;

public class GoodweService
{
    //public enum BatteryStatus
    //{
    //    NoBattery = 0,
    //    Standby = 1,
    //    Discharging = 2,
    //    Charging = 3,
    //}

    //public enum Days
    //{
    //    Sunday = 0x1,
    //    Monday = 0x2,
    //    Tuesday = 0x4,
    //    Wednesday = 0x8,
    //    Thursday = 0x10,
    //    Friday = 0x20,
    //    Saturday = 0x40,
    //    All = 0x7F,
    //}

    //[NotMapped]
    //private readonly ModbusRtuUdp _modbusRtuUdp = new(0xF7, 8899, "192.168.0.240", 2);


    //public uint? GetPV1Power() => _modbusRtuUdp.ReadU32Register(35105);

    ///// <summary>
    /////  Get Grid Power in wats
    ///// </summary>
    ///// <returns>negative value = consuming, positive value = suplying</returns>
    //public int? GetGridPower() => (int?)_modbusRtuUdp.ReadU32Register(35139);
    //public uint? GetBackupPower() => _modbusRtuUdp.ReadU32Register(35169);
    //public uint? GetLoadPower() => _modbusRtuUdp.ReadU32Register(35171);
    //public uint? GetBatteryPower() => _modbusRtuUdp.ReadU32Register(35182);
    //public float? GetInverterTemperature() => _modbusRtuUdp.ReadFLoatFromS16Register(35174) / 10;
    //public float? GetBatteryTemperature() => _modbusRtuUdp.ReadFLoatFromS16Register(37003) / 10;
    //public ushort? GetBatterySOC() => _modbusRtuUdp.ReadU16Register(37007);
    //public BatteryStatus? GetBatteryStatus()
    //{
    //    var value = _modbusRtuUdp.ReadU16Register(35184);
    //    return value == null ? null : (BatteryStatus)value;
    //}

    //public void SetBatteryDays(byte days)
    //{
    //    var value = (ushort)(0xFF00 + days);
    //    _modbusRtuUdp.WriteU16Register(37001, value);
    //}

    //public void SetBatteryStartTime(byte hour, byte minute)
    //{
    //    var value = (ushort)((hour << 8) + minute);
    //    _modbusRtuUdp.WriteU16Register(47515, value);
    //}

    //public void SetBatteryStopTime(byte hour, byte minute)
    //{
    //    var value = (ushort)((hour << 8) + minute);
    //    _modbusRtuUdp.WriteU16Register(47516, value);
    //}

    //public void SetBatteryCharge(short power) => SetBattery((short)-power);
    //public void SetBatteryDischarge(short power) => SetBattery(power);

    //// TODO change percent to power in Wats, 1 percent == 100W
    //private void SetBattery(short power)
    //{
    //    _modbusRtuUdp.WriteU16Register(47515, 0x0000);
    //    _modbusRtuUdp.WriteU16Register(47516, 0x173B);
    //    _modbusRtuUdp.WriteS16Register(47517, power);
    //    //var workWeek = _modbusRtuUdp.ReadU16Register(47518);
    //    //if (workWeek is not null)
    //    //{
    //    //    var workWeekAndMode = (ushort)(0xFF00 | workWeek);
    //    //    _modbusRtuUdp.WriteU16Register(47518, workWeekAndMode);
    //    //}
    //    //else
    //    //{
    //    //    Console.WriteLine("Error: SetBattery, when reading register 47518");
    //    //}
    //    _modbusRtuUdp.WriteU16Register(47518, 0xFF7F);
    //}
}
