using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            //AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            Debug.Log(words.Length);
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            Debug.Log(numbers.Length);
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            bool isValid = true;
            int invalidId = 0;

            Stack<char> expecting = new Stack<char>();
            Dictionary<char, char> supportedBracketsDict = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' },
            };

            foreach (char c in input)
            {
                if (supportedBracketsDict.TryGetValue(c, out char expectedClosing))
                {
                    expecting.Push(expectedClosing);
                }
                else if (supportedBracketsDict.ContainsValue(c))
                {
                    if (!expecting.Any())
                    {
                        isValid = false;
                        invalidId = input.IndexOf(c);
                        break;
                    }

                    if (expecting.Peek() != c)
                    {
                        isValid = false;
                        invalidId = input.IndexOf(c);
                        break;
                    }
                    else
                    {
                        expecting.Pop();
                    }
                }
            }

            if (!isValid)
            {
                Debug.Log($"Invalid brackets: Unexpected '{input[invalidId]}' at index {invalidId}");
            }
            else if (expecting.Count > 0)
            {
                Debug.Log($"Invalid brackets: expecting '{string.Join(", ", expecting.Reverse())}'");
            }
            else
            {
                Debug.Log("Brackets Valid");
            }
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();

            Debug.Log($"{string.Join(", ", list.Reverse())}");
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            LinkedListNode<string> result = list.First;
            if (list.Count % 2 == 0)
            {
                Debug.Log("Can't find middle element in even number list");
                return;
            }
            else
            {
                int middle = (list.Count - 1) / 2;
                for (int i = 0; i < middle; i++)
                {
                    result = result.Next;
                }
            }

            Debug.Log($"Result: {result.Value}");
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();

            Dictionary<string, int> merged = new(dict1);
            foreach (var kvp in dict2)
            {
                // item already exist in one dict
                if (merged.TryGetValue(kvp.Key, out int value))
                {
                    merged[kvp.Key] += kvp.Value;
                }
                else
                {
                    merged.Add(kvp.Key, value);
                }
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();

            LinkedList<int> nodup = new LinkedList<int>(list.ToHashSet());
            Debug.Log($"{string.Join(", ", nodup)}");
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            Dictionary<int, int> frequencyMap = new();
            foreach (var number in numbers)
            {
                if (!frequencyMap.ContainsKey(number))
                {
                    frequencyMap.Add(number, 1);
                }
                else frequencyMap[number]++;
            }

            KeyValuePair<int, int> mostFrequent = new(0, int.MinValue);
            foreach (var kvp in frequencyMap)
            {
                 if (kvp.Value > mostFrequent.Value)
                {
                    mostFrequent = kvp;
                }
            }

            Debug.Log($"Top Frequent is '{mostFrequent.Key}' appeared '{mostFrequent.Value}' time(s)");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;
            if (!inventory.ContainsKey(itemName)) inventory.Add(itemName, quantity);
            else inventory[itemName] += quantity;

            Debug.Log("--- Inventory Content ---");
            if (inventory.Count == 0)
            {
                Debug.Log("Inventory is empty.");
                return;
            }

            foreach (var itemEntry in inventory)
            {
                Debug.Log(itemEntry.Key + ": " + itemEntry.Value);
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            while (eventQueue.Count > 0)
            {
                GameEvent processingEvent = eventQueue.First();
                eventQueue.Remove(processingEvent);
                Debug.Log($"Processing event: {processingEvent.Name}");
                Debug.Log($"Remaining event in queue: {eventQueue.Count}");
                Debug.Log($"{processingEvent.EventType} event processed - {processingEvent.Name}");
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;

            if (!playerStats.ContainsKey(statName)) playerStats.Add(statName, value);
            else playerStats[statName] += value;

            Debug.Log($"Updated {statName}: {playerStats[statName]}");
            Debug.Log("Current player statistics:");
            foreach (var kvp in playerStats)
            {
                Debug.Log(kvp.Key + ": " + kvp.Value);
            }
        }

        #endregion
    }
}
