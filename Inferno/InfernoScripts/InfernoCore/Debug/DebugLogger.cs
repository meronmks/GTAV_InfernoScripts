﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inferno
{
    public class DebugLogger
    {
        private TcpSocketManager tcpSocketManager;
        private string logPath = @"InfernoScript.log";

        public DebugLogger()
        {
            tcpSocketManager = new TcpSocketManager();
            tcpSocketManager.ServerStart();
        }

        /// <summary>
        /// メッセージをブロードキャストする
        /// </summary>
        /// <param name="message"></param>
        private void WriteToTCP(string message)
        {
            tcpSocketManager.SendToAll(message);
        }

        /// <summary>
        /// テキストに書き出す
        /// </summary>
        /// <param name="message"></param>
        private void WriteToText(string message)
        {
            try
            {
                using (var w = new StreamWriter(logPath, true,Encoding.UTF8))
                {
                    w.WriteLineAsync(message);
                }
            }
            catch (Exception)
            {
                
            }

        }
       

        public void Log(string message)
        {
            var sendMessage = String.Format("[{0}] {1}", DateTime.Now, message);
            WriteToTCP(sendMessage);
            WriteToText(sendMessage);
        }

    }

}