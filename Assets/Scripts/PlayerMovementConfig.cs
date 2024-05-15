using UnityEngine;

namespace UndertaleMinigame {
    /*
     * Статик для установки клавиш для взаимодействия игрока с миром
     */
    public static class PlayerMovementConfig {
        public static KeyCode GoForward = KeyCode.W;
        public static KeyCode GoLeft = KeyCode.A;
        public static KeyCode GoRight = KeyCode.D;
        public static KeyCode GoBack = KeyCode.S;
    }
}