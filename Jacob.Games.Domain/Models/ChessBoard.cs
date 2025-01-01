using Jacob.Games.Domain.Enums;
using Jacob.Games.Domain.Structs;

namespace Jacob.Games.Domain.Models;

public class ChessBoard
{
    public ChessBoard()
    {
        Board = new Piece?[8,8]
        {
            { new Piece(Side.Black, PawnType.Rook), new Piece(Side.Black, PawnType.Knight), new Piece(Side.Black, PawnType.Bishop), new Piece(Side.Black, PawnType.Queen), new Piece(Side.Black, PawnType.King), new Piece(Side.Black, PawnType.Bishop), new Piece(Side.Black, PawnType.Knight), new Piece(Side.Black, PawnType.Rook), },
            { new Piece(Side.Black, PawnType.Pawn), new Piece(Side.Black, PawnType.Pawn), new Piece(Side.Black, PawnType.Pawn), new Piece(Side.Black, PawnType.Pawn), new Piece(Side.Black, PawnType.Pawn), new Piece(Side.Black, PawnType.Pawn), new Piece(Side.Black, PawnType.Pawn), new Piece(Side.Black, PawnType.Pawn), },
            { null, null, null, null, null, null, null, null, },
            { null, null, null, null, null, null, null, null, },
            { null, null, null, null, null, null, null, null, },
            { null, null, null, null, null, null, null, null, },
            { new Piece(Side.White, PawnType.Pawn), new Piece(Side.White, PawnType.Pawn), new Piece(Side.White, PawnType.Pawn), new Piece(Side.White, PawnType.Pawn), new Piece(Side.White, PawnType.Pawn), new Piece(Side.White, PawnType.Pawn), new Piece(Side.White, PawnType.Pawn), new Piece(Side.White, PawnType.Pawn), },
            { new Piece(Side.White, PawnType.Rook), new Piece(Side.White, PawnType.Knight), new Piece(Side.White, PawnType.Bishop), new Piece(Side.White, PawnType.King), new Piece(Side.White, PawnType.Queen), new Piece(Side.White, PawnType.Bishop), new Piece(Side.White, PawnType.Knight), new Piece(Side.White, PawnType.Rook), },
        };
        MovesPlayed = [];
    }
    
    public ChessBoard(Piece?[,] board)
    {
        Board = (Piece?[,]?)board.Clone() ?? throw new InvalidOperationException();
        MovesPlayed = [];
    }
    
    public Piece?[,] Board { get; }

    public List<int> MovesPlayed { get; }

    public Side SideToMove => (Side)(MovesPlayed.Count % 2);

    public void MovePiece((int x, int y) from, (int x, int y) to)
    {
        Piece? pieceAtFrom = Board[from.y, from.x];

        if (pieceAtFrom is null)
            return;
        
        Board[to.y, to.x] = pieceAtFrom;
        Board[from.y, from.x] = null;
    }
}