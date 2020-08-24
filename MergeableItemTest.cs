using System.Collections.Generic;
using UnityEngine;

public class MergeableItemTest : MonoBehaviour
{
    private int totalCreated;
    private int onPower;
    public float createRate;
    private float lastCreate;

    List<MergeableItem> items;

    void Start()
    {
        items = new List<MergeableItem>();
        totalCreated = 0;
        onPower = 0;
    }

    void Update()
    {
        if (Time.time - lastCreate >= createRate)
        {
            Create();

            if (IsPowerOfThree(totalCreated))
            {
                Test();
                onPower++;
            }
        }
    }

    void Create()
    {
        lastCreate = Time.time;
        MergeableItem item = new MergeableItem();
        items.Add(item);
        MergeableItem.CheckMerge(items);
        totalCreated++;
    }

    void Test()
    {
        bool countTest = CountTest();
        bool levelTest = LevelTest();

        Debug.Log(
            string.Format("Testing:\nTotal created: {0}\nOn power: {1}\nCount test: {2}\nLevel test: {3}",
            totalCreated, onPower, countTest, levelTest));

        if (!countTest || !levelTest)
        {
            Debug.LogWarning("Failed test!");
            Debug.Log(string.Format("Item count is: {0}, expected to be 1, state={1}", items.Count, items.Count == 1));
            Debug.Log(string.Format("Item level is: {0}, expected to be {1}, state={2}", items[0].level, onPower, items[0].level == onPower));
        }
    }

    bool CountTest()
    {
        return items.Count == 1;
    }

    bool LevelTest()
    {
        return items[0].level == onPower;
    }

    public bool IsPowerOfThree(int n) {
        return n > 0 && 1162261467 % n == 0;
    }
}
