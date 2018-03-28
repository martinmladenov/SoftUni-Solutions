namespace Froggy
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(IEnumerable<int> stones)
        {
            this.stones = stones.ToArray();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i += 2)
            {
                yield return stones[i];
            }

            for (int i = stones.Length - (stones.Length % 2 == 0 ? 1 : 2); i > 0; i -= 2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
