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
            10,
            50,
            5,
            0,
            0,
            "Items/sword_iron"
            ),
        new Item(
            2,
            "�������� �����",
            12,
            40,
            4,
            0,
            0,
            "Items/spear_iron"
            ),
        new Item(
            3,
            "�������� �����",
            10,
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
            25,
            80,
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
            150,
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
            30,
            0,
            0,
            "Items/halberd_arichalcum"
            ),
        new Item(
            13,
            "�������� ���",
            8,
            50,
            0,
            4,
            0,
            "Items/shield_iron"
            ),
        new Item(
            14,
            "�������� ���",
            14,
            100,
            0,
            10,
            0,
            "Items/shield_steel"
            ),
        new Item(
            15,
            "������������ ���",
            20,
            190,
            0,
            10,
            0,
            "Items/shield_magic"
            ),
        new Item(
            16,
            "����������� ���",
            25,
            400,
            0,
            30,
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
