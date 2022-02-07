#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `BulletManager`. Inherits from `AtomDrawer&lt;BulletManagerConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(BulletManagerConstant))]
    public class BulletManagerConstantDrawer : VariableDrawer<BulletManagerConstant> { }
}
#endif
