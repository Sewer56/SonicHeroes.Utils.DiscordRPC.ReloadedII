using System.Runtime.InteropServices;
using SonicHeroes.Utils.DiscordRPC.Heroes.Definitions.Enums;

namespace SonicHeroes.Utils.DiscordRPC.Heroes.Definitions
{
    [StructLayout(LayoutKind.Explicit)]
    public struct SomeGameControlStruct
    {
        [FieldOffset(0x00000027)]
        public byte StoryModeFlag;

        [FieldOffset(0x00000028)]
        public MissionMode MissionMode;
    }
}
