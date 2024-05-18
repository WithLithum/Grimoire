namespace Grimoire.Minecraft.Models;

using MineJason.Data.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Defines a two-dimensional vector (X, Z) that represents an entire column of blocks in world space.
/// </summary>
public readonly record struct ColumnPosition : IValidatable
{
    public ColumnPosition(BlockPositionComponent x, BlockPositionComponent z)
    {
        X = x;
        Z = z;
    }

    public ColumnPosition(int x, int z, BlockPositionComponentType type = BlockPositionComponentType.Absolute)
    {
        X = new BlockPositionComponent(x, type);
        Z = new BlockPositionComponent(z, type);
    }

    /// <summary>
    /// Gets the X component of this instance.
    /// </summary>
    public BlockPositionComponent X { get; }

    /// <summary>
    /// Gets the Y component of this instance.
    /// </summary>
    public BlockPositionComponent Z { get; }

    public bool IsValid()
    {
        return X.Type == BlockPositionComponentType.Local
            != (Z.Type == BlockPositionComponentType.Local);
    }
}
