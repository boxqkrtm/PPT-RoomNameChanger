using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PPT_RoomNameChanger
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread worker = null;
        int loopc = 1;
        ProcessMemory Game;
        public MainWindow()
        {
            InitializeComponent();
            worker = new Thread(() => Run(0));
            worker.Start();
        }

        private void Run(int val)
        {
            while (true)
            {
                if (loopc == 0)
                {
                    Game = new ProcessMemory("puyopuyotetris");
                    var roomtitle = Game.ReadStringUnicode(new IntPtr(
                               Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                         Game.ReadInt32(new IntPtr(
                                                Game.ReadInt32(new IntPtr(
                                                    Game.ReadInt32(new IntPtr(
                                                        0x140460690
                                                    )) + 0x20
                                                )) + 0x20
                                            )) + 0x20
                                        )) + 0x610
                                    )) + 0x4
                            + 0xAC), 32);
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                    {
                    //사용할 메서드 및 동작
                    textBox1.Text = ("" + roomtitle);
                    }));
                }
                Thread.Sleep(1000);
                loopc -= 1;
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //if (worker != null) 
            worker.Abort();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Game = new ProcessMemory("puyopuyotetris");
            Game.WriteStringUnicode(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                     Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    0x140460690
                                )) + 0x20
                            )) + 0x20
                        )) + 0x20
                    )) + 0x610
                )) + 0x4
                + 0xAC),
                "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0");
            Game.WriteStringUnicode(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                     Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    0x140460690
                                )) + 0x20
                            )) + 0x20
                        )) + 0x20
                    )) + 0x610
                )) + 0x4
                + 0xAC),
                textBox1.Text);
            loopc = 30;
        }
    }
}

