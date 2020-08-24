using System.Collections.Generic;

public class MergeableItem
{
    public int level;

    /// <summary>
    /// Checks for mergeable items in given list.
    /// If it can find three mergeable items, merges them.
    /// </summary>
    /// <param name="items"></param>
    public static void CheckMerge(List<MergeableItem> items) 
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            List<MergeableItem> mergeableItems = new List<MergeableItem>() { items[i] };
            for (int j = i - 1; j >= 0 && mergeableItems.Count != 3; j--)
            {
                if (items[i].IsMergeableWith(items[j]))
                {
                    mergeableItems.Add(items[j]);
                }
            }

            if (mergeableItems.Count == 3)
            {
                Merge(items, mergeableItems);
                i--;
            }
        }
    }

    /// <summary>
    /// Checks if this item is mergeable with given item.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>True if mergeable.</returns>
    public bool IsMergeableWith(MergeableItem item) 
    {
        return this.level == item.level;
    }

    /// <summary>
    /// Merges mergeable items into one.
    /// Removes the excessive ones from the list.
    /// </summary>
    /// <param name="items">Complete list of items.</param>
    /// <param name="itemsToMergeWith">Three of mergeable items.</param>
    private static void Merge(List<MergeableItem> items, List<MergeableItem> itemsToMergeWith) 
    {
        itemsToMergeWith[0].level++;
        for (int i = 1; i < itemsToMergeWith.Count; i++)
            items.Remove(itemsToMergeWith[i]);
    }
}
