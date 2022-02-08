using UnityEngine;

namespace Core.UI
{

    [RequireComponent(typeof(Animation))]
    public sealed class LootBoxView : MonoBehaviour
    {
        private Animation _animation;

        private void Awake()
        {
            _animation = GetComponent<Animation>();
        }

        public Animation PlayOpenAnimation()
        {
            _animation.Play("Crate_Open");
            return _animation;
        }

        public Animation PlayCloseAnimation()
        {
            _animation.Play("Crate_Close");
            return _animation;
        }
    }

}