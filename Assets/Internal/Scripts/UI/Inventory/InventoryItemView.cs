using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{

    public sealed class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _rateText;
        [SerializeField] private Image _selectedIndicator;

        public void Init(Sprite icon, float rateValue)
        {
            _image.sprite = icon;
            _rateText.text = rateValue.ToString();
        }


        public void EnableOutline()
        {
            _selectedIndicator.enabled = true;
        }

        public void DisableOutline()
        {
            _selectedIndicator.enabled = false;
        }
    }

}