using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Set variable value Action of type `BulletManager`. Inherits from `SetVariableValue&lt;BulletManager, BulletManagerPair, BulletManagerVariable, BulletManagerConstant, BulletManagerReference, BulletManagerEvent, BulletManagerPairEvent, BulletManagerVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/BulletManager", fileName = "SetBulletManagerVariableValue")]
    public sealed class SetBulletManagerVariableValue : SetVariableValue<
        BulletManager,
        BulletManagerPair,
        BulletManagerVariable,
        BulletManagerConstant,
        BulletManagerReference,
        BulletManagerEvent,
        BulletManagerPairEvent,
        BulletManagerBulletManagerFunction,
        BulletManagerVariableInstancer>
    { }
}
