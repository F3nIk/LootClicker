using System;

using UnityEngine;

[CreateAssetMenu(menuName = "CashRewardDataBundle")]
public class CashRewardDataBundle : ScriptableObject
{
    [SerializeField] [Min(0)] private float _baseReward;

    [SerializeField] [Min(0)] private float _additionalReward;
    [SerializeField] [Min(1)] private float _rewardRate;
    [SerializeField] [Min(0)] private float _tapRewardRate;

    public float BaseReward => _baseReward;
    public float Reward => (_baseReward + _additionalReward) * _rewardRate;
    public float RewardPerTap => (_baseReward + _additionalReward) * _tapRewardRate;

    public event Action<float> RewardChanged;

    public float AdditionalReward
    {
        get => _additionalReward;
        set
        {
            _additionalReward = value;
            RewardChanged?.Invoke(Reward);
        }
    }

    public float RewardRate
    {
        get => _rewardRate;
        set
        {
            _rewardRate = value;
            RewardChanged?.Invoke(Reward);
        }
    }
}
