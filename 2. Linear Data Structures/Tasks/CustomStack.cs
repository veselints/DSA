using System;

namespace Tasks
{
    // 12. Implement the ADT stack as auto-resizable array.
    public class CustomStack<T>
    {
        private T[] values;
        private const int initialValuesCount = 4;
        private int numberOfFiledCells = 0;

        public CustomStack()
        {
            this.values = new T[initialValuesCount];
        }

        public int Count
        {
            get { return this.numberOfFiledCells; }
        }

        public void Push(T itemToAdd)
        {
            if (this.numberOfFiledCells == this.values.Length)
            {
                T[] oldValues = this.values;
                this.values = new T[oldValues.Length * 2];
                for (int i = 0; i < oldValues.Length; i++)
                {
                    this.values[i] = oldValues[i];
                }
            }

            this.values[numberOfFiledCells] = itemToAdd;
            this.numberOfFiledCells += 1;
        }

        public T Pop()
        {
            ValidateAction();

            numberOfFiledCells -= 1;
            T result = this.values[numberOfFiledCells];
            this.values[numberOfFiledCells] = default(T);
            return result;
        }

        public T Peak()
        {
            ValidateAction();

            T result = this.values[numberOfFiledCells - 1];
            return result;
        }

        private void ValidateAction()
        {
            if (numberOfFiledCells == 0)
            {
                throw new NullReferenceException("The CustomStack is empty!");
            }
        }
    }
}
