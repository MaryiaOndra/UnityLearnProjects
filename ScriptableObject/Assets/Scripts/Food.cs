using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Goods/Food", order = 51)]
public class Food : Goods
{
    [SerializeField] private int _calorie;

    public override void ShowGoods()
    {
        Debug.Log($"Название - {Label} Описание - {Description} Стоимость - {Price} Калорийность:{_calorie}");
    }
}
