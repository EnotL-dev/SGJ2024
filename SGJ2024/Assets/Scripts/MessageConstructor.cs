using UnityEngine;

public class MessageConstructor
{
    public string character_name; //может быть пустым
    public string message;
    public string eventTrigger;

    public MessageConstructor(string character_name, string message, string eventTrigger)
    {
        this.character_name = character_name;
        this.message = message;
        this.eventTrigger = eventTrigger;
    }
}
