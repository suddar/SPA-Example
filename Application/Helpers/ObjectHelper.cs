namespace Application.Helpers
{
    public static class ObjectHelper
    {
        public static void CopyFrom(this object target, object from)
        {
            if (target == null || from == null)
                throw new Exception("Must not specify null parameters");

            var properties = from.GetType().GetProperties().Where(p => p.CanRead && p.CanWrite).ToList();

            foreach (var p in properties)
            {
                object? copyValue = p.GetValue(from);
                p.SetValue(target, copyValue);
            }
        }
    }
}
