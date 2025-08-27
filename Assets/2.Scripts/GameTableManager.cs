using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineEnums;

public class GameTableManager : SingletonGameobject<GameTableManager>
{
    Dictionary<TableName, TableBase> _tableList;
    protected override void Awake()
    {
        base.Awake();
        _tableList = new Dictionary<TableName, TableBase>();
    }

    private void Start()
    {
        AllLoadTables();
    }

    bool Load<T>(TableName name) where T : TableBase, new()
    {
        if (_tableList.ContainsKey(name))
            return true;

        TextAsset tAsset = Resources.Load(name.ToString()) as TextAsset;
        if (tAsset != null)
        {
            T t = new T();
            t.Load(tAsset.text);
            _tableList.Add(name, t);
        }
        else
            return false;

        return true;
    }

    public void AllLoadTables()
    {
        if (!Load<ItemTable>(TableName.ItemTable))
            Debug.Log("Fail ItemTable Load, Check Path and Name");
    }

    public TableBase Get(TableName name)
    {
        if (_tableList.ContainsKey(name))
            return _tableList[name];

        return null;
    }
}
