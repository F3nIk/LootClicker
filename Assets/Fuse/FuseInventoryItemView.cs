using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{

    public class FuseInventoryItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _rateText;
        [SerializeField] private Image _selected;

        public void Init(Sprite sprite, float rate)
        {
            _image.sprite = sprite;
            _rateText.text = rate.ToString();
        }
    }
}