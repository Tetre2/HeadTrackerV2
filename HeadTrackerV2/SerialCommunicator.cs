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
            //NOTE: checksum = args[0] + args[1] + ... + args[n] + 1 // to offset serial.parse of bad character is 0
            //<0> //Arduino Dump data, i.e. Request Arduino print it all to serial
            //<1> //reset view
            //<2 sensX sensY sensZ checksum>
            //<3 expX expY expZ checksum>
            //<4 offsetX offsetY offsetZ checksum>
            //<5 limitX limitY limitZ checksum>
            //<6 bool> //Toggle Smoothness
            //<7> //run calibrateGyro
            //<8 bool> //Turn on/off
            //<9 bool> //Use Exponential

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

        //<0> //Arduino Dump data, i.e. Request Arduino print it all to serial
        public void getGyroData()
        {
            writeToSerial("<0>");
        }
        
        //<1> //reset view
        public void resetView()
        {
            writeToSerial("<1>");
        }

        //<2 sensX sensY sensZ checksum>
        public void setSensitivity(float pitch, float yaw, float roll)
        {
            byte checksum = (byte)(pitch + yaw + roll + 1);
            String s = "<2" + pitch.ToString().Replace(',','.') + ";" + yaw.ToString().Replace(',', '.') + ";" + roll.ToString().Replace(',', '.') + ";" + checksum.ToString() + ">";
            writeToSerial(s);
        }
        
        //<3 expX expY expZ checksum>
        public void setExponentialView(float pitch, float yaw, float roll)
        {
            byte checksum = (byte)(pitch + yaw + roll + 1);
            String s = "<3" + pitch.ToString().Replace(',', '.') + ";" + yaw.ToString().Replace(',', '.') + ";" + roll.ToString().Replace(',', '.') + ";" + checksum.ToString() + ">";
            writeToSerial(s);
        }
        
        //<4 offsetX offsetY offsetZ checksum>
        public void setOffset(float pitch, float yaw, float roll)
        {
            byte checksum = (byte)(pitch + yaw + roll + 1);
            String s = "<4" + pitch.ToString().Replace(',', '.') + ";" + yaw.ToString().Replace(',', '.') + ";" + roll.ToString().Replace(',', '.') + ";" + checksum.ToString() + ">";
            writeToSerial(s);
        }
        
        //<5 limitX limitY limitZ checksum>
        public void setLimit(float pitch, float yaw, float roll)
        {
            byte checksum = (byte)(pitch + yaw + roll + 1);
            String s = "<5" + pitch.ToString().Replace(',', '.') + ";" + yaw.ToString().Replace(',', '.') + ";" + roll.ToString().Replace(',', '.') + ";" + checksum.ToString() + ">";
            writeToSerial(s);
        }

        //<6 bool> //Toggle Smoothness
        public void setSmoothness(bool enable)
        {
            String s = "<6" + (enable ? '1' : '0') + ">";
            writeToSerial(s);
        }

        //<7> //run calibrateGyro
        public void calibrateGyro()
        {
            writeToSerial("<7>");
        }

        //<8 bool> //Turn on/off
        public void setEnabled(bool enable)
        {
            String s = "<8" + (enable ? '1' : '0') + ">";
            writeToSerial(s);
        }

        //<9 bool> //Use Exponential
        public void setExponentialMode (bool enable)
        {
            String s = "<9" + (enable ? '1' : '0') + ">";
            writeToSerial(s);
        }

        public void setDebug(bool enable)
        {

        }

    }
}
