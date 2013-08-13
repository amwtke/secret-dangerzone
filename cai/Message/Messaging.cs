using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace cai
{
    public class Messaging
    {
        public const int USER = 0x0400;
        public const int PROCESSBAR = USER + 1;
        public const int PROCESSBAR_BEGIN = USER + 2;
        public const int PROCESSBAR_COMPLETED = USER + 3;

        public const int TABLEUPDATE = USER + 4;
        public const int FIELDUPDATE = USER + 5;
        public const int CHUPDATE = USER + 6;
        public const int REFRESHCATALOUGE = USER + 7;
        public const int CLOSE_PICK_CATALOUGE = USER + 8;
        public const int UPDATE_FORM2 = USER + 9;
        public const int BULK_UPDATE_COMPLETE = USER + 10;

        public const int UPDATE_PREFERENCE = USER + 11;
        public const int UPDATE_PREFERENCE_OVER = USER + 12;
        public const int UPDATE_PREFERENCE_BEGIN = USER + 13;

        public const int UPDATE_PREFERENCE_ALL = USER + 14;
        public const int UPDATE_PREFERENCE_OVER_ALL = USER + 15;
        public const int UPDATE_PREFERENCE_BEGIN_ALL = USER + 16;
        public const int PREFERENCE_SAVED = USER + 17;


        public const int REFRESH_NOTE_CATEGORY = USER + 18;
        public const int UPDATE_NOTEBOOK = USER + 19;
        public const int UPDATE_NOTEBOOK_TEXT = USER + 20;


        public const int CLOSE_CIHUI = USER + 21;
        public const int CLOSE_PREFERENCE = USER + 22;
        public const int CLOSE_PREFERENCE_ALL = USER + 23;
        public const int CLOSE_NOTEBOOK = USER + 24;
        public const int CLOSE_HELP = USER + 25;

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
                IntPtr hWnd,      // handle to destination window
                uint Msg,         // message
                uint wParam,      // first message parameter
                uint lParam       // second message parameter
                );
        public static void FireMessage(IntPtr hWnd ,uint Message)
        {
            SendMessage(hWnd, Message, 0, 0);
        }
    }
}
