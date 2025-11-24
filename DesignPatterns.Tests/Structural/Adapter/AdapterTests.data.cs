using System;
using System.Collections.Generic;

namespace DesignPatterns.Tests.Structural.Adapter
{
    public partial class AdapterTests
    {
        List<string> _list = new List<string>()
        {
            "Madness",
            "Crowds",
            "Management",
            "Operation",
            "Permutation"
        };
        static List<string> queueData =
        [
            "Audi",
            "Saab",
            "Honda",
            "Maserati",
            "Suzuki"
        ];
        static List<string> stackData =
        [
            "MAN",
            "Volvo",
            "DAF",
            "Renault",
            "Scania"
        ];

        IEnumerable<string> _queue = new Queue<string>(queueData);

        IEnumerable<string> _stack = new Stack<string>(stackData);

        System.Collections.Generic.Dictionary<Guid, string> _dictionary = new System.Collections.Generic.Dictionary<Guid, string>()
        {
            { Guid.NewGuid(), "David" },
            { Guid.NewGuid(), "Lewis" },
            { Guid.NewGuid(), "Peterson" },
            { Guid.NewGuid(), "Mark" },
            { Guid.NewGuid(), "SHawn" }
        };
    }
}
