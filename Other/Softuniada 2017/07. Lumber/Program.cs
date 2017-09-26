using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Lumber
{
    class Program
    {
        public static List<LogNetwork> Networks;
        public static short NextNetworkId;
        public static Log[] Logs;

        static void Main(string[] args)
        {
            int[] split = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = split[0];
            int m = split[1];
            Logs = new Log[n];

            Networks = new List<LogNetwork>();

            for (short i = 0; i < n; i++)
            {
                short[] input = Array.ConvertAll(Console.ReadLine().Split(), short.Parse);
                Logs[i] = new Log(input[0], input[1], input[2], input[3], i);
            }

            
            while (true)
            {
                bool addNetwork = true;

                foreach (var log in Logs)
                {
                    if (log.HasNetwork()) continue;
                    foreach (var network in Networks)
                        if (network.CanAdd(log))
                        {
                            addNetwork = false;
                            log.NetworkId = network.Id;
                            network.Add(log);
                            break;
                        }
                }

                if (!addNetwork) continue;
                bool hasAdded = false;
                foreach (var log in Logs)
                {
                    if (log.HasNetwork()) continue;
                    var newNetwork = new LogNetwork(log);
                    log.NetworkId = newNetwork.Id;
                    Networks.Add(newNetwork);
                    hasAdded = true;
                    break;
                }
                if (!hasAdded) break;
            }
//            Networks = null;
            for (int i = 0; i < m; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s) - 1);

                Console.WriteLine(Logs[input[0]].NetworkId == Logs[input[1]].NetworkId ? "YES" : "NO");

            }

        }
    }

    class LogNetwork
    {
        public LogNetwork(Log initialLog)
        {
            Logs = new List<short> { initialLog.LogId };
            Id = Program.NextNetworkId;
            Program.NextNetworkId++;
        }

        public short Id { get; }

        public List<short> Logs { get; }

        public void Add(Log log)
        {
            Logs.Add(log.LogId);
        }

        public bool CanAdd(Log newLog)
        {
            return Logs.Any(log => Program.Logs[log].IsConnectedSimple(newLog));
        }

    }

    class Log
    {
        public short X1 { get; }
        public short X2 { get; }
        public short Y1 { get; }
        public short Y2 { get; }
        public short NetworkId { get; set; }
        public short LogId { get; }

        public Log(short x1, short y1, short x2, short y2, short logId)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            NetworkId = -1;
            LogId = logId;
        }

        public bool IsConnectedSimple(Log otherLog)
        {
            return X1 <= otherLog.X2 && X2 >= otherLog.X1 && Y2 <= otherLog.Y1 && Y1 >= otherLog.Y2;
        }

        public bool HasNetwork()
        {
            return NetworkId != -1;
        }

        public LogNetwork GetNetwork()
        {
            return Program.Networks[NetworkId];
        }

    }
}