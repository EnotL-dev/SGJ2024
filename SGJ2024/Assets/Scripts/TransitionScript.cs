using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour
{
    [SerializeField] private Image bakcground;
    [Space(10)]
    [SerializeField] private List<GameObject> activateObjs = new List<GameObject>();
    [SerializeField] private List<GameObject> disableObjs = new List<GameObject>();
    [Space(10)]
    [SerializeField] private bool reverse;
    [SerializeField] private bool fullTransit; // значит вернет затемнение обратно
    [SerializeField] private List<GameObject> activateObjs_afterFull = new List<GameObject>();
    [SerializeField] private List<GameObject> disableObjs_afterFull = new List<GameObject>();

    private void OnEnable()
    {
        if (!reverse)
        {
            bakcground.color = new Color(bakcground.color.r, bakcground.color.g, bakcground.color.b, 0);
            StartCoroutine(startFade());
        }
        else
        {
            bakcground.color = new Color(bakcground.color.r, bakcground.color.g, bakcground.color.b, 1);
            StartCoroutine(backFade());
        }
    }

    private IEnumerator backFade()
    {
        while (true)
        {
            if (bakcground.color.a > 0f)
            {
                bakcground.color = new Color(bakcground.color.r, bakcground.color.g, bakcground.color.b, bakcground.color.a - 0.1f);

                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                ActivateObjs(activateObjs_afterFull);
                DisableObjs(disableObjs_afterFull);
                yield return null;
            }
        }
    }

    private IEnumerator startFade()
    {
        while (true)
        {
            if (bakcground.color.a < 1f)
            {
                bakcground.color = new Color(bakcground.color.r, bakcground.color.g, bakcground.color.b, bakcground.color.a + 0.1f);

                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                ActivateObjs(activateObjs);
                DisableObjs(disableObjs);

                if (fullTransit) StartCoroutine(backFade());
                yield return null;
            }
        }
    }

    private void ActivateObjs(List<GameObject> objs)
    {
        foreach (GameObject obj in objs)
        {
            obj.SetActive(true);
        }
    }

    private void DisableObjs(List<GameObject> objs)
    {
        foreach (GameObject obj in objs)
        {
            obj.SetActive(false);
        }
    }
}
