using UnityEngine;

public class WaitForAnimationFinish : CustomYieldInstruction
{

    private Animation _animation;

    public WaitForAnimationFinish(Animation animation)
    {
        _animation = animation;
    }

    public override bool keepWaiting
    {
        get => _animation.isPlaying;
    }

}
