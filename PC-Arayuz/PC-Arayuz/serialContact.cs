using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Arayuz
{
    public partial class serialContact
    {
        #region degiskenler
        private readonly char startChar = '{';
        private readonly char endChar = '}';
        private string openMessage;
        private string saveMessage;
        private string deltMessage;
        private string listMessage;
        private DateTime startTime = new DateTime();
        private int[] timeint = new int[3];
        private string isNumber = "0123456789";
        #endregion

        #region Yapici metodlar
        public serialContact(DateTime StartTime)
        {
            this.startTime = StartTime;
        }
        #endregion

        #region Kapsuller
        public string OpenMessage
        {
            get
            {
                openMessage = createOpenMessage();
                return openMessage;
            }
            set
            {

            }
        }

        public string SaveMessage
        {
            get
            {
                saveMessage = createSaveMessage();
                return saveMessage;
            }
            set
            {

            }
        }

        public string ListMessage
        {
            get
            {
                listMessage = createListMessage();
                return listMessage;
            }
            set
            {

            }
        }

        public string deleteMessage
        {
            get
            {
                deltMessage = createDeleteMessage();
                return deleteMessage;
            }
            set
            {

            }
        }
        #endregion

        #region DelMsg
        public string createDeleteMessage()
        {
            string timeText;
            string buff = "";
            string pieceOne = "@d^";
            int[] time = new int[3];

            calculateTime(time);
            timeText = convertIntString(time);

            buff = pieceOne + timeText;
            buff = startChar.ToString() + Convert.ToChar(calculateParityByte(buff)) + buff + endChar.ToString();
            return buff;
        }

        public string calculateDeleteQuestIndet(int index)
        {

            string buff = "";
            int[] indx = new int[1];
            indx[0] = index;
            buff += convertIntString(indx);

            buff = startChar.ToString() + Convert.ToChar(calculateParityByte(buff)) + buff + endChar.ToString();
            return buff;

        }
        #endregion

        #region ListMsg


        public string createListMessage()
        {
            string timeText;
            string buff = "";
            string pieceOne = "@l^";
            int[] time = new int[3];

            calculateTime(time);
            timeText = convertIntString(time);

            buff = pieceOne + timeText;
            buff = startChar.ToString() + Convert.ToChar(calculateParityByte(buff)) + buff + endChar.ToString();

            return buff;
        }

        #endregion

        #region SaveMsg
        public string createSaveMessage()
        {
            string timeText;
            string buff = "";
            string pieceOne = "@s^";
            int[] time = new int[3];

            calculateTime(time);
            timeText = convertIntString(time);

            buff = pieceOne + timeText;
            buff = startChar.ToString() + Convert.ToChar(calculateParityByte(buff)) + buff + endChar.ToString();
            return buff;
        }

        public string createQuestCoordinates(string text)
        {
            string buff = "";

            string[] temp = text.Split('.');
            
            int[] coordinate = new int[6];
            int count = 0;
            int buffValue = 0;
            for(byte loop = 0; loop < temp.Length; loop++)
            {
                if (checkIsNumber(temp[loop]))
                {
                    for(byte underLoop = 0; underLoop<temp[loop].Length; underLoop++)
                    {
                        buffValue += (Convert.ToInt32(temp[loop][underLoop]) % 48) * (int)Math.Pow(10, (temp[loop].Length - (underLoop + 1)));
                    }
                    coordinate[count] = buffValue;
                    count++;
                }
                else
                {
                    continue;
                }
                buffValue = 0;
            }

            buff = convertIntString(coordinate);
            buff = startChar.ToString() + Convert.ToChar(calculateParityByte(buff)) + buff + endChar.ToString();
            return buff;
        }

        private bool checkIsNumber(string v)
        {
            Boolean state = false;
            byte underLoop;
            for (byte loop=0; loop< v.Length; loop++)
            {
                for(underLoop = 0; underLoop < isNumber.Length; underLoop++)
                {
                    if(v[loop] == isNumber[underLoop])
                    {
                        state = true;
                        break;
                    }
                }
                if(underLoop == isNumber.Length)
                {
                    state = false;
                    break;
                }
            }
            return state;
        }
        #endregion

        #region OpenMsg
        public string createOpenMessage()
        {
            string timeText;
            string buff = "";
            string pieceOne = "@o^";
            int[] time = new int[3];

            calculateTime(time);
            timeText = convertIntString(time);

            buff = pieceOne + timeText;
            buff = startChar.ToString() + Convert.ToChar(calculateParityByte(buff)) + buff + endChar.ToString();

            return buff;
        }
        #endregion

        #region Zaman hesaplama alani
        public int[] calculateTime(int[] time)
        {
            time[0] = DateTime.Now.Minute - startTime.Minute;
            time[1] = DateTime.Now.Second - startTime.Second;
            time[2] = DateTime.Now.Millisecond - startTime.Millisecond;
            if (time[2] < 0)
            {
                time[2] += 1000;
                time[1]--;
            }
            if (time[1] < 0)
            {
                time[1] += 60;
                time[0]--;
            }
            if( time [0] < 0)
            {
                time[0] += 60;
            }
            time[2] /= 10;
            return time;
        }

        public string convertIntString(int[] character)
        {
            char[] set = new char[character.Length];
            string inCodding = "";
            for (byte loop = 0; loop < set.Length; loop++)
            {
                set[loop] = Convert.ToChar(character[loop]);
                inCodding += set[loop].ToString();
            }
            return inCodding;
        }
        #endregion

        #region Parity hesaplama
        private uint calculateParityByte(string buff)
        {
            uint parity = 0xFF;
            for (byte loop = 0; loop < buff.Length; loop++)
            {
                parity &= buff[loop];
            }
            return parity;
        }
        #endregion
    }
}
