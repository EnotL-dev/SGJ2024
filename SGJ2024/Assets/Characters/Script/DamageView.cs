using TMPro;
using UnityEngine;

namespace BattleSystem
{
    public class DamageView : MonoBehaviour
    {
        [SerializeField] private Animation _animation;
        [SerializeField] private TMP_Text _textMeshPro;

        public void Play(int damage)
        {
            gameObject.SetActive(true);
            _animation.Play();
            _textMeshPro.text = $"- {damage}";
        }
    }
}