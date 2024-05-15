using UnityEngine;

namespace UndertaleMinigame {
    public class UndertaleEnemyTurnManager : MonoBehaviour {
        public bool finishedTurn;

        [SerializeField]
        private int attackAmount = 2;

        private static readonly int AttackNumber = Animator.StringToHash("AttackNumber");

        private Animator _anim;

        private void Start() {
            finishedTurn = false;
            int attackNumber = Random.Range(0, attackAmount);
            _anim = GetComponent<Animator>();
            _anim.SetInteger(AttackNumber, attackNumber);
        }

        private void AttackFinished() {
            finishedTurn = true;
        }
    }
}