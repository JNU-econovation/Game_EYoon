using System.IO;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;

namespace Rokoko.MotionLibraryCompatibility
{
    internal class MotionLibraryWindowCompatibility : EditorWindow
    {        
        internal class Fonts
        {
            public static Font normalText = (Font)Resources.Load("Fonts/ProximaNova/Regular/proximanova-regular-webfont");
            public static Font boldText = (Font)Resources.Load("Fonts/ProximaNova/Bold/proximanova-bold-webfont");
        }

        internal static readonly string SHOW_MOLIB_PLAYER_PREFS_KEY = "MotionLibraryShow";
        
#if !NET_4_6

        // Add menu item named "My Window" to the Window menu
        [MenuItem("Window/Motion Library")]
        public static void ShowWindow()
        {
            var scriptingRuntimeNeedsUpgrade = PlayerSettings.scriptingRuntimeVersion != ScriptingRuntimeVersion.Latest;
            var apiCompatibilityNeedsUpgrade =
                PlayerSettings.GetApiCompatibilityLevel(EditorUserBuildSettings.selectedBuildTargetGroup) !=
                ApiCompatibilityLevel.NET_4_6;

            if (!scriptingRuntimeNeedsUpgrade && !apiCompatibilityNeedsUpgrade)
            {     
                AssetDatabase.Refresh();
                var assets = AssetDatabase.FindAssets("MotionLibraryWindowCompatibility");
                if (assets.Length > 0)
                    AssetDatabase.ImportAsset(AssetDatabase.GUIDToAssetPath(assets[0]));
                
                PlayerPrefs.SetInt(SHOW_MOLIB_PLAYER_PREFS_KEY, 1);
                PlayerPrefs.Save();
                return;
            }

            //Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(MotionLibraryWindowCompatibility));
        }
#endif

        private void OnEnable()
        {
            minSize = new Vector2(650, 180);
        }

        void OnGUI()
        {            
            // Bold text style
            var boldText = new GUIStyle(GUI.skin.label);
            boldText.alignment = TextAnchor.MiddleCenter;
            boldText.font = Fonts.boldText;
            // Normal text style
            var centeredText = new GUIStyle(GUI.skin.label);
            centeredText.font = Fonts.normalText;
            centeredText.wordWrap = true;
            centeredText.alignment = TextAnchor.MiddleCenter;
            
            var buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fixedWidth = 260;
            buttonStyle.fixedHeight = 50;

            GUILayout.FlexibleSpace();
            GUILayout.Space(10);
            GUILayout.Label("Motion Library needs different fuel", boldText);
            GUILayout.Space(25);
            
            GUILayout.Label("You are currently using an older version of .NET, however Motion Library requires you to use .NET API version 4.X. You can easily switch by clicking the button below.", centeredText);

            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            
            // Runtime version needs change and restart is required
            if (PlayerSettings.scriptingRuntimeVersion != ScriptingRuntimeVersion.Latest)
            {
                if (GUILayout.Button("Please change the setting and close Unity", buttonStyle))
                {
                    if (EditorUtility.DisplayDialog("You need to set the Scripting Runtime Version to .NET 4.x Equivalent", "The Motion Library plugin can do this for you, but remember you need to manually re-open Unity and the project afterwards. Do you want to proceed?", "Yes, change it and close Unity", "No, not right now"))
                    {
                        Close();

                        if (PlayerSettings.GetApiCompatibilityLevel(EditorUserBuildSettings.selectedBuildTargetGroup) != ApiCompatibilityLevel.NET_4_6)
                        {
                            PlayerSettings.SetApiCompatibilityLevel(EditorUserBuildSettings.selectedBuildTargetGroup, ApiCompatibilityLevel.NET_4_6);
                        }

                        PlayerSettings.scriptingRuntimeVersion = ScriptingRuntimeVersion.Latest;
                        
                        EditorApplication.Exit(0);
                    }
                }
            }
            // Only API Compatibility level needs change and restart isn't required.
            else
            {
                if (GUILayout.Button("Change API Compatibility level to .NET 4.X", buttonStyle))
                {
                    if (EditorUtility.DisplayDialog(
                        "Confirm",
                        "Unity will load for a few seconds and The Motion Library will then open. Do you want to proceed?",
                        "Yes", "No, not right now"))
                    {
                        if (PlayerSettings.GetApiCompatibilityLevel(EditorUserBuildSettings.selectedBuildTargetGroup) !=
                            ApiCompatibilityLevel.NET_4_6)
                        {
                            PlayerSettings.SetApiCompatibilityLevel(EditorUserBuildSettings.selectedBuildTargetGroup,
                                ApiCompatibilityLevel.NET_4_6);
                        }

                        PlayerPrefs.SetInt(SHOW_MOLIB_PLAYER_PREFS_KEY, 1);
                        PlayerPrefs.Save();
                        Close();
                    }
                }
            }
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
        }
    }
}
