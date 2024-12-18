using System;
using System.Globalization;
using System.IO.Ports;
using Unity.Collections;
using UnityEngine;

public class SerialHandler : MonoBehaviour
{

    public static SerialHandler instance;

    private SerialPort _serial;

    // Common default serial device on a Windows machine
    [SerializeField] private string serialPort = "COM1";
    [SerializeField] private int baudrate = 115200;


    float xVar;
    float yVar;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        _serial = new SerialPort(serialPort, baudrate);
        // Guarantee that the newline is common across environments.
        _serial.NewLine = "\n";
        // Once configured, the serial communication must be opened just like a file : the OS handles the communication.
        _serial.Open();

        xVar = 0.5f;
        yVar = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Return early if not open, prevent spamming errors for no reason.
        if (!_serial.IsOpen) return;
        // Prevent blocking if no message is available as we are not doing anything else
        // Alternative solutions : set a timeout, read messages in another thread, coroutines, futures...
        if (_serial.BytesToRead <= 0) return;

        // Trim leading and trailing whitespaces, makes it easier to handle different line endings.
        // Arduino uses \r\n by default with `.println()`.
        var message = _serial.ReadLine().Trim();

        // Split the message on spaces, in case we want to pass a value as well.
        var messageParts = message.Split(' ');
        int i = 0;
        if (messageParts.Length > 2)
        {
            switch (messageParts[0])
            {
                case "fire":
                    break;
                case "change":
                    break;
                default:
                    Debug.Log($"Unknown message: {message}");
                    break;
            }
            i++;
        }
        xVar = float.Parse(messageParts[i], CultureInfo.InvariantCulture);
        yVar = float.Parse(messageParts[i+1], CultureInfo.InvariantCulture);
    }

    public void SetLed(bool newState)
    {
        if (!_serial.IsOpen) return;
        _serial.WriteLine(newState ? "LED ON" : "LED OFF");
    }

    private void OnDestroy()
    {
        if (!_serial.IsOpen) return;
        _serial.Close();
    }

    public Vector2 GetVector()
    {
        return new Vector2(xVar, yVar);
    }
}
