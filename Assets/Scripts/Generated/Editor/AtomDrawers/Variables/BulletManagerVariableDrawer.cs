#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `BulletManager`. Inherits from `AtomDrawer&lt;BulletManagerVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(BulletManagerVariable))]
    public class BulletManagerVariableDrawer : VariableDrawer<BulletManagerVariable> { }
}
#endif
