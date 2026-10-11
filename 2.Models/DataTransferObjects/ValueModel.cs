namespace Models.DataTransferObjects;

// Simple generic wrapper, kept as a starting point for the Models layer.
public class ValueModel<T>
{
    public T Value { get; set; }
}
