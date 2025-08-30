using UnityEngine;

namespace homework
{
    public class HomeWork_3 : MonoBehaviour
    {
        [SerializeField] private int hp;
        [SerializeField] private int damage;
        [SerializeField] private Character character;
        [SerializeField] private int characterCount;

        private bool isDeath;
        private bool isEnemy;

        private void Start()
        {
            hp = 100;
            isDeath = false;
            Spawner();
        }

        private void Update()
        {
            if (isDeath)
            {
                return;
            }

            Damage(damage);
            Debug.Log(hp);
        }

        private void Damage(int damageDone)
        {
            hp -= damageDone;

            if (hp <= 0)
            {
                isDeath = true;
                Debug.Log($"Dead");
            }
        }

        private void Spawner()
        {
            float x = 0;
            float y = 0;
            float z = 0;

            for (int i = 0; i < characterCount; i++)
            {
                isEnemy = Random.Range(0, 2) != 0;

                x = Random.Range(0f, 10f);
                y = Random.Range(0f, 10f);
                z = Random.Range(0f, 10f);

                Character cube = Instantiate(character, new Vector3(x, y, z), Quaternion.identity);
                cube.Init(isEnemy, i.ToString());
            }

            character.SetActive(false);
        }
    }
}


