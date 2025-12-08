#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;

namespace Beyond.Networking.Editor {
    /// <summary>
    /// Borrowed this from Mirror
    /// </summary>
    static class ScriptDefine {
        [InitializeOnLoadMethod]
        public static void AddDefineSymbols() {
#if UNITY_2021_2_OR_NEWER
            string currentDefines = PlayerSettings.GetScriptingDefineSymbols(UnityEditor.Build.NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup));
#else
            // Deprecated in Unity 2023.1
            string currentDefines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
#endif
            HashSet<string> defines = new HashSet<string>(currentDefines.Split(';'))
            {
                "BEYONDNETWORKING",
            };
            string newDefines = string.Join(";", defines);
            if (newDefines != currentDefines) {
#if UNITY_2021_2_OR_NEWER
                PlayerSettings.SetScriptingDefineSymbols(UnityEditor.Build.NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup), newDefines);
#else
                // Deprecated in Unity 2023.1
                PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, newDefines);
#endif
            }
        }
    }
}
#endif