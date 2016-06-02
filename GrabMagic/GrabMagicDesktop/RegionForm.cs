using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GrabMagicDesktop
{
    public partial class RegionForm : Form
    {
        public Form InstanceRef { get; set; }
        private readonly Pen _eraserPen = new Pen(Color.FromArgb(254, 255, 192), 1);
        private readonly Pen _myPen = new Pen(Color.FromArgb(255, 255, 192), 3);
        private readonly Graphics g;
        public Point ClickPoint;
        public ClickAction CurrentAction;
        public Point CurrentBottomRight;
        public Point CurrentTopLeft;
        public Point DragClickRelative;
        public bool LeftButtonDown;
        public bool ReadyToDrag = false;
        public bool RectangleDrawn;
        public int RectangleHeight;
        public int RectangleWidth;
        public BalloonForm BalloonForm;

        public RegionForm(BalloonForm balloonForm, Form instanceRef)
        {
            InstanceRef = instanceRef;
            BalloonForm = balloonForm;
            InitializeComponent();
            MouseDown += mouse_Click;
            MouseUp += mouse_Up;
            MouseMove += mouse_Move;
            KeyUp += key_press;
            g = CreateGraphics();
            Opacity = 0.01D;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Opacity = 0.04D;
            if (e.Button == MouseButtons.Right)
            {
                e = null;
            }

            if (e != null) base.OnMouseClick(e);
        }

        public void SaveSelection()
        {
            var curPos = new Point(Cursor.Position.X - CurrentTopLeft.X, Cursor.Position.Y - CurrentTopLeft.Y);
            var curSize = new Size
            {
                Height = Cursor.Current.Size.Height,
                Width = Cursor.Current.Size.Width
            };

            //Allow 100 milliseconds for the screen to repaint itself (we don't want to include this form in the capture)
            Thread.Sleep(100);

            var startPoint = new Point(CurrentTopLeft.X, CurrentTopLeft.Y);
            var bounds = new Rectangle(CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X,
                CurrentBottomRight.Y - CurrentTopLeft.Y);

            new Screenshot().CaptureImage(curSize, curPos, startPoint, Point.Empty, bounds);
            BalloonForm.SuccesfullUploadBalloon();
            InstanceRef.Show();
            Close();
        }

        public void key_press(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "S" &&
                (RectangleDrawn &&
                 (CursorPosition() == GrabMagicDesktop.CursorPosition.WithinSelectionArea ||
                  CursorPosition() == GrabMagicDesktop.CursorPosition.OutsideSelectionArea)))
            {
                SaveSelection();
            }
        }

        private void mouse_Click(object sender, MouseEventArgs e)
        {
            Opacity = 0.05D;
            if (e.Button == MouseButtons.Left)
            {
                SetClickAction();
                LeftButtonDown = true;
                ClickPoint = new Point(MousePosition.X, MousePosition.Y);

                if (RectangleDrawn)
                {
                    RectangleHeight = CurrentBottomRight.Y - CurrentTopLeft.Y;
                    RectangleWidth = CurrentBottomRight.X - CurrentTopLeft.X;
                    DragClickRelative.X = Cursor.Position.X - CurrentTopLeft.X;
                    DragClickRelative.Y = Cursor.Position.Y - CurrentTopLeft.Y;
                }
            }
        }

        private void mouse_Up(object sender, MouseEventArgs e)
        {
            RectangleDrawn = true;
            LeftButtonDown = false;
            CurrentAction = ClickAction.NoClick;
            SaveSelection();
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (LeftButtonDown && !RectangleDrawn)
            {
                Invalidate();
            }

            if (RectangleDrawn)
            {
                CursorPosition();

                if (CurrentAction == ClickAction.Dragging)
                {
                    DragSelection();
                }
            }
        }

        private CursorPosition CursorPosition()
        {
            if (((Cursor.Position.X > CurrentTopLeft.X - 10 && Cursor.Position.X < CurrentTopLeft.X + 10)) &&
                ((Cursor.Position.Y > CurrentTopLeft.Y + 10) && (Cursor.Position.Y < CurrentBottomRight.Y - 10)))
            {
                Cursor = Cursors.SizeWE;
                return GrabMagicDesktop.CursorPosition.LeftLine;
            }
            if (((Cursor.Position.X >= CurrentTopLeft.X - 10 && Cursor.Position.X <= CurrentTopLeft.X + 10)) &&
                ((Cursor.Position.Y >= CurrentTopLeft.Y - 10) && (Cursor.Position.Y <= CurrentTopLeft.Y + 10)))
            {
                Cursor = Cursors.SizeNWSE;
                return GrabMagicDesktop.CursorPosition.TopLeft;
            }
            if (((Cursor.Position.X >= CurrentTopLeft.X - 10 && Cursor.Position.X <= CurrentTopLeft.X + 10)) &&
                ((Cursor.Position.Y >= CurrentBottomRight.Y - 10) && (Cursor.Position.Y <= CurrentBottomRight.Y + 10)))
            {
                Cursor = Cursors.SizeNESW;
                return GrabMagicDesktop.CursorPosition.BottomLeft;
            }
            if (((Cursor.Position.X > CurrentBottomRight.X - 10 && Cursor.Position.X < CurrentBottomRight.X + 10)) &&
                ((Cursor.Position.Y > CurrentTopLeft.Y + 10) && (Cursor.Position.Y < CurrentBottomRight.Y - 10)))
            {
                Cursor = Cursors.SizeWE;
                return GrabMagicDesktop.CursorPosition.RightLine;
            }
            if (((Cursor.Position.X >= CurrentBottomRight.X - 10 && Cursor.Position.X <= CurrentBottomRight.X + 10)) &&
                ((Cursor.Position.Y >= CurrentTopLeft.Y - 10) && (Cursor.Position.Y <= CurrentTopLeft.Y + 10)))
            {
                Cursor = Cursors.SizeNESW;
                return GrabMagicDesktop.CursorPosition.TopRight;
            }
            if (((Cursor.Position.X >= CurrentBottomRight.X - 10 && Cursor.Position.X <= CurrentBottomRight.X + 10)) &&
                ((Cursor.Position.Y >= CurrentBottomRight.Y - 10) && (Cursor.Position.Y <= CurrentBottomRight.Y + 10)))
            {
                Cursor = Cursors.SizeNWSE;
                return GrabMagicDesktop.CursorPosition.BottomRight;
            }
            if (((Cursor.Position.Y > CurrentTopLeft.Y - 10) && (Cursor.Position.Y < CurrentTopLeft.Y + 10)) &&
                ((Cursor.Position.X > CurrentTopLeft.X + 10 && Cursor.Position.X < CurrentBottomRight.X - 10)))
            {
                Cursor = Cursors.SizeNS;
                return GrabMagicDesktop.CursorPosition.TopLine;
            }
            if (((Cursor.Position.Y > CurrentBottomRight.Y - 10) && (Cursor.Position.Y < CurrentBottomRight.Y + 10)) &&
                ((Cursor.Position.X > CurrentTopLeft.X + 10 && Cursor.Position.X < CurrentBottomRight.X - 10)))
            {
                Cursor = Cursors.SizeNS;
                return GrabMagicDesktop.CursorPosition.BottomLine;
            }
            if (
                (Cursor.Position.X >= CurrentTopLeft.X + 10 && Cursor.Position.X <= CurrentBottomRight.X - 10) &&
                (Cursor.Position.Y >= CurrentTopLeft.Y + 10 && Cursor.Position.Y <= CurrentBottomRight.Y - 10))
            {
                Cursor = Cursors.Hand;
                return GrabMagicDesktop.CursorPosition.WithinSelectionArea;
            }

            Cursor = Cursors.No;
            return GrabMagicDesktop.CursorPosition.OutsideSelectionArea;
        }

        private void SetClickAction()
        {
            switch (CursorPosition())
            {
                case GrabMagicDesktop.CursorPosition.BottomLine:
                    CurrentAction = ClickAction.BottomSizing;
                    break;
                case GrabMagicDesktop.CursorPosition.TopLine:
                    CurrentAction = ClickAction.TopSizing;
                    break;
                case GrabMagicDesktop.CursorPosition.LeftLine:
                    CurrentAction = ClickAction.LeftSizing;
                    break;
                case GrabMagicDesktop.CursorPosition.TopLeft:
                    CurrentAction = ClickAction.TopLeftSizing;
                    break;
                case GrabMagicDesktop.CursorPosition.BottomLeft:
                    CurrentAction = ClickAction.BottomLeftSizing;
                    break;
                case GrabMagicDesktop.CursorPosition.RightLine:
                    CurrentAction = ClickAction.RightSizing;
                    break;
                case GrabMagicDesktop.CursorPosition.TopRight:
                    CurrentAction = ClickAction.TopRightSizing;
                    break;
                case GrabMagicDesktop.CursorPosition.BottomRight:
                    CurrentAction = ClickAction.BottomRightSizing;
                    break;
                case GrabMagicDesktop.CursorPosition.WithinSelectionArea:
                    CurrentAction = ClickAction.Dragging;
                    break;
                case GrabMagicDesktop.CursorPosition.OutsideSelectionArea:
                    CurrentAction = ClickAction.Outside;
                    break;
            }
        }

        private void DragSelection()
        {
            //Ensure that the rectangle stays within the bounds of the screen

            //Erase the previous rectangle
            g.DrawRectangle(_eraserPen, CurrentTopLeft.X, CurrentTopLeft.Y, RectangleWidth, RectangleHeight);

            if (Cursor.Position.X - DragClickRelative.X > 0 &&
                Cursor.Position.X - DragClickRelative.X + RectangleWidth < Screen.PrimaryScreen.Bounds.Width)
            {
                CurrentTopLeft.X = Cursor.Position.X - DragClickRelative.X;
                CurrentBottomRight.X = CurrentTopLeft.X + RectangleWidth;
            }
            else
            //Selection area has reached the right side of the screen
                if (Cursor.Position.X - DragClickRelative.X > 0)
                {
                    CurrentTopLeft.X = Screen.PrimaryScreen.Bounds.Width - RectangleWidth;
                    CurrentBottomRight.X = CurrentTopLeft.X + RectangleWidth;
                }
                //Selection area has reached the left side of the screen
                else
                {
                    CurrentTopLeft.X = 0;
                    CurrentBottomRight.X = CurrentTopLeft.X + RectangleWidth;
                }

            if (Cursor.Position.Y - DragClickRelative.Y > 0 &&
                Cursor.Position.Y - DragClickRelative.Y + RectangleHeight < Screen.PrimaryScreen.Bounds.Height)
            {
                CurrentTopLeft.Y = Cursor.Position.Y - DragClickRelative.Y;
                CurrentBottomRight.Y = CurrentTopLeft.Y + RectangleHeight;
            }
            else
            //Selection area has reached the bottom of the screen
                if (Cursor.Position.Y - DragClickRelative.Y > 0)
                {
                    CurrentTopLeft.Y = Screen.PrimaryScreen.Bounds.Height - RectangleHeight;
                    CurrentBottomRight.Y = CurrentTopLeft.Y + RectangleHeight;
                }
                //Selection area has reached the top of the screen
                else
                {
                    CurrentTopLeft.Y = 0;
                    CurrentBottomRight.Y = CurrentTopLeft.Y + RectangleHeight;
                }

            //Draw a new rectangle
            g.DrawRectangle(_myPen, CurrentTopLeft.X, CurrentTopLeft.Y, RectangleWidth, RectangleHeight);
        }

        private void RegionForm_Paint(object sender, PaintEventArgs e)
        {
            Cursor = Cursors.Arrow;

            //Erase the previous rectangle
            g.DrawRectangle(_eraserPen, CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X,
                CurrentBottomRight.Y - CurrentTopLeft.Y);

            //Calculate X Coordinates
            if (Cursor.Position.X < ClickPoint.X)
            {
                CurrentTopLeft.X = Cursor.Position.X;
                CurrentBottomRight.X = ClickPoint.X;
            }
            else
            {
                CurrentTopLeft.X = ClickPoint.X;
                CurrentBottomRight.X = Cursor.Position.X;
            }

            //Calculate Y Coordinates
            if (Cursor.Position.Y < ClickPoint.Y)
            {
                CurrentTopLeft.Y = Cursor.Position.Y;
                CurrentBottomRight.Y = ClickPoint.Y;
            }
            else
            {
                CurrentTopLeft.Y = ClickPoint.Y;
                CurrentBottomRight.Y = Cursor.Position.Y;
            }

            //Draw a new rectangle
            g.DrawRectangle(_myPen, CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X,
                CurrentBottomRight.Y - CurrentTopLeft.Y);
        }
    }
}