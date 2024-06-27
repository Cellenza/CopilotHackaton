#include "pch.h"
#include "Cell.h"

Cell::Cell()
    : _columnPosition(-1), _linePosition(-1)
{}

Cell::Cell(int columnPosition, int linePosition)
    : _columnPosition(columnPosition), _linePosition(linePosition)
{}

bool Cell::IsEmpty() const
{
    return (_columnPosition < 0) && (_linePosition < 0);
}

int Cell::ColumnPosition() const
{
    return _columnPosition;
}

int Cell::LinePosition() const
{
    return _linePosition;
}
