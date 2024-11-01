using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChoicesConstructor
{
    public string answer;
    [Space(10)]
    public string name_constructor; //ссылка на следующий конструктор
    [Space(10)]
    public List<GameObject> activateObjs = new List<GameObject>();
    public List<GameObject> disableObjs = new List<GameObject>();
}
