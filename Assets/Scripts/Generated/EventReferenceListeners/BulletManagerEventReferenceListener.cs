using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `BulletManager`. Inherits from `AtomEventReferenceListener&lt;BulletManager, BulletManagerEvent, BulletManagerEventReference, BulletManagerUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/BulletManager Event Reference Listener")]
    public sealed class BulletManagerEventReferenceListener : AtomEventReferenceListener<
        BulletManager,
        BulletManagerEvent,
        BulletManagerEventReference,
        BulletManagerUnityEvent>
    { }
}
