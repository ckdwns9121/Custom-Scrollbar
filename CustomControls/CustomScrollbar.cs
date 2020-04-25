using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;


namespace CustomControls {

    [Designer(typeof(ScrollbarControlDesigner))]
    public class CustomScrollbar : UserControl {

        protected Color moChannelColor = Color.Empty;
        protected Image moUpArrowImage = null;
        //protected Image moUpArrowImage_Over = null;
        //protected Image moUpArrowImage_Down = null;
        protected Image moDownArrowImage = null;
        //protected Image moDownArrowImage_Over = null;
        //protected Image moDownArrowImage_Down = null;
        protected Image moThumbArrowImage = null;

        protected Image moThumbTopImage = null;
        protected Image moThumbTopSpanImage = null;
        protected Image moThumbBottomImage = null;
        protected Image moThumbBottomSpanImage = null;
        protected Image moThumbMiddleImage = null;

        protected Image moThumbHoverImage = null;
        protected Image moThumbNomalImage = null;

        protected int moLargeChange = 10;
        protected int moSmallChange = 1;
        protected int moMinimum = 0;
        protected int moMaximum = 100;
        protected int moValue = 0;
        private int nClickPoint;

        protected int moThumbTop = 0;

        protected bool moAutoSize = false;

        private bool moThumbDown = false;
        private bool moThumbDragging = false;

        public new event EventHandler Scroll = null;
        public event EventHandler ValueChanged = null;

        private int GetThumbHeight()
        {
        //    int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            int nTrackHeight = 0;
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            return nThumbHeight;
        }

        public CustomScrollbar() {

            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            moChannelColor = Color.FromArgb(51, 166, 3);
            //UpArrowImage = Resource.uparrow;
            //DownArrowImage = Resource.downarrow;
            

            ThumbBottomImage = Resource.ThumbBottom;
            ThumbBottomSpanImage = Resource.ThumbSpanBottom;
            ThumbTopImage = Resource.ThumbTop;
            ThumbTopSpanImage = Resource.ThumbSpanTop;
            ThumbMiddleImage = Resource.ThumbMiddle;

          //  this.Width = UpArrowImage.Width;

            this.Width = 0;

           // base.MinimumSize = new Size(UpArrowImage.Width, UpArrowImage.Height + DownArrowImage.Height + GetThumbHeight());
            base.MinimumSize = new Size(0, 0 + 0 + GetThumbHeight());
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("LargeChange")]
        public int LargeChange {
            get { return moLargeChange; }
            set { moLargeChange = value;
            Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("SmallChange")]
        public int SmallChange {
            get { return moSmallChange; }
            set { moSmallChange = value;
            Invalidate();    
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Minimum")]
        public int Minimum {
            get { return moMinimum; }
            set { moMinimum = value;
            Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Maximum")]
        public int Maximum {
            get { return moMaximum; }
            set { moMaximum = value;
            Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Value")]
        public int Value {
            get { return moValue; }
            set { moValue = value;

                //int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            int nTrackHeight = (this.Height);

            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            //figure out value
            int nPixelRange = nTrackHeight - nThumbHeight;
            int nRealRange = (Maximum - Minimum)-LargeChange;
            float fPerc = 0.0f;
            if (nRealRange != 0)
            {
                fPerc = (float)moValue / (float)nRealRange;
                
            }
            
            float fTop = fPerc * nPixelRange;
            moThumbTop = (int)fTop;
            

            Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Channel Color")]
        public Color ChannelColor
        {
            get { return moChannelColor; }
            set { moChannelColor = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image UpArrowImage {
            get { return moUpArrowImage; }
            set { moUpArrowImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image DownArrowImage {
            get { return moDownArrowImage; }
            set { moDownArrowImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbTopImage {
            get { return moThumbTopImage; }
            set { moThumbTopImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbTopSpanImage {
            get { return moThumbTopSpanImage; }
            set { moThumbTopSpanImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbBottomImage {
            get { return moThumbBottomImage; }
            set { moThumbBottomImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbBottomSpanImage {
            get { return moThumbBottomSpanImage; }
            set { moThumbBottomSpanImage = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbMiddleImage {
            get { return moThumbMiddleImage; }
            set { moThumbMiddleImage = value; }
        }


        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbHoverImage
        {
            get { return moThumbHoverImage; }
            set { moThumbHoverImage = value; }
        }


        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Up Arrow Graphic")]
        public Image ThumbNomalImage
        {
            get { return moThumbNomalImage; }
            set { moThumbNomalImage = value; }
        }

        protected override void OnPaint(PaintEventArgs e) {

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            //위쪽 화살표
           // if (UpArrowImage != null) {
           //     e.Graphics.DrawImage(UpArrowImage, new Rectangle(new Point(0,0), new Size(this.Width, UpArrowImage.Height)));
        //    }

            Brush oBrush = new SolidBrush(moChannelColor);
            Brush oWhiteBrush = new SolidBrush(Color.FromArgb(255,255,255));


           // draw channel
            //e.Graphics.FillRectangle(oBrush, new Rectangle(1, UpArrowImage.Height, this.Width - 2, (this.Height - DownArrowImage.Height)));
            
            //채널의 높이를 위에서부터 그리기
            e.Graphics.FillRectangle(oBrush, new Rectangle(1, 0, this.Width-2, (this.Height-2)));

            //draw thumb
            // int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            int nTrackHeight = (this.Height);
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight) {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56) {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            //Debug.WriteLine(nThumbHeight.ToString());

            float fSpanHeight = (fThumbHeight - (ThumbMiddleImage.Height + ThumbTopImage.Height + ThumbBottomImage.Height)) / 2.0f;
            int nSpanHeight = (int)fSpanHeight;

            int nTop = moThumbTop;
            //nTop += UpArrowImage.Height;
            nTop += 0;

            //draw top
            e.Graphics.DrawImage(ThumbTopImage, new Rectangle(1, nTop, this.Width - 2, ThumbTopImage.Height));

            nTop += ThumbTopImage.Height;
            //draw top span
            Rectangle rect = new Rectangle(1, nTop, this.Width - 2, nSpanHeight);


            e.Graphics.DrawImage(ThumbTopSpanImage, 1.0f,(float)nTop, (float)this.Width-2.0f, (float) fSpanHeight*2);

            nTop += nSpanHeight;
            //draw middle
            e.Graphics.DrawImage(ThumbMiddleImage, new Rectangle(1, nTop, this.Width - 2, ThumbMiddleImage.Height));


            nTop += ThumbMiddleImage.Height;
            //draw top span
            rect = new Rectangle(1, nTop, this.Width - 2, nSpanHeight*2);
            e.Graphics.DrawImage(ThumbBottomSpanImage, rect);

            nTop += nSpanHeight;

          //  draw bottom
          //  e.Graphics.DrawImage(ThumbBottomImage, new Rectangle(1, nTop, this.Width - 200, nSpanHeight));

            //if (DownArrowImage != null) {
            //     e.Graphics.DrawImage(DownArrowImage, new Rectangle(new Point(0, (this.Height-DownArrowImage.Height)), new Size(this.Width, DownArrowImage.Height)));
            // }

        }

        public override bool AutoSize {
            get {
                return base.AutoSize;
            }
            set {
                base.AutoSize = value;
                if (base.AutoSize) {
                    this.Width = moUpArrowImage.Width;
                }
            }
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // CustomScrollbar
            // 
            this.Name = "CustomScrollbar";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseDown);
            this.MouseLeave += new System.EventHandler(this.CustomScrollbar_MouseLeave);
            this.MouseHover += new System.EventHandler(this.CustomScrollbar_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseUp);
            this.ResumeLayout(false);

        }


        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e) {

            Console.WriteLine("다운");
            Point ptPoint = this.PointToClient(Cursor.Position);
            //int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
          
            int nTrackHeight = this.Height;
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            Console.WriteLine("nTrackHeight" + nTrackHeight);
            Console.WriteLine("fThumbHeight" + fThumbHeight);
            Console.WriteLine("nThumbHeight" + nThumbHeight);


            if (nThumbHeight > nTrackHeight) {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56) {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            int nTop = moThumbTop;
            //nTop += UpArrowImage.Height;
            nTop += 0;

            Rectangle thumbrect = new Rectangle(new Point(1, nTop), new Size(ThumbMiddleImage.Width, nThumbHeight));
            if (thumbrect.Contains(ptPoint))
            {
                
                //hit the thumb
                nClickPoint = (ptPoint.Y - nTop);
                //MessageBox.Show(Convert.ToString((ptPoint.Y - nTop)));
                this.moThumbDown = true;
            }

          //  Rectangle uparrowrect = new Rectangle(new Point(1, 0), new Size(UpArrowImage.Width, UpArrowImage.Height));
            Rectangle uparrowrect = new Rectangle(new Point(1, 0), new Size(0, 0));

            if (uparrowrect.Contains(ptPoint))
            {

                int nRealRange = (Maximum - Minimum)-LargeChange;
                int nPixelRange = (nTrackHeight - nThumbHeight);
                if (nRealRange > 0)
                {
                    if (nPixelRange > 0)
                    {
                        if ((moThumbTop - SmallChange) < 0)
                            moThumbTop = 0;
                        else
                            moThumbTop -= SmallChange;

                        //figure out value
                        float fPerc = (float)moThumbTop / (float)nPixelRange;
                        float fValue = fPerc * (Maximum - LargeChange);
                        
                            moValue = (int)fValue;
                        Debug.WriteLine(moValue.ToString());

                        if (ValueChanged != null)
                            ValueChanged(this, new EventArgs());

                        if (Scroll != null)
                            Scroll(this, new EventArgs());

                        Invalidate();
                    }
                }
            }

            //  Rectangle downarrowrect = new Rectangle(new Point(1, UpArrowImage.Height+nTrackHeight), new Size(UpArrowImage.Width, UpArrowImage.Height));
            Rectangle downarrowrect = new Rectangle(new Point(1,  nTrackHeight), new Size(0, 0));
            if (downarrowrect.Contains(ptPoint))
            {
                int nRealRange = (Maximum - Minimum) - LargeChange;
                int nPixelRange = (nTrackHeight - nThumbHeight);
                if (nRealRange > 0)
                {
                    if (nPixelRange > 0)
                    {
                        if ((moThumbTop + SmallChange) > nPixelRange)
                            moThumbTop = nPixelRange;
                        else
                            moThumbTop += SmallChange;

                        //figure out value
                        float fPerc = (float)moThumbTop / (float)nPixelRange;
                        float fValue = fPerc * (Maximum-LargeChange);
                       
                            moValue = (int)fValue;
                        Debug.WriteLine(moValue.ToString());

                        if (ValueChanged != null)
                            ValueChanged(this, new EventArgs());

                        if (Scroll != null)
                            Scroll(this, new EventArgs());

                        Invalidate();
                    }
                }
            }
        }

        private void CustomScrollbar_MouseUp(object sender, MouseEventArgs e) {
            Console.WriteLine("업");
            this.moThumbDown = false;
            this.moThumbDragging = false;
        }

        public void MoveThumb(int y) {
            int nRealRange = Maximum - Minimum;
            //int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            int nTrackHeight = this.Height;
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            //Console.WriteLine("무브");
            //Console.WriteLine("nTrackHeight" + nTrackHeight);
            //Console.WriteLine("fThumbHeight" + fThumbHeight);
            //Console.WriteLine("nThumbHeight" + nThumbHeight);

            if (nThumbHeight > nTrackHeight) {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56) {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            int nSpot = nClickPoint;

            int nPixelRange = (nTrackHeight - nThumbHeight);
            if (moThumbDown && nRealRange > 0) {
                if (nPixelRange > 0) {
                    //int nNewThumbTop = y - (UpArrowImage.Height+nSpot);
                    int nNewThumbTop = y - (0 + nSpot);

                  //  Console.WriteLine("위화살표 높이" + UpArrowImage.Height);
                    
                    if(nNewThumbTop<0)
                    {
                        moThumbTop = nNewThumbTop = 0;
                        Console.WriteLine("1");

                    }
                    else if(nNewThumbTop > nPixelRange)
                    {
                        moThumbTop = nNewThumbTop = nPixelRange;
                        Console.WriteLine("2");

                    }
                    else {
                        //moThumbTop = y - (UpArrowImage.Height + nSpot);
                        moThumbTop = y - (0 + nSpot);
                        Console.WriteLine("3");


                    }

                    //figure out value
                    float fPerc = (float)moThumbTop / (float)nPixelRange;
                    float fValue = fPerc * (Maximum-LargeChange);
                    moValue = (int)fValue;
                    Console.WriteLine("움직인 벨류"+moValue.ToString());

                    Application.DoEvents();

                    Invalidate();
                }
            }
        }


        public void scrollTest(int y)
        {
            Console.WriteLine("움직인 값" + y);
            int nRealRange = Maximum - Minimum;
            //int nTrackHeight = (this.Height - (UpArrowImage.Height + DownArrowImage.Height));
            int nTrackHeight = this.Height;
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            //Console.WriteLine("무브");
            //Console.WriteLine("nTrackHeight" + nTrackHeight);
            //Console.WriteLine("fThumbHeight" + fThumbHeight);
            //Console.WriteLine("nThumbHeight" + nThumbHeight);

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 56)
            {
                nThumbHeight = 56;
                fThumbHeight = 56;
            }

            int nSpot = nClickPoint;

            int nPixelRange = (nTrackHeight - nThumbHeight);
            if (nRealRange > 0)
            {
                if (nPixelRange > 0)
                {
                    //int nNewThumbTop = y - (UpArrowImage.Height+nSpot);
                    int nNewThumbTop = y - (0 + nSpot);

                    //  Console.WriteLine("위화살표 높이" + UpArrowImage.Height);

                    if (nNewThumbTop < 0)
                    {
                        moThumbTop = nNewThumbTop = 0;
                        Console.WriteLine("1");

                    }
                    else if (nNewThumbTop > nPixelRange)
                    {
                        moThumbTop = nNewThumbTop = nPixelRange;
                        Console.WriteLine("2");

                    }
                    else
                    {
                        //moThumbTop = y - (UpArrowImage.Height + nSpot);
                        moThumbTop = y - (0 + nSpot);
                        Console.WriteLine("3");


                    }

                    //figure out value
                    float fPerc = (float)moThumbTop / (float)nPixelRange;
                    float fValue = fPerc * (Maximum - LargeChange);
                    moValue = (int)fValue;
                    Console.WriteLine("움직인 벨류" + moValue.ToString());

                    Application.DoEvents();

                    Invalidate();
                }
            }
        }


        private void CustomScrollbar_MouseMove(object sender, MouseEventArgs e) {
   
            if(moThumbDown == true)
            {

                //드래깅 모드 활성화
                this.moThumbDragging = true;
            }

            if (this.moThumbDragging) {

                //드래깅 모드가 활성화면
                Console.WriteLine("드래깅 모드 활성화 Y좌표" + e.Y);
                MoveThumb(e.Y);
            }

            if(ValueChanged != null)
                ValueChanged(this, new EventArgs());

            if(Scroll != null)
                Scroll(this, new EventArgs());
        }

        private void CustomScrollbar_MouseHover(object sender, EventArgs e)
        {
            //Console.WriteLine("호버");
            //this.moThumbMiddleImage = this.ThumbHoverImage;
        }

        private void CustomScrollbar_MouseLeave(object sender, EventArgs e)
        {
            //Console.WriteLine("리브");
            //this.moThumbMiddleImage = this.ThumbNomalImage;
        }
    }

    internal class ScrollbarControlDesigner : System.Windows.Forms.Design.ControlDesigner {

        

        public override SelectionRules SelectionRules {
            get {
                SelectionRules selectionRules = base.SelectionRules;
                PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(this.Component)["AutoSize"];
                if (propDescriptor != null) {
                    bool autoSize = (bool)propDescriptor.GetValue(this.Component);
                    if (autoSize) {
                        selectionRules = SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.BottomSizeable | SelectionRules.TopSizeable;
                    }
                    else {
                        selectionRules = SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable;
                    }
                }
                return selectionRules;
            }
        } 
    }
}