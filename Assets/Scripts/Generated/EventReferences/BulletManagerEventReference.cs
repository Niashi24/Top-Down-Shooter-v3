using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `BulletManager`. Inherits from `AtomEventReference&lt;BulletManager, BulletManagerVariable, BulletManagerEvent, BulletManagerVariableInstancer, BulletManagerEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class BulletManagerEventReference : AtomEventReference<
        BulletManager,
        BulletManagerVariable,
        BulletManagerEvent,
        BulletManagerVariableInstancer,
        BulletManagerEventInstancer>, IGetEvent 
    { }
}
