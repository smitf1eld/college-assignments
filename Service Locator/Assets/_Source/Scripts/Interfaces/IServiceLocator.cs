

public interface IServiceLocator
{
    bool GetService<T>(out T service);
    void AddService<T>(T service);
    void RemoveService<T>();
}
