using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace WindowsApplication.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // 窗口引用
    private Window? _window;
        
    // 设置窗口引用的方法
    public void SetWindowReference(Window window)
    {
        _window = window;
    }
        
    // 更新最大化按钮图标的方法
    public void UpdateMaximizeButtonIcon(bool isMaximized)
    {
        MaximizeButtonIcon = isMaximized ? "\uE923" : "\uE922";
    }

    // 窗口控制按钮状态
    private string _maximizeButtonIcon = "\uE922"; // 最大化按钮图标

    public string MaximizeButtonIcon
    {
        get => _maximizeButtonIcon;
        set => SetProperty(ref _maximizeButtonIcon, value);
    }
    
    // 窗口控制命令
    private RelayCommand? _minimizeWindowCommand;
    public RelayCommand MinimizeWindowCommand => _minimizeWindowCommand ??= new RelayCommand(MinimizeWindow);
    
    private RelayCommand? _maximizeWindowCommand;
    public RelayCommand MaximizeWindowCommand => _maximizeWindowCommand ??= new RelayCommand(MaximizeWindow);
    
    private RelayCommand? _closeWindowCommand;
    public RelayCommand CloseWindowCommand => _closeWindowCommand ??= new RelayCommand(CloseWindow);
    
    private void MinimizeWindow()
    {
        if (_window != null)
        {
            _window.WindowState = WindowState.Minimized;
        }
    }
    
    private void MaximizeWindow()
    {
        if (_window != null)
        {
            if (_window.WindowState == WindowState.Maximized)
            {
                _window.WindowState = WindowState.Normal;
            }
            else
            {
                _window.WindowState = WindowState.Maximized;
            }
        }
    }
    
    private void CloseWindow()
    {
        if (_window != null)
        {
            _window.Close();
        }
    }

}