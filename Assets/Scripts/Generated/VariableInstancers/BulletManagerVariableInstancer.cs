using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `BulletManager`. Inherits from `AtomVariableInstancer&lt;BulletManagerVariable, BulletManagerPair, BulletManager, BulletManagerEvent, BulletManagerPairEvent, BulletManagerBulletManagerFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/BulletManager Variable Instancer")]
    public class BulletManagerVariableInstancer : AtomVariableInstancer<
        BulletManagerVariable,
        BulletManagerPair,
        BulletManager,
        BulletManagerEvent,
        BulletManagerPairEvent,
        BulletManagerBulletManagerFunction>
    { }
}
