interface ICar
{
    string UseBrakes();
    string PushGas();
    
    string Model { get; }
    Driver Driver { get; }

    
}
