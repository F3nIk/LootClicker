using Core.IO;
using Core.ItemSystem;

using System;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace Core.InventorySystem
{

    public sealed class Inventory : ISaveable
    {
        private CashHandler _cashHandler;
        private List<LootItemData> _items;
        private LootItemData _equipedItem;

        private LootItemDataFactory _lootItemDataFactory;
        private InventorySaveableData _inventorySaveableData;

        private ISaver _saver;

        public event Action<LootItemData> EquipItemChanged;


        public IReadOnlyList<LootItemData> Items => _items;
        public CashHandler CashHandler => _cashHandler;
        public LootItemData EquipedItem => _equipedItem;
        public object SaveableObject => _inventorySaveableData;


        /*[Inject]
        public void Construct(LootItemDataFactory lootItemDataFactory, ISaver saver)
        {
            _lootItemDataFactory = lootItemDataFactory;
            _saver = saver;

            Init();
        }*/

        public Inventory(LootItemDataFactory lootItemDataFactory, ISaver saver)
        {
            _lootItemDataFactory = lootItemDataFactory;
            _saver = saver;

            Init();
        }

        public void Init()
        {
            _cashHandler = new CashHandler();
            _items = new List<LootItemData>();
            _inventorySaveableData = new InventorySaveableData();

            if (_saver.Exists(_cashHandler)) _saver.LoadOverwrite(_cashHandler);

            if (_saver.Exists(this))
            {
                _saver.LoadOverwrite(this);

                /*foreach (var id in _inventorySaveableData.container)
                {
                   _items.Add(_lootItemDataFactory.LoadFromDataBundle(id));
                }*/

                foreach (var itemWrapper in _inventorySaveableData.container)
                {
                    _items.Add(_lootItemDataFactory.LoadFromDataBundleAndSaveable(itemWrapper.id, itemWrapper.level));
                }

                _equipedItem = _items.Find(item => item.Id == _inventorySaveableData.equiped);
            }
        }

        public bool HasEquipedItemAndEqualsTo(LootItemData item)
        {
            return EquipedItem == null ? false : EquipedItem == item;
        }

        public void Save()
        {
            _saver.Save(_cashHandler);

            _inventorySaveableData = new InventorySaveableData(_items, _equipedItem);
            _saver.Save(this);
        }

        private void OnApplicationQuit()
        {
            Save();
        }


        public void AddItem(LootItemData item)
        {
            _items.Add(item);
        }
        
        public void RemoveItem(LootItemData item)
        {
            if (_items.Contains(item)) _items.Remove(item);
        }

        public void EquipItem(LootItemData item)
        {
            if (_items.Contains(item) == false) throw new System.Exception();

            _equipedItem = item;
            EquipItemChanged?.Invoke(_equipedItem);
        }

        public string GetFileName()
        {
            return Application.persistentDataPath + "/Inventory.rja";
        }
    }

}