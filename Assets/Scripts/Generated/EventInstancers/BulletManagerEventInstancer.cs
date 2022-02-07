using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `BulletManager`. Inherits from `AtomEventInstancer&lt;BulletManager, BulletManagerEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/BulletManager Event Instancer")]
    public class BulletManagerEventInstancer : AtomEventInstancer<BulletManager, BulletManagerEvent> { }
}
