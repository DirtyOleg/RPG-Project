using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public interface IMove 
    {
        void MoveToTarget(Vector3 target);
        void CancelMove();
    }
}
