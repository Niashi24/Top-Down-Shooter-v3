using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `BulletManagerPair`. Inherits from `AtomEventReferenceListener&lt;BulletManagerPair, BulletManagerPairEvent, BulletManagerPairEventReference, BulletManagerPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/BulletManagerPair Event Reference Listener")]
    public sealed class BulletManagerPairEventReferenceListener : AtomEventReferenceListener<
        BulletManagerPair,
        BulletManagerPairEvent,
        BulletManagerPairEventReference,
        BulletManagerPairUnityEvent>
    { }
}
