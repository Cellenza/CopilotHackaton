#include "pch.h"
#include "CppUnitTest.h"
#include "Game.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace LifeGame
{
	TEST_CLASS(GameTest)
	{
	public:
		
		TEST_METHOD(WhenGrisIsEmpty_GameFinishesAtNextRound)
		{
            // Arrange
			Grid grid(1, 1, { });
            Game game(std::move(grid));

            // Act
            game.Run();

            // Assert
            Assert::IsTrue(game.IsFinished());
		}

		TEST_METHOD(WhenGridIsInitialized_GameIsNotFinished)
		{
            // Arrange
            Grid grid(1, 1, { });
            Game game(std::move(grid));

            // Assert
            Assert::IsFalse(game.IsFinished());
        }

        TEST_METHOD(WhenGrid1x1With1Cell_GameContinuesAfter1Round)
        {
            // Arrange
            Grid grid(1, 1, { Cell(1, 1) });
            Game game(std::move(grid));

            // Act
            game.Run();

            // Assert
            Assert::IsFalse(game.IsFinished());
        }

        TEST_METHOD(WhenGrid1x1With1Cell_GameFinishesAfter2Rounds)
        {
            // Arrange
            Grid grid(1, 1, { Cell(1, 1) });
            Game game(std::move(grid));

            // Act
            game.Run();
            game.Run();

            // Assert
            Assert::IsTrue(game.IsFinished());
        }

        TEST_METHOD(WhenGrid2x2With2Cells_GameFinishesAfter2Rounds)
        {
            // Arrange
            Grid grid(2, 2, { Cell(1, 1), Cell(1, 2) });
            Game game(std::move(grid));

            // Act
            game.Run();
            game.Run();

            // Assert
            Assert::IsTrue(game.IsFinished());
        }

        TEST_METHOD(WhenGrid2x2With3Cells_GameFinishesAfter2Rounds)
        {
            // Arrange
            Grid grid(2, 2, { Cell(1, 1), Cell(1, 2), Cell(2, 1) });
            Game game(std::move(grid));

            // Act
            game.Run();
            game.Run();

            // Assert
            Assert::IsTrue(game.IsFinished());
        }

        TEST_METHOD(WhenGrid4x4WithCellsBlock_GameFinishesAfter1Round)
        {
            // Arrange
            Grid grid(4, 4, { Cell(2, 2), Cell(2, 3), Cell(3, 2), Cell(3, 3) });
            Game game(std::move(grid));

            // Act
            game.Run();

            // Assert
            Assert::IsTrue(game.IsFinished());
        }

        TEST_METHOD(WhenGrid2x3With3Cells_GameContinuesAfter1Round)
        {
            // Arrange
            Grid grid(2, 3, { Cell(1, 1), Cell(2, 2), Cell(2, 3) });
            Game game(std::move(grid));

            // Act
            game.Run();

            // Assert
            Assert::IsFalse(game.IsFinished());
        }

        TEST_METHOD(WhenGrid4x3With6Cells_GameContinuesAfter1Round)
        {
            // Arrange
            Grid grid(4, 3, { Cell(2, 1), Cell(3, 1), Cell(2, 2), Cell(3, 2), Cell(2, 3), Cell(3, 3) });
            Game game(std::move(grid));

            // Act
            game.Run();

            // Assert
            Assert::IsFalse(game.IsFinished());
        }
    };
}
