#pragma once
#include "Grid.h"

class Game
{
public:
    Game(Grid&& grid);
    bool IsFinished() const;
    void Run();
    bool GridIsEmpty() const;

private:
    bool _isFinished;
    Grid _grid;
};

