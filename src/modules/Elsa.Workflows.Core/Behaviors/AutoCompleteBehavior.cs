using JetBrains.Annotations;

namespace Elsa.Workflows.Behaviors;

/// <summary>
/// Automatically completes the currently executing activity.
/// </summary>
[UsedImplicitly]
public class AutoCompleteBehavior : Behavior
{
    /// <inheritdoc />
    public AutoCompleteBehavior(IActivity owner) : base(owner)
    {
    }

    /// <inheritdoc />
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        // If the activity created any bookmarks, do not complete. 
        if (context.NewBookmarks.Any(x => x.ActivityId == context.Activity.Id))
            return;
        
        await context.CompleteActivityAsync();
    }
}