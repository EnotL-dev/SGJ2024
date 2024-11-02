using UnityEngine;
using UnityEngine.UI;

public class InformationPanelScript : MonoBehaviour
{
    [SerializeField] private Text text_name;
    [SerializeField] private Text description_name;
    [SerializeField] private Text cost_name;
    public void informate(int id, int durability)
    {
        ItemList itemList = ItemList.GetInstance();
        Item item = itemList.returnItemById(id);

        string prepare_description = "";
        if(item.damage > 0)
        {
            prepare_description += $"<color=red>����: {item.damage}</color>\n";
        }
        if(item.armor > 0)
        {
            prepare_description += $"<color=cyan>������: {item.armor}</color>\n";
        }
        if (item.durability > 0)
        {
            prepare_description += $"<color=yellow>���������: {item.durability}/{durability}</color>\n";
        }
        if(item.id == 3 || item.id == 6 || item.id == 9 || item.id == 12)
        {
            prepare_description += "������� �� �������.\n";
        }
        if (item.heal > 0)
        {
            prepare_description += $"<color=red>�� +{item.heal}</color>\n";
            prepare_description += "������ ����������.\n";
        }
        if(item.id == 17)
        {
            prepare_description += "���������� �������. �� ��������� ������!\n";
        }
        if (item.id == 21)
        {
            prepare_description += "���������� ���� � ������!\n<color=cyan>�������� ����</color> �� ����������� �� ���� ���.";
        }
        if (item.id == 22)
        {
            prepare_description += "��� ����� ���� � �����������.\n�������� ������ � <color=magenta>������</color> �� ���� ���.";
        }
        if (item.id == 23)
        {
            prepare_description += "�������� �� <color=green>����</color> � ��������.";
        }
        prepare_description = prepare_description.TrimEnd('\n');

        text_name.text = item.name;
        description_name.text = prepare_description;
        cost_name.text = $"���� {item.cost}";
    }
}
