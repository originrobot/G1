// Small helper class to allow Fsm to call SetDirty
// Fsm is inside dll so cannot use #if UNITY_EDITOR

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HutongGames.PlayMaker
{
    public class UpdateHelper
    {
        public static void SetDirty(Fsm fsm)
        {
#if UNITY_EDITOR
            //Debug.Log("SetDirty: " + FsmUtility.GetFullFsmLabel(fsm));
            EditorUtility.SetDirty(fsm.OwnerObject);
#endif
        }
    }
}
