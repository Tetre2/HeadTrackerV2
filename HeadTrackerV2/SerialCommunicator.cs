using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;


namespace HeadTrackerV2
{
    internal class SerialCommunicator
    {
        SerialPort mySerialPort;
        Action<String> printToTextbox;

        public SerialCommunicator(Action<String> printToTextbox)
        {
            this.printToTextbox = printToTextbox;

            mySerialPort = new SerialPort();
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(dataRecived);

            // ----- Protocol -----
            //<0> //Arduino Dump data, i.e. Request Arduino print it all to serial
            //<1> //reset view
            //<2 sensX sensY sensZ checksum>
            //<3 expX expY expZ checksum>
            //<4 offsetX offsetY offsetZ checksum>
            //<5 limitX limitY limitZ checksum>
            //<6 bool> //Toggle Smoothness
            //<7> //run calibrateGyro
            //<8 bool> //Turn on/off

        }

        public void close()
        {
            if (mySerialPort.IsOpen)
            {
                Thread CloseDown = new Thread(new ThreadStart(CloseSerialOnExit)); //close port in new thread to avoid hang
                CloseDown.Start(); //close port in new thread to avoid hang
            }
        }

        private void CloseSerialOnExit()
        {
            try
            {
                mySerialPort.Close(); //close the serial port
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //catch any serial port closing error messages
            }
            //this.Invoke(new EventHandler(NowClose)); //now close back in the main thread
        }

        private void NowClose(object sender, EventArgs e)
        {
            //this.Close(); //now close the form
        }

        public bool open()
        {
            try
            {
                mySerialPort.Open();
                printToTextbox("Connected to device!");
            }
            catch (Exception)
            {

                printToTextbox("ERROR: Can not open selected port!");
                return false;
            }
            return true;
        }

        public bool setCOMPort(String port)
        {
            try
            {
                //close();//Dont know if necessary
                mySerialPort.PortName = port;
            }
            catch (Exception)
            {

                printToTextbox("ERROR: No valid COM port with that name!");
                return false;
            }
            return true;
        }

        public String[] getOpenPorts()
        {
            return SerialPort.GetPortNames(); ;
        }

        private void dataRecived(object sender, SerialDataReceivedEventArgs e)
        {
            String data = mySerialPort.ReadExisting();
            if (data != null)
            {
                printToTextbox(data);
            }


        }

        private void writeToSerial(String message)
        {
            if (mySerialPort != null && mySerialPort.IsOpen)
            {
                mySerialPort.Write(message);
            }
            else
            {
                printToTextbox("ERROR: Not connected to a device!");
            }
        }

        private void writeToSerial(Byte[] message)
        {
            if (mySerialPort != null && mySerialPort.IsOpen)
            {
                mySerialPort.Write(message, 0, message.Length);
            }
            else
            {
                printToTextbox("ERROR: Not connected to a device!");
            }
        }

        public void getGyroData()
        {
            writeToSerial("<0>");
        }

        public void resetView()
        {
            writeToSerial("<1>");
        }

        public void calibrateGyro()
        {
            writeToSerial("<7>");
        }

        public void setSensitivity(float pitch, float yaw, float roll)
        {
            byte checksum = (byte)(pitch + yaw + roll);
            String s = "<2" + pitch.ToString().Replace(',','.') + ";" + yaw.ToString().Replace(',', '.') + ";" + roll.ToString().Replace(',', '.') + ";" + checksum.ToString() + ">";
            writeToSerial(s);

            /*byte[] pitchArr = BitConverter.GetBytes(pitch);
            byte[] yawArr = BitConverter.GetBytes(yaw);
            byte[] rollArr = BitConverter.GetBytes(roll);
            byte[] checksum = BitConverter.GetBytes(pitch + yaw + roll);

            byte[] msg = { (byte) '<', (byte) '2',
                pitchArr[0], (byte) ';', pitchArr[1], (byte) ';', pitchArr[2], (byte) ';', pitchArr[3], (byte) ';',
                yawArr[0], (byte) ';', yawArr[1], (byte) ';', yawArr[2], (byte) ';', yawArr[3], (byte) ';',
                rollArr[0], (byte) ';', rollArr[1], (byte) ';', rollArr[2], (byte) ';', rollArr[3], (byte) ';',
                checksum[0], (byte) ';', checksum[1], (byte) ';', checksum[2], (byte) ';', checksum[3],
                (byte) '>' };

            string hexString = Convert.ToHexString(msg);

            Console.WriteLine($"   Hex value: \"{hexString}\"");*/
        }

        public void setExponentialView(float pitch, float yaw, float roll)
        {

        }

        public void setClampView(bool enable)
        {

        }

        public void setEnabled(bool enable)
        {

        }

        public void setDebug(bool enable)
        {

        }

    }
}
