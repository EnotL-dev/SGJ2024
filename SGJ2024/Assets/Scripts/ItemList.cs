using UnityEngine;

public class ItemList
{
    private static ItemList instance = null;
    private ItemList()
    {
    }
    public static ItemList GetInstance()
    {
        if (instance == null)
        {
            instance = new ItemList();
        }
        return instance;
    }

    public Item returnItemById(int id)
    {
        foreach (Item item in items)
        {
            if(item.id == id)
            {
                return item;
            }
        }
        return null;
    }

    //public int id;
    //public string name;

    //public int durability;
    //public int cost;

    //public int damage;
    //public int armor;

    //public int heal;

    //public string spriteLink;

    public Item[] items = 
    {
        new Item(
            1,
            "�������� ���",
            15,
            40,
            5,
            0,
            0,
            "Items/sword_iron"
            ),
        new Item(
            2,
            "�������� �����",
            20,
            40,
            4,
            0,
            0,
            "Items/spear_iron"
            ),
        new Item(
            3,
            "�������� �����",
            15,
            50,
            3,
            0,
            0,
            "Items/axe_iron"
            ),
        new Item(
            4,
            "�������� ���",
            20,
            100,
            10,
            0,
            0,
            "Items/sword_steel"
            ),
        new Item(
            5,
            "�������� �����",
            30,
            90,
            8,
            0,
            0,
            "Items/spear_steel"
            ),
        new Item(
            6,
            "�������� ��������",
            20,
            150,
            7,
            0,
            0,
            "Items/halberd_steal"
            ),
        new Item(
            7,
            "������������ ���",
            30,
            200,
            20,
            0,
            0,
            "Items/sword_magic"
            ),
        new Item(
            8,
            "������������ �����",
            40,
            170,
            15,
            0,
            0,
            "Items/spear_magic"
            ),
        new Item(
            9,
            "������������ ��������",
            30,
            220,
            14,
            0,
            0,
            "Items/halberd_magic"
            ),
        new Item(
            10,
            "����������� ���",
            40,
            500,
            50,
            0,
            0,
            "Items/sword_arichalcum"
            ),
        new Item(
            11,
            "����������� �����",
            50,
            400,
            40,
            0,
            0,
            "Items/spear_arichalcum"
            ),
        new Item(
            12,
            "����������� ��������",
            42,
            500,
            35,
            0,
            0,
            "Items/halberd_arichalcum"
            ),
        new Item(
            13,
            "�������� ���",
            15,
            50,
            0,
            4,
            0,
            "Items/shield_iron"
            ),
        new Item(
            14,
            "�������� ���",
            25,
            100,
            0,
            10,
            0,
            "Items/shield_steel"
            ),
        new Item(
            15,
            "������������ ���",
            35,
            200,
            0,
            15,
            0,
            "Items/shield_magic"
            ),
        new Item(
            16,
            "����������� ���",
            45,
            400,
            0,
            25,
            0,
            "Items/shield_arichalcum"
            ),
        new Item(
            17,
            "����",
            0,
            2,
            0,
            0,
            1,
            "Items/beer"
            ),
        new Item(
            18,
            "����� ������� (�����)",
            0,
            20,
            0,
            0,
            15,
            "Items/poison_health_small"
            ),
        new Item(
            19,
            "����� ������� (�������)",
            0,
            100,
            0,
            0,
            40,
            "Items/poison_health_medium"
            ),
        new Item(
            20,
            "����� ������� (�������)",
            0,
            250,
            0,
            0,
            100,
            "Items/poison_health_big"
            ),
        new Item(
            21,
            "����� �������� ����",
            0,
            200,
            0,
            0,
            0,
            "Items/poison_rock"
            ),
        new Item(
            22,
            "����� ������",
            0,
            300,
            0,
            0,
            0,
            "Items/poison_rage"
            ),
        new Item(
            23,
            "�����������",
            0,
            100,
            0,
            0,
            0,
            "Items/poison_antidote"
            ),
            // ������
            new Item(
            -10,
            "������",
            0,
            1,
            0,
            0,
            0,
            "Items/head_evil"
            ),
            new Item(
            -11,
            "������",
            0,
            1,
            0,
            0,
            0,
            "Items/head_goblin"
            ),
            new Item(
            -12,
            "������",
            0,
            1,
            0,
            0,
            0,
            "Items/head_grifon"
            ),
            new Item(
            -13,
            "������",
            0,
            1,
            0,
            0,
            0,
            "Items/head_rockman"
            ),
            new Item(
            -14,
            "������",
            0,
            1,
            0,
            0,
            0,
            "Items/head_skelet"
            ),
            new Item(
            -15,
            "������",
            0,
            1,
            0,
            0,
            0,
            "Items/head_spider"
            ),
            new Item(
            -16,
            "������",
            0,
            1,
            0,
            0,
            0,
            "Items/head_werewolf"
            ),
    };
}
