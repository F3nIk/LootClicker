using Core.IO;

using System;

using UnityEngine;

namespace Core
{

    public sealed class CashHandler : ISaveable
    {
        private readonly CashData _cashData = new CashData();


        public event Action<float> CashChanged;

        public object SaveableObject => _cashData;
        public float Cash => _cashData.cash;



        public void Add(float amount)
        {
            if (amount < 0) throw new System.ArgumentException("Less then zero", nameof(amount));

            _cashData.cash += amount;
            CashChanged?.Invoke(_cashData.cash);
        }

        public void Take(float amount)
        {
            _cashData.cash -= amount;
            CashChanged?.Invoke(_cashData.cash);
        }

        public bool IsEnough(float cost) => cost <= _cashData.cash;

        public string GetFileName()
        {
            return Application.persistentDataPath + "/Cash.rja";
        }
    }
}