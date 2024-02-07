using System.Diagnostics.CodeAnalysis;
using ModShardLauncher;
using ModShardLauncher.Mods;


// REQUIRES NEOCONSOLE

namespace NeoConsole_SteamAddon;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class NeoConsole_SteamAddon : Mod
{
    public override string Author => "Nylux";
    public override string Name => "NeoConsole Addon - Steam";
    public override string Description => "Adds commands unique to steam. Requires NeoConsole.";
    public override string Version => "1.1.1";

    public override void PatchMod()
    {
        // Adding the scripts to the game
        Msl.AddFunction(ModFiles.GetCode("scr_neoconsole_clear_steam.gml"), "scr_neoconsole_clear_steam");
        Msl.AddFunction(ModFiles.GetCode("scr_neoconsole_unlock_steam.gml"), "scr_neoconsole_unlock_steam");
        
        // Injecting scr_neoconsole_init to add the commands and their help to the console.
        Msl.InsertGMLString(ModFiles.GetCode("commandsMap.gml"), "scr_neoconsole_init", 13);
        Msl.InsertGMLString(ModFiles.GetCode("helpSyntaxMap.gml"), "scr_neoconsole_init", 77);
        Msl.InsertGMLString(ModFiles.GetCode("helpUsageMap.gml"), "scr_neoconsole_init", 138);
    }
}
