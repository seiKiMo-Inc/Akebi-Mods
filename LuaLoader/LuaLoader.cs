using Akebi.Loader;

namespace LuaLoader;

public class LuaLoader : Mod
{
    public static LuaLoader Instance { get; private set; } = null!;

    protected LuaLoader(ModInfo info, ModLogger logger) 
        : base(info, logger) { }

    public override void OnLoad()
    {
        Instance = this; // Register the instance.
        
        // Register commands.
        Handle?.GetCommandMap().Register("luarun", new LuaRunCommand());
        
        Logger.Info("Loaded 'LuaLoader' by KingRainbow44!");
    }

    public override void OnEnable()
    {
        Logger.Info("Enabled 'LuaLoader' by KingRainbow44!");
    }
}