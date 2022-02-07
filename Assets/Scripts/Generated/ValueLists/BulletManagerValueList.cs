using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Value List of type `BulletManager`. Inherits from `AtomValueList&lt;BulletManager, BulletManagerEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/BulletManager", fileName = "BulletManagerValueList")]
    public sealed class BulletManagerValueList : AtomValueList<BulletManager, BulletManagerEvent> { }
}
