using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // ============================================================
        // PLAN:
        // 1. Create a new double array with size equal to 'length'.
        // 2. Use a for loop to iterate from i = 0 to length - 1.
        // 3. In each iteration, compute the multiple as number * (i + 1)
        //    because the first multiple is number*1, second is number*2, etc.
        // 4. Store that computed value into the array at index i.
        // 5. After the loop finishes, return the filled array.
        // ============================================================

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // ============================================================
        // PLAN:
        // 1. Guard against invalid input: if the list is null, empty, or amount <= 0, return immediately.
        //    (The spec guarantees amount is between 1 and data.Count, but this check is safe.)
        // 2. Extract the last 'amount' elements from the original list using GetRange.
        //    The starting index is (data.Count - amount) and we take 'amount' items.
        //    Store this slice in a new List<int> called 'tail'.
        // 3. Remove those same elements from the end of the original list using RemoveRange,
        //    starting at index (data.Count - amount) and removing 'amount' items.
        // 4. Insert the 'tail' list at the very beginning of the original list using InsertRange(0, tail).
        // 5. The original list is now rotated to the right by the specified amount.
        //    No return value is needed because the list is modified in place.
        // ============================================================

        if (data == null || data.Count == 0 || amount <= 0)
            return;

        // Get the last 'amount' elements
        List<int> tail = data.GetRange(data.Count - amount, amount);

        // Remove them from the original list
        data.RemoveRange(data.Count - amount, amount);

        // Insert the extracted elements at the beginning
        data.InsertRange(0, tail);
    }
}