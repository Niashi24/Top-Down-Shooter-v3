#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `BulletManagerPair`. Inherits from `AtomEventEditor&lt;BulletManagerPair, BulletManagerPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(BulletManagerPairEvent))]
    public sealed class BulletManagerPairEventEditor : AtomEventEditor<BulletManagerPair, BulletManagerPairEvent> { }
}
#endif
