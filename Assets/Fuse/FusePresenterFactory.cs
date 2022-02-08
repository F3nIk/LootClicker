using Core.InventorySystem;
using Core.ItemSystem;

using UnityEngine;

using Zenject;

namespace Core.UI
{

    public sealed class FusePresenterFactory : MonoBehaviour
    {
        [SerializeField] private FusePresenter _fusePresenterPrefab;
        [SerializeField] private Transform _parent;

        private Inventory _inventory;
        private Fuse _fuse;

        [Inject]
        public void Construct(Inventory inventory, Fuse fuse)
        {
            _inventory = inventory;
            _fuse = fuse;
        }

        public FusePresenter Create(LootItemData targetItem)
        {
            var presenter = Instantiate(_fusePresenterPrefab, _parent);
            presenter.SetTargetItem(_inventory, _fuse, targetItem);

            return presenter;
        }
    }
}