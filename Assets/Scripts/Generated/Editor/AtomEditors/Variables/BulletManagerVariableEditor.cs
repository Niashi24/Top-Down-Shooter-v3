using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `BulletManager`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(BulletManagerVariable))]
    public sealed class BulletManagerVariableEditor : AtomVariableEditor<BulletManager, BulletManagerPair> { }
}
