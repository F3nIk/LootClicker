using Core.InventorySystem;
using Core.IO;

using UnityEngine;

using Zenject;

namespace Core.UI
{

    public sealed class InventoryPresenterFactory : MonoBehaviour
    {
        [Header("Target Object")]
        [SerializeField] private InventoryPresenter _presenterPrefab;

        [Space(10f)]
        [Header("Dependensies")]
        [SerializeField] private Transform _parent;

        private Inventory _inventory;

        [Inject]
        public void Construct(Inventory inventory)
        {
            _inventory = inventory;
        }

        public InventoryPresenter Create()
        {
            InventoryPresenter inventoryPresenter = Instantiate(_presenterPrefab, _parent);
            inventoryPresenter.Construct(_inventory);

            return inventoryPresenter;
        }
    }

}