namespace P04
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.stones[i];
                }
            }

            for (int i = this.stones.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.stones[i];
                }
            }

            //var evenPositions = input
            //    .Where(i => i % 2 == 0)
            //    .ToList();

            //var oddPositions = input
            //    .Where(i => i % 2 != 0)
            //    .ToList();
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
