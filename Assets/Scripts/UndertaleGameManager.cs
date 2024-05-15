using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UndertaleMinigame {
    public class UndertaleGameManager : MonoBehaviour {
        public int selectedAttack;
        
        public Action PlayerWinsGame;

        [SerializeField]
        private GameObject[] attacks;

        [SerializeField]
        private UndertalePlayerController player;

        [SerializeField]
        private UndertalePlayerHPController playerHp;

        private GameObject _currentAtk;
        private bool _battleEnded;
        private bool _roundEnded;
        private int _rounds = 3;

        private void Start() {
            NewRound();
        }

        private void Update() {
            if (IsAttackDone() && playerHp.Hp > 0) {
                PlayerWinRound();
            } else if (playerHp.Hp <= 0) {
                PlayerLost();
            }
        }

        private void PlayerWinRound() {
            _rounds--;
            if (_rounds <= 0) {
                _battleEnded = true;
                Time.timeScale = 0.0f;
                PlayerWinsGame?.Invoke();
            } else {
                _roundEnded = false;
                NewRound();
            }
        }

        private void PlayerLost() {
            Time.timeScale = 0.0f;
            _battleEnded = true;
        }

        private void NewRound() {
            player.Spawn();
            StartCoroutine(Waiter());
            SelectAttack();
        }

        private void SelectAttack() {
            selectedAttack = Random.Range(0, attacks.Length);
            _currentAtk = Instantiate(attacks[selectedAttack]);
        }

        private bool IsAttackDone() {
            if (_currentAtk.GetComponent<UndertaleEnemyTurnManager>().finishedTurn) {
                Destroy(_currentAtk);
                return true;
            }

            return false;
        }

        IEnumerator Waiter() {
            yield return new WaitForSeconds(5);
        }
    }
}