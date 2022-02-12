using UnityEngine;

namespace Core.UI
{

    public class DetailItemViewFactory : MonoBehaviour
    {
        [SerializeField] private DetailItemView _detailItemViewPrefab;
        [SerializeField] private Transform _parent;

        public virtual DetailItemView Create()
        {
            return Instantiate(_detailItemViewPrefab, _parent);
        }
    }

}