using System.Collections.Generic;
using System.Linq;
using Advanced.Web.EF;
using Microsoft.AspNetCore.Components;

namespace Advanced.Web.Blazor
{
    public partial class Split
    {
        [Inject] public DataContext Context { get; set; }

        public IEnumerable<string> Names => Context.People.Select(p => p.Firstname);
    }
}
