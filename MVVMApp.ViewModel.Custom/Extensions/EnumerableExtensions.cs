namespace MVVMApp.ViewModel.Custom
{
    public static class EnumerableExtensions
    {
        public static void DisposeSequence<T>(this IEnumerable<T> source)
        {
            foreach (IDisposable disposableObject in source.OfType<IDisposable>())
            {
                disposableObject.Dispose();
            }
        }
    }
}