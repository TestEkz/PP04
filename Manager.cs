using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PP04
{
    class Manager
    {
        private static BasedAgainPP04Entities _context;
        public static Frame MainFrame { get; set; }
        public static BasedAgainPP04Entities GetContext()
        {
            if (_context == null)
            {
                _context = new BasedAgainPP04Entities();
            }
            return _context;
        }
    }
}
