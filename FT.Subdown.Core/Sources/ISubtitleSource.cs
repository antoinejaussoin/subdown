using System.Collections.Generic;
using FT.Subdown.Core.Requests;

namespace FT.Subdown.Core.Sources
{
    public interface ISubtitleSource
    {
        IList<ISubtitleResult> Find(ISubtitleRequest request);

        int Reliability { get; }
    }
}
