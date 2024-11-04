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
            case "leave_guild":
                return leave_guild;
            case "welcome_guild":
                return welcome_guild;
            case "goodbye_guild":
                return goodbye_guild;
            default:
                Debug.Log("<Color=red>������ ���������� ���!</color>");
                return null;
        }
    }

    private MessageConstructor[] welcome_guild =
    {
        new MessageConstructor(
            "�������������",
            "����� ���������� �����.",
            "welcome_guild_1"
            ),
        new MessageConstructor(
            "�������������",
            "������� �����������?",
            "welcome_guild_2"
            ),
    };

    private MessageConstructor[] goodbye_guild =
    {
        new MessageConstructor(
            "�������������",
            "���������� ������.",
            ""
            )
    };

    private MessageConstructor[] leave_guild =
    {
        new MessageConstructor(
            "",
            "�� ������ ��������� � ������������ ���� ��� ����������� � ����������?",
            "leave_guild"
            )
    };

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
