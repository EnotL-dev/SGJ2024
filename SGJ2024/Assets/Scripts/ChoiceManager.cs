using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    [SerializeField] private DialogManager dialogManager;
    [Space(10)]
    [SerializeField] private List<GameObject> buttons_obj = new List<GameObject>();
    [SerializeField] private List<Text> text_buttons = new List<Text>();

    private List<ChoicesConstructor> choices = new List<ChoicesConstructor>();

    public void InitChoice(List<ChoicesConstructor> new_choices)
    {
        choices = new_choices;

        for (int i = 0; i < choices.Count; i++)
        {
            text_buttons[i].text = choices[i].answer;
            buttons_obj[i].SetActive(true);
        }
    }

    public void SelectedChoice(int id)
    {
        hideButtons();
        ActivateObjs(id);
        DisableObjs(id);

        dialogManager.ChangeConstructor(choices[id].name_constructor);
    }

    private void hideButtons()
    {
        foreach (GameObject button in buttons_obj)
        {
            button.SetActive(false);
        }
    }

    private void ActivateObjs(int id)
    {
        foreach (GameObject obj in choices[id].activateObjs)
        {
            obj.SetActive(true);
        }
    }

    private void DisableObjs(int id)
    {
        foreach (GameObject obj in choices[id].activateObjs)
        {
            obj.SetActive(true);
        }
    }
}
