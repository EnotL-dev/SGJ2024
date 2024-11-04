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
            default:
                Debug.Log("<Color=red>ТАКОГО КОНСТРУКТА НЕТ!</color>");
                return null;
        }
    }

    private MessageConstructor[] dialog2_gold =
    {
        new MessageConstructor(
            "",
            "Рыцарь аккуратно открывает пыльный сундук",
            "change_gold"
            ),
        new MessageConstructor(
            "",
            "Внутри лежит 90 монет горсткой",
            ""
            ),
        new MessageConstructor(
            "",
            "Пополнив кошель, вы возвращаетесь в гильдию с чувством облегчения",
            ""
            ),
        new MessageConstructor(
            "",
            "Пополнив кошель вы возвращаетесь в гильдию с чувством облегчения",
            "dialog2_gold"
            ),
    };

    private MessageConstructor[] dialog2_mimic =
    {
        new MessageConstructor(
            "",
            "Сундук оказывается мимиком!",
            "change_mimic"
            ),
        new MessageConstructor(
            "",
            "Зубастая пасть из крови и плоти раскрывается, заглатывая большого рыцаря по пояс",
            ""
            ),
        new MessageConstructor(
            "",
            "Вы пронзаете тело мимика лезвием своего кинжала, спасая Сира Рыцаря от неминуемой смерти",
            ""
            ),
        new MessageConstructor(
            "",
            "*Максимальное здоровье Сира Рыцаря снижено вдвое на следующий бой.*",
            ""
            ),
        new MessageConstructor(
            "",
            "*Максимальное здоровье Сира Рыцаря снижено вдвое на следующий бой.*",
            "dialog2_mimic"
            ),
    };

    private MessageConstructor[] dialog2_notcheck =
    {
        new MessageConstructor(
            "",
            "Рыцарь присматривается к сундуку и решает не рисковать",
            ""
            ),
        new MessageConstructor(
            "",
            "Вы покидаете подземелье с томным чувством сомнения",
            ""
            ),
        new MessageConstructor(
            "",
            "Вы покидаете подземелье с томным чувством сомнения",
            "dialog2_notcheck"
            ),
    };

    private MessageConstructor[] dialog2 =
    {
        new MessageConstructor(
            "",
            "На обратном пути вам встречается старый сундук с незатейливой замочной скважиной",
            ""
            ),
        new MessageConstructor(
            "",
            "Сир Рыцарь опустился на одно колено, чтобы проверить содержимое",
            "dialog2"
            ),
    };

    private MessageConstructor[] dialog1_choose3 =
    {
        new MessageConstructor(
            "",
            "Сир Рыцарь и вы замераете",
            ""
            ),
        new MessageConstructor(
            "",
            "Стены неспешно движутся навстречу друг к другу. Безопасного места нет.",
            ""
            ),
        new MessageConstructor(
            "",
            "В ваши тела вонзаются лезвия клинков и копий, проходя насквозь",
            ""
            ),
        new MessageConstructor(
            "",
            "Не в силах слезть с лезвий, вы погибаете расплющенными стенами",
            ""
            ),
        new MessageConstructor(
            "",
            "Не в силах слезть с лезвий, вы погибаете расплющенными стенами",
            "dialog1_choose3"
            ),
    };

    private MessageConstructor[] dialog1_choose2 =
    {
        new MessageConstructor(
            "",
            "Сир Рыцарь беспокойно оглядывается на вас",
            ""
            ),
        new MessageConstructor(
            "",
            "Долго не думая, ваш напарник вскидывает вас и вашу ношу под руки",
            ""
            ),
        new MessageConstructor(
            "",
            "С резким рывком, пробиваясь через острые копья и мечи, вы бежите к концу коридора",
            ""
            ),
        new MessageConstructor(
            "",
            "Плоть тела рыцаря рвется в местах не защищенных доспехом",
            ""
            ),
        new MessageConstructor(
            "",
            "Но ему удается спасти вас, себя и вашу ношу до того как стены сомкнуться",
            ""
            ),
        new MessageConstructor(
            "",
            "*Максимальное здоровье Сира Рыцаря снижено вдвое на следующий бой*",
            ""
            ),
        new MessageConstructor(
            "",
            "*Максимальное здоровье Сира Рыцаря снижено вдвое на следующий бой*",
            "dialog1_choose2"
            ),
    };

    private MessageConstructor[] dialog1_choose1 =
    {
        new MessageConstructor(
            "",
            "Сир Рыцарь замахивается тяжелыми руками, сокрушая длинные копья и хрупкие клинки",
            ""
            ),
        new MessageConstructor(
            "",
            "Этого оказывается достаточно, чтобы дать вам места для маневра и сбежать до того как стены сомкнуться",
            ""
            ),
        new MessageConstructor(
            "",
            "Этого оказывается достаточно, чтобы дать вам места для маневра и сбежать до того как стены сомкнуться",
            "dialog1_choose1"
            ),
    };

    private MessageConstructor[] dialog1 =
    {
        new MessageConstructor(
            "",
            "По дороге на выход Сир Рыцарь наступает на каменную плиту",
            ""
            ),
        new MessageConstructor(
            "",
            "Из стен пробиваются острые как бритва мечи и копья",
            ""
            ),
        new MessageConstructor(
            "",
            "Длинный коридор сужается, готовый превратить вас в расплющенное решето",
            ""
            ),
        new MessageConstructor(
            "",
            "Нужно решать быстро...",
            "dialog1"
            ),
    };

    private MessageConstructor[] dialog0_1 =
    {
        new MessageConstructor(
            "",
            "Вы собираете головы монстров с поле боя Сира Рыцаря и отправляетесь в город",
            ""
            ),
        new MessageConstructor(
            "",
            "Минуя стражу из безликих гвардейцев, вы оказываетесь на пороге гильдии, откуда доносится музыка и запах хмеля",
            ""
            ),
        new MessageConstructor(
            "",
            "Минуя стражу из безликих гвардейцев, вы оказываетесь на пороге гильдии, откуда доносится музыка и запах хмеля",
            "dialog0_1_end"
            ),
    };

    private MessageConstructor[] dialog0_choose2 =
    {
        new MessageConstructor(
            "",
            "Вы уверяете напарника, что не стоит воровать у мертвых. Он прислушивается к вам",
            ""
            ),
        new MessageConstructor(
            "",
            "Как только вы отходите от повозки из кустов доносится шелест",
            ""
            ),
        new MessageConstructor(
            "",
            "Как только вы отходите от повозки из кустов доносится шелест",
            "dialog0_choose"
            ),
    };

    private MessageConstructor[] dialog0_choose1 =
    {
        new MessageConstructor(
            "",
            "Вы находите 10 спрятанных под сеном монет",
            ""
            ),
        new MessageConstructor(
            "",
            "Как только вы отходите от повозки из кустов доносится шелест",
            ""
            ),
        new MessageConstructor(
            "",
            "Как только вы отходите от повозки из кустов доносится шелест",
            "dialog0_choose"
            ),
    };

    private MessageConstructor[] dialog0_0 =
    {
        new MessageConstructor(
            "",
            "Вы идете долгой дорогой по тракту",
            ""
            ),
        new MessageConstructor(
            "",
            "В планах было дойти до захода солнца до города, но с того момента прошло несколько часов",
            ""
            ),
        new MessageConstructor(
            "",
            "Неловкое молчание сквозь шумы леса - все что вас сопровождает",
            ""
            ),
        new MessageConstructor(
            "",
            "Тяжелый рюкзак натирает вам плечи",
            ""
            ),
        new MessageConstructor(
            "",
            "Ваш напарник останавливается",
            ""
            ),
        new MessageConstructor(
            "",
            "За его массивным туловищем виднеется разбитая повозка в которой лежит теплая рука бедолаги",
            "dialog0_povozka"
            ),
        new MessageConstructor(
            "",
            "Из уст вырывается...",
            "dialog0_0"
            ),
    };

    private MessageConstructor[] welcome_guild =
    {
        new MessageConstructor(
            "Администратор",
            "Добро пожаловать домой",
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
            "Счастливой дороги",
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
