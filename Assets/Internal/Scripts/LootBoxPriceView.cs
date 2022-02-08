using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public sealed class LootBoxPriceView : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void ChangeValue(float value)
        {
            _text.text = string.Format("{0:0.###}", value);
        }
    }

}

