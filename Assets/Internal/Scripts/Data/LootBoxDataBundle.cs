using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Core.ItemSystem
{
    [CreateAssetMenu(menuName = "LootBoxDataBundle")]
    public class LootBoxDataBundle : ScriptableObject
    {
        [SerializeField] [Min(0)] private float _baseCost;
        [SerializeField] [Min(0)] private float _costPerOpen;

        [SerializeField] private LootItemData[] _data;

        public IReadOnlyList<LootItemData> Data => _data;
        public float Cost => _baseCost;
        public float AdditionalCostPerOpen => _costPerOpen;
        
        public LootItemData GetLoot()
        {
            var random = _data.ToList()[Random.Range(0, _data.Length - 1)];
            return new LootItemData(random);
        }
    }
}