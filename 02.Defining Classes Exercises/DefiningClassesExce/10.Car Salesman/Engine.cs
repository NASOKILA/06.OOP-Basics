using System;

public class Engine
{
    public Engine()
    {}

    public string EngineModel { get; set; }

    public int EnginePower { get; set; }

    public string EngineDisplacement { get; set; }

    public string EngineEfficiency { get; set; }



    public override string ToString()
    {
        return $"  {EngineModel}:" + Environment.NewLine  
             + $"    Power: {EnginePower}" + Environment.NewLine
             + $"    Displacement: {EngineDisplacement}" + Environment.NewLine
             + $"    Efficiency: {EngineEfficiency}";
    }

}