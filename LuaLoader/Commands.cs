using Akebi.Loader;

namespace LuaLoader;

public class LuaRunCommand : ICommand
{
    public void Execute(string[] args)
    {
        // Validate the passed arguments.
        if (args.Length < 1)
        {
            LuaLoader.Instance.Logger.Warn("No file specified.");
            LuaLoader.Instance.Logger.Info("Usage: luarun <data path>");
            return;
        }
        
        // Get the file from the arguments.
        var fileName = string.Join(' ', args);
        var filePath = $"{LuaLoader.Instance.GetDataDirectory().FullName}/{fileName}";
        
        // Check if the file exists.
        if (!File.Exists(filePath))
        {
            LuaLoader.Instance.Logger.Warn("File does not exist.");
            return;
        }
        
        // Execute the Lua.
        LuaLoader.Instance.Handle?.CallLua(
            File.ReadAllBytes(filePath), 
            filePath.EndsWith(".luac"));
        LuaLoader.Instance.Logger.Info($"Executed the Lua script at '{filePath}'!");
    }
}