using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [System.Serializable]
    public class TriggerEvents
    {
        public string eventTrigger;
        public bool HideActivatedObjInNextMessage;
        public List<GameObject> activateObjs;
        public List<GameObject> disableObjs;
    }

    [SerializeField] private Image panel;
    [SerializeField] private Text name_text;
    [SerializeField] private Text message_text;
    [Space(20)]
    public string name_constructor = "test_messages";
    private int mess_num = 0;
    private MessageConstructor[] messagesConstructor = null;
    private MessagesClass messagesClass;
    [Space(20)]
    [SerializeField] private string nextSceneName; //Для загрузки после конца
    [SerializeField] private TriggerEvents[] triggerEvents;
    private List<GameObject> needHideObjs = new List<GameObject>();

    private void Start()
    {
        messagesClass = MessagesClass.GetInstance();

        name_text.color = new Color(name_text.color.r, name_text.color.g, name_text.color.b, 0);
        message_text.color = new Color(message_text.color.r, message_text.color.g, message_text.color.b, 0);
        panel.color = new Color(0, 0, 0, 0);

        messagesConstructor = messagesClass.returnMessages(name_constructor);

        checktriggers();
        name_text.text = messagesConstructor[mess_num].character_name;
        message_text.text = messagesConstructor[mess_num].message;
        mess_num++;

        StartCoroutine(startMessage());
    }

    public void ChangeConstructor(string name_new_constructor)
    {
        name_constructor = name_new_constructor;
        mess_num = 0;

        name_text.color = new Color(name_text.color.r, name_text.color.g, name_text.color.b, 0);
        message_text.color = new Color(message_text.color.r, message_text.color.g, message_text.color.b, 0);

        messagesConstructor = messagesClass.returnMessages(name_constructor);

        checktriggers();
        name_text.text = messagesConstructor[mess_num].character_name;
        message_text.text = messagesConstructor[mess_num].message;
        mess_num++;

        StartCoroutine(startMessage());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            nextMessage();
        }
    }

    private void nextMessage()
    {
        if (mess_num < messagesConstructor.Length)
        {
            name_text.color = new Color(name_text.color.r, name_text.color.g, name_text.color.b, 0);
            message_text.color = new Color(message_text.color.r, message_text.color.g, message_text.color.b, 0);

            name_text.text = messagesConstructor[mess_num].character_name;
            message_text.text = messagesConstructor[mess_num].message;

            if(needHideObjs.Count > 0)
            {
                disableObjs(needHideObjs);
                needHideObjs = new List<GameObject>();
            }

            checktriggers();

            mess_num++;
            StopAllCoroutines();
            StartCoroutine(nextMessageAppear());
        }
        else
        {
            print("Конец диалога");
        }
    }

    private IEnumerator startMessage()
    {
        while(true)
        {
            if(message_text.color.a < 1f)
            {
                name_text.color = new Color(name_text.color.r, name_text.color.g, name_text.color.b, name_text.color.a + 0.1f);
                message_text.color = new Color(message_text.color.r, message_text.color.g, message_text.color.b, message_text.color.a + 0.1f);
                panel.color = new Color(0, 0, 0, panel.color.a + 0.1f);

                yield return new WaitForSeconds(0.05f);
            }
            yield return null;
        }
    }

    private IEnumerator nextMessageAppear()
    {
        while (true)
        {
            if (message_text.color.a < 1f)
            {
                name_text.color = new Color(name_text.color.r, name_text.color.g, name_text.color.b, name_text.color.a + 0.1f);
                message_text.color = new Color(message_text.color.r, message_text.color.g, message_text.color.b, message_text.color.a + 0.1f);

                yield return new WaitForSeconds(0.05f);
            }
            yield return null;
        }
    }

    private void checktriggers()
    {
        if (messagesConstructor[mess_num].eventTrigger == "") return;

        for(int i = 0; i < triggerEvents.Length; i++)
        {
            if (triggerEvents[i].eventTrigger == messagesConstructor[mess_num].eventTrigger)
            {
                if(triggerEvents[i].HideActivatedObjInNextMessage)
                {
                    needHideObjs = triggerEvents[i].activateObjs;
                }

                activateObjs(triggerEvents[i].activateObjs);
                disableObjs(triggerEvents[i].disableObjs);
            }
        }
    }

    private void activateObjs(List<GameObject> objs)
    {
        foreach(GameObject obj in objs)
        {
            obj.SetActive(true);
        }
    }

    private void disableObjs(List<GameObject> objs)
    {
        foreach (GameObject obj in objs)
        {
            obj.SetActive(false);
        }
    }
}
