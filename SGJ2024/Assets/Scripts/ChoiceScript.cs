using System.Collections.Generic;
using UnityEngine;

public class ChoiceScript : MonoBehaviour
{
    [SerializeField] private ChoiceManager choiceManager;
    [SerializeField] private List<ChoicesConstructor> choices = new List<ChoicesConstructor>();

    private void OnEnable()
    {
        choiceManager.InitChoice(choices);
        gameObject.SetActive(false);
    }
}
