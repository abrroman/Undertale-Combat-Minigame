using UnityEngine;

namespace UndertaleMinigame {
    public class UndertalePlayerController : MonoBehaviour {
        private Vector2 _startPos = new Vector2(0.0f, -3.0f);

        [SerializeField]
        private float speed = 5.0f;

        [SerializeField]
        private Vector2 max;

        [SerializeField]
        private Vector2 min;

        [SerializeField]
        private GameObject topBorder;

        [SerializeField]
        private GameObject rightBorder;


        void Start() {
            max = new Vector2(rightBorder.transform.position.x - 0.3f, topBorder.transform.position.y - 0.3f);
            min = new Vector2(-max.x, max.y - 4.3f);
            Reset();
        }

        void Update() {
            Move();
        }

        public void Reset() {
            transform.position = _startPos;
        }

        private void Move() {
            if (Input.GetKey(PlayerMovementConfig.GoLeft)) {
                transform.position = Vector2.Lerp(transform.position, transform.position + Vector3.left, speed * Time.deltaTime);
            }

            if (Input.GetKey(PlayerMovementConfig.GoRight)) {
                transform.position = Vector2.Lerp(transform.position, transform.position + Vector3.right, speed * Time.deltaTime);
            }

            if (Input.GetKey(PlayerMovementConfig.GoForward)) {
                transform.position = Vector2.Lerp(transform.position, transform.position + Vector3.up, speed * Time.deltaTime);
            }

            if (Input.GetKey(PlayerMovementConfig.GoBack)) {
                transform.position = Vector2.Lerp(transform.position, transform.position + Vector3.down, speed * Time.deltaTime);
            }

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, min.x, max.x),
                Mathf.Clamp(transform.position.y, min.y, max.y));
        }
    }
}