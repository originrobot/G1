using System.Linq;
using HutongGames.PlayMaker;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

namespace HutongGames.PlayMakerEditor
{
    public class PlayMakerBuildCallbacks
    {
        [PostProcessSceneAttribute(2)]
        public static void OnPostprocessScene()
        {
            //Debug.Log("OnPostprocessScene");

            PlayMakerGlobals.IsBuilding = true;
            PlayMakerGlobals.Initialize();

            var fsmList = Resources.FindObjectsOfTypeAll<PlayMakerFSM>();
            foreach (var playMakerFSM in fsmList)
            {
                //Debug.Log(FsmEditorUtility.GetFullFsmLabel(playMakerFSM));
                
                if (!Application.isPlaying) // actually making a build vs playing in editor
                {
                    playMakerFSM.Preprocess();
                }
            }

            PlayMakerGlobals.IsBuilding = false;

            //Debug.Log("EndPostProcessScene");
        }
    }
}
