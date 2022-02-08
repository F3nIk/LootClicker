using Core.IO;

using System;
using UnityEngine;

namespace Core.ItemSystem
{

    [Serializable]
    public class LootItemData
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private float _rewardRate;
        [SerializeField] private float _lootRate;
        [SerializeField] private int _maxLevel;

        private int _level = 1;

        public int Id => _id;
        public string Name => _name;
        public Sprite Icon => _sprite;
        public float RewardRate => _rewardRate * _level;
        public float LootRate => _lootRate;
        public int Level => _level;
        public int MaxLevel => _maxLevel;

        public LootItemData(LootItemData item, int level = 1)
        {
            _id = item._id;
            _name = item._name;
            _sprite = item._sprite;
            _rewardRate = item._rewardRate;
            _lootRate = item._lootRate;
            _level = level;
            _maxLevel = item._maxLevel;

        }
        public void IncreaseLevel()
        {
            _level++;
        }
    }

}