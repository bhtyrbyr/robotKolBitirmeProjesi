using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace PC_Arayuz
{
    public partial class Form1 : Form
    {
        
        string takeMessage;
        public DateTime startTime;
        public serialContact SC;
        public byte questCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void turnAllEnabledFalse()
        {
            startPosTxt.Enabled = false;
            endPosTxt.Enabled = false;
            disconnectBtn.Enabled = false;
            saveBtn.Enabled = false;
            checkBtn.Enabled = false;
            start.Enabled = false;
            end.Enabled = false;
            fillComboBoxQuestCount();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            SC = new serialContact(startTime);
            turnAllEnabledFalse();
            string[] portNames = SerialPort.GetPortNames();
            foreach (var port in portNames)
            {
                portComboBox.Items.Add(port);
            }

        }

        private void connectBox_Click(object sender, EventArgs e)
        {
            string message = SC.OpenMessage;
            listBox1.Items.Add(message);
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = portComboBox.SelectedItem.ToString();
                    serialPort1.BaudRate = Convert.ToInt32(baudrateComboBox.SelectedItem);
                    serialPort1.Open();
                    serialPort1.Write(message);
                    portComboBox.Enabled = false;
                    baudrateComboBox.Enabled = false;
                    connectBox.Enabled = false;
                    disconnectBtn.Enabled = true;
                    saveBtn.Enabled = true;
                    checkBtn.Enabled = true;
                    startPosTxt.Enabled = true;
                    endPosTxt.Enabled = true;
                    start.Enabled = true;
                    end.Enabled = true;
                }
                else
                {
                    throw new NotImplementedException("Acik olan portu tekrar acamazsiniz!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                portComboBox.Enabled = true;
                baudrateComboBox.Enabled = true;
                connectBox.Enabled = true;
                turnAllEnabledFalse();
                serialPort1.Close();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string questCoordinates = startPosTxt.Text.ToString() + "./." + endPosTxt.Text.ToString();
                string[] buff = questCoordinates.Split('.');
                if (buff[3] == "/")
                {
                    dataTransmit(SC.createSaveMessage(), serialPort1);
                    questCoordinates = SC.createQuestCoordinates(questCoordinates);
                    dataTransmit(questCoordinates, serialPort1);
                }
                else
                {
                    throw new NotImplementedException("Gorev koordinatlarini girin!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string delMsg;
            string delIndex;
            try
            {
                if(comboBox1.SelectedIndex >=0 && comboBox1.SelectedIndex <= questCount)
                {
                    delMsg = SC.createDeleteMessage();
                    dataTransmit(delMsg, serialPort1);
                    delIndex  = SC.calculateDeleteQuestIndet(comboBox1.SelectedIndex);
                    dataTransmit(delIndex, serialPort1);
                }
                else
                {
                    throw new NotImplementedException("Gecerli deger girin!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), " ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            string checkMsg = SC.ListMessage;

            dataTransmit(checkMsg, serialPort1);
        }
        public delegate void takeData(string s);

        public void dataProcessing(string s)
        {

            if (s[s.Length - 1] == '}')
            {
                takeMessage += s;
                serialMsg SM = new serialMsg(startTime);
                if(takeMessage[0] == 'l')
                {
                    listBox1.Items.Clear();
                    string[] questList = SM.encoddingMsg(takeMessage).Split('~');
                    for(byte loop = 0; loop < questList.Length; loop++)
                    {
                        listBox1.Items.Add(questList[loop]);
                    }
                    questCount = SM.questCount;
                    fillComboBoxQuestCount();
                }
                else if(takeMessage[0] == 'z' && takeMessage[1] == '}')
                {
                    robot_arm_show_screen1.RobotArmState = robot_arm_show_screen.robotArmState.BUSSY;
                }
                else if(takeMessage[0] == 'z' && takeMessage[1] == '!')
                {
                    robot_arm_show_screen1.RobotArmState = robot_arm_show_screen.robotArmState.AVAILABLE;
                }
                else if(takeMessage == "y}")
                {
                    robot_arm_show_screen1.TakeorDrop = robot_arm_show_screen.takeDropState.TAKE;
                }
                else if(takeMessage == "y!}")
                {
                    robot_arm_show_screen1.TakeorDrop = robot_arm_show_screen.takeDropState.DROP;
                }
                else
                {
                    listBox2.Items.Add(SM.encoddingMsg(takeMessage));
                }
                takeMessage = "";
            }
            else
            {
                takeMessage += s;
            }
        }

        private void messageAddList(string s)
        {
            string[] buff;
            buff = s.Split('\n');
            for (int loop = 0; loop < buff.Length; loop++)
            {
                listBox2.Items.Add(buff[loop]);
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = serialPort1.ReadExisting();
            listBox2.Invoke(new takeData(dataProcessing), receivedData);
        }
        private void dataTransmit(string data, SerialPort comPort)
        {
            comPort.Write(data);
        }

        private void APP_EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }
        
        public void fillComboBoxQuestCount()
        {
            comboBox1.Items.Clear();

            comboBox1.Enabled = true;
            deleteBtn.Enabled = true;
            if (questCount != 0)
            {
                for (byte loop = 1; loop <= questCount; loop++)
                {
                    comboBox1.Items.Add(loop.ToString() + ". Gorev");
                }
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                deleteBtn.Enabled = false;
                comboBox1.Enabled = false;
                comboBox1.Text = "Gorev yok";
            }
        }

        public int[] tempTime = new int[3];
        private void timer1_Tick(object sender, EventArgs e)
        {
            tempTime = SC.calculateTime(tempTime);
            fillComboBoxQuestCount();
            label4.Text = "Calisma suresi : " + tempTime[0].ToString() + " . " + tempTime[1].ToString() + " / " + tempTime[2].ToString();
        }

        private void robot_arm_show_screen1_Click(object sender, EventArgs e)
        {
        }

        private void robot_arm_show_screen1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = e.Location;
            if(e.Button == MouseButtons.Left)
            {
                robot_arm_show_screen1.StartPoint = point;
            }
            else if( e.Button == MouseButtons.Middle)
            {
                robot_arm_show_screen1.EndPoint = point;
            }
        }
    }
}
