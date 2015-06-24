using System.IO;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMakerEditor
{
    public class ProjectTools
    {
        // Change MenuRoot to move the Playmaker Menu
        // E.g., MenuRoot = "Plugins/PlayMaker/"
        private const string MenuRoot = "PlayMaker/";

        [MenuItem(MenuRoot + "Tools/Update All Loaded FSMs", false, 31)]
        public static void ReSaveAllLoadedFSMs()
        {
            SaveAllLoadedFSMs();
        }

        [MenuItem(MenuRoot + "Tools/Update All FSMs in Build", false, 32)]
        public static void ReSaveAllFSMsInBuild()
        {        
            SaveAllFSMsInBuild();
        }

        /*WIP
        [MenuItem(MenuRoot + "Tools/Scan Scenes", false, 33)]
        public static void ScanScenesInProject()
        {
            FindAllScenes();
        }
*/

        private static void SaveAllLoadedFSMs()
        {
            Debug.Log("Checking loaded FSMs...");
            FsmEditor.RebuildFsmList();
            foreach (var fsm in FsmEditor.FsmList)
            {
                // Re-initialize loads data and forces a dirty check
                // so we can just call this and let it handle dirty etc.

                fsm.Reinitialize();
            }
        }

        private static void SaveAllFSMsInBuild()
        {
            // Allow the user to save his work!
            if (!EditorApplication.SaveCurrentSceneIfUserWantsTo())
            {
                return;
            }

            LoadPrefabsWithPlayMakerFSMComponents();

            foreach (var scene in EditorBuildSettings.scenes)
            {
                Debug.Log("Open Scene: " + scene.path);
                EditorApplication.OpenScene(scene.path);
                SaveAllLoadedFSMs();
                if (!EditorApplication.SaveScene())
                {
                    Debug.LogError("Could not save scene!");
                }
            }
        }

        private static void LoadPrefabsWithPlayMakerFSMComponents()
        {
            Debug.Log("Finding Prefabs with PlayMakerFSMs");

            var searchDirectory = new DirectoryInfo(Application.dataPath);
            var prefabFiles = searchDirectory.GetFiles("*.prefab", SearchOption.AllDirectories);

            foreach (var file in prefabFiles)
            {
                var filePath = file.FullName.Replace(@"\", "/").Replace(Application.dataPath, "Assets");
                //Debug.Log(filePath + "\n" + Application.dataPath);

                var dependencies = AssetDatabase.GetDependencies(new[] { filePath });
                foreach (var dependency in dependencies)
                {
                    if (dependency.Contains("/PlayMaker.dll"))
                    {
                        Debug.Log("Found Prefab with FSM: " + filePath);
                        AssetDatabase.LoadAssetAtPath(filePath, typeof(GameObject));
                    }
                }
            }

            FsmEditor.RebuildFsmList();
        }

        /* WIP
        [Localizable(false)]
        private static void FindAllScenes()
        {
            Debug.Log("Finding all scenes...");

            var searchDirectory = new DirectoryInfo(Application.dataPath);
            var assetFiles = searchDirectory.GetFiles("*.unity", SearchOption.AllDirectories);

            foreach (var file in assetFiles)
            {
                var filePath = file.FullName.Replace(@"\", "/").Replace(Application.dataPath, "Assets");
                var obj = AssetDatabase.LoadAssetAtPath(filePath, typeof(Object));
                if (obj == null)
                {
                    //Debug.Log(filePath + ": null!");
                }
                else if (obj.GetType() == typeof(Object))
                {
                    Debug.Log(filePath);// + ": " + obj.GetType().FullName);
                }
                //var obj = AssetDatabase.
            }
        }
         */
    }
}

