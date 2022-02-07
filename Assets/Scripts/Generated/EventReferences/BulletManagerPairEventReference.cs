using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `BulletManagerPair`. Inherits from `AtomEventReference&lt;BulletManagerPair, BulletManagerVariable, BulletManagerPairEvent, BulletManagerVariableInstancer, BulletManagerPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class BulletManagerPairEventReference : AtomEventReference<
        BulletManagerPair,
        BulletManagerVariable,
        BulletManagerPairEvent,
        BulletManagerVariableInstancer,
        BulletManagerPairEventInstancer>, IGetEvent 
    { }
}
