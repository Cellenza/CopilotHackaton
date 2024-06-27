#pragma once

class Cell
{
public:
    Cell();
    Cell(int columnPosition, int linePosition);
    bool IsEmpty() const;
    int ColumnPosition() const;
    int LinePosition() const;

private:
    int _columnPosition;
    int _linePosition;
};

