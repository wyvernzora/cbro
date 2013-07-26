using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TaskRoute.Sandbox
{
    public partial class VisualizerSurface : Control
    {
        #region Constants

        public const Int32 TaskPointRadius = 10;

        #endregion

        #region Win32 API
        // ReSharper disable InconsistentNaming
        // ReSharper disable MemberCanBePrivate.Local

        private const int WM_PAINT = 0x000F;
        private const int WM_ERASEBKGND = 0x0014;
        private const int WM_PRINTCLIENT = 0x0318;

        // Win32 Structures
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        private struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public int fErase;
            public RECT rcPaint;
            public int fRestore;
            public int fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        // Win32 Functions
        [DllImport("user32.dll")]
        private static extern IntPtr BeginPaint(IntPtr hWnd,
                                        ref PAINTSTRUCT paintStruct);

        [DllImport("user32.dll")]
        private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT paintStruct);

        // ReSharper restore MemberCanBePrivate.Local
        // ReSharper restore InconsistentNaming
        #endregion

        #region Win32 WndProc

        

        // Actual rendering is here
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_ERASEBKGND:
                    return;
                case WM_PAINT:
                    PAINTSTRUCT paintStruct = new PAINTSTRUCT();
                    IntPtr screenHdc = BeginPaint(m.HWnd, ref paintStruct);

                    if (Tasks != null)
                    {
                        using (var screen = Graphics.FromHdc(screenHdc))
                        {
                            screen.Clear(BackColor);

                            Int32 width = Width;
                            Int32 height = Height;

                            var pointOutline = new Pen(Color.Black, 1);
                            var pointOutlineSelected = new Pen(Color.Orange, 2);
                            var pointFill = new SolidBrush(Color.MediumPurple);
                            var pointFillCurrent = new SolidBrush(Color.Red);

                            var visitedLinkPen = new Pen(Color.DarkSlateBlue, 4);
                            var activeLinkPen = new Pen(Color.HotPink, 2);

                            if (Tasks.Count > 0)
                            {
                                // Draw Visited Links
                                if (Path.Count > 1)
                                {
                                    Int32 i = 0;
                                    Task c = Path[i];
                                    do
                                    {
                                        i++;

                                        Task n = Path[i];

                                        Int32 x0 = (Int32) (c.Location.X * width);
                                        Int32 y0 = (Int32) (c.Location.Y * height);
                                        Int32 x1 = (Int32) (n.Location.X * width);
                                        Int32 y1 = (Int32) (n.Location.Y * height);

                                        screen.DrawLine(visitedLinkPen, x0, y0, x1, y1);

                                        c = n;

                                    } while (i < Path.Count - 1);
                                }


                                // Draw Tasks
                                foreach (var t in Tasks)
                                {
                                    Int32 x = (Int32) (t.Location.X * width);
                                    Int32 y = (Int32) (t.Location.Y * height);

                                    var outlinePen = t.Equals(SelectedTask) ? pointOutlineSelected : pointOutline;
                                    var fillBrush = pointFill;

                                    screen.FillEllipse(fillBrush, x - TaskPointRadius, y - TaskPointRadius,
                                                       2 * TaskPointRadius, 2 * TaskPointRadius);
                                    screen.DrawEllipse(outlinePen, x - TaskPointRadius, y - TaskPointRadius,
                                                       2 * TaskPointRadius, 2 * TaskPointRadius);
                                }
                            }
                            else
                            {
                                screen.DrawString("Shift+Click to add tasks", new Font(Font.FontFamily, 12, FontStyle.Bold), new SolidBrush(Color.DarkGray), 10, 10);
                            }

                            // Draw Border
                            screen.DrawRectangle(pointOutline, 0, 0, width - 1, height - 1);
                        }
                    }
                    
                    EndPaint(m.HWnd, ref paintStruct);
                    return;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }


        #endregion
        
        public VisualizerSurface()
        {
            InitializeComponent();

            Tasks = new List<Task>();
            Path = new List<Task>();

            Cursor = Cursors.Cross;

            AttachEventHandlers();
        }

        #region Properties

        //public CbroAlgorithm Algorithm { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Task> Path { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Task> Tasks { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Task SelectedTask { get; set; }


        private Boolean AddMode { get; set; }

        #endregion

        #region Event Handling

        private void AttachEventHandlers()
        {
            SizeChanged += (@s, e) => UpdateSurface();

            MouseDown += (@s, a) =>
                {
                    // Add/Select Task
                    var mousePoint = new Location(a.X / (double)Width, a.Y / (double)Height);
                    var pxScale = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));

                    // Check if clicked on a task or not
                    Task select =
                        Tasks.FirstOrDefault(
                            t => t.Location.DistanceTo(mousePoint) * pxScale < TaskPointRadius);

                    if (select != null)
                    {
                        // Selection, handle
                        SelectedTask = select;

                    }
                    else
                    {
                        SelectedTask = null;

                        // Addition
                        if (ModifierKeys.HasFlag(Keys.Shift))
                        {
                            var newTask = new Task()
                                {
                                    Location = mousePoint,
                                    Value = 1.0
                                };
                            Tasks.Add(newTask);
                        }

                    }


                    UpdateSurface();
                };
        }

        public void UpdateSurface()
        {
            if (!DesignMode)
                Invalidate();
        }

        #endregion

        #region Color Utilities

        

        #endregion
    }
}
