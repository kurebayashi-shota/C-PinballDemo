using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PinballDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    DispatcherTimer timer = new DispatcherTimer();

    double ballX = 190;
    double ballY = 300;
    double ballVX = 3;
    double ballVY = 4;

    double paddleX = 150;
    const double paddleY = 540;

    public MainWindow()
    {
        InitializeComponent();

        // 初期配置
        Canvas.SetLeft(Ball, ballX);
        Canvas.SetTop(Ball, ballY);

        Canvas.SetLeft(Paddle, paddleX);
        Canvas.SetTop(Paddle, paddleY);

        // タイマー（ゲームループ）
        timer.Interval = TimeSpan.FromMilliseconds(16); // 約60FPS
        timer.Tick += GameLoop;
        timer.Start();
    }

    void GameLoop(object? sender, EventArgs e)
    {
        // ボール移動
        ballX += ballVX;
        ballY += ballVY;

        // 壁反射（左右）
        if (ballX <= 0 || ballX >= GameCanvas.ActualWidth - 20)
            ballVX *= -1;

        // 上反射
        if (ballY <= 0)
            ballVY *= -1;

        // パドル衝突
        if (ballY >= paddleY - 20 &&
            ballX + 20 >= paddleX &&
            ballX <= paddleX + 100)
        {
            ballVY *= -1;
        }

        // 落下（ゲームオーバー）
        if (ballY > GameCanvas.ActualHeight)
        {
            timer.Stop();
            MessageBox.Show("Game Over");
        }

        Canvas.SetLeft(Ball, ballX);
        Canvas.SetTop(Ball, ballY);
    }

    // キー操作
    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Left && paddleX > 0)
            paddleX -= 20;

        if (e.Key == Key.Right && paddleX < GameCanvas.ActualWidth - 100)
            paddleX += 20;

        Canvas.SetLeft(Paddle, paddleX);
    }
}