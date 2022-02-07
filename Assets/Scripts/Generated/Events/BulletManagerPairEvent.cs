using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `BulletManagerPair`. Inherits from `AtomEvent&lt;BulletManagerPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/BulletManagerPair", fileName = "BulletManagerPairEvent")]
    public sealed class BulletManagerPairEvent : AtomEvent<BulletManagerPair>
    {
    }
}
