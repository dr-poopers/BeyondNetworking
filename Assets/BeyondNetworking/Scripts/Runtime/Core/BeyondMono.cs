using Riptide;
using Riptide.Utils;
using UnityEngine;

namespace Beyond.Networking
{
    public class BeyondMono : MonoBehaviour
    {
        public Server Server {
            get; set;
        } = new("BEYONDSERVER");

        public Client Client {
            get; set;
        } = new("BEYONDCLIENT");

        private void Start() {
            DontDestroyOnLoad(this);
            RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);
        }

        private void LateUpdate() {
            Server?.Update();
            Client?.Update();
        }
    }
}
