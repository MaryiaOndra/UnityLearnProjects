using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "Goods/Sword", order = 51)]
public class Sword : Goods
{
    [SerializeField] private int _damage;

    public override void ShowGoods()
    {
        Debug.Log($"Название - {Label} Описание - {Description} Стоимость - {Price} Урон:{_damage}");
    }
}
