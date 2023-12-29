using System.Diagnostics.CodeAnalysis;
using ModShardLauncher;
using ModShardLauncher.Mods;


// REQUIRES NEOCONSOLE

namespace NeoConsole_SteamAddon;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class NeoConsole_SteamAddon : Mod
{
    public override string Author => "Nylux";
    public override string Name => "NeoConsole Addon - Steam Achievements";
    public override string Description => "Adds commands related to steam achievemnts. Requires NeoConsole.";
    public override string Version => "1.0.0";

    public override void PatchMod()
    {
        // Adding the scripts to the game
        ModLoader.AddFunction(ModFiles.GetCode("scr_neoconsole_clear_steam.gml"), "scr_neoconsole_clear_steam");
        ModLoader.AddFunction(ModFiles.GetCode("scr_neoconsole_unlock_steam.gml"), "scr_neoconsole_unlock_steam");
        
        // Injecting scr_neoconsole_init to add the commands and their help to the console.
        ModLoader.InsertDecompiledCode(ModFiles.GetCode("commandsMap.gml"), "scr_neoconsole_init", 13);
        ModLoader.InsertDecompiledCode(ModFiles.GetCode("helpSyntaxMap.gml"), "scr_neoconsole_init", 77);
        ModLoader.InsertDecompiledCode(ModFiles.GetCode("helpUsageMap.gml"), "scr_neoconsole_init", 138);
    }
}