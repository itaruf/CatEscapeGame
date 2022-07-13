// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Inputs"",
            ""id"": ""90ceed9b-2fc3-43b5-a801-9f5210a2f8c8"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8d26ec4c-cd95-49fb-8ffc-9ee0f2247cfe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scratch"",
                    ""type"": ""Button"",
                    ""id"": ""a6e4c481-af1d-4804-ae54-d0b5259d62b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Push"",
                    ""type"": ""Button"",
                    ""id"": ""626392b3-f5b4-4474-aef2-62efacb12c2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6b499121-8df8-4c37-a2bf-526d3e1635d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bite"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c117356a-9dff-4984-a1b5-65cc5da71d0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sleep"",
                    ""type"": ""Button"",
                    ""id"": ""70b44b0b-cb5f-477b-9738-7b08730a4196"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d7c0c7e1-c00d-459f-8e65-2327cda14558"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6a2b2771-74a1-40f3-b88e-fc3e35e47a95"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""562403c8-09dc-4c6d-8b86-207d7519d13c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ae2f9c0f-14b4-4e8e-8b66-f26965cc7c6b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""94001b38-9faa-4e73-9c58-52e423e3500c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b63b34a4-c9b8-4aae-b0c4-383dcc150caf"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""734e4fe0-b862-4dac-9e51-9d15ed0c7678"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7c115098-3df0-404f-99c1-c84ac5314371"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f3c94bb1-4807-4316-a7ad-834a9ddf77a0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c3ed1179-55a2-41d5-8376-581876617bd9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1c613b0d-ade2-467f-ac52-dfd92cb3c20a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cfdc6b01-c486-4675-9245-d5d57e98a521"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scratch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91845a8d-ce84-45e8-8e8e-afc83f115f35"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d02b68ba-4fb0-460f-965b-9d63431f59bc"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Push"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ff39804-6a6c-42d0-8888-43f7df22420c"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bite"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b995306b-6d41-4bcf-be9d-0d374b35595a"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sleep"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inputs
        m_Inputs = asset.FindActionMap("Inputs", throwIfNotFound: true);
        m_Inputs_Move = m_Inputs.FindAction("Move", throwIfNotFound: true);
        m_Inputs_Scratch = m_Inputs.FindAction("Scratch", throwIfNotFound: true);
        m_Inputs_Push = m_Inputs.FindAction("Push", throwIfNotFound: true);
        m_Inputs_Jump = m_Inputs.FindAction("Jump", throwIfNotFound: true);
        m_Inputs_Bite = m_Inputs.FindAction("Bite", throwIfNotFound: true);
        m_Inputs_Sleep = m_Inputs.FindAction("Sleep", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Inputs
    private readonly InputActionMap m_Inputs;
    private IInputsActions m_InputsActionsCallbackInterface;
    private readonly InputAction m_Inputs_Move;
    private readonly InputAction m_Inputs_Scratch;
    private readonly InputAction m_Inputs_Push;
    private readonly InputAction m_Inputs_Jump;
    private readonly InputAction m_Inputs_Bite;
    private readonly InputAction m_Inputs_Sleep;
    public struct InputsActions
    {
        private @PlayerInputs m_Wrapper;
        public InputsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Inputs_Move;
        public InputAction @Scratch => m_Wrapper.m_Inputs_Scratch;
        public InputAction @Push => m_Wrapper.m_Inputs_Push;
        public InputAction @Jump => m_Wrapper.m_Inputs_Jump;
        public InputAction @Bite => m_Wrapper.m_Inputs_Bite;
        public InputAction @Sleep => m_Wrapper.m_Inputs_Sleep;
        public InputActionMap Get() { return m_Wrapper.m_Inputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsActions set) { return set.Get(); }
        public void SetCallbacks(IInputsActions instance)
        {
            if (m_Wrapper.m_InputsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Scratch.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnScratch;
                @Scratch.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnScratch;
                @Scratch.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnScratch;
                @Push.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnPush;
                @Push.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnPush;
                @Push.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnPush;
                @Jump.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
                @Bite.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnBite;
                @Bite.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnBite;
                @Bite.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnBite;
                @Sleep.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnSleep;
                @Sleep.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnSleep;
                @Sleep.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnSleep;
            }
            m_Wrapper.m_InputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Scratch.started += instance.OnScratch;
                @Scratch.performed += instance.OnScratch;
                @Scratch.canceled += instance.OnScratch;
                @Push.started += instance.OnPush;
                @Push.performed += instance.OnPush;
                @Push.canceled += instance.OnPush;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Bite.started += instance.OnBite;
                @Bite.performed += instance.OnBite;
                @Bite.canceled += instance.OnBite;
                @Sleep.started += instance.OnSleep;
                @Sleep.performed += instance.OnSleep;
                @Sleep.canceled += instance.OnSleep;
            }
        }
    }
    public InputsActions @Inputs => new InputsActions(this);
    public interface IInputsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnScratch(InputAction.CallbackContext context);
        void OnPush(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnBite(InputAction.CallbackContext context);
        void OnSleep(InputAction.CallbackContext context);
    }
}
