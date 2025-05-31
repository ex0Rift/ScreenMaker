using System.IO.Ports;

namespace Console_screen;

public class Controller
{
    static SerialPort serialPort;

    public Controller()
    {
        serialPort = new SerialPort("COM3",9600);
        serialPort.Open();
    }

    public int[] Getdata()
    {
        var data = serialPort.ReadLine();
        int[] datal = data.Split(",").Select(int.Parse).ToArray();
        return datal;
    }
}