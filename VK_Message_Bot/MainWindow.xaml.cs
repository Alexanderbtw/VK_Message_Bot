﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using VK_Mes_ModelLib;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VK_Message_Bot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Utility.Initialize();
            Task.Factory.StartNew(() => Utility.StartReceiving());
            Utility.Log += GetUserIngo;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void GetUserIngo(UserInfo uInfo)
        {
            txtLogInfo.Text = uInfo.message;
        }
    }
}
