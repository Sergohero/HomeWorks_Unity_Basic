using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private MeshRenderer m_Renderer;
    [SerializeField] private bool isEnemy;

    public void SetActive(bool isActive) 
    {
        gameObject.SetActive(isActive);
    }

    public void Init(bool isEnemy, string name) 
    {
        m_Renderer.material.color = isEnemy ? Color.red : Color.blue;
        this.isEnemy = isEnemy;
        gameObject.name = $"Character {name}";
    }

}
