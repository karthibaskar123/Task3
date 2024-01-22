using System;

public class MyController : IDisposable
{
    private bool isDisposed = false;

    // Simulating a managed resource
    private readonly string managedResource = "This is a managed resource.";

    // Simulating an unmanaged resource
    private IntPtr unmanagedResource;

    public MyController()
    {
        // Initialize unmanaged resource (e.g., open a file, allocate memory, etc.)
        unmanagedResource = IntPtr.Zero; // Replace with actual initialization code
    }

    public void SomeOperation()
    {
        if (isDisposed)
        {
            throw new ObjectDisposedException(nameof(MyController), "The controller has been disposed.");
        }

        // Perform the operation
        Console.WriteLine(managedResource);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
            {
                // Release managed resources
                Console.WriteLine("Releasing managed resources.");
            }

            // Release unmanaged resources
            if (unmanagedResource != IntPtr.Zero)
            {
                // Replace with actual cleanup code for unmanaged resource
                Console.WriteLine("Releasing unmanaged resources.");
            }

            isDisposed = true;
        }
    }

    // Destructor (finalizer) in case Dispose() is not called explicitly
    ~MyController()
    {
        Dispose(false);
    }
}

class Program
{
    static void Main()
    {
        // Using statement ensures proper disposal even if an exception occurs
        using (MyController controller = new MyController())
        {
            // Use the controller
            controller.SomeOperation();
        } // The controller will be automatically disposed when exiting this block

        // Outside the using block, the controller is disposed if needed
    }
}
