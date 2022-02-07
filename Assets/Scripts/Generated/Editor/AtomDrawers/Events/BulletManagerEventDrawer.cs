#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `BulletManager`. Inherits from `AtomDrawer&lt;BulletManagerEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(BulletManagerEvent))]
    public class BulletManagerEventDrawer : AtomDrawer<BulletManagerEvent> { }
}
#endif
