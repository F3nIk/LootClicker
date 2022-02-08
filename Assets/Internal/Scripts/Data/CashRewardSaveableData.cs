using Core.IO;

using System;

using UnityEngine;

[Serializable]
public class CashRewardSaveableData
{
    public float baseReward;
    public float additionalReward;
    public float rewardRate;
    public float tapRewardRate;

    public CashRewardSaveableData(CashRewardDataBundle cashRewardDataBundle)
    {
        baseReward = cashRewardDataBundle.BaseReward;
        additionalReward = cashRewardDataBundle.AdditionalReward;
        rewardRate = cashRewardDataBundle.RewardRate;
        tapRewardRate = cashRewardDataBundle.RewardPerTap;
    }

}
