using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace UndertaleMinigame {
    public class UndertaleUIHPCounter : UIElement {
        public UndertalePlayerHPController hpController;

        [SerializeField]
        private Sprite heartSprite;

        private VisualElement _hpContainer;
        private VisualElement[] hp;

        private void OnEnable() {
            hpController.DamageTaken += OnDamageTaken;
            InitLabel();
        }

        private void OnDisable() {
            hpController.DamageTaken -= OnDamageTaken;
        }

        private void InitLabel() {
            _hpContainer = _root.Q("HPCounter");
            hp = _hpContainer.Children().ToArray();
        }
        
        private void OnDamageTaken() {
            for (int i = 0; i < UndertalePlayerHPController.MAX_HP; i++) {
                hp[i].style.display = DisplayStyle.None;
            }

            for (int i = 0; i < hpController.Hp; i++) {
                hp[i].style.display = DisplayStyle.Flex;
            }
        }
    }
}