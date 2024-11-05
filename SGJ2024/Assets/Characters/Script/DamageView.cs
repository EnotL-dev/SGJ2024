using TMPro;
using UnityEngine;

namespace BattleSystem
{
    public class DamageView : MonoBehaviour
    {
        [SerializeField] private Animation _animation;
        [SerializeField] private TMP_Text _textMeshPro;
        [SerializeField] private Color _damageColor = Color.red;
        [SerializeField] private Color _healColor = Color.green;
        [SerializeField] private Color _poisonColor = Color.yellow;

        public void PlayMessage()
        {
            _textMeshPro.color = _damageColor;
            gameObject.SetActive(true);
            _animation.Play();
        }

        public void PlayDamage(int damage)
        {
            _textMeshPro.color = _damageColor;
            gameObject.SetActive(true);
            _animation.Play();
            _textMeshPro.text = $"-{damage}";
        }

        public void PlayPoison(int damage)
        {
            _textMeshPro.color = _poisonColor;
            gameObject.SetActive(true);
            _animation.Play();
            _textMeshPro.text = $"-{damage}";
        }

        public void PlayHeal(int value)
        {
            _textMeshPro.color = _healColor;
            gameObject.SetActive(true);
            _animation.Play();
            _textMeshPro.text = $"+{value}";
        }
    }
}