using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Tests.Structural.Adapter
{
    public partial class AdapterTests
    {
        ICollection<string> _list = new List<string>()
        {
            "Madness",
            "Crowds",
            "Management",
            "Operation",
            "Permutation"
        };

        ICollection<string> _queue = new Queue<string>()
        {
            "Audi",
            "Saab",
            "Honda",
            "Maserati",
            "Suzuki"
        };

        ICollection<string> _stack = new Stack<string>()
        {
            "MAN",
            "Volvo",
            "DAF",
            "Renault",
            "Scania"
        };

        Dictionary<Guid, string> _dictionary = new Dictionary<Guid, string>()
        {
            { Guid.NewGuid(), "David" },
            { Guid.NewGuid(), "Lewis" },
            { Guid.NewGuid(), "Peterson" },
            { Guid.NewGuid(), "Mark" },
            { Guid.NewGuid(), "SHawn" }
        };
    }
}
