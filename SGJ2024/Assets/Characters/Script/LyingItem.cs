using UnityEngine;

namespace BattleSystem
{
    public class LyingItem : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Item�ollector �ollector))
            {
                �ollector.Collect(null);
            }
            gameObject.SetActive(false);
        }
    }
}