using UnityEngine;

namespace homework
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private bool isEnemy;

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void Init(bool isEnemy, string name)
        {
            meshRenderer.material.color = isEnemy ? Color.red : Color.blue;
            this.isEnemy = isEnemy;
            gameObject.name = $"Character {name}";
        }
    }
}
