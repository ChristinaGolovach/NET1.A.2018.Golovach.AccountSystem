namespace BLL.Interface.Interfaces
{
    //TODO move in another project
    public interface INumberGenerator<out T>
    {
        T GenerateNumber(int numberLength = 10);
    }
}
