using System;
using System.Collections.Generic;
using System.Text;


public class Mission : IMission
{
    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;

        //Parsvame si string v Enum i ako ne e validen hvurlqme exception
        //ko e si go setvame
        ParseState(state);
    }

    private void ParseState(string state)
    {
        //try parse   // SUS true SLED state IGNORIRAME CASEING
        bool validState = Enum.TryParse(typeof(MissionState), state, out object outState);

        //Ako nqmame takuv state shte vhurlim exception
        if (!validState)
            throw new ArgumentException("Invalid State");

        //Ako imame si go setvame 
        this.State = (MissionState)outState;

    }

    public string CodeName { get; private set; }

    public MissionState State { get; private set; }

    public void Complete()
    {
        if (this.State == MissionState.Finished) {
            throw new InvalidOperationException("Mission is already completed!");
        }

        this.State = MissionState.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
    }


}

