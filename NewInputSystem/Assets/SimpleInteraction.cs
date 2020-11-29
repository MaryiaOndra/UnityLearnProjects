using UnityEngine.InputSystem;

public class SimpleInteraction : IInputInteraction
{
    public float Duration = 0.2f;

    [UnityEditor.InitializeOnLoadMethod]
    private static void Register() 
    {
        InputSystem.RegisterInteraction<SimpleInteraction>();
    }

    public void Process(ref InputInteractionContext context)
    {
        if (context.timerHasExpired)
        {
            context.Canceled();
            return;
        }

        switch (context.phase)
        {
            case InputActionPhase.Waiting:
                if (context.ReadValue<float>() == 1.0f)
                {
                    context.Started();
                    context.SetTimeout(Duration);
                }
                break;
            case InputActionPhase.Started:
                if (context.ReadValue<float>() == -1.0f)
                {
                    context.Performed();
                }
                break;
        }
    }

    public void Reset()
    {
        
    }
}
