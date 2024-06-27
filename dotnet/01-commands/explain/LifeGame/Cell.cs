
namespace LifeGame
{
    internal class Cell
    {
        public int ColumnPosition { get; private set; }
        public int LinePosition { get; private set; }


        public Cell(int columnPosition, int linePosition)
        {
            ColumnPosition = columnPosition;
            LinePosition = linePosition;
        }
    }
}