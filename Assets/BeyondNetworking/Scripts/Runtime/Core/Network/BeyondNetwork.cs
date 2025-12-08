using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beyond.Networking
{
    public static partial class BeyondNetwork
    {
        public static BeyondMono Mono;
        static BeyondNetwork() {
            var settings = Resources.Load<BeyondSettings>("Beyond Settings");
            if (!Application.IsPlaying(settings) || settings == null)
                return;
            NickName = PlayerPrefs.GetString("NICKNAME", $"Player{Random.Range(1000, 9999)}");
            UserId = Application.buildGUID;
            BeyondSettings.Settings = settings;
            Mono = new GameObject("Beyond Mono").AddComponent<BeyondMono>();
            Mono.Server.ClientDisconnected += Server_ClientDisconnected;
        }

        private static void Server_ClientDisconnected(object sender, Riptide.ServerDisconnectedEventArgs e) {
            CurrentServer.Clients.Remove(CurrentServer.Clients.Find(x => x.GetConnection() == e.Client));
            UpdateServerData();
        }
    }
}
