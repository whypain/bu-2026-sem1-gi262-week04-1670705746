using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        public void Start()
        {
            // LCT01_SyntaxList();
            // LCT02_SyntaxLinkedList();
            // LCT03_SyntaxHashTable();
            // LCT04_SyntaxDictionary();
        }

        #region Lecture

        public void LCT01_SyntaxList()
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_SyntaxLinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddLast("Node 1");
            linkedList.AddLast("Node 2");

            linkedList.AddFirst("Node 0");

            LinkedListNode<string> firstNode = linkedList.First;
            Debug.Log($"first: {firstNode.Value}");

            LinkedListNode<string> lastNode = linkedList.Last;
            Debug.Log($"last: {lastNode.Value}");

            Debug.Log($"firstNode.Next: {firstNode.Next.Value}");
            Debug.Log($"firstNode.Next.Next: {firstNode.Next.Next.Value}");

            Debug.Log($"lastNode.Previous: {lastNode.Previous.Value}");
            Debug.Log($"lastNode.Previous.Previous: {lastNode.Previous.Previous.Value}");

            if (firstNode.Previous == null) Debug.Log("firstNode.Previous == null");
            if (lastNode.Next == null) Debug.Log("lastNode.Next == null");

            linkedList.AddAfter(firstNode, "Node 0.5");
            linkedList.AddBefore(lastNode, "Node 1.5");

            LinkedListNode<string> node1 = linkedList.Find("Node 1");
            linkedList.Remove("Node 1");
            linkedList.Remove(node1);
            linkedList.RemoveLast();
            linkedList.RemoveFirst();

            linkedList.Clear();
        }

        public void LCT03_SyntaxHashTable()
        {
            Hashtable table = new Hashtable();
            table.Add("Potion", 1);
            table.Add(true, "");
            table.Add(0, 0);
        }

        public void LCT04_SyntaxDictionary()
        {
            Dictionary<string, int> inv = new();
            var inv2 = new Dictionary<string, int>();

            inv.Add("Potion", 1);
            inv.Add("Apple", 10);

            inv["Banana"] = 5;
            inv["Potion"] = 10;

            var pickupItem = "Sword";
            inv[pickupItem] = 1;

            foreach(KeyValuePair<string, int> pair in inv)
            {
                string key = pair.Key;
                int value = pair.Value;
                Debug.Log($"{key} {value}");
            }

            var appleExists = inv.ContainsKey("Apple");
            Debug.Log(appleExists);

            var keyExists = inv.ContainsKey("Key");
            Debug.Log(keyExists);

            inv.Remove("Apple");

            foreach(var pair in inv)
            {
                string key = pair.Key;
                int value = pair.Value;
                Debug.Log($"key {key}: value {value}");
            }
        }

        #endregion
    }
}
