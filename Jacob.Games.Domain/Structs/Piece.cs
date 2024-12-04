using Jacob.Games.Domain.Enums;

namespace Jacob.Games.Domain.Structs;

public struct Piece
{
    public Side Side { get; private set; }
    public PawnType PawnType { get; private set; }

    public Piece(Side side, PawnType pawnType)
    {
        Side = side;
        PawnType = pawnType;
    }

    public override string ToString()
    {
        return $"{(Side == Side.White ? "W" : "B")}-{PawnType}";
    }
}