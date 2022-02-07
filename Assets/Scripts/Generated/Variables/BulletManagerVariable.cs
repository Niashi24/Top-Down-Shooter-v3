using UnityEngine;
using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable of type `BulletManager`. Inherits from `AtomVariable&lt;BulletManager, BulletManagerPair, BulletManagerEvent, BulletManagerPairEvent, BulletManagerBulletManagerFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/BulletManager", fileName = "BulletManagerVariable")]
    public sealed class BulletManagerVariable : AtomVariable<BulletManager, BulletManagerPair, BulletManagerEvent, BulletManagerPairEvent, BulletManagerBulletManagerFunction>
    {
        protected override bool ValueEquals(BulletManager other)
        {
            throw new NotImplementedException();
        }
    }
}
