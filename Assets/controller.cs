//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/controller.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controller: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""controller"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""0543589e-404f-40e6-a9f1-e9a59eb9d720"",
            ""actions"": [
                {
                    ""name"": ""JoystickLeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""9887e9c5-5de0-47ea-a3de-b5f7a4018591"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""65c13ec1-85c3-4e24-b8d8-d5a8a02ba549"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox controller"",
                    ""action"": ""JoystickLeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Vr"",
            ""id"": ""0d47faa2-7712-45a0-8b9d-ebb93c6f39f7"",
            ""actions"": [
                {
                    ""name"": ""RightControllerRotation"",
                    ""type"": ""Value"",
                    ""id"": ""3a47db51-3014-455f-ac3b-ba36197f6ddd"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""264ef6a5-7cc8-45ee-bac7-2337a53e14b8"",
                    ""path"": ""<OculusTouchController>{RightHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightControllerRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox controller"",
            ""bindingGroup"": ""Xbox controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_JoystickLeftClick = m_Player.FindAction("JoystickLeftClick", throwIfNotFound: true);
        // Vr
        m_Vr = asset.FindActionMap("Vr", throwIfNotFound: true);
        m_Vr_RightControllerRotation = m_Vr.FindAction("RightControllerRotation", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_JoystickLeftClick;
    public struct PlayerActions
    {
        private @Controller m_Wrapper;
        public PlayerActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @JoystickLeftClick => m_Wrapper.m_Player_JoystickLeftClick;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @JoystickLeftClick.started += instance.OnJoystickLeftClick;
            @JoystickLeftClick.performed += instance.OnJoystickLeftClick;
            @JoystickLeftClick.canceled += instance.OnJoystickLeftClick;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @JoystickLeftClick.started -= instance.OnJoystickLeftClick;
            @JoystickLeftClick.performed -= instance.OnJoystickLeftClick;
            @JoystickLeftClick.canceled -= instance.OnJoystickLeftClick;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Vr
    private readonly InputActionMap m_Vr;
    private List<IVrActions> m_VrActionsCallbackInterfaces = new List<IVrActions>();
    private readonly InputAction m_Vr_RightControllerRotation;
    public struct VrActions
    {
        private @Controller m_Wrapper;
        public VrActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightControllerRotation => m_Wrapper.m_Vr_RightControllerRotation;
        public InputActionMap Get() { return m_Wrapper.m_Vr; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VrActions set) { return set.Get(); }
        public void AddCallbacks(IVrActions instance)
        {
            if (instance == null || m_Wrapper.m_VrActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_VrActionsCallbackInterfaces.Add(instance);
            @RightControllerRotation.started += instance.OnRightControllerRotation;
            @RightControllerRotation.performed += instance.OnRightControllerRotation;
            @RightControllerRotation.canceled += instance.OnRightControllerRotation;
        }

        private void UnregisterCallbacks(IVrActions instance)
        {
            @RightControllerRotation.started -= instance.OnRightControllerRotation;
            @RightControllerRotation.performed -= instance.OnRightControllerRotation;
            @RightControllerRotation.canceled -= instance.OnRightControllerRotation;
        }

        public void RemoveCallbacks(IVrActions instance)
        {
            if (m_Wrapper.m_VrActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IVrActions instance)
        {
            foreach (var item in m_Wrapper.m_VrActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_VrActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public VrActions @Vr => new VrActions(this);
    private int m_XboxcontrollerSchemeIndex = -1;
    public InputControlScheme XboxcontrollerScheme
    {
        get
        {
            if (m_XboxcontrollerSchemeIndex == -1) m_XboxcontrollerSchemeIndex = asset.FindControlSchemeIndex("Xbox controller");
            return asset.controlSchemes[m_XboxcontrollerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnJoystickLeftClick(InputAction.CallbackContext context);
    }
    public interface IVrActions
    {
        void OnRightControllerRotation(InputAction.CallbackContext context);
    }
}
