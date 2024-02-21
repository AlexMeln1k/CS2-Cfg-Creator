using System;

namespace Counter_StrikeCfgCreator
{
    internal class keybinds
    {
        internal static string ConvertToKey(string input)
        {
            switch (input)
            {

                case "Menu, Alt":
                    return "Alt";

                case "ControlKey, Control":
                    return "Ctrl";

                case "ShiftKey, Shift":
                    return "Shift";

                case "Capital":
                    return "CapsLock";

                case "Oemtilde":
                    return "`";

                case "OemQuestion":
                    return "/";

                case "OemPeriod":
                    return ".";

                case "Oemcomma":
                    return ",";

                case "Oem7":
                    return "'";

                case "Oem6":
                    return "]";

                case "OemOpenBrackets":
                    return "[";

                case "D1":
                    return "1";

                case "D2":
                    return "2";
                    
                case "D3":
                    return "3";
                    
                case "D4":
                    return "4";
                    
                case "D5":
                    return "5";
                    
                case "D6":
                    return "6";
                    
                case "D7":
                    return "7";
                    
                case "D8":
                    return "8";
                    
                case "D9":
                    return "9";
                    
                case "D0":
                    return "0";

                case "OemMinus":
                    return "-";

                case "Oemplus":
                    return "+";

                case "Next":
                    return "PageDown";

                default:
                    return input;
            }
        }
    }
}