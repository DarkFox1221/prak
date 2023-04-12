namespace PRAKTIKA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;

    public partial class ПрактикаEntities : DbContext
    {
        private static ПрактикаEntities _context;
        public static ПрактикаEntities GetContext()
        {
            if (_context == null)
                _context = new ПрактикаEntities();

            return _context;
        }
    }
}
