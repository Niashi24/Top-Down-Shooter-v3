using System;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `BulletManager`. Inherits from `AtomReference&lt;BulletManager, BulletManagerPair, BulletManagerConstant, BulletManagerVariable, BulletManagerEvent, BulletManagerPairEvent, BulletManagerBulletManagerFunction, BulletManagerVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class BulletManagerReference : AtomReference<
        BulletManager,
        BulletManagerPair,
        BulletManagerConstant,
        BulletManagerVariable,
        BulletManagerEvent,
        BulletManagerPairEvent,
        BulletManagerBulletManagerFunction,
        BulletManagerVariableInstancer>, IEquatable<BulletManagerReference>
    {
        public BulletManagerReference() : base() { }
        public BulletManagerReference(BulletManager value) : base(value) { }
        public bool Equals(BulletManagerReference other) { return base.Equals(other); }
        protected override bool ValueEquals(BulletManager other)
        {
            throw new NotImplementedException();
        }
    }
}
