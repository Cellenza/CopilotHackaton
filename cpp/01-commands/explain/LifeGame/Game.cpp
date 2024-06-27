#include "pch.h"
#include "Game.h"

Game::Game(Grid&& grid)
    : _grid(std::move(grid)), _isFinished(false)
{}

bool Game::IsFinished() const
{
    return _isFinished;
}

void Game::Run()
{
    Grid nextGrid = _grid.NextState();

    if (_grid.IsEqual(nextGrid))
    {
        _isFinished = true;
    }

    _grid = std::move(nextGrid);
}

bool Game::GridIsEmpty() const
{
    return _grid.IsEmpty();
}
