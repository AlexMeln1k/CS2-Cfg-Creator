using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_StrikeCfgCreator
{
    internal static class Description
    {
        public static string JumpThrow()
        {
            return "JumpThrow in CS:GO is an effective technique that allows players to throw grenades to precise distances or specific locations by performing a combination of jumping and throwing. This skill enables players to accurately control the distance and direction of grenade throws, which is crucial for tactical maneuvers and strategies on the map, and is one of many techniques experienced players use to improve their gameplay and effectiveness in CS2.";
        }
        public static string Bob()
        {
            return "In the latest update, Valve introduced a new setting called cl_usenewbob 1, which gives smoother movement to your character's hands. However, not all players are pleased with this change. If you find this update irritating, you can disable this feature and revert your character's hands to their usual movement style.";
        }
        public static string Optimize()
        {
            return "CS2 may encounter performance issues. However, there are some commands that can help optimize the performance of the game on your configuration. By adjusting certain parameters, you can achieve a smoother gaming experience.";
        }
        public static string HelloInConsole()
        {
            return "This script adds a greeting functionality upon loading your config in CS2. When the script is activated, the console will display a message indicating the loading of your config, along with a greeting addressed to you by your name.";
        }
        public static string FirstStart()
        {
            return "Before starting to work with the program for creating a new configuration, make sure all your CS2 settings are updated, fully saved, and meet your requirements.";
        }

        internal static string GunfireTraces()
        {
            return "This feature allows you to control bullet tracing for your weapon. When the option is enabled, tracer lines will be displayed, indicating the path of shots. However, if you disable this feature, bullet tracing will be hidden, which can be useful for improving game performance.";
        }

        internal static string GetPath(int id)
        {
#if DEBUG
            switch (id)
            {
                case 0:
                    return @"C:\Development\Counter-StrikeCfgCreator\ReBindCfg\bin\Debug\RebindCfg.exe";
                         case 1:
                    return @"C:\Development\Counter-StrikeCfgCreator\UnbindAllCfg\bin\Debug\UnbindAllCfg.exe";
                case 2:
                    return @"C:\Development\Counter-StrikeCfgCreator\Tweak1\bin\Debug\Tweak1.exe";
                case 3:
                    return @"C:\Development\Counter-StrikeCfgCreator\Tweak2\bin\Debug\Tweak2.exe";
                case 4:
                    return @"C:\Development\Counter-StrikeCfgCreator\Tweak3\bin\Debug\Tweak3.exe";
                case 5:
                    return @"C:\Development\Counter-StrikeCfgCreator\Tweak4\bin\Debug\Tweak4.exe";
                case 6:
                    return @"C:\Development\Counter-StrikeCfgCreator\Tweak5\bin\Debug\Tweak5.exe";

                default: return "";
            }
#else
            switch (id)
            {
                case 0:
                    return Path.Combine(Environment.CurrentDirectory, "ReBindCfg.exe");
                case 1:
                    return Path.Combine(Environment.CurrentDirectory, "UnbindAllCfg.exe");
                case 2:
                    return Path.Combine(Environment.CurrentDirectory, "Tweak1.exe");
                case 3:
                    return Path.Combine(Environment.CurrentDirectory, "Tweak2.exe");
                case 4:
                    return Path.Combine(Environment.CurrentDirectory, "Tweak3.exe");
                case 5:
                    return Path.Combine(Environment.CurrentDirectory, "Tweak4.exe");
                case 6:
                    return Path.Combine(Environment.CurrentDirectory, "Tweak5.exe");
                default:
                    return "";
            }
#endif
        }

        internal static string CsOptimizationPreview()
        {
            return "As of the beginning of 2024, CS2 is not optimally optimized, leading to FPS issues, stutters, and freezes. While this feature won't boost FPS, it will make the game a bit more stable. The best solution to optimize the game is tweaking Nvidia or Radeon Control Panel settings, lowering graphics settings, optimizing Windows, and more. You can find detailed information about this online.";
        }
    }
}
