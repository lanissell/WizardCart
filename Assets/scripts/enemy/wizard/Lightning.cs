using UnityEngine;


namespace enemy.wizard
{
    public class Lightning : MonoBehaviour, IProjectile
    {
        private RaycastHit hit;
        [SerializeField]
        private GameObject _lightning;
        public void Throw(Vector3 targetPosition)
        {
            transform.LookAt(targetPosition);
            _lightning.SetActive(true);
        }
    }
}