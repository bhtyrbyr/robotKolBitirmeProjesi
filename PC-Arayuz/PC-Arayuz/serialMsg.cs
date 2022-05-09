using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Arayuz
{
    public class serialMsg
    {
        private readonly string openMsg = "Baglanti basarili!";
        private readonly string saveMsgOK = "Gorev basarili bir sekilde kaydedildi.";
        private readonly string daveMsgERR = "Gorev kaydedilirken bir hata olustu!";
        private readonly string delMsgOK = "Gorev basarili bir sekilde silindi.";
        private readonly string delMsgERR = "Gorev silinirken bir hata olustu!";
        private readonly string listMsg = "Gorev listesi";
        private readonly string listItems = ". Gorev";
        private readonly string listEmptyMsg = "Gosterilecek gorev yok";
        public byte questCount = 0;
        private serialContact SCcrtMsg;


        public serialMsg(DateTime startTime)
        {
            SCcrtMsg = new serialContact(startTime);
        }

        public string encoddingMsg(string text)
        {
            string[] buff = text.Split('~');
            string encoddedMsg = "";
            string msgMode = "";
            for (byte loop = 0; loop< buff[0].Length; loop++)
            {
                msgMode += buff[0][loop].ToString();
            }
            int[] time = new int[3];
            SCcrtMsg.calculateTime(time);
            string timeText = time[0].ToString() + " . " + time[1].ToString() + " . " + time[2].ToString();

            switch (msgMode)
            {
                case "o}":
                    {
                        return timeText + " | \t" + openMsg;
                    }
                case "s}":
                    {
                        return timeText + " | \t" + saveMsgOK;
                    }
                case "s!}":
                    {
                        return timeText + " | \t" + daveMsgERR;
                    }
                case "d}":
                    {
                        return timeText + " | \t" + delMsgOK;
                    }
                case "d!}":
                    {
                        return timeText + " | \t" + delMsgERR;
                    }
                case "l":
                    {
                        Form1 formObj = new Form1();
                        string temp = "";
                        temp += listMsg.ToString() + "~";
                        byte loop = 0;
                        for (loop=1; loop < buff.Length; loop++)
                        {
                            string[] questTemp = buff[loop].Split('/');
                            if(questTemp.Length > 1 && questTemp[1][questTemp.Length -1] == '}')
                            {
                                questTemp[1].Remove(-1, 1);
                            }

                            temp += loop.ToString() + listItems + "~" + "Baslangic " + questTemp[0] + " Bitis " + questTemp[1] + "~";
                            questCount++;
                        }
                        temp += "~Son guncelleme > " + timeText;
                        return temp;

                    }
                case "l!}":
                    {
                        questCount = 0;
                        return listEmptyMsg + "~Son guncelleme > " + timeText;
                    }
            }

            return encoddedMsg;
        }
    }
}
