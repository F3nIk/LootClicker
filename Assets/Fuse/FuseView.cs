using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{

    public sealed class FuseView : MonoBehaviour
    {
        [SerializeField] private Image _targetItemIcon;

        //TODO: Animation
        private Animation _animation;

        public void SetTargetIcon(Sprite sprite)
        {
            _targetItemIcon.sprite = sprite;
        }


    }

}