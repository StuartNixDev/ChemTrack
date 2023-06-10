using ChemTrack;
using System;

public class OnhireCheck
{
	public static string Check(Tank tank)
	{

        if (tank.OnHire == 0)
        {
            return "No";
        }
        else
        {
            return "Yes";
        }
    }
}
