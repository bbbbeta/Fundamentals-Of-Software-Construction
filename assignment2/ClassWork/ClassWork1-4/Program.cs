namespace ClassWork1_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = { [1, 2, 3, 4], [5, 1, 2, 3], [9, 5, 1, 2] };
            //如果矩阵上每一条由左上到右下的对角线上的元素都相同，那么这个矩阵是托普利茨矩阵 。
            //给定一个 M x N 的矩阵，当且仅当它是托普利茨矩阵时返回 True。
            Console.WriteLine(IsToeplitzMatrix(matrix));
        }

        static bool IsToeplitzMatrix(int[][] matrix)
        {
            for(var i = 0; i < matrix.Length; i++)
            {
                for(var j = 0; j < matrix[i].Length; j++)
                {
                    if (i != 0 && j != 0 && matrix[i][j] != matrix[i - 1][j - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
