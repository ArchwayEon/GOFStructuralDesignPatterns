using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern;

public class RoundHole
{
    public double Radius { get; set; }

    public bool Fits(RoundPeg peg)
    {
        return Radius >= peg.Radius;
    }
}

public class SquarePeg
{
    public double Width { get; set; }
}


public class RoundPeg
{
    private double _radius;

    public virtual double Radius
    {
        get => _radius;
        set => _radius = value;
    }
}

public class SquarePegAdapter : RoundPeg
{
    private SquarePeg _squarePeg;

    public SquarePegAdapter(SquarePeg squarePeg)
    {
        _squarePeg = squarePeg;
    }

    public override double Radius
    {
        // Gets the radius of the circle that fits inside the square peg
        get => _squarePeg.Width * Math.Sqrt(2.0) / 2.0;
        // Sets the width of the square peg based on the radius of the circle
        set
        {
            _squarePeg.Width = value / Math.Sqrt(2.0);
        }
    }
}


