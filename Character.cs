using UnityEngine;

namespace Assembly_CSharp
{
    public class Character : Monobehavior

    {
        public void SetActive(bool isDeath)
        {
            gameObject.SetActive(isDeath);
        }
    }
}
