using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace DVMegaToolsClone
{
    public partial class DVMegaToolsClone : Form
    {
        enum op_mode {
            AMBE,
            GMSK
        };

        op_mode m_op_mode = op_mode.AMBE;

        public DVMegaToolsClone()
        {
            InitializeComponent();

            this.comPort.Items.AddRange(SerialPort.GetPortNames());
            write.Enabled = false;
        }

        CHeaderData header = new CHeaderData();
        SerialPort myComPort;
        delegate void UpdateLogWindowDelegate(String msg);
        const uint RADIO_HEADER_LENGTH_BYTES = 41;
        const byte DVRPTR_FRAME_START = 0xD0; //44;
        bool bOpen = false;

        private void write_Click(object sender, EventArgs e)
        {
            yourCall.Enabled = false;
            myCall.Enabled = false;
            myCall2.Enabled = false;
            rpt1.Enabled = false;
            rpt2.Enabled = false;
            write.Enabled = false;

            //Write to ROM
            byte[] buffer = new byte[RADIO_HEADER_LENGTH_BYTES + 8 + 4 + 2 + 2 + (m_op_mode == op_mode.GMSK ? 2 : 0) + 1];

            int offset = 4;
            buffer[0] = DVRPTR_FRAME_START;
            buffer[1] = (byte)(m_op_mode == op_mode.AMBE ? 0x35 : 0x37); //0x37 for GMSK
            buffer[2] = 0x00;
            buffer[3] = (byte)(m_op_mode == op_mode.AMBE ? 0x21 : 0x24); //DVMega command 0x24 for GMSK

            buffer[0 + offset] = DVRPTR_FRAME_START;
            buffer[1 + offset] = 0x2F;
            buffer[2 + offset] = 0x00;
            buffer[3 + offset] = 0x17; //DVRPTR_HEADER

            buffer[4 + offset] = 10; // m_txCounter (dummy)
            buffer[5 + offset] = 0x00;
            buffer[6 + offset] = 0x00;
            buffer[7 + offset] = 0x00;

            //Start of header ----
            buffer[8 + offset] = header.Flag1;
            buffer[9 + offset] = header.Flag2;
            buffer[10 + offset] = header.Flag3;

            Array.Copy(header.getRptCall2(), 0, buffer, offset + 11, 8);
            Array.Copy(header.getRptCall1(), 0, buffer, offset + 19, 8);
            Array.Copy(header.getYourCall(), 0, buffer, offset + 27, 8);
            Array.Copy(header.getMyCall(), 0, buffer, offset + 35, 8);
            Array.Copy(header.getMyCall2(), 0, buffer, offset + 43, 4);

            //P_FCS of DSTAR
            CCITTChecksum cksum1 = new CCITTChecksum();
            cksum1.update(buffer, (ushort)(offset + 8), (ushort)(RADIO_HEADER_LENGTH_BYTES - 2));
            cksum1.result(buffer, (ushort)(offset + 8 + RADIO_HEADER_LENGTH_BYTES - 2));
            //--- until here 43 (2BH) bytes

            buffer[offset + 4 + RADIO_HEADER_LENGTH_BYTES + 4] = 0x00;
            buffer[offset + 4 + RADIO_HEADER_LENGTH_BYTES + 5] = 0x00;
            buffer[offset + 4 + RADIO_HEADER_LENGTH_BYTES + 6] = 0x0b;

            //I don't know why 0x0b, but original DVMega tools does so.
            if (m_op_mode == op_mode.GMSK)
            {
                buffer[offset + 4 + RADIO_HEADER_LENGTH_BYTES + 7] = (byte)(rxInvert.Checked ? 0x01 : 0x00);
                buffer[offset + 4 + RADIO_HEADER_LENGTH_BYTES + 8] = (byte)(txInvert.Checked ? 0x01 : 0x00);

                buffer[offset + 4 + RADIO_HEADER_LENGTH_BYTES + 9] = 0x00;
                buffer[offset + 4 + RADIO_HEADER_LENGTH_BYTES + 10] = 0x0b;
            }
            else
            {
                buffer[offset + 4 + RADIO_HEADER_LENGTH_BYTES + 7] = 0x00;
                buffer[offset + 4 + RADIO_HEADER_LENGTH_BYTES + 8] = 0x0b;
            }

            //cksum1.reset();
            //cksum1.update(buffer, (ushort)(offset + 4), (ushort)(RADIO_HEADER_LENGTH_BYTES + 4));
            //cksum1.result(buffer, (ushort)(offset + 4 + RADIO_HEADER_LENGTH_BYTES + 4));
            //cksum1.reset();
            //cksum1.update(buffer, (ushort)offset, (ushort)(RADIO_HEADER_LENGTH_BYTES + 8 + 2));
            //cksum1.result(buffer, (ushort)(RADIO_HEADER_LENGTH_BYTES + 8 + 2 + offset));

            try
            {
                myComPort.Write(buffer, 0, buffer.Length);
                int cnt = 0;
                while (cnt == 0)
                {
                    Thread.Sleep(200);
                    cnt = myComPort.Read(buffer, 0, 4);
                }
                myComPort.Close();
                string resp = Encoding.ASCII.GetString(buffer, 0, cnt);
                if (resp == "OK2" || resp == "OK3")
                {
                    logOutput("Callsign successfully written");
                }
            }
            catch (Exception ex)
            {
                myComPort.Close();
                logOutput("Failed to write data, ex: " + ex.Message);
            }
        }

        private void comPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Comport Changed
            string curComPort = (string)this.comPort.SelectedItem;

            yourCall.Enabled = false;
            myCall.Enabled = false;
            myCall2.Enabled = false;
            rpt1.Enabled = false;
            rpt2.Enabled = false;
            write.Enabled = false;

            try
            {
                myComPort = new SerialPort(curComPort, 115200, Parity.None, 8, StopBits.One);
                myComPort.WriteTimeout = 1000;
                myComPort.ReadTimeout = 1000;
                myComPort.Open();

                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        checkVersion();
                        break;
                    }
                    catch (Exception ex2)
                    {
                        if (i == 4)
                        {
                            throw new Exception(string.Format("Failed to open {0}", curComPort));
                        }
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                logOutput(String.Format("Failed to open {0}, ex: {1}", curComPort, ex.Message));
            }
        }

        private void checkVersion()
        {
            byte[] buffer = new byte[] { DVRPTR_FRAME_START, 0x01, 0x00, 0x22, 0, 0x0b };
            myComPort.Write(buffer, 0, 6);
            int cnt = 0;
            while (cnt == 0)
            {
                Thread.Sleep(500);
                cnt = myComPort.Read(buffer, 0, 4);
            }
            //Expects C10A as version string
            if (cnt == 4)
            {
                string version = Encoding.ASCII.GetString(buffer, 0, cnt);
                //C10A for AMBE board
                //C12A for AMBE+GMSK
                if (version == "C10A")
                {
                    m_op_mode = DVMegaToolsClone.op_mode.AMBE;
                    txInvert.Enabled = false;
                    rxInvert.Enabled = false;
                }
                else if (version == "C12A")
                {
                    m_op_mode = DVMegaToolsClone.op_mode.GMSK;
                    txInvert.Enabled = true;
                    rxInvert.Enabled = true;
                }
                else
                {
                    logOutput("Got wrong version string: " + version);
                    myComPort.Close();
                    throw new Exception("Wrong version");
                }

                //Good
                logOutput("Version string: " + version + " mode: " + m_op_mode);
                comPort.Enabled = false;
                bOpen = true;

                yourCall.Enabled = true;
                myCall.Enabled = true;
                myCall2.Enabled = true;
                rpt1.Enabled = true;
                rpt2.Enabled = true;
            }
            else
            {
                //Wrong version
                logOutput("Got wrong version string");
                throw new Exception("Wrong version");
            }
        }

        private void logOutput(String message)
        {
            // Check whether the caller must call an invoke method when making method calls to listBoxCCNetOutput because the caller is 
            // on a different thread than the one the listBoxCCNetOutput control was created on.
            if (logOutputBox.InvokeRequired)
            {
                var update = new UpdateLogWindowDelegate(logOutput);
                logOutputBox.Invoke(update, message);
            }
            else
            {
                logOutputBox.Items.Add(message);
                if (logOutputBox.Items.Count > 5)
                {
                    logOutputBox.Items.RemoveAt(0); // remove first line
                }
                // Make sure the last item is made visible
                logOutputBox.SelectedIndex = logOutputBox.Items.Count - 1;
                logOutputBox.ClearSelected();
            }
        }

        void checkAllFilled()
        {
            if (header.getRptCall2().Length > 0 &&
                header.getRptCall1().Length > 0 &&
                header.getYourCall().Length > 0 &&
                header.getMyCall().Length > 0 &&
                header.getMyCall2().Length > 0 && 
                bOpen)
            {
                write.Enabled = true;
            }
            else
            {
                write.Enabled = false;
            }
        }

        private void yourCall_TextChanged(object sender, EventArgs e)
        {
            header.setRptCall2(this.yourCall.Text);
            checkAllFilled();
        }

        private void myCall_TextChanged(object sender, EventArgs e)
        {
            header.setMyCall(this.myCall.Text);
            checkAllFilled();
        }

        private void myCall2_TextChanged(object sender, EventArgs e)
        {
            header.setMyCall2(this.myCall2.Text);
            checkAllFilled();
        }

        private void rpt1_TextChanged(object sender, EventArgs e)
        {
            header.setRptCall1(this.rpt1.Text);
            checkAllFilled();
        }

        private void rpt2_TextChanged(object sender, EventArgs e)
        {
            header.setRptCall2(this.rpt2.Text);
            checkAllFilled();
        }
    }
}