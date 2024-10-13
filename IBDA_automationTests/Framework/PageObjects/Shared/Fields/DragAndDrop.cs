namespace IBDA_automationTests.Framework.PageObjects.Shared.Components;

public class DragAndDrop : PomBase
{
    public void sendJpg(string text)
    {
        RelatedElement.SendKeys(text);
    }
}