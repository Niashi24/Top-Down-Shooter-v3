#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `BulletManager`. Inherits from `AtomDrawer&lt;BulletManagerValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(BulletManagerValueList))]
    public class BulletManagerValueListDrawer : AtomDrawer<BulletManagerValueList> { }
}
#endif
