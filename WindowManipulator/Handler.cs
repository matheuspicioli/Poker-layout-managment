using System.Diagnostics;

namespace WindowManipulator;

public class Handler
{
    public readonly int DefaultWidth = 476;
    private int X { get; set; } = 0;
    private int Y { get; set; } = 0;
    private int Width { get; set; }
    private int Height { get; set; } = 356;
    private Process[] Processes { get; set; }
    public int ScreenWidth { get; set; } = 1920;
    
    public Handler GetProcesses()
    {
        // Use Notepad process to easily tests
        Processes = Process.GetProcessesByName("Notepad");
        // Processes = Process.GetProcessesByName(EProcess.Pokerstars.ToString())
            // .Concat(Process.GetProcessesByName(EProcess.GGnet.ToString()))
            // .ToArray();
        
        if (Processes.Length == 0)
        {
            throw new Exception("--- Has no poker window ---");
        }

        return this;
    }

    public Handler ResetCoordinates()
    {
        X = 0;
        Y = 0;

        return this;
    }

    private void ValidateProcess(Process process)
    {
        if (String.IsNullOrEmpty(process.MainWindowTitle))
        {
            throw new Exception("--- Process has not window ---");
        }
    }
    
    // @TODO: make dinamyc rules only here
    // Builder methods strategy idea
    public Handler DynamicWidth()
    {
        // Divide window size to comport with biggest size 
        
        return this;
    }

    public void ResizeWindows()
    {
        if ((Width = ScreenWidth / Processes.Length) < DefaultWidth)
        {
            Width = DefaultWidth;
        }
        
        foreach (Process process in Processes)
        {
            IntPtr handle = process.MainWindowHandle;
            Rect rect = new Rect();
            if (!ExternalMethods.GetWindowRect(handle, ref rect))
            {
                throw new Exception("--- Cannot get main window rect ---");
            }
            
            // Reset "line"
            if ((X + Width) > ScreenWidth)
            {
                Y += Height;
                X = 0;
            }
                        
            ExternalMethods.MoveWindow(handle, X, Y, Width, Height, true);
            X += Width;
        }
    }
}
