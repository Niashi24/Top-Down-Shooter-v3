using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `BulletManager`. Inherits from `AtomEvent&lt;BulletManager&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/BulletManager", fileName = "BulletManagerEvent")]
    public sealed class BulletManagerEvent : AtomEvent<BulletManager>
    {
    }
}
