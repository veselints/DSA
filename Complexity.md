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
    As the start is increased or the edn is decresed each time we are running the loop, the exact time needed will be n/2;
  
  
  2. **What is the expected running time of the following C# code?**
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

  ```cs
  long CalcCount(int[,] matrix)
  {
      long count = 0;
      for (int row=0; row<matrix.GetLength(0); row++)
      {
          if (matrix[row, 0] % 2 == 0)
          {
              for (int col=0; col<matrix.GetLength(1); col++)
              {
                  if (matrix[row,col] > 0)
                  {
                      count++;
                  }
              }
          }
      }
      return count;
  }
  
  The running time is n*m.Complexity is O(n*m).
  - the n is because of the for-loop on the rows which will be run n times;
  - the m is because of the for-loop on the cols which will be run m times in the worst case
    (when matrix[row, 0] % 2 is allways 0);
  

3. **(*) What is the expected running time of the following C# code?**
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

  ```cs
  long CalcSum(int[,] matrix, int row)
  {
      long sum = 0;
      for (int col = 0; col < matrix.GetLength(0); col++)
      {
          sum += matrix[row, col];
      }
      if (row + 1 < matrix.GetLength(1))
      {
          sum += CalcSum(matrix, row + 1);
      }
      return sum;
  }
  
  Console.WriteLine(CalcSum(matrix, 0));
  
  The running time is m.Complexity is O(n*n).
  - this is because in the whole operation the for loop will be executed exactly n times;
  - and the method itself will be called maximum m times;
  (equal to the number of cols in the matrix);
  
