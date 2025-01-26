using UnityEngine;

public class HomeWork_3 : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int damage;
    [SerializeField] private Character character;
    [SerializeField] private int CharacterCount;

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
        float a = 0;
        float b = 0;
        float c = 0;

        for (int i = 0; i < CharacterCount; i++)
        {
            isEnemy = Random.Range(0, 2) != 0;

            a = Random.Range(0f, 10f);
            b = Random.Range(0f, 10f);
            c = Random.Range(0f, 10f);

            Character cube = Instantiate(character, new Vector3(a, b, c), Quaternion.identity);            
            cube.Init(isEnemy, i.ToString());
        }

        character.SetActive(false);
    }

}


