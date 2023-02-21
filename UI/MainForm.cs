using WindowManipulator;

namespace UI;

public partial class MainForm : Form
{
    private Handler _handler = new Handler();
    
    public MainForm()
    {
        InitializeComponent();
        InitializeRunButton();
        _handler.ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
    }
    
    private void InitializeRunButton()
    {
        Button runProgramButton = new Button();
        runProgramButton.Location = new Point(20, 150);
        runProgramButton.Height = 40;
        runProgramButton.Width = 150;
        runProgramButton.Text = "Tile tables";
        runProgramButton.Name = "TileTables";
        runProgramButton.Click += ButtonRunProgram_Click;
        
        Controls.Add(runProgramButton);
    }

    private void ButtonRunProgram_Click(object sender, EventArgs e)
    {
        _handler
            .GetProcesses()
            .ResetCoordinates()
            .ResizeWindows();
    }
}