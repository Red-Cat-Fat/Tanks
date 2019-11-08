// GENERATED AUTOMATICALLY FROM 'Assets/Prefabs/Control/PlayerTankController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Assets.Scripts.Game.Controllers.TanksInput
{
    public class @PlayerTankInputController : IInputActionCollection, IDisposable
    {
        private InputActionAsset asset;
        public @PlayerTankInputController()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerTankController"",
    ""maps"": [
        {
            ""name"": ""Android"",
            ""id"": ""e8b5f9ae-c3bd-4301-b072-db2ab75c8e13"",
            ""actions"": [
                {
                    ""name"": ""MoveDirection"",
                    ""type"": ""Value"",
                    ""id"": ""83ea4e8c-b3ae-4e4e-829a-0a641d106200"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireDirection"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8ede87c5-f478-4041-ba94-5272fa0f754c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9def46a4-a56c-447e-9291-01c043035c0a"",
                    ""path"": ""<AndroidJoystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""41f3df45-914d-4032-b523-ba665e435db3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""571904c9-cdf2-4e6c-a4a6-250748c5d258"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7b3f07e1-8371-47dd-9ad6-a4ed6bf66853"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2af3f9f9-6a0d-4860-9a73-809c12a60db4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a35c345d-c589-48b8-968a-693e6ff8658e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joy"",
                    ""id"": ""382ae01e-1a60-46d9-a04b-3b37e5bde56a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5b6a2267-d9b8-4e7b-9bee-7d9b9270da81"",
                    ""path"": ""<Joystick>/stick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a8f115a5-dfa3-47dc-9ced-6aaea4b1ac49"",
                    ""path"": ""<Joystick>/stick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f72fd0b8-8fb0-493e-92a2-6f43e0c2ab31"",
                    ""path"": ""<Joystick>/stick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d78c6be2-72ab-4295-857c-e84efd42e7a2"",
                    ""path"": ""<Joystick>/stick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a283c6ea-97fc-44c7-b9c6-cacf4c842382"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""1298b37a-69df-4ea9-8011-e4ff9c8daeaa"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b80d2e06-47b0-4d11-a6d8-6bcf08cc4e35"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""42b79b1e-1bca-4f31-a9b9-62a71536eb1a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5886c03c-6d92-4998-9583-0b903a5a54d5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""431c42ba-8945-4e0a-8a16-3427b2125288"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Android
            m_Android = asset.FindActionMap("Android", throwIfNotFound: true);
            m_Android_MoveDirection = m_Android.FindAction("MoveDirection", throwIfNotFound: true);
            m_Android_FireDirection = m_Android.FindAction("FireDirection", throwIfNotFound: true);
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

        // Android
        private readonly InputActionMap m_Android;
        private IAndroidActions m_AndroidActionsCallbackInterface;
        private readonly InputAction m_Android_MoveDirection;
        private readonly InputAction m_Android_FireDirection;
        public struct AndroidActions
        {
            private @PlayerTankInputController m_Wrapper;
            public AndroidActions(@PlayerTankInputController wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveDirection => m_Wrapper.m_Android_MoveDirection;
            public InputAction @FireDirection => m_Wrapper.m_Android_FireDirection;
            public InputActionMap Get() { return m_Wrapper.m_Android; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(AndroidActions set) { return set.Get(); }
            public void SetCallbacks(IAndroidActions instance)
            {
                if (m_Wrapper.m_AndroidActionsCallbackInterface != null)
                {
                    @MoveDirection.started -= m_Wrapper.m_AndroidActionsCallbackInterface.OnMoveDirection;
                    @MoveDirection.performed -= m_Wrapper.m_AndroidActionsCallbackInterface.OnMoveDirection;
                    @MoveDirection.canceled -= m_Wrapper.m_AndroidActionsCallbackInterface.OnMoveDirection;
                    @FireDirection.started -= m_Wrapper.m_AndroidActionsCallbackInterface.OnFireDirection;
                    @FireDirection.performed -= m_Wrapper.m_AndroidActionsCallbackInterface.OnFireDirection;
                    @FireDirection.canceled -= m_Wrapper.m_AndroidActionsCallbackInterface.OnFireDirection;
                }
                m_Wrapper.m_AndroidActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveDirection.started += instance.OnMoveDirection;
                    @MoveDirection.performed += instance.OnMoveDirection;
                    @MoveDirection.canceled += instance.OnMoveDirection;
                    @FireDirection.started += instance.OnFireDirection;
                    @FireDirection.performed += instance.OnFireDirection;
                    @FireDirection.canceled += instance.OnFireDirection;
                }
            }
        }
        public AndroidActions @Android => new AndroidActions(this);
        public interface IAndroidActions
        {
            void OnMoveDirection(InputAction.CallbackContext context);
            void OnFireDirection(InputAction.CallbackContext context);
        }
    }
}
