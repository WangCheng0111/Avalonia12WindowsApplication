using Avalonia;
using System;
using Avalonia.Controls;
using WindowsApplication.ViewModels;

namespace WindowsApplication.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // 创建ViewModel并设置DataContext
        var viewModel = new MainWindowViewModel();
        DataContext = viewModel;
        
        // 将窗口引用传递给ViewModel
        viewModel.SetWindowReference(this);
        
        // 监听窗口状态变化
        PropertyChanged += MainWindow_PropertyChanged;
                
    }
    
    private void MainWindow_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property == WindowStateProperty)
        {
            // 更新ViewModel中的按钮图标
            if (DataContext is MainWindowViewModel viewModel)
            {
                var isMaximized = WindowState == WindowState.Maximized;
                viewModel.UpdateMaximizeButtonIcon(isMaximized);
            }
        }
    }

}