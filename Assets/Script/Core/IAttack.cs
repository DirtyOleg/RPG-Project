using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public interface IAttack
    {
        void AttackTarget(GameObject target);
        void CancelAttack();
    }
}