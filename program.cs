namespace Makro3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;


        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());         // We dont need the UI.

            Perform();
        }

        private static void Perform()
        {
            LeftMouseClick(1000, 515);              //Click to x=1000 and y=55 coords in FullHD Screen
            Thread.Sleep(500);                      //Wait
            SendKeyboard("Type Something...");      //Type
            Thread.Sleep(500);                      //Wait
            LeftMouseClick(1000, 550);              //Click
            Thread.Sleep(500);                      //Wait
            SendKeyboard("Type Something More..."); //Type
            Thread.Sleep(500);                      //Wait
            LeftMouseClick(950, 600);               //Click
        }

        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        public static void SendKeyboard(String str)
        {            
            SendKeys.SendWait(str);        
        }
    }
}
