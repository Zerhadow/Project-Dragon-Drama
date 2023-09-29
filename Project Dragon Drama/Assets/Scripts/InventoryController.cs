using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryController : MonoBehaviour
{
    [System.Serializable]
    public class InventoryEvent
    {
        public string key;
        public UnityEvent OnAdd, OnRemove;
    }


    [System.Serializable]
    public class InventoryChecker
    {
        public string[] inventoryItems;
        public UnityEvent OnHasItem, OnDoesNotHaveItem;

        public bool CheckInventory(InventoryController inventory)
        {
            if (inventory != null)
            {
                for (var i = 0; i < inventoryItems.Length; i++)
                {
                    if (!inventory.HasItem(inventoryItems[i]))
                    {
                        OnDoesNotHaveItem.Invoke();
                        return false;
                    }
                }
                OnHasItem.Invoke();
                return true;
            }
            return false;
        }
    }


    public InventoryEvent[] inventoryEvents;

    HashSet<string> m_GossipItems = new HashSet<string>();


    //Debug function useful in editor during play mode to print in console all objects in that InventoyController
    [ContextMenu("Dump")]
    void Dump()
    {
        Debug.Log("Gossip Inventory:");
        foreach (var item in m_GossipItems)
        {
            Debug.Log(item);
        }
    }

    public void AddItem(string key)
    {
        if (!m_GossipItems.Contains(key))
        {
            m_GossipItems.Add(key);
            var ev = GetInventoryEvent(key);
            if (ev != null) ev.OnAdd.Invoke();
        }
    }

    public void RemoveItem(string key)
    {
        if (m_GossipItems.Contains(key))
        {
            var ev = GetInventoryEvent(key);
            if (ev != null) ev.OnRemove.Invoke();
            m_GossipItems.Remove(key);
        }
    }

    public bool HasItem(string key)
    {
        return m_GossipItems.Contains(key);
    }

    public int GetSize()
    {
        return m_GossipItems.Count;
    }

    public void Clear()
    {
        m_GossipItems.Clear();
    }

    InventoryEvent GetInventoryEvent(string key)
    {
        foreach (var iv in inventoryEvents)
        {
            if (iv.key == key) return iv;
        }
        return null;
    }
}
