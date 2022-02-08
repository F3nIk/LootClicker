using Core.ItemSystem;

using System;
using System.Collections.Generic;

[Serializable]
public class InventorySaveableData
{
    public ItemDataWrapper[] container;
    public int equiped;

    public InventorySaveableData() { }

    public InventorySaveableData(List<LootItemData> itemsContainer, LootItemData equipedItem)
    {
        /*  container = new int[itemsContainer.Count, itemsContainer.Count];

          for (int index = 0; index < container.Length; index++)
          {
              container[index] = itemsContainer[index].Id;
          }

          if (equipedItem != null)
              equiped = equipedItem.Id;*/

        container = new ItemDataWrapper[itemsContainer.Count];

        for (int index = 0; index < container.Length; index++)
        {
            container[index] = new ItemDataWrapper(itemsContainer[index].Id, itemsContainer[index].Level);
        }

        if (equipedItem != null)
            equiped = equipedItem.Id;
    }

    [Serializable]
    public class ItemDataWrapper
    {
        public int id;
        public int level;

        public ItemDataWrapper(int id, int level)
        {
            this.id = id;
            this.level = level;
        }
    }
}

