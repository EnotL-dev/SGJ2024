using UnityEngine;

public class MessagesClass //��� ��������
{
    private static MessagesClass instance = null;
    private MessagesClass()
    {
    }
    public static MessagesClass GetInstance()
    {
        if (instance == null)
        {
            instance = new MessagesClass();
        }
        return instance;
    }

    public MessageConstructor[] returnMessages(string id)
    {
        switch(id)
        {
            case "test_messages":
                return test_messages;
            case "test_choice1":
                return test_choice1;
            case "test_choice2":
                return test_choice2;
            case "test_choice3":
                return test_choice3;
            default:
                Debug.Log("<Color=red>������ ���������� ���!</color>");
                return null;
        }
    }

    private MessageConstructor[] test_messages =
    {
        new MessageConstructor(
            "����� �����",
            "� ����� ������ ����� �������� ����, ��?",
            ""
            ),
        new MessageConstructor(
            "����� �����",
            "��� ��� � �������",
            "mishka_freddy"
            ),
        new MessageConstructor(
            "����� �����",
            "� ��������� ����� � ��������",
            "choice_testing"
            ),
    };

    private MessageConstructor[] test_choice1 =
    {
        new MessageConstructor(
            "����� �����",
            "� ����.",
            "test_choice3"
            ),
    };

    private MessageConstructor[] test_choice2 =
    {
        new MessageConstructor(
            "����� �����",
            "������ �������, ��?",
            "test_choice3"
            )
    };

    private MessageConstructor[] test_choice3 =
    {
        new MessageConstructor(
            "����� �����",
            "��� ������ �������� ��� ������� ������",
            ""
            ),
        new MessageConstructor(
            "����� �����",
            "�� �������� ������ �������� �����",
            ""
            ),
        new MessageConstructor(
            "����� �����",
            "�� �������� ������ �������� �����",
            "sceneload1"
            )
    };
}
