#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `BulletManager`. Inherits from `AtomEventEditor&lt;BulletManager, BulletManagerEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(BulletManagerEvent))]
    public sealed class BulletManagerEventEditor : AtomEventEditor<BulletManager, BulletManagerEvent> { }
}
#endif
