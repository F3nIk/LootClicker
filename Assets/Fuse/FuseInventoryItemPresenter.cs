using Core.InventorySystem;
using Core.ItemSystem;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI
{

    public class FuseInventoryItemPresenter : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private FuseInventoryItemView _fuseInventoryItemView;

        private FusePresenter _fusePresenter;
        private LootItemData _item;

        public void Init(FusePresenter fusePresenter, LootItemData item)
        {
            _fusePresenter = fusePresenter;
            _item = item;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _fusePresenter.AddItem(_item);
        }
    }

}