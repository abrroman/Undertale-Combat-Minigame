using UnityEngine.UIElements;

namespace UndertaleMinigame {
    public class UndertaleUIMessage : UIElement {
        public UndertalePlayerHPController hpController;
        public UndertaleGameManager GameManager;

        private Label _message;

        private void OnEnable() {
            hpController.PlayerDied += OnPlayerDeath;
            GameManager.PlayerWinsGame += OnPlayerWins;
        }

        private void OnDisable() {
            hpController.PlayerDied -= OnPlayerDeath;
            GameManager.PlayerWinsGame -= OnPlayerWins;
        }

        private void Start() {
            _message = _root.Q<Label>("DeathMessage");
            _message.style.display = DisplayStyle.None;
        }

        private void OnPlayerDeath() {
            _message.text = "You Lost";
            _message.style.display = DisplayStyle.Flex;
        }

        private void OnPlayerWins() {
            _message.text = "You Win";
            _message.style.display = DisplayStyle.Flex;
        }
    }
}