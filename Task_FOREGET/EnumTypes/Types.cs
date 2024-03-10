namespace Task_FOREGET.Models.EnumTypes
{
    public enum Mode
    {
        LCL,
        FCL,
        Air
    }
    public enum MovementType
    {
        DoorToDoor, PortToDoor, DoorToPort, PortToPort
    }
    public enum Incoterms
    {
        DDP,DAT
    }
    public enum PackageType
    {
        Pallets, Boxes, Cartons
    }
    public enum UnitFirst
    {
        CM, IN
    }
    public enum SecondUnit
    {
        KG, LB
    }
    public enum Currency
    {
        USD, CNY, TRY
    }

}
