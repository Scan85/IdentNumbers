using IdentNumbers.Contracts;
using System;
using System.Collections.Generic;

namespace IdentNumbers
{
    public class MatrixGenerator : IMatrixGenerator
    {
        private readonly IReaderWrapper _readerWrapper;

        private readonly char vertical = '|';
        private readonly char horizontal = '-';
        private readonly char backslash = '\\';
        private readonly char slash = '/';
        private readonly char empty = ' ';


        public MatrixGenerator() : this(new ReaderWrapper())
        {

        }

        public MatrixGenerator(IReaderWrapper readerWrapper)
        {
            if (readerWrapper == null) throw new NullReferenceException();
            _readerWrapper = readerWrapper;
        }

        public List<char[]> GetMatrix(string path)
        {
            try
            {
                var stringList = _readerWrapper.ReadFile(path);
                if (stringList == null) return null;

                var matrix = new List<char[]>();

                foreach (var line in stringList)
                {
                    var characters = line.ToCharArray();
                    matrix.Add(characters);
                }
                return matrix;
            }
            catch (Exception ex)
            {
                throw new Exception("MatrixGenerator->GetMatrix:" + ex.Message);
            }
        }


        public List<MatrixChar> GetDefinedMatrixChars()
        {
            var matrixChars = new List<MatrixChar>();

            matrixChars.Add(new MatrixChar { matrix = GetOneMatrix(), value = "1" });
            matrixChars.Add(new MatrixChar { matrix = GetTwoMatrix(), value = "2" });
            matrixChars.Add(new MatrixChar { matrix = GetThreeMatrix(), value = "3" });
            matrixChars.Add(new MatrixChar { matrix = GetFourMatrix(), value = "4" });
            matrixChars.Add(new MatrixChar { matrix = GetFiveMatrix(), value = "5" });

            return matrixChars;
        }

        private List<char[]> GetOneMatrix()
        {
            return new List<char[]> {
                new char[] { vertical },
                new char[] { vertical },
                new char[] { vertical },
                new char[] { vertical }
            };
        }

        private List<char[]> GetTwoMatrix()
        {
            return new List<char[]>
            {
               new char[] { horizontal , horizontal , horizontal },
               new char[] { empty, horizontal , vertical },
               new char[] { vertical, empty, empty },
               new char[] { horizontal , horizontal , horizontal }
            };
        }

        private List<char[]> GetThreeMatrix()
        {
            return new List<char[]>
            {
               new char[] { horizontal , horizontal , horizontal },
               new char[] { empty, slash, empty },
               new char[] { empty, backslash, empty },
               new char[] { horizontal , horizontal , horizontal }
            };
        }

        private List<char[]> GetFourMatrix()
        {
            return new List<char[]>
            {
               new char[] { vertical, empty, empty,empty, vertical},
               new char[] { vertical, horizontal, horizontal, horizontal, vertical },
               new char[] { empty, empty, empty,empty, vertical },
               new char[] { empty, empty, empty, empty, vertical }
            };
        }

        private List<char[]> GetFiveMatrix()
        {
            return new List<char[]>
            {
               new char[] { horizontal, horizontal, horizontal, horizontal, horizontal},
               new char[] { vertical, horizontal, horizontal, horizontal, empty },
               new char[] { empty, empty, empty,empty, vertical },
               new char[] { horizontal, horizontal, horizontal, horizontal, vertical }
            };
        }
    }
}