using System;
using UnityEngine;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;BulletManager&gt;`. Inherits from `IPair&lt;BulletManager&gt;`.
    /// </summary>
    [Serializable]
    public struct BulletManagerPair : IPair<BulletManager>
    {
        public BulletManager Item1 { get => _item1; set => _item1 = value; }
        public BulletManager Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private BulletManager _item1;
        [SerializeField]
        private BulletManager _item2;

        public void Deconstruct(out BulletManager item1, out BulletManager item2) { item1 = Item1; item2 = Item2; }
    }
}