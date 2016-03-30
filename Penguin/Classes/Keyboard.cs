//using System.Runtime.InteropServices;

//namespace Penguin
//{
//    public enum WindowsVirtualKey
//    {
//        [Description("Left mouse button")]
//        VK_LBUTTON = 0x01,

//        [Description("Right mouse button")]
//        VK_RBUTTON = 0x02,

//        [Description("Control-break processing")]
//        VK_CANCEL = 0x03,

//        [Description("Middle mouse button (three-button mouse)")]
//        VK_MBUTTON = 0x04,

//        [Description("X1 mouse button")]
//        VK_XBUTTON1 = 0x05,

//        [Description("X2 mouse button")]
//        VK_XBUTTON2 = 0x06,

//        [Description("BACKSPACE key")]
//        VK_BACK = 0x08,

//        [Description("TAB key")]
//        VK_TAB = 0x09,

//        [Description("CLEAR key")]
//        VK_CLEAR = 0x0C,

//        [Description("ENTER key")]
//        VK_RETURN = 0x0D,

//        [Description("SHIFT key")]
//        VK_SHIFT = 0x10,

//        [Description("CTRL key")]
//        VK_CONTROL = 0x11,

//        [Description("ALT key")]
//        VK_MENU = 0x12,

//        [Description("PAUSE key")]
//        VK_PAUSE = 0x13,

//        [Description("CAPS LOCK key")]
//        VK_CAPITAL = 0x14,

//        [Description("IME Kana mode")]
//        VK_KANA = 0x15,

//        [Description("IME Hanguel mode (maintained for compatibility; use VK_HANGUL)")]
//        VK_HANGUEL = 0x15,

//        [Description("IME Hangul mode")]
//        VK_HANGUL = 0x15,

//        [Description("IME Junja mode")]
//        VK_JUNJA = 0x17,

//        [Description("IME final mode")]
//        VK_FINAL = 0x18,

//        [Description("IME Hanja mode")]
//        VK_HANJA = 0x19,

//        [Description("IME Kanji mode")]
//        VK_KANJI = 0x19,

//        [Description("ESC key")]
//        VK_ESCAPE = 0x1B,

//        [Description("IME convert")]
//        VK_CONVERT = 0x1C,

//        [Description("IME nonconvert")]
//        VK_NONCONVERT = 0x1D,

//        [Description("IME accept")]
//        VK_ACCEPT = 0x1E,

//        [Description("IME mode change request")]
//        VK_MODECHANGE = 0x1F,

//        [Description("SPACEBAR")]
//        VK_SPACE = 0x20,

//        [Description("PAGE UP key")]
//        VK_PRIOR = 0x21,

//        [Description("PAGE DOWN key")]
//        VK_NEXT = 0x22,

//        [Description("END key")]
//        VK_END = 0x23,

//        [Description("HOME key")]
//        VK_HOME = 0x24,

//        [Description("LEFT ARROW key")]
//        VK_LEFT = 0x25,

//        [Description("UP ARROW key")]
//        VK_UP = 0x26,

//        [Description("RIGHT ARROW key")]
//        VK_RIGHT = 0x27,

//        [Description("DOWN ARROW key")]
//        VK_DOWN = 0x28,

//        [Description("SELECT key")]
//        VK_SELECT = 0x29,

//        [Description("PRINT key")]
//        VK_PRINT = 0x2A,

//        [Description("EXECUTE key")]
//        VK_EXECUTE = 0x2B,

//        [Description("PRINT SCREEN key")]
//        VK_SNAPSHOT = 0x2C,

//        [Description("INS key")]
//        VK_INSERT = 0x2D,

//        [Description("DEL key")]
//        VK_DELETE = 0x2E,

//        [Description("HELP key")]
//        VK_HELP = 0x2F,

//        [Description("0 key")]
//        K_0 = 0x30,

//        [Description("1 key")]
//        K_1 = 0x31,

//        [Description("2 key")]
//        K_2 = 0x32,

//        [Description("3 key")]
//        K_3 = 0x33,

//        [Description("4 key")]
//        K_4 = 0x34,

//        [Description("5 key")]
//        K_5 = 0x35,

//        [Description("6 key")]
//        K_6 = 0x36,

//        [Description("7 key")]
//        K_7 = 0x37,

//        [Description("8 key")]
//        K_8 = 0x38,

//        [Description("9 key")]
//        K_9 = 0x39,

//        [Description("A key")]
//        K_A = 0x41,

//        [Description("B key")]
//        K_B = 0x42,

//        [Description("C key")]
//        K_C = 0x43,

//        [Description("D key")]
//        K_D = 0x44,

//        [Description("E key")]
//        K_E = 0x45,

//        [Description("F key")]
//        K_F = 0x46,

//        [Description("G key")]
//        K_G = 0x47,

//        [Description("H key")]
//        K_H = 0x48,

//        [Description("I key")]
//        K_I = 0x49,

//        [Description("J key")]
//        K_J = 0x4A,

//        [Description("K key")]
//        K_K = 0x4B,

//        [Description("L key")]
//        K_L = 0x4C,

//        [Description("M key")]
//        K_M = 0x4D,

//        [Description("N key")]
//        K_N = 0x4E,

//        [Description("O key")]
//        K_O = 0x4F,

//        [Description("P key")]
//        K_P = 0x50,

//        [Description("Q key")]
//        K_Q = 0x51,

//        [Description("R key")]
//        K_R = 0x52,

//        [Description("S key")]
//        K_S = 0x53,

//        [Description("T key")]
//        K_T = 0x54,

//        [Description("U key")]
//        K_U = 0x55,

//        [Description("V key")]
//        K_V = 0x56,

//        [Description("W key")]
//        K_W = 0x57,

//        [Description("X key")]
//        K_X = 0x58,

//        [Description("Y key")]
//        K_Y = 0x59,

//        [Description("Z key")]
//        K_Z = 0x5A,

//        [Description("Left Windows key (Natural keyboard)")]
//        VK_LWIN = 0x5B,

//        [Description("Right Windows key (Natural keyboard)")]
//        VK_RWIN = 0x5C,

//        [Description("Applications key (Natural keyboard)")]
//        VK_APPS = 0x5D,

//        [Description("Computer Sleep key")]
//        VK_SLEEP = 0x5F,

//        [Description("Numeric keypad 0 key")]
//        VK_NUMPAD0 = 0x60,

//        [Description("Numeric keypad 1 key")]
//        VK_NUMPAD1 = 0x61,

//        [Description("Numeric keypad 2 key")]
//        VK_NUMPAD2 = 0x62,

//        [Description("Numeric keypad 3 key")]
//        VK_NUMPAD3 = 0x63,

//        [Description("Numeric keypad 4 key")]
//        VK_NUMPAD4 = 0x64,

//        [Description("Numeric keypad 5 key")]
//        VK_NUMPAD5 = 0x65,

//        [Description("Numeric keypad 6 key")]
//        VK_NUMPAD6 = 0x66,

//        [Description("Numeric keypad 7 key")]
//        VK_NUMPAD7 = 0x67,

//        [Description("Numeric keypad 8 key")]
//        VK_NUMPAD8 = 0x68,

//        [Description("Numeric keypad 9 key")]
//        VK_NUMPAD9 = 0x69,

//        [Description("Multiply key")]
//        VK_MULTIPLY = 0x6A,

//        [Description("Add key")]
//        VK_ADD = 0x6B,

//        [Description("Separator key")]
//        VK_SEPARATOR = 0x6C,

//        [Description("Subtract key")]
//        VK_SUBTRACT = 0x6D,

//        [Description("Decimal key")]
//        VK_DECIMAL = 0x6E,

//        [Description("Divide key")]
//        VK_DIVIDE = 0x6F,

//        [Description("F1 key")]
//        VK_F1 = 0x70,

//        [Description("F2 key")]
//        VK_F2 = 0x71,

//        [Description("F3 key")]
//        VK_F3 = 0x72,

//        [Description("F4 key")]
//        VK_F4 = 0x73,

//        [Description("F5 key")]
//        VK_F5 = 0x74,

//        [Description("F6 key")]
//        VK_F6 = 0x75,

//        [Description("F7 key")]
//        VK_F7 = 0x76,

//        [Description("F8 key")]
//        VK_F8 = 0x77,

//        [Description("F9 key")]
//        VK_F9 = 0x78,

//        [Description("F10 key")]
//        VK_F10 = 0x79,

//        [Description("F11 key")]
//        VK_F11 = 0x7A,

//        [Description("F12 key")]
//        VK_F12 = 0x7B,

//        [Description("F13 key")]
//        VK_F13 = 0x7C,

//        [Description("F14 key")]
//        VK_F14 = 0x7D,

//        [Description("F15 key")]
//        VK_F15 = 0x7E,

//        [Description("F16 key")]
//        VK_F16 = 0x7F,

//        [Description("F17 key")]
//        VK_F17 = 0x80,

//        [Description("F18 key")]
//        VK_F18 = 0x81,

//        [Description("F19 key")]
//        VK_F19 = 0x82,

//        [Description("F20 key")]
//        VK_F20 = 0x83,

//        [Description("F21 key")]
//        VK_F21 = 0x84,

//        [Description("F22 key")]
//        VK_F22 = 0x85,

//        [Description("F23 key")]
//        VK_F23 = 0x86,

//        [Description("F24 key")]
//        VK_F24 = 0x87,

//        [Description("NUM LOCK key")]
//        VK_NUMLOCK = 0x90,

//        [Description("SCROLL LOCK key")]
//        VK_SCROLL = 0x91,

//        [Description("Left SHIFT key")]
//        VK_LSHIFT = 0xA0,

//        [Description("Right SHIFT key")]
//        VK_RSHIFT = 0xA1,

//        [Description("Left CONTROL key")]
//        VK_LCONTROL = 0xA2,

//        [Description("Right CONTROL key")]
//        VK_RCONTROL = 0xA3,

//        [Description("Left MENU key")]
//        VK_LMENU = 0xA4,

//        [Description("Right MENU key")]
//        VK_RMENU = 0xA5,

//        [Description("Browser Back key")]
//        VK_BROWSER_BACK = 0xA6,

//        [Description("Browser Forward key")]
//        VK_BROWSER_FORWARD = 0xA7,

//        [Description("Browser Refresh key")]
//        VK_BROWSER_REFRESH = 0xA8,

//        [Description("Browser Stop key")]
//        VK_BROWSER_STOP = 0xA9,

//        [Description("Browser Search key")]
//        VK_BROWSER_SEARCH = 0xAA,

//        [Description("Browser Favorites key")]
//        VK_BROWSER_FAVORITES = 0xAB,

//        [Description("Browser Start and Home key")]
//        VK_BROWSER_HOME = 0xAC,

//        [Description("Volume Mute key")]
//        VK_VOLUME_MUTE = 0xAD,

//        [Description("Volume Down key")]
//        VK_VOLUME_DOWN = 0xAE,

//        [Description("Volume Up key")]
//        VK_VOLUME_UP = 0xAF,

//        [Description("Next Track key")]
//        VK_MEDIA_NEXT_TRACK = 0xB0,

//        [Description("Previous Track key")]
//        VK_MEDIA_PREV_TRACK = 0xB1,

//        [Description("Stop Media key")]
//        VK_MEDIA_STOP = 0xB2,

//        [Description("Play/Pause Media key")]
//        VK_MEDIA_PLAY_PAUSE = 0xB3,

//        [Description("Start Mail key")]
//        VK_LAUNCH_MAIL = 0xB4,

//        [Description("Select Media key")]
//        VK_LAUNCH_MEDIA_SELECT = 0xB5,

//        [Description("Start Application 1 key")]
//        VK_LAUNCH_APP1 = 0xB6,

//        [Description("Start Application 2 key")]
//        VK_LAUNCH_APP2 = 0xB7,

//        [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key")]
//        VK_OEM_1 = 0xBA,

//        [Description("For any country/region, the '+' key")]
//        VK_OEM_PLUS = 0xBB,

//        [Description("For any country/region, the ',' key")]
//        VK_OEM_COMMA = 0xBC,

//        [Description("For any country/region, the '-' key")]
//        VK_OEM_MINUS = 0xBD,

//        [Description("For any country/region, the '.' key")]
//        VK_OEM_PERIOD = 0xBE,

//        [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key")]
//        VK_OEM_2 = 0xBF,

//        [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '`~' key")]
//        VK_OEM_3 = 0xC0,

//        [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key")]
//        VK_OEM_4 = 0xDB,

//        [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\\|' key")]
//        VK_OEM_5 = 0xDC,

//        [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key")]
//        VK_OEM_6 = 0xDD,

//        [Description("Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key")]
//        VK_OEM_7 = 0xDE,

//        [Description("Used for miscellaneous characters; it can vary by keyboard.")]
//        VK_OEM_8 = 0xDF,


//        [Description("Either the angle bracket key or the backslash key on the RT 102-key keyboard")]
//        VK_OEM_102 = 0xE2,

//        [Description("IME PROCESS key")]
//        VK_PROCESSKEY = 0xE5,


//        [Description("Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP")]
//        VK_PACKET = 0xE7,

//        [Description("Attn key")]
//        VK_ATTN = 0xF6,

//        [Description("CrSel key")]
//        VK_CRSEL = 0xF7,

//        [Description("ExSel key")]
//        VK_EXSEL = 0xF8,

//        [Description("Erase EOF key")]
//        VK_EREOF = 0xF9,

//        [Description("Play key")]
//        VK_PLAY = 0xFA,

//        [Description("Zoom key")]
//        VK_ZOOM = 0xFB,

//        [Description("PA1 key")]
//        VK_PA1 = 0xFD,

//        [Description("Clear key")]
//        VK_OEM_CLEAR = 0xFE,

//    }

//    class Keyboard
//    {
//        [DllImport("user32.dll", SetLastError = true)]
//        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

//        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
//        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
//        public const int VK_LCONTROL = 0xA2; //Left Control key code
//        public const int SPACE = 0x20; // Space key
//        public const int BANG = 0x21; // ! key
//        public const int QOUTE = 0x22; // " key
//        public const int POUND = 0x23; // # key
//        public const int DOLLAR = 0x24; // $ key
//        public const int PERCENT = 0x25; // % key
//        public const int AMPER = 0x26; // & key
//        public const int APOSTRAPHE = 0x27; // ' key
//        public const int LEFTPAREN = 0x28; // ( key
//        public const int RIGHTPAREN = 0x29; // ) key
//        public const int ASTERIK = 0x2a; // * key
//        public const int PLUS = 0x2b; // + key
//        public const int COMMA = 0x2c; // , key
//        public const int MINUS = 0x2d; // - key
//        public const int PERIOD = 0x2e; // . key
//        public const int FSLASH = 0x2f; // / key
//        public const int N0 = 0x30; // 0 key
//        public const int N1 = 0x31; // 1 key
//        public const int N2 = 0x32; // 2 key
//        public const int N3 = 0x33; // 3 key
//        public const int N4 = 0x34; // 4 key
//        public const int N5 = 0x35; // 5 key
//        public const int N6 = 0x36; // 6 key
//        public const int N7 = 0x37; // 7 key
//        public const int N8 = 0x38; // 8 key
//        public const int N9 = 0x39; // 9 key
//        public const int COLON = 0x3a; // : key
//        public const int SEMICOLON = 0x3b; // ; key
//        public const int LESSTHAN = 0x3c; // < key
//        public const int EQUAL = 0x3d; // = key
//        public const int GREATERTHAN = 0x3e; // > key
//        public const int QUESTION = 0x3f; // ? key
//        public const int ATSYMBOL = 0x40; // @ key
//        public const int A = 0x41; // A key
//        public const int B = 0x42; // B key
//        public const int C = 0x43; // C key
//        public const int D = 0x44; // D key
//        public const int E = 0x45; // E key
//        public const int F = 0x46; // F key
//        public const int G = 0x47; // G key
//        public const int H = 0x48; // H key
//        public const int I = 0x49; // I key
//        public const int J = 0x4a; // J key
//        public const int K = 0x4b; // K key
//        public const int L = 0x4c; // L key
//        public const int M = 0x4d; // M key
//        public const int N = 0x4e; // N key
//        public const int O = 0x4f; // O key
//        public const int P = 0x50; // P key
//        public const int Q = 0x51; // Q key
//        public const int R = 0x52; // R key
//        public const int S = 0x53; // S key
//        public const int T = 0x54; // T key
//        public const int U = 0x55; // U key
//        public const int V = 0x56; // V key
//        public const int W = 0x57; // W key
//        public const int X = 0x58; // X key
//        public const int Y = 0x59; // Y key
//        public const int Z = 0x5a; // Z key
//        public const int LBRACKET = 0x5b; // [ key
//        public const int BSLASH = 0x5c; // \ key
//        public const int RBRACKET = 0x5d; // ] key
//        public const int CARROT = 0x5e; // ^ key
//        public const int UNDERSCORE = 0x5f; // _ key
//        public const int GRAVE = 0x60; // ` key
//        public const int a = 0x61; // a key
//        public const int b = 0x62; // b key
//        public const int c = 0x63; // c key
//        public const int d = 0x64; // d key
//        public const int e = 0x65; // e key
//        public const int f = 0x66; // f key
//        public const int g = 0x67; // g key
//        public const int h = 0x68; // h key
//        public const int i = 0x69; // i key
//        public const int j = 0x6a; // j key
//        public const int k = 0x6b; // k key
//        public const int l = 0x6c; // l key
//        public const int m = 0x6d; // m key
//        public const int n = 0x6e; // n key
//        public const int o = 0x6f; // o key
//        public const int p = 0x70; // p key
//        public const int q = 0x71; // q key
//        public const int r = 0x72; // r key
//        public const int s = 0x73; // s key
//        public const int t = 0x74; // t key
//        public const int u = 0x75; // u key
//        public const int v = 0x76; // v key
//        public const int w = 0x77; // w key
//        public const int x = 0x78; // x key
//        public const int y = 0x79; // y key
//        public const int z = 0x7a; // z key
//        public const int LCHEV = 0x7b; // { key
//        public const int PIPE = 0x7c; // | key
//        public const int RCHEV = 0x7d; // } key
//        public const int TILDE = 0x7e; // ~ key

//        public static void PressKey(char character)
//        {
//            byte press;

//            switch (character)
//            {
//                case '!':
//                    press = BANG;
//                    break;
//                case '"':
//                    press = QOUTE;
//                    break;
//                case '#':
//                    press = POUND;
//                    break;
//                case '$':
//                    press = DOLLAR;
//                    break;
//                case '%':
//                    press = PERCENT;
//                    break;
//                case '&':
//                    press = QOUTE;
//                    break;
//                case '\'':
//                    press = APOSTRAPHE;
//                    break;
//                case '(':
//                    press = LEFTPAREN;
//                    break;
//                case ')':
//                    press = RIGHTPAREN;
//                    break;
//                case '*':
//                    press = ASTERIK;
//                    break;
//                case '+':
//                    press = PLUS;
//                    break;
//                case ',':
//                    press = COMMA;
//                    break;
//                case '-':
//                    press = MINUS;
//                    break;
//                case '.':
//                    press = PERIOD;
//                    break;
//                case '/':
//                    press = FSLASH;
//                    break;
//                case '0':
//                    press = N0;
//                    break;
//                case '1':
//                    press = N1;
//                    break;
//                case '2':
//                    press = N2;
//                    break;
//                case '3':
//                    press = N3;
//                    break;
//                case '4':
//                    press = N4;
//                    break;
//                case '5':
//                    press = N5;
//                    break;
//                case '6':
//                    press = N6;
//                    break;
//                case '7':
//                    press = N7;
//                    break;
//                case '8':
//                    press = N8;
//                    break;
//                case '9':
//                    press = N9;
//                    break;
//                case ':':
//                    press = COLON;
//                    break;
//                case ';':
//                    press = SEMICOLON;
//                    break;
//                case '<':
//                    press = LESSTHAN;
//                    break;
//                case '=':
//                    press = EQUAL;
//                    break;
//                case '>':
//                    press = GREATERTHAN;
//                    break;
//                case '?':
//                    press = QUESTION;
//                    break;
//                case '@':
//                    press = ATSYMBOL;
//                    break;
//                case 'A':
//                    press = A;
//                    break;
//                case 'B':
//                    press = B;
//                    break;
//                case 'C':
//                    press = C;
//                    break;
//                case 'D':
//                    press = D;
//                    break;
//                case 'E':
//                    press = E;
//                    break;
//                case 'F':
//                    press = F;
//                    break;
//                case 'G':
//                    press = G;
//                    break;
//                case 'H':
//                    press = H;
//                    break;
//                case 'I':
//                    press = I;
//                    break;
//                case 'J':
//                    press = J;
//                    break;
//                case 'K':
//                    press = K;
//                    break;
//                case 'L':
//                    press = L;
//                    break;
//                case 'M':
//                    press = M;
//                    break;
//                case 'N':
//                    press = N;
//                    break;
//                case 'O':
//                    press = O;
//                    break;
//                case 'P':
//                    press = P;
//                    break;
//                case 'Q':
//                    press = Q;
//                    break;
//                case 'R':
//                    press = R;
//                    break;
//                case 'S':
//                    press = S;
//                    break;
//                case 'T':
//                    press = T;
//                    break;
//                case 'U':
//                    press = U;
//                    break;
//                case 'V':
//                    press = V;
//                    break;
//                case 'W':
//                    press = W;
//                    break;
//                case 'X':
//                    press = X;
//                    break;
//                case 'Y':
//                    press = Y;
//                    break;
//                case 'Z':
//                    press = Z;
//                    break;
//                case '[':
//                    press = LBRACKET;
//                    break;
//                case '\\':
//                    press = BSLASH;
//                    break;
//                case ']':
//                    press = RBRACKET;
//                    break;
//                case '^':
//                    press = CARROT;
//                    break;
//                case '_':
//                    press = UNDERSCORE;
//                    break;
//                case '`':
//                    press = GRAVE;
//                    break;
//                case 'a':
//                    press = a;
//                    break;
//                case 'b':
//                    press = b;
//                    break;
//                case 'c':
//                    press = c;
//                    break;
//                case 'd':
//                    press = d;
//                    break;
//                case 'e':
//                    press = e;
//                    break;
//                case 'f':
//                    press = f;
//                    break;
//                case 'g':
//                    press = g;
//                    break;
//                case 'h':
//                    press = h;
//                    break;
//                case 'i':
//                    press = i;
//                    break;
//                case 'j':
//                    press = j;
//                    break;
//                case 'k':
//                    press = k;
//                    break;
//                case 'l':
//                    press = l;
//                    break;
//                case 'm':
//                    press = m;
//                    break;
//                case 'n':
//                    press = n;
//                    break;
//                case 'o':
//                    press = o;
//                    break;
//                case 'p':
//                    press = p;
//                    break;
//                case 'q':
//                    press = q;
//                    break;
//                case 'r':
//                    press = r;
//                    break;
//                case 's':
//                    press = s;
//                    break;
//                case 't':
//                    press = t;
//                    break;
//                case 'u':
//                    press = u;
//                    break;
//                case 'v':
//                    press = v;
//                    break;
//                case 'w':
//                    press = w;
//                    break;
//                case 'x':
//                    press = x;
//                    break;
//                case 'y':
//                    press = y;
//                    break;
//                case 'z':
//                    press = z;
//                    break;
//                case '{':
//                    press = LCHEV;
//                    break;
//                case '|':
//                    press = PIPE;
//                    break;
//                case '}':
//                    press = RCHEV;
//                    break;
//                case '~':
//                    press = TILDE;
//                    break;
//                default:
//                    //DEFAULTING TO A BOGUS KEY
//                    press = BANG;
//                    break;
//            }

//            keybd_event(press, 0x9e, 0, 0); // Key pressed
//            keybd_event(press, 0x9e, KEYEVENTF_KEYUP, 0); //Key Released
//        }

//    }
//}   
