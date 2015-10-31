# DSA

1. **What is the expected running time of the following C# code?**
  - Explain why using Markdown.
  - Assume the array's size is `n`.

  ```cs
  long Compute(int[] arr)
  {
      long count = 0;
      for (int i=0; i<arr.Length; i++)
      {
          int start = 0, end = arr.Length-1;
          while (start < end)
              if (arr[start] < arr[end])
              {
                  start++; count++;
              }
              else 
              {
                  end--;
              }
      }
      return count;
  }
  
  The running time is n*n / 2. Considering that we donot take into account constants, complexity is O(n*n).
  - the first n is because of the for-loop which will be run n times (the length of the array);
  - the second n is because the nested while loop which will be executed untill start is smaller than end.
    As the start is increased or the edn is decresed each time we are running the loop, the exact time needed will be n/2.
  
  
  
