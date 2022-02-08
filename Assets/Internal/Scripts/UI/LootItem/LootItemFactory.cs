using Core.IO;

using UnityEngine;

namespace Core.UI
{

    public class LootItemFactory : MonoBehaviour
    {
        [SerializeField] private LootItemPresenter _lootItemPrefab;
        [SerializeField] private Transform _parent;

        public virtual LootItemPresenter Create(IInput input)
        {
            var item = Instantiate(_lootItemPrefab, _parent);
            item.Init(input);

            return item;
        }

    }

}