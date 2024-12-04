using Jacob.Games.Domain.Enums;
using Jacob.Games.Domain.Structs;
using Reqnroll;

namespace Jacob.Games.Domain.Tests.Transformations;

[Binding]
public class ChessBoardTransformations
{
    [StepArgumentTransformation]
    public Piece?[,] TransformBoard(string input)
    {
        Piece?[,] board = new Piece?[8, 8];

        // Strip everything that is not in this list:
        char[] allowedValues = ['r', 'R', 'n', 'N', 'b', 'B', 'q', 'Q', 'k', 'K', 'p', 'P'];
        
        // Convert the input to above format
        List<Piece?> pieces = new List<Piece?>();
        
        foreach (char c in input)
        {
            if (!allowedValues.Contains(c) && c != '.')
                continue;

            Piece? piece = null;
            switch (c)
            {
                case '.':
                    break;
                case 'r':
                    piece = new Piece(Side.Black, PawnType.Rook);
                    break;
                case 'R':
                    piece = new Piece(Side.White, PawnType.Rook);
                    break;
                case 'n':
                    piece = new Piece(Side.Black, PawnType.Knight);
                    break;
                case 'N':
                    piece = new Piece(Side.White, PawnType.Knight);
                    break;
                case 'b':
                    piece = new Piece(Side.Black, PawnType.Bishop);
                    break;
                case 'B':
                    piece = new Piece(Side.White, PawnType.Bishop);
                    break;
                case 'q':
                    piece = new Piece(Side.Black, PawnType.Queen);
                    break;
                case 'Q':
                    piece = new Piece(Side.White, PawnType.Queen);
                    break;
                case 'k':
                    piece = new Piece(Side.Black, PawnType.King);
                    break;
                case 'K':
                    piece = new Piece(Side.White, PawnType.King);
                    break;
                case 'p':
                    piece = new Piece(Side.Black, PawnType.Pawn);
                    break;
                case 'P':
                    piece = new Piece(Side.White, PawnType.Pawn);
                    break;
                default:
                    throw new ArgumentException($"Invalid piece type: {c}");
            }
            pieces.Add(piece);
        }
        
        if(pieces.Count != 64)
            throw new ArgumentException($"Invalid board size: {input}");

        int x = 0;
        int y = 0;
        foreach (Piece? piece in pieces)
        {
            board[y, x] = piece;
            if (x == 7)
            {
                x = 0;
                y += 1;
            }
            else
            {
                x += 1;
            }
        }
        
        return board;
    }

    [StepArgumentTransformation]
    public (int x, int y) TransformPosition(string input)
    {
        var parts = input.Split(',');

        int x = int.Parse(parts[0]);
        int y = int.Parse(parts[1]);

        if (x < 0 || x > 7 || y < 0 || y > 7)
        {
            throw new ArgumentOutOfRangeException(nameof(input), $"Invalid position: {input}");
        }

        return (x, y);
    }
}