using UnityEngine;
using UnityEngine.Serialization;

namespace chunk
{
    public class DestroyWithChance : MonoBehaviour
    {
        [FormerlySerializedAs("ChanceOfStaying")] [Range(0, 1)]
        public float chanceOfStaying = 0.5f;

        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameManager.Instance;
            if (gameObject.CompareTag("obstacle")) 
            {
                chanceOfStaying = _gameManager.ChanceOfActivateObstacle;
                if (!(Random.value > chanceOfStaying)) return;
                try
                {
                    var actObst = transform.GetComponent<ActivateObstacle>();
                    actObst.enabled = false;
                }
                catch
                {
                    throw new System.Exception($"obstacle dont have [activateObstacle] script on {gameObject.name}");
                }
            }else if (Random.value > chanceOfStaying) Destroy(gameObject); }
    }
}