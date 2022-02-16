using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TopDownShooter.MapGeneration
{
    public abstract class RuleTile {
        public TileBase tile;

        public RuleTile(TileBase tile) {
            this.tile = tile;
        }

        public abstract bool Use8Dir {get;}

        public bool RuleApplies(int x, int y, Dictionary<(int,int), bool> landTiles) =>
            Use8Dir ? 
                RuleApplies1(x,y,landTiles) : 
                RuleApplies2(x,y,landTiles);

        public bool RuleApplies2(int x, int y, Dictionary<(int,int), bool> landTiles) {
            var valid = valids;

            if (landTiles[(x, y + 1)] != valid[1]) return false;
            if (landTiles[(x - 1, y)] != valid[3]) return false;
            if (landTiles[(x + 1, y)] != valid[5]) return false;
            if (landTiles[(x, y - 1)] != valid[7]) return false;

            return true;
        }

        public bool RuleApplies1(int x, int y, Dictionary<(int,int), bool> landTiles) {
            var valid = valids;

            if (landTiles[(x - 1, y + 1)] != valid[0]) return false;
            if (landTiles[(x, y + 1)] != valid[1]) return false;
            if (landTiles[(x + 1, y + 1)] != valid[2]) return false;
            if (landTiles[(x - 1, y)] != valid[3]) return false;
            if (landTiles[(x, y)] != valid[4]) return false;
            if (landTiles[(x + 1, y)] != valid[5]) return false;
            if (landTiles[(x - 1, y - 1)] != valid[6]) return false;
            if (landTiles[(x, y - 1)] != valid[7]) return false;
            if (landTiles[(x + 1, y - 1)] != valid[8]) return false;

            return true;
        }

        // 0,1,2
        // 3,4,5
        // 6,7,8
        protected abstract bool[] valids {get;}

        protected const bool T = true;
        protected const bool F = false;
    }

    public class UpLeftTile : RuleTile
    {
        public UpLeftTile(TileBase tile) : base(tile)
        {
        }

        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            F, F, F,
            F, T, T,
            F, T, T
        };
    }

    public class UpTile : RuleTile
    {
        public UpTile(TileBase tile) : base(tile)
        {
        }

        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            F, F, F,
            T, T, T,
            T, T, T
        };
    }

    public class UpRightTile : RuleTile
    {
        public UpRightTile(TileBase tile) : base(tile)
        {
        }

        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            F, F, F,
            T, T, F,
            T, T, F
        };
    }

    public class LeftTile : RuleTile
    {
        public LeftTile(TileBase tile) : base(tile)
        {
        }
        
        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            F, T, T,
            F, T, T,
            F, T, T
        };
    }

    public class RightTile : RuleTile
    {
        public RightTile(TileBase tile) : base(tile)
        {
        }
        
        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            T, T, F,
            T, T, F,
            T, T, F
        };
    }

    public class DownLeftTile : RuleTile
    {
        public DownLeftTile(TileBase tile) : base(tile)
        {
        }
        
        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            F, T, T,
            F, T, T,
            F, F, F
        };
    }

    public class DownTile : RuleTile
    {
        public DownTile(TileBase tile) : base(tile)
        {
        }
        
        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            T, T, T,
            T, T, T,
            F, F, F
        };
    }

    public class DownRightTile : RuleTile
    {
        public DownRightTile(TileBase tile) : base(tile)
        {
        }
        
        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            T, T, F,
            T, T, F,
            F, F, F
        };
    }

    public class InnerUpLeftTile : RuleTile
    {
        public InnerUpLeftTile(TileBase tile) : base(tile)
        {
        }

        public override bool Use8Dir => true;

        protected override bool[] valids => new bool[] {
            T, T, T,
            T, T, T,
            T, T, F
        };
    }

    public class InnerUpRightTile : RuleTile
    {
        public InnerUpRightTile(TileBase tile) : base(tile)
        {
        }

        public override bool Use8Dir => true;

        protected override bool[] valids => new bool[] {
            T, T, T,
            T, T, T,
            F, T, T
        };
    }

    public class InnerDownRightTile : RuleTile {
        public InnerDownRightTile(TileBase tile) : base(tile)
        {
        }

        public override bool Use8Dir => true;

        protected override bool[] valids => new bool[] {
            F, T, T,
            T, T, T,
            T, T, T
        };
    }

    public class InnerDownLeftTile : RuleTile {
        public InnerDownLeftTile(TileBase tile) : base(tile)
        {
        }

        public override bool Use8Dir => true;

        protected override bool[] valids => new bool[] {
            T, T, F,
            T, T, T,
            T, T, T
        };
    }

    public class LonelyTile : RuleTile {
        public LonelyTile(TileBase tile) : base(tile) {
        }

        public override bool Use8Dir => true;

        protected override bool[] valids => new bool[] {
            F, F, F,
            F, T, F,
            F, F, F
        };
    }

    public class LeftPeninsulaTile : RuleTile
    {
        public LeftPeninsulaTile(TileBase tile) : base(tile)
        {
        }

        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            F, F, F,
            F, T, T,
            F, F, F,
        };
    }

    public class RightPeninsulaTile : RuleTile
    {
        public RightPeninsulaTile(TileBase tile) : base(tile)
        {
        }

        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            F, F, F,
            T, T, F,
            F, F, F,
        };
    }

    public class UpPeninsulaTile : RuleTile
    {
        public UpPeninsulaTile(TileBase tile) : base(tile)
        {
        }

        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            F, F, F,
            F, T, F,
            F, T, F,
        };
    }



    public class DownPeninsulaTile : RuleTile
    {
        public DownPeninsulaTile(TileBase tile) : base(tile)
        {
        }

        public override bool Use8Dir => false;

        protected override bool[] valids => new bool[] {
            F, T, F,
            F, T, F,
            F, F, F,
        };
    }
}
