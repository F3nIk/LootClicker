using System;

using UnityEngine;

using Zenject;

namespace Core.IO
{

    public class DesktopInput : IInput, ITickable
    {
        public event Action OnClick;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick?.Invoke();
            }
        }
    }

}