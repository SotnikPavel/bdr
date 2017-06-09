using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace RfidWorker
{

    public class RfidRead
    {
        SerialPort currentPort;

        public List<string> GetPorts()
        {
            try
            {
                string[]  ports = SerialPort.GetPortNames();
                return ports.ToList();
            }
            catch { }
            return null;
        }

        public bool ReadUid(string port, out string resultString)
        {
            currentPort = new SerialPort(port, 9600);

            System.Threading.Thread.Sleep(500); 

            currentPort.BaudRate = 9600;
            currentPort.DtrEnable = true;
            currentPort.ReadTimeout = 1000;
            try
            {
                currentPort.Open();
                currentPort.DiscardInBuffer();
            }
            catch
            {
                currentPort.Close();
                resultString = "PortError";
                return false;
            }

            currentPort.Write("1");
            int inf = 0;
            string res = "";
            while (inf < 10)
            {
                try
                {

                    res = currentPort.ReadLine();
                    if(res.Contains("<<") && res.Contains(">>"))
                    {
                        res = res.Substring(res.IndexOf("<<") + 2, res.IndexOf(">>") - res.IndexOf("<<") - 2);
                        currentPort.DiscardInBuffer();
                        break;
                    }
                    inf++;
                }
                catch
                {
                    inf++;
                }
            }
            if (res != "")
            {
                currentPort.Close();
                resultString = res;
                return true;
            }
            else
            {
                currentPort.Close();
                resultString = "TimeOutError";
                return false;
            }
        }

    }
}
