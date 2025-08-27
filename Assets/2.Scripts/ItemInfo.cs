using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] Image _item_Image;
    [SerializeField] TextMeshProUGUI _item_Name;
    [SerializeField] TextMeshProUGUI _item_Price;
    [SerializeField] TextMeshProUGUI _item_Info;
    [SerializeField] TextMeshProUGUI _item_Rate;

    TableBase _itemTable;

    public void SetItem(int itemID)
    {
        _itemTable = GameTableManager._Instance.Get(DefineEnums.TableName.ItemTable);

        if (_itemTable == null)
            return;
        string name = "Image" + _itemTable.ToS(itemID, "ImageNumber");
        _item_Image.material.mainTexture = Resources.Load<Texture>(name);
        _item_Name.text = _itemTable.ToS(itemID, "Item");
        _item_Price.text = _itemTable.ToS(itemID, "Price");
        _item_Info.text = _itemTable.ToS(itemID, "Info");
        _item_Rate.text = _itemTable.ToS(itemID, "Rate");
    }
}
