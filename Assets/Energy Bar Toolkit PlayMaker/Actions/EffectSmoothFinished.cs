/*
* Copyright (c) Mad Pixel Machine
* http://www.madpixelmachine.com/
*/

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("Energy Bar Toolkit")]
[Tooltip("Sends an Event when the specified bar burn effect animation is finished.")]
public class EffectSmoothFinished : FsmStateAction {

    [RequiredField]
    [CheckForComponent(typeof(EnergyBarBase))]
    public FsmOwnerDefault bar;

    public FsmEvent callback;

    public bool everyFrame;

    private bool notified;

    public override void Reset() {
        base.Reset();

        bar = null;
        callback = null;
        everyFrame = false;
        notified = false;
    }

    public override void OnEnter() {
        base.OnEnter();

        var energyBarBase = bar.GameObject.Value.GetComponent<EnergyBarBase>();
        energyBarBase.effectSmoothChangeFinishedNotify.eventReceiver += @base => {
            notified = true;
        };
    }

    public override void OnUpdate() {
        base.OnUpdate();

        Execute();

        if (!everyFrame) {
            Finish();
        }
    }

    private void Execute() {
        if (notified) {
            notified = false;
            Fsm.Event(callback);
            Finish();
        }
    }
}

} // namespace