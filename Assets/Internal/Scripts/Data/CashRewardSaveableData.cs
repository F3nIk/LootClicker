
using System;


[Serializable]
public sealed class CashRewardSaveableData
{
    public float baseReward;
    public float additionalReward;
    public float rewardRate;
    public float tapRewardRate;

    public float Reward => (baseReward + additionalReward) * rewardRate;
    public float RewardPerTap => (baseReward + additionalReward) * tapRewardRate;

    public CashRewardSaveableData(CashRewardDataBundle cashRewardDataBundle)
    {
        baseReward = cashRewardDataBundle.BaseReward;
        additionalReward = cashRewardDataBundle.AdditionalReward;
        rewardRate = cashRewardDataBundle.RewardRate;
        tapRewardRate = cashRewardDataBundle.RewardPerTap;
    }

}
