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
            case "dialog0_0":
                return dialog0_0;
            case "dialog0_choose1":
                return dialog0_choose1;
            case "dialog0_choose2":
                return dialog0_choose2;
            case "dialog0_1":
                return dialog0_1;
            case "dialog1":
                return dialog1;
            case "dialog1_choose1":
                return dialog1_choose1;
            case "dialog1_choose2":
                return dialog1_choose2;
            case "dialog1_choose3":
                return dialog1_choose3;
            case "dialog2":
                return dialog2;
            case "dialog2_notcheck":
                return dialog2_notcheck;
            case "dialog2_mimic":
                return dialog2_mimic;
            case "dialog2_gold":
                return dialog2_gold;
            case "dialog3":
                return dialog3;
            case "dialog3_choose1":
                return dialog3_choose1;
            case "dialog3_choose2":
                return dialog3_choose2;
            case "dialog3_choose3":
                return dialog3_choose3;
            case "dialog4":
                return dialog4;
            case "dialog4_choose1":
                return dialog4_choose1;
            case "dialog4_choose2":
                return dialog4_choose2;
            case "dialog4_choose3":
                return dialog4_choose3;
            default:
                Debug.Log("<Color=red>������ ���������� ���!</color>");
                return null;
        }
    }

    private MessageConstructor[] dialog4_choose3 =
    {
        new MessageConstructor(
            "",
            "�� ������� �� ������� ����� � ����������",
            ""
            ),
        new MessageConstructor(
            "",
            "��� ������ ������ ��� �� ����������������",
            ""
            ),
        new MessageConstructor(
            "",
            "��� ������ ������ ��� �� ����������������",
            "dialog4_choose3"
            ),
    };

    private MessageConstructor[] dialog4_choose2 =
    {
        new MessageConstructor(
            "",
            "��� ������ ����� ��� ����� ����������� �������",
            ""
            ),
        new MessageConstructor(
            "",
            "�� ����� ����� �� �������� ��������� �������� ����. ����� ������ ���� �����-�� ������������������",
            ""
            ),
        new MessageConstructor(
            "",
            "���� �� �� ���������, �� ���� �������� ����������� �����, ������ ��� � ����� ������� ��������",
            ""
            ),
        new MessageConstructor(
            "",
            "*������������ �������� ���� ������ ������� ����� �� ��������� ���*",
            ""
            ),
        new MessageConstructor(
            "",
            "*������������ �������� ���� ������ ������� ����� �� ��������� ���*",
            "dialog4_choose2"
            ),
    };

    private MessageConstructor[] dialog4_choose1 =
    {
        new MessageConstructor(
            "",
            "��� ������ ������ ������� � ���� ���������. �� ��� ���� ������ �������",
            ""
            ),
        new MessageConstructor(
            "",
            "������������, ������ ��� ���� ���� ��������� � ����� �������� �� �������",
            ""
            ),
        new MessageConstructor(
            "",
            "�������� ������������ ������� ������, � �� ������ ����������� ������ �� ������� ����� ������� �������� �����",
            ""
            ),
        new MessageConstructor(
            "",
            "��������� ����� ��������� �� ������������� � �������",
            ""
            ),
        new MessageConstructor(
            "",
            "��������� ����� ��������� �� ������������� � �������",
            "dialog4_choose1"
            ),
    };

    private MessageConstructor[] dialog4 =
    {
        new MessageConstructor(
            "",
            "� ����� ����������� �� ����������� �� �������������� �����. ��� ����� �����!",
            ""
            ),
        new MessageConstructor(
            "",
            "�� ��� �� ��� �������?",
            "dialog4"
            ),
    };

    private MessageConstructor[] dialog3_choose3 =
    {
        new MessageConstructor(
            "",
            "�� ������� �� ������ � ��������� �������. ��� ������ ��������� �� ����",
            ""
            ),
        new MessageConstructor(
            "",
            "���� ���������� ��������� � ���������� ���� �������� �� ���",
            ""
            ),
        new MessageConstructor(
            "",
            "��� ��������� ������� ���� �������. ������, ��� �� �����������",
            ""
            ),
        new MessageConstructor(
            "",
            "������������� ���� ������ �� ����, ������� �� ����� ����� ������ ������� ������� �����",
            ""
            ),
        new MessageConstructor(
            "",
            "������������� ���� ������ �� ����, ������� �� ����� ����� ������ ������� ������� �����",
            "dialog3_choose3"
            ),
    };

    private MessageConstructor[] dialog3_choose2 =
    {
        new MessageConstructor(
            "",
            "��� ������ ����� ����������� ����� ������� ������ ����",
            ""
            ),
        new MessageConstructor(
            "",
            "�� ��� �� �������� �����������, ����� ����, ���� ������� ������������",
            ""
            ),
        new MessageConstructor(
            "",
            "���� ��������� ������ ���, ������� ������ ����� ��������",
            ""
            ),
        new MessageConstructor(
            "",
            "�� �������������, ��� ���� �������, � ������ � ���� ���-�� �� ������ �������",
            ""
            ),
        new MessageConstructor(
            "",
            "�� �������������, ��� ���� �������, � ������ � ���� ���-�� �� ������ �������",
            "dialog3_choose2"
            ),
    };

    private MessageConstructor[] dialog3_choose1 =
    {
        new MessageConstructor(
            "",
            "�� � ��� ������ �������� �� ���� ��� �����",
            ""
            ),
        new MessageConstructor(
            "",
            "���� ��� �� ����������",
            ""
            ),
       new MessageConstructor(
            "",
            "���������� ������� ����, �� �� ������������� � �������, ������ ������� �� �������� ���� �����",
            ""
            ),
        new MessageConstructor(
            "",
            "���������� ������� ����, �� �� ������������� � �������, ������ ������� �� �������� ���� �����",
            "dialog3_choose1"
            ),
    };

    private MessageConstructor[] dialog3 =
    {
        new MessageConstructor(
            "",
            "����������� �����, �� ����� ���� ���������� �������������� ����",
            ""
            ),
        new MessageConstructor(
            "",
            "��������� ������� ������� ������� �� ��������",
            ""
            ),
        new MessageConstructor(
            "",
            "�� ������������...",
            "dialog3"
            ),
    };

    private MessageConstructor[] dialog2_gold =
    {
        new MessageConstructor(
            "",
            "������ ��������� ��������� ������� ������",
            "change_gold"
            ),
        new MessageConstructor(
            "",
            "������ ����� 90 ����� ��������",
            ""
            ),
        new MessageConstructor(
            "",
            "�������� ������, �� ������������� � ������� � �������� ����������",
            ""
            ),
        new MessageConstructor(
            "",
            "�������� ������ �� ������������� � ������� � �������� ����������",
            "dialog2_gold"
            ),
    };

    private MessageConstructor[] dialog2_mimic =
    {
        new MessageConstructor(
            "",
            "������ ����������� �������!",
            "change_mimic"
            ),
        new MessageConstructor(
            "",
            "�������� ����� �� ����� � ����� ������������, ���������� �������� ������ �� ����",
            ""
            ),
        new MessageConstructor(
            "",
            "�� ��������� ���� ������ ������� ������ �������, ������ ���� ������ �� ���������� ������",
            ""
            ),
        new MessageConstructor(
            "",
            "*������������ �������� ���� ������ ������� ����� �� ��������� ���*",
            ""
            ),
        new MessageConstructor(
            "",
            "*������������ �������� ���� ������ ������� ����� �� ��������� ���*",
            "dialog2_mimic"
            ),
    };

    private MessageConstructor[] dialog2_notcheck =
    {
        new MessageConstructor(
            "",
            "������ ��������������� � ������� � ������ �� ���������",
            ""
            ),
        new MessageConstructor(
            "",
            "�� ��������� ���������� � ������ �������� ��������",
            ""
            ),
        new MessageConstructor(
            "",
            "�� ��������� ���������� � ������ �������� ��������",
            "dialog2_notcheck"
            ),
    };

    private MessageConstructor[] dialog2 =
    {
        new MessageConstructor(
            "",
            "�� �������� ���� ��� ����������� ������ ������ � ������������ �������� ���������",
            ""
            ),
        new MessageConstructor(
            "",
            "��� ������ ��������� �� ���� ������, ����� ��������� ����������",
            "dialog2"
            ),
    };

    private MessageConstructor[] dialog1_choose3 =
    {
        new MessageConstructor(
            "",
            "��� ������ � �� ���������",
            ""
            ),
        new MessageConstructor(
            "",
            "����� �������� �������� ��������� ���� � �����. ����������� ����� ���.",
            ""
            ),
        new MessageConstructor(
            "",
            "� ���� ���� ��������� ������ ������� � �����, ������� ��������",
            ""
            ),
        new MessageConstructor(
            "",
            "�� � ����� ������ � ������, �� ��������� ������������� �������",
            ""
            ),
        new MessageConstructor(
            "",
            "�� � ����� ������ � ������, �� ��������� ������������� �������",
            "dialog1_choose3"
            ),
    };

    private MessageConstructor[] dialog1_choose2 =
    {
        new MessageConstructor(
            "",
            "��� ������ ���������� ������������ �� ���",
            ""
            ),
        new MessageConstructor(
            "",
            "����� �� �����, ��� �������� ���������� ��� � ���� ���� ��� ����",
            ""
            ),
        new MessageConstructor(
            "",
            "� ������ ������, ���������� ����� ������ ����� � ����, �� ������ � ����� ��������",
            ""
            ),
        new MessageConstructor(
            "",
            "����� ���� ������ ������ � ������ �� ���������� ��������",
            ""
            ),
        new MessageConstructor(
            "",
            "�� ��� ������� ������ ���, ���� � ���� ���� �� ���� ��� ����� ����������",
            ""
            ),
        new MessageConstructor(
            "",
            "*������������ �������� ���� ������ ������� ����� �� ��������� ���*",
            ""
            ),
        new MessageConstructor(
            "",
            "*������������ �������� ���� ������ ������� ����� �� ��������� ���*",
            "dialog1_choose2"
            ),
    };

    private MessageConstructor[] dialog1_choose1 =
    {
        new MessageConstructor(
            "",
            "��� ������ ������������ �������� ������, �������� ������� ����� � ������� ������",
            ""
            ),
        new MessageConstructor(
            "",
            "����� ����������� ����������, ����� ���� ��� ����� ��� ������� � ������� �� ���� ��� ����� ����������",
            ""
            ),
        new MessageConstructor(
            "",
            "����� ����������� ����������, ����� ���� ��� ����� ��� ������� � ������� �� ���� ��� ����� ����������",
            "dialog1_choose1"
            ),
    };

    private MessageConstructor[] dialog1 =
    {
        new MessageConstructor(
            "",
            "�� ������ �� ����� ��� ������ ��������� �� �������� �����",
            ""
            ),
        new MessageConstructor(
            "",
            "�� ���� ����������� ������ ��� ������ ���� � �����",
            ""
            ),
        new MessageConstructor(
            "",
            "������� ������� ��������, ������� ���������� ��� � ������������ ������",
            ""
            ),
        new MessageConstructor(
            "",
            "����� ������ ������...",
            "dialog1"
            ),
    };

    private MessageConstructor[] dialog0_1 =
    {
        new MessageConstructor(
            "",
            "�� ��������� ������ �������� � ���� ��� ���� ������ � ������������� � �����",
            ""
            ),
        new MessageConstructor(
            "",
            "����� ������ �� �������� ����������, �� ������������ �� ������ �������, ������ ��������� ������ � ����� �����",
            ""
            ),
        new MessageConstructor(
            "",
            "����� ������ �� �������� ����������, �� ������������ �� ������ �������, ������ ��������� ������ � ����� �����",
            "dialog0_1_end"
            ),
    };

    private MessageConstructor[] dialog0_choose2 =
    {
        new MessageConstructor(
            "",
            "�� �������� ���������, ��� �� ����� �������� � �������. �� �������������� � ���",
            ""
            ),
        new MessageConstructor(
            "",
            "��� ������ �� �������� �� ������� �� ������ ��������� ������",
            ""
            ),
        new MessageConstructor(
            "",
            "��� ������ �� �������� �� ������� �� ������ ��������� ������",
            "dialog0_choose"
            ),
    };

    private MessageConstructor[] dialog0_choose1 =
    {
        new MessageConstructor(
            "",
            "�� �������� 10 ���������� ��� ����� �����",
            ""
            ),
        new MessageConstructor(
            "",
            "��� ������ �� �������� �� ������� �� ������ ��������� ������",
            ""
            ),
        new MessageConstructor(
            "",
            "��� ������ �� �������� �� ������� �� ������ ��������� ������",
            "dialog0_choose"
            ),
    };

    private MessageConstructor[] dialog0_0 =
    {
        new MessageConstructor(
            "",
            "�� ����� ������ ������� �� ������",
            ""
            ),
        new MessageConstructor(
            "",
            "� ������ ���� ����� �� ������ ������ �� ������, �� � ���� ������� ������ ��������� �����",
            ""
            ),
        new MessageConstructor(
            "",
            "�������� �������� ������ ���� ���� - ��� ��� ��� ������������",
            ""
            ),
        new MessageConstructor(
            "",
            "������� ������ �������� ��� �����",
            ""
            ),
        new MessageConstructor(
            "",
            "��� �������� ���������������",
            ""
            ),
        new MessageConstructor(
            "",
            "�� ��� ��������� ��������� ��������� �������� ������� � ������� ����� ������ ���� ��������",
            "dialog0_povozka"
            ),
        new MessageConstructor(
            "",
            "�� ��� ����������...",
            "dialog0_0"
            ),
    };

    private MessageConstructor[] welcome_guild =
    {
        new MessageConstructor(
            "�������������",
            "����� ���������� �����",
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
            "���������� ������",
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
