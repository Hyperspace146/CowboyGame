// GENERATED AUTOMATICALLY FROM 'Assets/Code/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""65b2d75e-e86f-4afe-96a0-c1acc476d8f5"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""96bdab4c-fe16-4cfe-ae57-4e5ae9a3dc37"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressShoot"",
                    ""type"": ""Button"",
                    ""id"": ""67cadc42-636e-43e8-b1f9-07d03f8eba45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.02)""
                },
                {
                    ""name"": ""HoldShoot"",
                    ""type"": ""Button"",
                    ""id"": ""eeafd8e4-129b-4d72-b12a-abd6b4b50d68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""97e697ad-8f6c-4195-810c-8596cdb32541"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressMelee"",
                    ""type"": ""Button"",
                    ""id"": ""80600e41-30ce-4267-a743-3f6cae766c9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.02)""
                },
                {
                    ""name"": ""HoldMelee"",
                    ""type"": ""Button"",
                    ""id"": ""d9b3c995-9a30-433f-8d2a-62f3a2cd07fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PressInteract"",
                    ""type"": ""Button"",
                    ""id"": ""070b76f7-60b0-411c-94a7-de81c57450f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.02)""
                },
                {
                    ""name"": ""HoldInteract"",
                    ""type"": ""Button"",
                    ""id"": ""e54a0f7b-f743-480d-a8e8-82674edd86a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.5)""
                },
                {
                    ""name"": ""PressRoll"",
                    ""type"": ""Button"",
                    ""id"": ""008cbedf-db60-48cd-a574-6d96e24101ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.02)""
                },
                {
                    ""name"": ""HoldRoll"",
                    ""type"": ""Button"",
                    ""id"": ""b7fc3412-8ccc-4441-9452-9f6eecee3bba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""HoldReload"",
                    ""type"": ""Button"",
                    ""id"": ""fa19166d-7e65-468c-8d59-41a0cc0ba47c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b330ad1f-210d-4024-b747-a8af62e8d96a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""43ee3511-a516-4e79-ac7a-9bfb432299c6"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4172dbe9-f0db-4dfd-ab01-f471dbfcaf81"",
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
                    ""id"": ""195a83cc-f232-4753-bf23-dc98371b14ad"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1eda0b2c-ce56-4d68-9e6b-ec1d841fb7af"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""45b4c1d2-1b8e-4c0e-9b89-46e9db98726a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""457299c3-11ba-412d-967d-da2cba1ff82e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9f66722b-5f8e-4924-af19-e994c13d4916"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""PressShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9d1fc95-df7b-4b9f-9297-59af20b07621"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""PressShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2b2a0b2-fefe-40da-a433-0a76e8a3597a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5135e47c-5ccf-4890-ad63-609867aee1ae"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b62049f-215c-4497-aec5-483059cc79df"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""HoldShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a36fa45-de89-47cb-aaf9-e49d0515e3b3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""HoldShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d88dd913-abe5-4de3-86f4-df6fbf4b835c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""PressMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6524a855-438c-4c8c-9269-ca36e13c2bd2"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""PressMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""030d1b05-006d-48af-a449-04169319460b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""HoldMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6636d0b2-644b-4a28-ac48-011aaddd2e98"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""HoldMelee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d90337f-4cf4-47bc-9709-815cf7c5f2ab"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""PressInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9465b682-7c78-430d-8953-90ac58749505"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""PressInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""071cd0bd-81d5-4fde-b32d-eb9123660b00"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""HoldInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9c830bd-e1e2-4a0f-a817-851309f655b9"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""HoldInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59033a47-2ec8-4694-9b3b-7f22a05c1eac"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""PressRoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf7a28d3-b212-4d6d-ac46-54fbcc996664"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""PressRoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b0dab6c-f6dc-46f7-9113-bd9f1b9e4caf"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""HoldRoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03a0c9f3-dfde-4398-b0a9-3f6cc03b49a9"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""HoldRoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea6226b4-04db-4ca3-9618-f990ca19bbb9"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + mouse"",
                    ""action"": ""HoldReload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c3d9bd5-1859-42af-b9d6-096d8560f30f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""HoldReload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard + mouse"",
            ""bindingGroup"": ""Keyboard + mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": []
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_PressShoot = m_Gameplay.FindAction("PressShoot", throwIfNotFound: true);
        m_Gameplay_HoldShoot = m_Gameplay.FindAction("HoldShoot", throwIfNotFound: true);
        m_Gameplay_Rotate = m_Gameplay.FindAction("Rotate", throwIfNotFound: true);
        m_Gameplay_PressMelee = m_Gameplay.FindAction("PressMelee", throwIfNotFound: true);
        m_Gameplay_HoldMelee = m_Gameplay.FindAction("HoldMelee", throwIfNotFound: true);
        m_Gameplay_PressInteract = m_Gameplay.FindAction("PressInteract", throwIfNotFound: true);
        m_Gameplay_HoldInteract = m_Gameplay.FindAction("HoldInteract", throwIfNotFound: true);
        m_Gameplay_PressRoll = m_Gameplay.FindAction("PressRoll", throwIfNotFound: true);
        m_Gameplay_HoldRoll = m_Gameplay.FindAction("HoldRoll", throwIfNotFound: true);
        m_Gameplay_HoldReload = m_Gameplay.FindAction("HoldReload", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_PressShoot;
    private readonly InputAction m_Gameplay_HoldShoot;
    private readonly InputAction m_Gameplay_Rotate;
    private readonly InputAction m_Gameplay_PressMelee;
    private readonly InputAction m_Gameplay_HoldMelee;
    private readonly InputAction m_Gameplay_PressInteract;
    private readonly InputAction m_Gameplay_HoldInteract;
    private readonly InputAction m_Gameplay_PressRoll;
    private readonly InputAction m_Gameplay_HoldRoll;
    private readonly InputAction m_Gameplay_HoldReload;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @PressShoot => m_Wrapper.m_Gameplay_PressShoot;
        public InputAction @HoldShoot => m_Wrapper.m_Gameplay_HoldShoot;
        public InputAction @Rotate => m_Wrapper.m_Gameplay_Rotate;
        public InputAction @PressMelee => m_Wrapper.m_Gameplay_PressMelee;
        public InputAction @HoldMelee => m_Wrapper.m_Gameplay_HoldMelee;
        public InputAction @PressInteract => m_Wrapper.m_Gameplay_PressInteract;
        public InputAction @HoldInteract => m_Wrapper.m_Gameplay_HoldInteract;
        public InputAction @PressRoll => m_Wrapper.m_Gameplay_PressRoll;
        public InputAction @HoldRoll => m_Wrapper.m_Gameplay_HoldRoll;
        public InputAction @HoldReload => m_Wrapper.m_Gameplay_HoldReload;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @PressShoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressShoot;
                @PressShoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressShoot;
                @PressShoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressShoot;
                @HoldShoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldShoot;
                @HoldShoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldShoot;
                @HoldShoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldShoot;
                @Rotate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @PressMelee.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressMelee;
                @PressMelee.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressMelee;
                @PressMelee.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressMelee;
                @HoldMelee.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldMelee;
                @HoldMelee.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldMelee;
                @HoldMelee.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldMelee;
                @PressInteract.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressInteract;
                @PressInteract.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressInteract;
                @PressInteract.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressInteract;
                @HoldInteract.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldInteract;
                @HoldInteract.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldInteract;
                @HoldInteract.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldInteract;
                @PressRoll.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressRoll;
                @PressRoll.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressRoll;
                @PressRoll.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPressRoll;
                @HoldRoll.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldRoll;
                @HoldRoll.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldRoll;
                @HoldRoll.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldRoll;
                @HoldReload.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldReload;
                @HoldReload.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldReload;
                @HoldReload.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHoldReload;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @PressShoot.started += instance.OnPressShoot;
                @PressShoot.performed += instance.OnPressShoot;
                @PressShoot.canceled += instance.OnPressShoot;
                @HoldShoot.started += instance.OnHoldShoot;
                @HoldShoot.performed += instance.OnHoldShoot;
                @HoldShoot.canceled += instance.OnHoldShoot;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @PressMelee.started += instance.OnPressMelee;
                @PressMelee.performed += instance.OnPressMelee;
                @PressMelee.canceled += instance.OnPressMelee;
                @HoldMelee.started += instance.OnHoldMelee;
                @HoldMelee.performed += instance.OnHoldMelee;
                @HoldMelee.canceled += instance.OnHoldMelee;
                @PressInteract.started += instance.OnPressInteract;
                @PressInteract.performed += instance.OnPressInteract;
                @PressInteract.canceled += instance.OnPressInteract;
                @HoldInteract.started += instance.OnHoldInteract;
                @HoldInteract.performed += instance.OnHoldInteract;
                @HoldInteract.canceled += instance.OnHoldInteract;
                @PressRoll.started += instance.OnPressRoll;
                @PressRoll.performed += instance.OnPressRoll;
                @PressRoll.canceled += instance.OnPressRoll;
                @HoldRoll.started += instance.OnHoldRoll;
                @HoldRoll.performed += instance.OnHoldRoll;
                @HoldRoll.canceled += instance.OnHoldRoll;
                @HoldReload.started += instance.OnHoldReload;
                @HoldReload.performed += instance.OnHoldReload;
                @HoldReload.canceled += instance.OnHoldReload;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    private int m_KeyboardmouseSchemeIndex = -1;
    public InputControlScheme KeyboardmouseScheme
    {
        get
        {
            if (m_KeyboardmouseSchemeIndex == -1) m_KeyboardmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard + mouse");
            return asset.controlSchemes[m_KeyboardmouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPressShoot(InputAction.CallbackContext context);
        void OnHoldShoot(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnPressMelee(InputAction.CallbackContext context);
        void OnHoldMelee(InputAction.CallbackContext context);
        void OnPressInteract(InputAction.CallbackContext context);
        void OnHoldInteract(InputAction.CallbackContext context);
        void OnPressRoll(InputAction.CallbackContext context);
        void OnHoldRoll(InputAction.CallbackContext context);
        void OnHoldReload(InputAction.CallbackContext context);
    }
}
