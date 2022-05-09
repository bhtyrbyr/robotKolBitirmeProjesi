using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Arayuz
{
    public class robot_arm_show_screen : Control
    {
        //Variables
        private float robotArmOutsideCircle = 180.0F;
        private float robotArmInsideCircle = 180.0F;
        private float armRotateDegree = 0.0F;
        private float ArmLenght = 200.0F;
        private float firstArmDegree = 60.0F;
        private float secondArmDegree = 60.0F;
        private int robotArmCrossSize = 10;
        private int ArmWidth = 20;
        private int takeDropGaugeRectangleSize = 25;
        private int positionGaugeRectangleSize = 280;
        private int armPositionX = 999;
        private int armPositionY = 999;
        private int armPositionZ = 999;

        private Point[] robotArmStartPos = new Point[5];
        private short startCount = 0;
        private Point[] robotArmEndPos = new Point[5];
        private short endCount = 0;

        private Boolean drawRefresh = true;
        private takeDropState takeorDrop = takeDropState.DROP;
        private robotArmState robotArmStt = robotArmState.AVAILABLE;


        public enum robotArmState
        {
            BUSSY,
            AVAILABLE
        };

        public enum takeDropState
        {
            TAKE,
            DROP
        };

        /// <summary>
        /// Yapici metod
        /// </summary>
        public robot_arm_show_screen()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        #region Properties
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Robot kolun donus acisi.")]
        public float ArmRotateDegree
        {
            get
            {
                return armRotateDegree;
            }
            set
            {
                drawRefresh = true;
                armRotateDegree = value;
                this.Refresh();
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Robot kolun ilk parcanin acisi.")]
        public float FirstArmDegree
        {
            get
            {
                return firstArmDegree;
            }
            set
            {
                drawRefresh = true;
                firstArmDegree = value;
                this.Refresh();
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Robot kolun ikinci parcanin acisi.")]
        public float SecondArmDegree
        {
            get
            {
                return secondArmDegree;
            }
            set
            {
                drawRefresh = true;
                secondArmDegree = value;
                this.Refresh();
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Robot kolun x konumunu belirtir.")]
        public int ArmPositionX
        {
            get
            {
                return armPositionX;
            }
            set
            {
                drawRefresh = true;
                armPositionX = value;
                this.Refresh();
            }
        }


        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Robot kolun y konumunu belirtir.")]
        public int ArmPositionY
        {
            get
            {
                return armPositionY;
            }
            set
            {
                drawRefresh = true;
                armPositionY = value;
                this.Refresh();
            }
        }
        
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Robot kolun z konumunu belirtir.")]
        public int ArmPositionZ
        {
            get
            {
                return armPositionZ;
            }
            set
            {
                drawRefresh = true;
                armPositionZ = value;
                this.Refresh();
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Carpi Boyutlarini belirler")]
        public int CorssSize
        {
            get
            {
                return robotArmCrossSize;
            }
            set
            {
                drawRefresh = true;
                robotArmCrossSize = value;
                this.Refresh();
            }
        }
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Dis cember acisinin belirler")]
        public float OutsideCircle
        {
            get
            {
                return robotArmOutsideCircle;
            }
            set
            {
                drawRefresh = true;
                robotArmOutsideCircle = value;
                this.Refresh();
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Ic cember acisinin belirler")]
        public float InsideCircle
        {
            get
            {
                return robotArmInsideCircle;
            }
            set
            {
                drawRefresh = true;
                robotArmInsideCircle = value;
                this.Refresh();
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Bitis konumlarini tutar")]
        public Point EndPoint
        {
            get
            {
                return robotArmEndPos[0];
            }
            set
            {
                drawRefresh = true;
                robotArmEndPos[endCount] = value;
                endCount++;
                endCount %= 5;
                this.Refresh();
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Baslangic konumlarini tutar")]
        public Point StartPoint
        {
            get
            {
                return robotArmStartPos[0];
            }
            set
            {
                drawRefresh = true;
                robotArmStartPos[startCount] = value;
                startCount++;
                startCount %= 5;
                this.Refresh();
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Robot kolun tutma pozisyonunda olup olmadigini belirtir.")]
        public takeDropState TakeorDrop
        {
            get
            {
                return takeorDrop;
            }
            set
            {
                drawRefresh = true;
                takeorDrop = value;
                this.Refresh();
            }
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Gostege ozellikleri"),
        System.ComponentModel.Description("Robot kolun gorevde olup olmadigini belirtir.")]
        public robotArmState RobotArmState
        {
            get
            {
                return robotArmStt;
            }
            set
            {
                drawRefresh = true;
                robotArmStt = value;
                this.Refresh();
            }
        }
        #endregion
        //Draw
        protected override void OnPaint(PaintEventArgs e)
        {
            if (drawRefresh)
            {
                drawRefresh = false;
                Point[] arcLinePoint = new Point[2];
                Pen linePen = new Pen(Color.Blue, 3.0F);
                Pen redCross = new Pen(Color.Red, 2F);
                Pen greenCross = new Pen(Color.Green, 2F);
                Point[] startCrossPoint = new Point[4];
                Point[] endCrossPoint = new Point[4];
                Font drawSubTextFont = new Font("Arial", 15);

                drawStatusBar(e);

                drawInsideandOutsideCircle(e, linePen, arcLinePoint);

                drawStartCross(e, redCross);
                drawEndCross(e, greenCross);

                drawStartEndPoints(e, redCross, greenCross, startCrossPoint, endCrossPoint, drawSubTextFont);

                drawRobotArm(e);
            }
        }



        private void drawRobotArm(PaintEventArgs e)
        {
            Pen redPen = new Pen(Color.Red);
            Pen greenPen = new Pen(Color.Green);
            Brush redBrush = new SolidBrush(Color.Red);
            Brush greenBrush = new SolidBrush(Color.Green);
            Brush yellowBrush = new SolidBrush(Color.Yellow);
            Brush darkBlueBrush = new SolidBrush(Color.DarkBlue);
            Brush whiteBrush = new SolidBrush(Color.White);
            Matrix rotateMatrix = new Matrix();

            int[] armsLenght = new int[2];
            armsLenght[0] = 200;
            armsLenght[1] = 200;
            calculateArmPieceLength(armsLenght);
            //draw first piece 
            Point armFirstPieceStartPoint = new Point(440, 600);
            Point[] firstPiecePoints = new Point[4];
            firstPiecePoints[0].X = armFirstPieceStartPoint.X - ArmWidth / 2;
            firstPiecePoints[0].Y = armFirstPieceStartPoint.Y - armsLenght[0];

            firstPiecePoints[1].X = armFirstPieceStartPoint.X + ArmWidth / 2;
            firstPiecePoints[1].Y = armFirstPieceStartPoint.Y - armsLenght[0];

            firstPiecePoints[2].X = armFirstPieceStartPoint.X + ArmWidth / 2;
            firstPiecePoints[2].Y = armFirstPieceStartPoint.Y + 25;

            firstPiecePoints[3].X = armFirstPieceStartPoint.X - ArmWidth / 2;
            firstPiecePoints[3].Y = armFirstPieceStartPoint.Y + 25;



            //draw second piece 
            int buff = firstPiecePoints[0].Y;
            Point armSecondPieceStartPoint = new Point(440, buff);
            Point[] secondPiecePoints = new Point[4];
            secondPiecePoints[0].X = armSecondPieceStartPoint.X - ArmWidth / 2;
            secondPiecePoints[0].Y = armSecondPieceStartPoint.Y - armsLenght[1];

            secondPiecePoints[1].X = armSecondPieceStartPoint.X + ArmWidth / 2;
            secondPiecePoints[1].Y = armSecondPieceStartPoint.Y - armsLenght[1];

            secondPiecePoints[2].X = armSecondPieceStartPoint.X + ArmWidth / 2;
            secondPiecePoints[2].Y = armSecondPieceStartPoint.Y;

            secondPiecePoints[3].X = armSecondPieceStartPoint.X - ArmWidth / 2;
            secondPiecePoints[3].Y = armSecondPieceStartPoint.Y;

            rotateMatrix.RotateAt(ArmRotateDegree, armFirstPieceStartPoint);
            e.Graphics.Transform = rotateMatrix;
            e.Graphics.FillPolygon(greenBrush, firstPiecePoints);
            e.Graphics.FillPolygon(yellowBrush, secondPiecePoints);
        }

        private void calculateArmPieceLength(int[] lengths)
        {
            float thirtDegree = 180 - (firstArmDegree + secondArmDegree);
            lengths[0] = (int)(ArmLenght * Math.Cos(FirstArmDegree * Math.PI/180));
            lengths[1] = (int)(ArmLenght * Math.Cos(thirtDegree * Math.PI / 180));

        }

        private void drawStatusBar(PaintEventArgs e)
        {
            Pen redPen = new Pen(Color.Red);
            Pen greenPen = new Pen(Color.Green);
            Brush redBrush = new SolidBrush(Color.Red);
            Brush greenBrush = new SolidBrush(Color.Green);
            Brush darkBlueBrush = new SolidBrush(Color.DarkBlue);
            Brush whiteBrush = new SolidBrush(Color.White);

            //take-drop draw area
            Point takeDropGaugePoint = new Point(20,40);
            Point[] takeDropGaugeRectanglePoint = new Point[4];
            Font drawTextFont = new Font("Arial", 12, FontStyle.Bold);
            Point textPoint = new Point();
            takeDropGaugeRectanglePoint[0].X = takeDropGaugePoint.X;
            takeDropGaugeRectanglePoint[0].Y = takeDropGaugePoint.Y;

            takeDropGaugeRectanglePoint[1].X = takeDropGaugePoint.X + takeDropGaugeRectangleSize;
            takeDropGaugeRectanglePoint[1].Y = takeDropGaugePoint.Y;

            takeDropGaugeRectanglePoint[2].X = takeDropGaugePoint.X + takeDropGaugeRectangleSize;
            takeDropGaugeRectanglePoint[2].Y = takeDropGaugePoint.Y + takeDropGaugeRectangleSize;

            takeDropGaugeRectanglePoint[3].X = takeDropGaugePoint.X ;
            takeDropGaugeRectanglePoint[3].Y = takeDropGaugePoint.Y + takeDropGaugeRectangleSize;
            textPoint.X = takeDropGaugeRectanglePoint[1].X + 3;
            textPoint.Y = takeDropGaugeRectanglePoint[1].Y + 3;
            if (TakeorDrop == takeDropState.DROP)
            {
                e.Graphics.FillPolygon(redBrush, takeDropGaugeRectanglePoint);
                e.Graphics.DrawString("Durum > Tutmuyor", drawTextFont, redBrush, textPoint);
            }
            else
            {
                e.Graphics.FillPolygon(greenBrush, takeDropGaugeRectanglePoint);
                e.Graphics.DrawString("Durum > Tutuyor", drawTextFont, greenBrush, textPoint);
            }

            //robot arm state draw area
            Point robotArmStateGaugePoint = new Point(250, 40);
            Point[] robotArmStateGaugeRectanglePoint = new Point[4];
            //Font drawTextFont = new Font("Arial", 10);
            //Point textPoint = new Point();
            robotArmStateGaugeRectanglePoint[0].X = robotArmStateGaugePoint.X;
            robotArmStateGaugeRectanglePoint[0].Y = robotArmStateGaugePoint.Y;

            robotArmStateGaugeRectanglePoint[1].X = robotArmStateGaugePoint.X + takeDropGaugeRectangleSize;
            robotArmStateGaugeRectanglePoint[1].Y = robotArmStateGaugePoint.Y;

            robotArmStateGaugeRectanglePoint[2].X = robotArmStateGaugePoint.X + takeDropGaugeRectangleSize;
            robotArmStateGaugeRectanglePoint[2].Y = robotArmStateGaugePoint.Y + takeDropGaugeRectangleSize;

            robotArmStateGaugeRectanglePoint[3].X = robotArmStateGaugePoint.X;
            robotArmStateGaugeRectanglePoint[3].Y = robotArmStateGaugePoint.Y + takeDropGaugeRectangleSize;
            textPoint.X = robotArmStateGaugeRectanglePoint[1].X + 3;
            textPoint.Y = robotArmStateGaugeRectanglePoint[1].Y + 3;
            if (robotArmStt == robotArmState.BUSSY)
            {
                e.Graphics.FillPolygon(redBrush, robotArmStateGaugeRectanglePoint);
                e.Graphics.DrawString("Durum > Mesgul", drawTextFont, redBrush, textPoint);
            }
            else
            {
                e.Graphics.FillPolygon(greenBrush, robotArmStateGaugeRectanglePoint);
                e.Graphics.DrawString("Durum > Bosta", drawTextFont, greenBrush, textPoint);
            }
            // positionGaugeRectangleSize
            //position state show area
            Point positionStateGaugePoint = new Point(450, 40);
            Point[] positionGaugeRectanglePoint = new Point[4];
            //Font drawTextFont = new Font("Arial", 10);
            //Point textPoint = new Point();
            positionGaugeRectanglePoint[0].X = positionStateGaugePoint.X;
            positionGaugeRectanglePoint[0].Y = positionStateGaugePoint.Y;

            positionGaugeRectanglePoint[1].X = positionStateGaugePoint.X + positionGaugeRectangleSize;
            positionGaugeRectanglePoint[1].Y = positionStateGaugePoint.Y;

            positionGaugeRectanglePoint[2].X = positionStateGaugePoint.X + positionGaugeRectangleSize;
            positionGaugeRectanglePoint[2].Y = positionStateGaugePoint.Y + takeDropGaugeRectangleSize;

            positionGaugeRectanglePoint[3].X = positionStateGaugePoint.X;
            positionGaugeRectanglePoint[3].Y = positionStateGaugePoint.Y + takeDropGaugeRectangleSize;
            textPoint.X = positionGaugeRectanglePoint[0].X + 3;
            textPoint.Y = positionGaugeRectanglePoint[0].Y + 3;
            e.Graphics.FillPolygon(darkBlueBrush, positionGaugeRectanglePoint);
            string positionInfo = "Kol konumu: X " + ArmPositionX + " , Y " + ArmPositionY + " , Z " + ArmPositionZ;
            e.Graphics.DrawString(positionInfo, drawTextFont, whiteBrush, positionGaugeRectanglePoint[0]);
            //e.Graphics.DrawString("Durum > Mesgul", drawTextFont, redBrush, textPoint);
            //if (robotArmStt == robotArmState.BUSSY)
            //{
            //    e.Graphics.FillPolygon(redBrush, robotArmStateGaugeRectanglePoint);
            //    e.Graphics.DrawString("Durum > Mesgul", drawTextFont, redBrush, textPoint);
            //}
            //else
            //{
            //    e.Graphics.FillPolygon(greenBrush, robotArmStateGaugeRectanglePoint);
            //    e.Graphics.DrawString("Durum > Bosta", drawTextFont, greenBrush, textPoint);
            //}

        }

        private void drawStartEndPoints(PaintEventArgs e, Pen redCross, Pen greenCross, Point[] startCrossPoint, Point[] endCrossPoint, Font drawSubTextFont)
        {
            Brush endTextBrush = new SolidBrush(Color.Green);
            Brush startTextBrush = new SolidBrush(Color.Red);
            for (int loop = 0; loop < endCount; loop++)
            {
                endCrossPoint[0].X = robotArmEndPos[loop].X - CorssSize / 2;
                endCrossPoint[0].Y = robotArmEndPos[loop].Y - CorssSize / 2;
                endCrossPoint[1].X = robotArmEndPos[loop].X + CorssSize / 2;
                endCrossPoint[1].Y = robotArmEndPos[loop].Y + CorssSize / 2;

                endCrossPoint[2].X = robotArmEndPos[loop].X - CorssSize / 2;
                endCrossPoint[2].Y = robotArmEndPos[loop].Y + CorssSize / 2;
                endCrossPoint[3].X = robotArmEndPos[loop].X + CorssSize / 2;
                endCrossPoint[3].Y = robotArmEndPos[loop].Y - CorssSize / 2;

                e.Graphics.DrawLine(greenCross, endCrossPoint[0], endCrossPoint[1]);
                e.Graphics.DrawLine(greenCross, endCrossPoint[2], endCrossPoint[3]);
                e.Graphics.DrawString((loop + 1).ToString(), drawSubTextFont, endTextBrush, endCrossPoint[3]);
            }
            for (int loop = 0; loop < startCount; loop++)
            {
                startCrossPoint[0].X = robotArmStartPos[loop].X - CorssSize / 2;
                startCrossPoint[0].Y = robotArmStartPos[loop].Y - CorssSize / 2;
                startCrossPoint[1].X = robotArmStartPos[loop].X + CorssSize / 2;
                startCrossPoint[1].Y = robotArmStartPos[loop].Y + CorssSize / 2;

                startCrossPoint[2].X = robotArmStartPos[loop].X - CorssSize / 2;
                startCrossPoint[2].Y = robotArmStartPos[loop].Y + CorssSize / 2;
                startCrossPoint[3].X = robotArmStartPos[loop].X + CorssSize / 2;
                startCrossPoint[3].Y = robotArmStartPos[loop].Y - CorssSize / 2;

                e.Graphics.DrawLine(redCross, startCrossPoint[0], startCrossPoint[1]);
                e.Graphics.DrawLine(redCross, startCrossPoint[2], startCrossPoint[3]);
                e.Graphics.DrawString((loop + 1).ToString(), drawSubTextFont, startTextBrush, startCrossPoint[3]);
            }
            Pen line1 = new Pen(Color.Black);
            Pen line2 = new Pen(Color.Purple, 1.75F);

            for (int loop = 0; loop < Math.Min(startCount, endCount); loop++)
            {
                e.Graphics.DrawLine(line1, robotArmStartPos[loop], robotArmEndPos[loop]);
                if(loop == Math.Min(startCount, endCount) - 1)
                {
                    Point stopPoint = new Point(440, 650);
                    e.Graphics.DrawLine(line2, robotArmEndPos[loop], stopPoint);
                }
                else
                {
                    e.Graphics.DrawLine(line2, robotArmEndPos[loop], robotArmStartPos[loop + 1]);
                }
            }
        }

        private void drawEndCross(PaintEventArgs e, Pen redCross)
        {
        }

        private void drawStartCross(PaintEventArgs e, Pen redCross)
        {
            Font drawSubTextFont = new Font("Arial", 15);
            Point[] crossPoint = new Point[4];
            Brush textBrush = new SolidBrush(Color.Red);
        }

        private void drawInsideandOutsideCircle(PaintEventArgs e, Pen linePen, Point[] arcLinePoint)
        {
            float[] sizeArc = new float[4];
            sizeArc[0] = 800;
            sizeArc[1] = 800;
            sizeArc[2] = 100;
            sizeArc[3] = 100;
            arcLinePoint[0].X = 40;
            arcLinePoint[0].Y = 200;

            arcLinePoint[1].X = 390;
            arcLinePoint[1].Y = 550;
            for(int loop = 0; loop< arcLinePoint.Length; loop++)
            {
                e.Graphics.DrawArc(linePen, arcLinePoint[loop].X, arcLinePoint[loop].Y, sizeArc[(loop * 2)], sizeArc[(loop * 2) + 1], 0.0F, -180.0F);
            }
            e.Graphics.DrawLine(linePen, 40, 600, 390, 600);
            e.Graphics.DrawLine(linePen, 490, 600, 840, 600);
        }
    }
}
