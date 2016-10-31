using IdentNumbers.Contracts;
using System.Collections.Generic;

namespace IdentNumbers
{
    public class MatrixComparer : IMatrixComparer
    {
        public string CompareMatrixes(List<char[]> matrix, int x, int y, MatrixChar matrixChar)
        {
            try
            {
                var matrixToReturn = new List<char[]>();

                for (var i = 0; i < matrixChar.matrix.Count; i++)
                {
                    for (var j = 0; j < matrixChar.matrix[0].Length; j++)
                    {
                        if (matrix.Count < (y + i)) return "";
                        if (matrix[0].Length < (x + j)) return "";
                        if (matrix[y + i][x + j] != matrixChar.matrix[i][j])
                        {
                            return "";
                        }
                    }
                }

                return matrixChar.value;
            }
            catch
            {
                return null;
            }
        }

        public List<int> GetMatrixSize(List<char[]> matrix)
        {
            try
            {
                var matrixSize = new List<int>();
                matrixSize.Add(matrix[0].Length);
                matrixSize.Add(matrix.Count);
                return matrixSize;
            }
            catch
            {
                return null;
            }
        }
    }
}