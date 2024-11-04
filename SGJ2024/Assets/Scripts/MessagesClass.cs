using UnityEngine;

public class MessagesClass //ЭТО СИНГЛТОН
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
                Debug.Log("<Color=red>ТАКОГО КОНСТРУКТА НЕТ!</color>");
                return null;
        }
    }

    private MessageConstructor[] welcome_guild =
    {
        new MessageConstructor(
            "Администратор",
            "Добро пожаловать домой.",
            "welcome_guild_1"
            ),
        new MessageConstructor(
            "Администратор",
            "Желаете поторговать?",
            "welcome_guild_2"
            ),
    };

    private MessageConstructor[] goodbye_guild =
    {
        new MessageConstructor(
            "Администратор",
            "Счастливой дороги.",
            ""
            )
    };

    private MessageConstructor[] leave_guild =
    {
        new MessageConstructor(
            "",
            "Вы хотите отдохнуть и восстановить силы или отправиться в подземелье?",
            "leave_guild"
            )
    };

    private MessageConstructor[] test_messages =
    {
        new MessageConstructor(
            "Мишка Бебра",
            "Я здесю только чтобы показать тест, ок?",
            ""
            ),
        new MessageConstructor(
            "Мишка Бебра",
            "Вот так я выгляжу",
            "mishka_freddy"
            ),
        new MessageConstructor(
            "Мишка Бебра",
            "И проверить выбор в диалогах",
            "choice_testing"
            ),
    };

    private MessageConstructor[] test_choice1 =
    {
        new MessageConstructor(
            "Мишка Бебра",
            "Я знал.",
            "test_choice3"
            ),
    };

    private MessageConstructor[] test_choice2 =
    {
        new MessageConstructor(
            "Мишка Бебра",
            "Второй вариант, да?",
            "test_choice3"
            )
    };

    private MessageConstructor[] test_choice3 =
    {
        new MessageConstructor(
            "Мишка Бебра",
            "Это просто проверка для второго выбора",
            ""
            ),
        new MessageConstructor(
            "Мишка Бебра",
            "По хорошему дальше загрузка сцены",
            ""
            ),
        new MessageConstructor(
            "Мишка Бебра",
            "По хорошему дальше загрузка сцены",
            "sceneload1"
            )
    };
}
