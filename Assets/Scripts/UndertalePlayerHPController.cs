using System;
using UnityEngine;

namespace UndertaleMinigame {
    public class UndertalePlayerHPController : MonoBehaviour {
        public Action DamageTaken;
        public Action PlayerDied;

        [SerializeField]
        private int _hp;

        public const int MAX_HP = 3;

        public int Hp {
            get { return _hp; }
            set { _hp = value; }
        }

        private void Start() {
            _hp = MAX_HP;
        }

        public void TakeDamage() {
            _hp--;

            if (_hp <= 0) {
                Death();
            }

            DamageTaken?.Invoke();
        }

        private void Death() {
            PlayerDied?.Invoke();
        }
    }
}