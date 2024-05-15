using UnityEngine;

namespace UndertaleMinigame {
    public class UndertaleProjectileHazard : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                other.GetComponent<UndertalePlayerHPController>().TakeDamage();
            }
        }
    }
}