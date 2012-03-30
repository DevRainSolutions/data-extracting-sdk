namespace DevRain.Data.Extracting
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    /// <summary>
    /// PrintScreenExtractor class.
    /// </summary>
    public static class PrintScreenExtractor
    {
        /// <summary>
        /// Makes print screen screenshot.
        /// </summary>
        /// <returns>PrintScreen Bitmap object.</returns>
        public static Bitmap GetBitmap()
        {
            int hdcSrc = NativeMethods.GetWindowDC(NativeMethods.GetDesktopWindow()), hdcDest = NativeMethods.CreateCompatibleDC(hdcSrc), hBitmap = NativeMethods.CreateCompatibleBitmap(hdcSrc, NativeMethods.GetDeviceCaps(hdcSrc, 8), NativeMethods.GetDeviceCaps(hdcSrc, 10));
            NativeMethods.SelectObject(hdcDest, hBitmap);
            NativeMethods.BitBlt(hdcDest, 0, 0, NativeMethods.GetDeviceCaps(hdcSrc, 8),
            NativeMethods.GetDeviceCaps(hdcSrc, 10), hdcSrc, 0, 0, 0x00CC0020);

            var image = new Bitmap(
                Image.FromHbitmap(new IntPtr(hBitmap)),
                Image.FromHbitmap(new IntPtr(hBitmap)).Width,
                Image.FromHbitmap(new IntPtr(hBitmap)).Height);

            NativeMethods.ReleaseDC(NativeMethods.GetDesktopWindow(), hdcSrc);
            NativeMethods.DeleteDC(hdcDest);
            NativeMethods.DeleteObject(hBitmap);

            return image;
        }
    }

    internal static class NativeMethods
    {
        [DllImport("GDI32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]   
        public static extern bool BitBlt(int hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, int hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("GDI32.dll")]
        [return: MarshalAs(UnmanagedType.I4)]   
        public static extern int CreateCompatibleBitmap(int hdc, int nWidth, int nHeight);

        [DllImport("GDI32.dll")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern int CreateCompatibleDC(int hdc);
        
        [DllImport("GDI32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]   
        public static extern bool DeleteDC(int hdc);

        [DllImport("GDI32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]   
        public static extern bool DeleteObject(int hObject);

        [DllImport("GDI32.dll")]
        [return: MarshalAs(UnmanagedType.I4)]   
        public static extern int GetDeviceCaps(int hdc, int nIndex);

        [DllImport("GDI32.dll")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern int SelectObject(int hdc, int hgdiobj);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern int GetDesktopWindow();

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern int GetWindowDC(int hWnd);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern int ReleaseDC(int hWnd, int hDC);

    }
}
