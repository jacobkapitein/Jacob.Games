using FluentAssertions;
using Jacob.Games.Domain.Models;
using Jacob.Games.Domain.Structs;
using Reqnroll;

namespace Jacob.Games.Domain.Tests.Steps;

[Binding]
public class MakeMoveSteps
{
    private ChessBoard _board = null!;
    private Piece?[,] _originalBoard = null!;
    
    [Given(@"the following board")]
    public void GivenTheFollowingBoard(Piece?[,] board)
    {
        _board = new ChessBoard(board);
        _originalBoard = board;
    }

    [When(@"'(.*)' moves to '(.*)'")]
    public void WhenMovesTo((int x, int y) from, (int x, int y) to)
    {
        _board.MovePiece(from, to);
    }

    [Then(@"the board should look as follows")]
    public void ThenTheBoardShouldLookAsFollows(Piece?[,] board)
    {
        _board.Board.Should().BeEquivalentTo(board);
    }

    [Then(@"the board should not have changed")]
    public void ThenTheBoardShouldNotHaveChanged()
    {
        _board.Board.Should().BeEquivalentTo(_originalBoard);
    }
}