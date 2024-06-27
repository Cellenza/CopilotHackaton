#include "pch.h"
#include "CppUnitTest.h"
#include "Grid.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace LifeGame
{
	TEST_CLASS(GridTest)
	{
	public:
		
		TEST_METHOD(WhenCreatingGridWithoutColumn_ExceptionIsThrown)
		{
			// Arrange
			const int numberOfLines = 1;
			const std::vector<Cell> cells = { Cell(1, 1) };

			// Act
			auto action0 = [&] { Grid grid(0, numberOfLines, cells); };
			auto action1 = [&] { Grid grid(-1, numberOfLines, cells); };

			// Assert
			Assert::ExpectException<std::invalid_argument>(action0);
			Assert::ExpectException<std::invalid_argument>(action1);
		}

		TEST_METHOD(WhenCreatingGridWithoutLine_ExceptionIsThrown)
		{
            // Arrange
            const int numberOfColumns = 1;
            const std::vector<Cell> cells = { Cell(1, 1) };

            // Act
            auto action0 = [&] { Grid grid(numberOfColumns, 0, cells); };
            auto action1 = [&] { Grid grid(numberOfColumns, -1, cells); };

            // Assert
            Assert::ExpectException<std::invalid_argument>(action0);
            Assert::ExpectException<std::invalid_argument>(action1);
        }

		TEST_METHOD(WhenCreatingGrid1x1_GridWithOneColumnAndOneLineIsCreated)
		{
            // Arrange
            const int numberOfColumns = 1;
            const int numberOfLines = 1;
            const std::vector<Cell> cells = { Cell(1, 1) };

            // Act
            Grid grid(numberOfColumns, numberOfLines, cells);

            // Assert
            Assert::AreEqual(numberOfColumns, grid.NumberOfColumns());
            Assert::AreEqual(numberOfLines, grid.NumberOfLines());
			Assert::IsFalse(grid.IsEmpty());
        }

		TEST_METHOD(WhenCellHas2Neighbours_ItIsAliveNextRound)
		{
            // Arrange
            const int numberOfColumns = 2;
            const int numberOfLines = 2;
            const std::vector<Cell> cells = { Cell(1, 1), Cell(1, 2), Cell(2, 1) };
            Grid grid(numberOfColumns, numberOfLines, cells);

            // Act
            Grid nextGrid = grid.NextState();

            // Assert
            Assert::IsTrue(nextGrid.IsCellAliveAtThisPosition(1, 1));
            Assert::IsTrue(nextGrid.IsCellAliveAtThisPosition(1, 2));
            Assert::IsTrue(nextGrid.IsCellAliveAtThisPosition(2, 1));
        }

        TEST_METHOD(WhenCellHas1Neighbor_ItIsDeadNextRound)
        {
            // Arrange
            const int numberOfColumns = 2;
            const int numberOfLines = 2;
            const std::vector<Cell> cells = { Cell(1, 1), Cell(1, 2) };
            Grid grid(numberOfColumns, numberOfLines, cells);

            // Act
            Grid nextGrid = grid.NextState();

            // Assert
            Assert::IsFalse(nextGrid.IsCellAliveAtThisPosition(1, 1));
            Assert::IsFalse(nextGrid.IsCellAliveAtThisPosition(1, 2));
            Assert::IsFalse(nextGrid.IsCellAliveAtThisPosition(2, 1));
            Assert::IsFalse(nextGrid.IsCellAliveAtThisPosition(2, 2));
        }

        TEST_METHOD(WhenCellHasMoreThan3Neighbors_ItIsDeadNextRound)
        {
            // Arrange
            //X X
            //X X
            //  X
            const int numberOfColumns = 2;
            const int numberOfLines = 3;
            const std::vector<Cell> cells = { Cell(1, 1), Cell(1, 2), Cell(2, 1), Cell(2, 2), Cell(2, 3) };
            Grid grid(numberOfColumns, numberOfLines, cells);

            // Act
            Grid nextGrid = grid.NextState();

            // Assert
            Assert::IsTrue (nextGrid.IsCellAliveAtThisPosition(1, 1));
            Assert::IsFalse(nextGrid.IsCellAliveAtThisPosition(1, 2));
            Assert::IsTrue (nextGrid.IsCellAliveAtThisPosition(2, 1));
            Assert::IsFalse(nextGrid.IsCellAliveAtThisPosition(2, 2));
            Assert::IsTrue (nextGrid.IsCellAliveAtThisPosition(2, 3));
        }

        TEST_METHOD(WhenCellHas3Neighbors_ItComesToLifeNextRound)
        {
            // Arrange
            const int numberOfColumns = 2;
            const int numberOfLines = 2;
            const std::vector<Cell> cells = { Cell(1, 1), Cell(1, 2), Cell(2, 1) };
            Grid grid(numberOfColumns, numberOfLines, cells);

            // Act
            Grid nextGrid = grid.NextState();

            // Assert
            Assert::IsTrue(nextGrid.IsCellAliveAtThisPosition(1, 1));
            Assert::IsTrue(nextGrid.IsCellAliveAtThisPosition(1, 2));
            Assert::IsTrue(nextGrid.IsCellAliveAtThisPosition(2, 1));
            Assert::IsTrue(nextGrid.IsCellAliveAtThisPosition(2, 2));
        }
	};
}
