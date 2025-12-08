using Beyond.Networking;
using UnityEngine;

public class NetworkGUI : MonoBehaviour
{
    Rect GUIWindowRect = new(0, 0, 200, 200);
    void OnGUI() {
        if (!enabled)
            return;
        GUIWindowRect = GUILayout.Window(0, GUIWindowRect, GUIWindow, "NetworkGUI");
    }
    string address;
    bool showData;
    private void GUIWindow(int id) {
        GUILayout.Box("Server");
        showData = GUILayout.Toggle(showData, "Show Data");
        if (showData) {
            GUILayout.Box("DATA");
            if (GUILayout.Button("Update Server Data to Clients")) {
                BeyondNetwork.UpdateServerData();
            }
            GUILayout.Box(JsonUtility.ToJson(BeyondNetwork.CurrentServer, true));
        }
        if (GUILayout.Button("Create Server")) {
            var properties = new string[3];
            properties[0] = "Balls";
            properties[1] = "Squares";
            properties[2] = "CUSTOM";
            BeyondNetwork.CreateServer("", properties);
        }
        
        GUILayout.Box("Client");
        BeyondNetwork.NickName = GUILayout.TextField(BeyondNetwork.NickName);
        BeyondNetwork.UserId = GUILayout.TextField(BeyondNetwork.UserId);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Join Server")) {
            BeyondNetwork.JoinServer(address);
        }
        address = GUILayout.TextField(address);
        GUILayout.EndHorizontal();
    }
}
