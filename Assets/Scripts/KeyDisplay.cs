using UnityEngine;
using UnityEngine.UI;

public partial class InputDisplay
{
    [System.Serializable]
    public class KeyDisplay {
        public Sprite inactiveSprite;
        public Sprite activeSprite;
        public Image image;
        public bool active = false;

        public void SetActive(bool active) {
            this.active = active;
            image.sprite = active ? activeSprite : inactiveSprite;
        }
    }
}
