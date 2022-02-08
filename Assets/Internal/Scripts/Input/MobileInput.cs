using System;

using UnityEngine;
using Zenject;

namespace Core.IO
{

    public class MobileInput : IInput, ITickable
    {
        public event Action OnClick;

        public void Tick()
        {
            if (Input.touches.Length > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    OnClick?.Invoke();
                }
            }
        }

    }

}