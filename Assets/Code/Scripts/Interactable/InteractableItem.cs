public class InteractableTool : Interactable
{
    // Overrides the base method to provide organ specific UI details.
    protected override void SetInformation()
    {
        UIManager.SetToolDetails(inspectableData);
    }
}
    