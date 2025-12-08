using Riptide;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Beyond.Networking
{
    [CreateAssetMenu(fileName = "Beyond Settings", menuName ="Beyond/Networking/Settings")]
    public class BeyondSettings : ScriptableObject
    {
        public static BeyondSettings Settings;
        [Header("Default Settings")]
        public uint MaxMessagePayloadSize = ushort.MaxValue;
        public uint MaxMessagePoolSize = 4;
        public ushort MaxConnectionAttempts = 5;
        public ushort MaxClients = 10;
        public string ServerName;
        public bool PublishUserIds = false;

        [Header("Data")]
        public List<PrefabReference> Prefabs = new();
        public List<RpcReference> Rpcs = new();

        private void Awake() {
            Setup();
        }

        public void Setup() {
            Settings = this;
            this.name = "Beyond Settings";
        }

        private void OnValidate() {
            Setup();
        }
    }

    [Serializable]
    public class PrefabReference {
        public string Key;
        public GameObject Prefab;
    }

    [Serializable]
    public class RpcReference {
        public Type Type => Type.GetType(TypeName);
        public string TypeName;
        public string MethodName;
    }
}
