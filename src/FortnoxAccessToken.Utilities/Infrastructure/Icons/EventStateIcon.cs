using FortnoxAccessToken.Core.Infrastructure.Icons.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAccessToken.Core.Infrastructure.Icons {
  /// <summary>
  /// Event state icon.
  /// </summary>
  public enum EventStateIcon {
    /// <summary>
    /// The not started state.
    /// </summary>
    [IconDescriptor('\ue708')]
    NotStarted,

    /// <summary>
    /// The in progress state.
    /// </summary>
    [IconDescriptor('\ue706')]
    InProgress,

    /// <summary>
    /// The in progress timeout state.
    /// </summary>
    [IconDescriptor('\ue707')]
    InProgressTimeout,

    /// <summary>
    /// The finished completed state.
    /// </summary>
    [IconDescriptor('\ue701')]
    Completed,

    /// <summary>
    /// The finished failed state.
    /// </summary>
    [IconDescriptor('\ue6a0')]
    Failed,

    /// <summary>
    /// The canceled state.
    /// </summary>
    [IconDescriptor('\ue708')]
    Cancelled,

    /// <summary>
    /// The avoided state.
    /// </summary>
    [IconDescriptor('\ue708')]
    Avoided,

    /// <summary>
    /// The scheduled state.
    /// </summary>
    [IconDescriptor('\ue70B')]
    Scheduled,
  }
}
