public class InteractableOrgan : Interactable
{
    // Overrides the base method to provide tool specific UI details.
    protected override void SetInformation()
    {
        UIManager.SetOrganDetails(inspectableData);
    }
}
    